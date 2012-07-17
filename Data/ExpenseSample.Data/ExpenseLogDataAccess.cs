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
using System.Linq;

using ExpenseSample.Business.Entities;
using System.Diagnostics;

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
    public class ExpenseLogDataAccess 
    {
        private const string ENTITY_SET_NAME = "ExpenseLogs";

        /// <summary>
        /// Inserts an expense log row.
        /// </summary>
        /// <param name="expense">An ExpenseLog object.</param>
        public void Create(ExpenseLog log)
        {
            using (ExpenseDataContext ctx = new ExpenseDataContext())
            {
                ctx.AddObject(ENTITY_SET_NAME, log);
                ctx.SaveChanges();
            }

        }

        public List<ExpenseLog> SelectByExpenseID(long expenseID)
        {
            List<ExpenseLog> resultsList = null;

            using (ExpenseDataContext ctx = new ExpenseDataContext())
            {
                resultsList =
                     (from log in ctx.ExpenseLogs
                      where log.Expense.ExpenseID == expenseID
                      orderby log.DateCreated
                      select log).ToList();
            }

            return resultsList;

        }

    }
}
