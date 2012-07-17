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
using System.Diagnostics;
using System.Text;
using System.Transactions;
using System.Reflection;
using System.Threading;

using ExpenseSample.Data;
using ExpenseSample.Business.Entities;
using System.Data;

// NOTE:
// 
// Business Components are used to contain the business processing logic of the
// application. Business components interacts with data access components to
// store and retrieved data that is required for processing. Business components
// can also re-validate data that is passed in from the Presentation or Services
// layer.
//
// In this sample, you can see that each business method is coded to perform a 
// specific task. Individually, they appear to be independent from each other 
// but collectively, they will be used to assembly the business processing flow
// through the Business Workflow Component.

namespace ExpenseSample.Business.Components
{
    /// <summary>
    /// Core business component.
    /// </summary>
    public class ExpenseComponent 
    {

        public ExpenseComponent()
        {
        }
        
        /// <summary>
        /// Submit an Expense.
        /// </summary>
        /// <param name="expense">An Expense object.</param>
        public Expense Submit(Expense expense)
        {
            Console.WriteLine("Submitting... ");

            expense.Status = ExpenseStatus.Pending;

            using (TransactionScope ts =
                new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    expense = CreateExpense(expense);
                    LogStatus(expense);
                    ts.Complete();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
            }

            Console.WriteLine("New ExpenseID = " + expense.ExpenseID.ToString());

            return expense;
        }

        /// <summary>
        /// Cancels an Expense request.
        /// </summary>
        /// <param name="expense">An Expense object.</param>
        public Expense Cancel(Expense expense)
        {
            Console.WriteLine("Cancelling... ");

            expense.AssignedTo = string.Empty;
            expense.Status = ExpenseStatus.Cancelled;
            expense.IsCompleted = true;

            return UpdateExpenseRecord(expense);
      
        }

        /// <summary>
        /// Expires an unattended Expense request.
        /// </summary>
        /// <param name="expense">An Expense object.</param>
        public Expense Expire(Expense expense)
        {
            Console.WriteLine("Expiring... ");

            expense.AssignedTo = string.Empty;
            expense.Status = ExpenseStatus.Expired;
            expense.IsCompleted = true;

            return UpdateExpenseRecord(expense);
        }

        /// <summary>
        /// Escalates an unattended Expense request.
        /// </summary>
        /// <param name="expense">An Expense object.</param>
        public Expense Escalate(Expense expense)
        {
            Console.WriteLine("Escalating... ");

            expense.Status = ExpenseStatus.Escalated;
            return UpdateExpenseRecord(expense);
        }

        /// <summary>
        /// Approves an Expense request.
        /// </summary>
        /// <param name="expense">An Expense object.</param>
        /// <param name="review">An ExpenseReview object.</param>
        public Expense Approve(Expense expense, ExpenseReview review)
        {
            Console.WriteLine("Approving...");

            expense.Status = ExpenseStatus.Approved;
            expense.IsCompleted = false;

            return UpdateExpenseRecord(expense, review);
        }

        /// <summary>
        /// Rejects an Expense.
        /// </summary>
        /// <param name="expense">An Expense object.</param>
        /// <param name="review">An ExpenseReview object.</param>
        /// <returns></returns>
        public Expense Reject(Expense expense, ExpenseReview review)
        {
            Console.WriteLine("Rejecting...");

            expense.AssignedTo = string.Empty;
            expense.Status = ExpenseStatus.Rejected;
            expense.IsCompleted = true;

            return UpdateExpenseRecord(expense, review);
        }

        /// <summary>
        /// Reviews an Expense request.
        /// </summary>
        /// <param name="expense">An Expense object.</param>
        /// <param name="review">An ExpenseReview object.</param>
        public Expense Review(Expense expense, ExpenseReview review)
        {
            Console.WriteLine("Reviewing...");

            expense.Status = ExpenseStatus.Reviewed;
            expense.IsCompleted = false;

            return UpdateExpenseRecord(expense, review);
        }

        /// <summary>
        /// Disburses an Approved Expense request.
        /// </summary>
        /// <param name="expense">An Expense object.</param>
        /// <param name="review">An ExpenseReview object.</param>
        public Expense Disburse(Expense expense, ExpenseReview review)
        {
            Console.WriteLine("Disbursing...");

            expense.Status = ExpenseStatus.Disbursed;
            expense.AssignedTo = string.Empty;
            expense.IsCompleted = true;

           return UpdateExpenseRecord(expense, review);
        }


        private Expense UpdateExpenseRecord(Expense expense)
        {
            using (TransactionScope ts =
                new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    expense = UpdateExpense(expense);
                    LogStatus(expense);
                    ts.Complete();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
            }

            return expense;
        }

