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
using System.Text;
using System.Activities;
using ExpenseSample.Business.Entities;
using ExpenseSample.Business.Components;

namespace ExpenseSample.Business.Workflows.Activities
{

    [Serializable]
    public sealed class RejectExpense : CodeActivity
    {
        public InOutArgument<Expense> Expense { get; set; }
        public InArgument<ExpenseReview> ExpenseReview { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            Expense expense = context.GetValue(this.Expense);
            ExpenseReview review = context.GetValue(this.ExpenseReview);

            //expense.WorkflowID = this.WorkflowInstanceId;
            ExpenseComponent bc = new ExpenseComponent();
            context.SetValue(this.Expense, bc.Reject(expense, review));
        }
    }
}
