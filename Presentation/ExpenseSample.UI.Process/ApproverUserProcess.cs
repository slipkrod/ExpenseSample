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
    /// User Process Component for Approver UI.
    /// </summary>
    public class ApproverUserProcess : IApproverUserProcess 
    {
        /// <summary>
        /// Constructor to initialize the class.
        /// </summary>
        /// <param name="clientType"></param>
        public ApproverUserProcess()
        {
        }

        /// <summary>
        /// Return a list of roles that are available.
        /// </summary>
        /// <returns>An array of roles.</returns>
        public string[] GetRoles()
        {
            return new string[] {
                "Manager",
                "Head of Department",
                "HR Manager",
                "Financial Controller"
                };
        }

        /// <summary>
        /// Returns a list of expenses based on roles.
        /// </summary>
        /// <param name="role">The name of the role.</param>
        /// <returns>An expense list.</returns>
        public List<Expense> LoadExpenses(string role)
        {
            List<Expense> expensesList = null;

            ExpenseServiceClient proxy = new ExpenseServiceClient();

            try
            {
                expensesList = proxy.ListExpensesForApproval(role);
                proxy.Close();
            }
            catch (FaultException<ProcessExecutionFault> ex)
            {
                throw new ApplicationException(ex.Message);
            }

            return expensesList;

        }


        /// <summary>
        /// Approves/Reviews/Disburses an expense.
        /// </summary>
        /// <param name="expense">An Expense object.</param>
        /// <param name="review">An ExpenseReview object.</param>
        public void ApproveExpense(Expense expense, ExpenseReview review)
        {

            // Create message contract.
           ExpenseWorkflowService.ApproverRequestMessage requestMessage =
                new ExpenseWorkflowService.ApproverRequestMessage(expense.WorkflowID, expense, review);

            ExpenseWorkflowServiceClient proxy = new ExpenseWorkflowServiceClient();
            try
            {
                // For Manager.
                if (expense.Status == ExpenseStatus.Pending)
                {
                    proxy.ReviewExpense(requestMessage);
                }

                // For Head of Department/HR Manager.
                else if (expense.Status == ExpenseStatus.Reviewed ||
                    expense.Status == ExpenseStatus.Escalated)
                {
                    proxy.ApproveExpense(requestMessage);
                }

                // For Financial Controller.
                else if (expense.Status == ExpenseStatus.Approved)
                {
                    proxy.DisburseExpense(requestMessage);
                }

                proxy.Close();
            }
            catch (FaultException<ProcessExecutionFault> ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

   }
}
