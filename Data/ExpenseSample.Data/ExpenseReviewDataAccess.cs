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
    public class ExpenseReviewDataAccess 
    {
        private const string ENTITY_SET_NAME = "ExpenseReviews";

        /// <summary>
        /// Inserts an expense row.
        /// </summary>
        /// <param name="expense">An Expense object.</param>
        public void Create(ExpenseReview review)
        {
            using (ExpenseDataContext ctx = new ExpenseDataContext())
            {
                ctx.AddObject(ENTITY_SET_NAME, review);
                ctx.SaveChanges();
            }
        }

        public List<ExpenseReview> SelectByExpenseID(long expenseID)
        {
            List<ExpenseReview> resultsList = null;

            using (ExpenseDataContext ctx = new ExpenseDataContext())
            {
                resultsList =
                     (from review in ctx.ExpenseReviews
                      where review.Expense.ExpenseID == expenseID
                      orderby review.DateApproved
                      select review).ToList();
            }

            return resultsList;

        }
    }
}
