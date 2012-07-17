//--------------------------------------------------------------------------------
// Layered Architecture Sample: Expense Sample Application
// Developed by: Serena Yeoh
// 
// For updates, please visit http://www.codeplex.com/layersample
//--------------------------------------------------------------------------------
// THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//--------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using ExpenseSample.Business.Entities;

// NOTE:
//
// Data access components are responsible for querying and persisting the data for
// the application. All database related processing should be done here.
//
// All the CRUD activities are done here in this component to isolate them from 
// higher level components in the layer. This should allow us to freely upgrade or 
// change data access technologies as required.
//
// It is not necessary that each Data Access Component to be mapped directly to an
// individual table. In larger systems, one DAC may manage the CRUD activities for
// one or more tables/Entities.

namespace ExpenseSample.Data
{
    public class ExpenseDataAccess 
    {

        private const string ENTITY_SET_NAME = "Expenses";

        /// <summary>
        /// Inserts an expense row.
        /// </summary>
        /// <param name="expense">An Expense object.</param>
        public Expense Create(Expense expense)
        {
            using (ExpenseDataContext ctx = new ExpenseDataContext())
            {
                ctx.Expenses.AddObject(expense);
                ctx.SaveChanges();
            }

            return expense;
        }


        /// <summary>
        /// Updates an Expense row.
        /// </summary>
        /// <param name="expense">A Expense object.</param>
        public void Update(Expense expense)
        {
            EntityKey key = null;
            object original = null;

            using (ExpenseDataContext ctx = new ExpenseDataContext())
            {
                key = ctx.CreateEntityKey(ENTITY_SET_NAME, expense);
                if (ctx.TryGetObjectByKey(key, out original))
                {
                    ctx.ApplyCurrentValues(key.EntitySetName, expense);
                }
                ctx.SaveChanges();
            }
        }


        /// <summary>
        /// Returns a set of Expenses that belongs to an employee
        /// </summary>
        /// <param name="employeeID">An EmployeeID.</param>
        /// <returns>A List of expenses.</returns>
        public List<Expense> SelectForEmployee(string employee)
        {
            List<Expense> resultsList = null;

            using (ExpenseDataContext ctx = new ExpenseDataContext())
            {
                resultsList =
                    (from expense in ctx.Expenses
                     where expense.Employee == employee
                     orderby expense.DateSubmitted descending
                     select expense).ToList();
            }
            
            return resultsList;

        }

        public List<Expense> SelectForApproval(string reviewer)
        {
            List<Expense> resultsList = null;

            using (ExpenseDataContext ctx = new ExpenseDataContext())
            {
                resultsList =
                    (from expense in ctx.Expenses
                     where expense.AssignedTo == reviewer && expense.IsCompleted == false
                     orderby expense.DateSubmitted descending
                     select expense).ToList();
            }

            return resultsList;

        }

        public List<Expense> SelectActive()
        {
            List<Expense> resultsList = null;

            using (ExpenseDataContext ctx = new ExpenseDataContext())
            {
                resultsList =
                    (from expense in ctx.Expenses
                     where expense.IsCompleted == false
                     orderby expense.DateSubmitted descending
                     select expense).ToList();
            }

            return resultsList;

        }

        public void Purge()
        {
            using (ExpenseDataContext ctx = new ExpenseDataContext())
            {
                List<Expense> resultList =
                    (from expense in ctx.Expenses
                     select expense).ToList();

                foreach (Expense expense in resultList)
                {
                    ctx.DeleteObject(expense);
                }

                ctx.SaveChanges();
            }
        }
    }
}
