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
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Channels;
using ExpenseSample.Business.Entities;
using ExpenseSample.Services.Contracts;
using System.Diagnostics;
using ExpenseSample.UI.Process.ExpenseService;
using ExpenseSample.UI.Process.ExpenseWorkflowService;

// NOTE:
//
// User Process Components are used to abstract the common processing task from 
// the UI or control the UI navigation logic. You can also treat UPCs as a
// Controller (the Entities as the Model and the UI Forms as Views).
//
// This sample is too simplistic to show any navigation logic. However, it does
// illustrate how to abstract the service communication logic away from the UI.

namespace ExpenseSample.UI.Process
{

    /// <summary>
    /// Simple User Process Component for Expense Submitter UI.
    /// NOTE: This class is not necessary if there is only one client type.
    /// </summary>
    public class SubmitterUserProcess : ISubmitterUserProcess 
    {

        public SubmitterUserProcess() 
        {
        }

        /// <summary>
        /// Submit an expense.
        /// </summary>
        /// <param name="expense">An Expense instance.</param>
        public void SubmitExpense(Expense expense)
        {
            // Submit the expense.
            try
            {
                expense.WorkflowID = Guid.NewGuid();

                ExpenseWorkflowService.SubmitterRequestMessage requestMessage =
                    new ExpenseWorkflowService.SubmitterRequestMessage(expense.WorkflowID, expense);

                ExpenseWorkflowServiceClient proxy = new ExpenseWorkflowServiceClient();
                proxy.SubmitExpense(requestMessage);
                proxy.Close();
            }
            catch (FaultException<ProcessExecutionFault> ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        /// <summary>
        /// Cancel a pending expense.
        /// </summary>
        /// <param name="expense">An Expense instance.</param>
        /// <returns>A boolean value indicating the request has been made.</returns>
        public bool CancelExpense(Expense expense)
        {
            bool result = false;

            // Cancel the expense.
            try
            {
                ExpenseWorkflowService.SubmitterRequestMessage requestMessage =
                    new ExpenseWorkflowService.SubmitterRequestMessage(expense.WorkflowID, expense);

                ExpenseWorkflowServiceClient proxy = new ExpenseWorkflowServiceClient();

                proxy.CancelExpense(requestMessage);
            }
            catch (FaultException<ProcessExecutionFault> ex)
            {
                throw new ApplicationException(ex.Message);
            }
         
            result = true;

            return result;
        }

        public void ResetDatabase()
        {
            try
            {
                ExpenseServiceClient proxy = new ExpenseServiceClient();
                
                // Get a list of active expenses.
                List<Expense> expensesList = proxy.ListActiveExpenses();

                if (expensesList.Count > 0)
                {
                    throw new ApplicationException("Cannot reset ExpenseSample database when there are active expenses. Please Cancel all active expenses and then try again.");
                }

                proxy.Purge();
                proxy.Close();
            }
            catch (FaultException<ProcessExecutionFault> ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public string[] LoadCategories()
        {
            return Enum.GetNames(typeof(ExpenseCategory));
        }

        /// <summary>
        /// Loads the expenses.
        /// </summary>
        /// <param name="employeeID">An EmployeeID.</param>
        /// <returns>A List of Expenses.</returns>
        public List<Expense> LoadExpenses(string employeeID)
        {
            List<Expense> expensesList = null;

            try
            {
                ExpenseServiceClient proxy = new ExpenseServiceClient();
                expensesList = proxy.ListExpensesForEmployee(employeeID);
                proxy.Close();
            }
            catch (FaultException<ProcessExecutionFault> ex)
            {
                throw new ApplicationException(ex.Message);
            }

            return expensesList;
        }

        public List<ExpenseReview> LoadExpenseReviews(long expenseID)
        {
            List<ExpenseReview> reviewsList = null;

            try
            {
                ExpenseServiceClient proxy = new ExpenseServiceClient();
                reviewsList = proxy.ListExpenseReviews(expenseID);
                proxy.Close();
            }
            catch (FaultException<ProcessExecutionFault> ex)
            {
                throw new ApplicationException(ex.Message);
            }
            return reviewsList;
        }

        public List<ExpenseLog> LoadExpenseLogs(long expenseID)
        {
            List<ExpenseLog> LogsList = null;
            try
            {
                ExpenseServiceClient proxy = new ExpenseServiceClient();
                LogsList = proxy.ListExpenseLogs(expenseID);
                proxy.Close();
            }
            catch (FaultException<ProcessExecutionFault> ex)
            {
                throw new ApplicationException(ex.Message);
            }

            return LogsList;
        }

    }
}
