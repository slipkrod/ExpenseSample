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
using System.ServiceModel;
using ExpenseSample.Business.Components;
using ExpenseSample.Business.Entities;
using ExpenseSample.Services.Contracts;

// NOTE:
//
// Service components are responsible for exposing business methods that are
// required to be consumable by external callers as services. This sample uses
// the Business Entities as the data contracts. In larger systems, you may need
// to develop Message Types (Message Contracts) to expose the data.

namespace ExpenseSample.Services
{
    /// <summary>
    /// Service Interface component to expose the expense service to external clients. 
    /// </summary>
    [ServiceBehavior(UseSynchronizationContext = false,
    ConcurrencyMode = ConcurrencyMode.Multiple,
    InstanceContextMode = InstanceContextMode.PerCall)]
    public class ExpenseService : IExpenseService 
    {
        public ExpenseService()
        {
        }

        public List<Expense> ListExpensesForEmployee(string employeeID)
        {
            try
            {
                ExpenseComponent bc = new ExpenseComponent();
                return bc.ListExpensesForEmployee(employeeID);
            }
            catch (Exception ex)
            {
                throw new FaultException<ProcessExecutionFault>
                    (new ProcessExecutionFault(), ex.Message);
            }
        }

        public List<Expense> ListExpensesForApproval(string reviewerID)
        {
            try
            {
                ExpenseComponent bc = new ExpenseComponent();
                return bc.ListExpensesForApproval(reviewerID);
            }
            catch (Exception ex)
            {
                throw new FaultException<ProcessExecutionFault>
                    (new ProcessExecutionFault(), ex.Message);
            }
        }

        public List<Expense> ListActiveExpenses()
        {
            try
            {
                ExpenseComponent bc = new ExpenseComponent();
                return bc.ListActiveExpenses();
            }
            catch (Exception ex)
            {
                throw new FaultException<ProcessExecutionFault>
                    (new ProcessExecutionFault(), ex.Message);
            }
        }

        public List<ExpenseReview> ListExpenseReviews(long expenseID)
        {
            try
            {
                ExpenseComponent bc = new ExpenseComponent();
                return bc.ListExpenseReviews(expenseID);
            }
            catch (Exception ex)
            {
                throw new FaultException<ProcessExecutionFault>
                    (new ProcessExecutionFault(), ex.Message);
            }
        }

        public List<ExpenseLog> ListExpenseLogs(long expenseID)
        {
            try
            {
                ExpenseComponent bc = new ExpenseComponent();
                return bc.ListExpenseLogs(expenseID);
            }
            catch (Exception ex)
            {
                throw new FaultException<ProcessExecutionFault>
                    (new ProcessExecutionFault(), ex.Message);
            }
        }



        /// <summary>
        /// Resets the database for the demo. This should not exist in real world
        /// business components.
        /// </summary>
        public void Purge()
        {
            Console.WriteLine("Reseting demo database ...");

            // Get a list of active expenses.
            ExpenseComponent bc = new ExpenseComponent();

            try
            {
                bc.Purge();
            }
            catch (Exception ex)
            {
                throw new FaultException<ProcessExecutionFault>
                    (new ProcessExecutionFault(), ex.Message);
            }

            Console.WriteLine("Demo database reseted.");

        }

    }
}