        private Expense UpdateExpenseRecord(Expense expense, ExpenseReview review)
        {
            using (TransactionScope ts =
                new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    expense = UpdateExpense(expense);
                    CreateExpenseReview(review);
                    LogStatus(expense);
                    ts.Complete();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
            }

            return expense;
        }

        /// <summary>
        /// Returns a list of Expenses that belongs to an employee.
        /// </summary>
        /// <param name="employeeID">An EmployeeID</param>
        /// <returns>A List of Expenses</returns>
        public List<Expense> ListExpensesForEmployee(string employeeID)
        {
            // Retrieve data.
            ExpenseDataAccess dac = new ExpenseDataAccess();
            try
            {
                return dac.SelectForEmployee(employeeID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Returns a list of Expenses that is assigned to a reviewer.
        /// </summary>
        /// <param name="reviewerID">A ReviewerID</param>
        /// <returns>A List of Expenses</returns>
        public List<Expense> ListExpensesForApproval(string reviewerID)
        {
            // Retrieve data.
            ExpenseDataAccess dac = new ExpenseDataAccess();
            try
            {
                return dac.SelectForApproval(reviewerID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }


        public List<Expense> ListActiveExpenses()
        {
            // Retrieve data.
            ExpenseDataAccess dac = new ExpenseDataAccess();
            try
            {
                return dac.SelectActive();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Retrieves a list of Expense Reviews belonging to an Expense
        /// </summary>
        /// <param name="expenseID">An ExpenseID.</param>
        /// <returns>A List of Expense Reviews.</returns>
        public List<ExpenseReview> ListExpenseReviews(long expenseID)
        {
            // Retrieve data.
            ExpenseReviewDataAccess dac = new ExpenseReviewDataAccess();
            try
            {
                return dac.SelectByExpenseID(expenseID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Retrieves a list of Expense Logs belonging to an Expense
        /// </summary>
        /// <param name="expenseID">An ExpenseID.</param>
        /// <returns>A List of Expense Logs.</returns>
        public List<ExpenseLog> ListExpenseLogs(long expenseID)
        {
            // Retrieve data.
            ExpenseLogDataAccess dac = new ExpenseLogDataAccess();
            try
            {
                return dac.SelectByExpenseID(expenseID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Creates a new Expense record in the database.
        /// </summary>
        /// <param name="expense">An Expense object.</param>
        private Expense CreateExpense(Expense expense)
        {
            // Business logic.
            expense.IsCompleted = false;
            expense.DateSubmitted = DateTime.Now;
            expense.DateModified = DateTime.Now;

            Console.WriteLine(expense.ToString());

            // Persist data.
            ExpenseDataAccess dac = new ExpenseDataAccess();
            try
            {
                return dac.Create(expense);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Updates the Expense information into the database.
        /// </summary>
        /// <param name="expense">An Expense object.</param>
        private Expense UpdateExpense(Expense expense)
        {
            // Business logic.
            expense.DateModified = DateTime.Now;

            Console.WriteLine(expense.ToString());

            // Persist data.
            ExpenseDataAccess dac = new ExpenseDataAccess();
            try
            {
                dac.Update(expense);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }

            return expense;
        }

        /// <summary>
        /// Resets the database to initial state. This should only be done in demos
        /// and not in real-life.
        /// </summary>
        public void Purge()
        {
            using (TransactionScope ts =
                new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    ExpenseDataAccess dac = new ExpenseDataAccess();
                    dac.Purge();
                    ts.Complete();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
            }
        }

        
        /// <summary>
        /// Creates a new Expense Review record in the database.
        /// </summary>
        /// <param name="expense">An Expense Review object.</param>
        private void CreateExpenseReview(ExpenseReview review)
        {
            // Business logic.
            review.DateApproved = DateTime.Now;

            Console.WriteLine(review.ToString());

            // Persist data.
            ExpenseReviewDataAccess dac = new ExpenseReviewDataAccess();
            try
            {
                dac.Create(review);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        

        /// <summary>
        /// Logs the status of the Expense.
        /// </summary>
        /// <param name="expense">An Expense object.</param>
        private void LogStatus(Expense expense)
        {
            ExpenseLog log = new ExpenseLog();
            log.ExpenseID = expense.ExpenseID;
            log.Status = expense.Status;
            log.DateCreated = DateTime.Now;

            // Persist data.
            ExpenseLogDataAccess dac = new ExpenseLogDataAccess();
            try
            {
                dac.Create(log);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

    }
}
