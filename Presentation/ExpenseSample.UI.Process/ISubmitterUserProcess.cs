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
using ExpenseSample.Business.Entities;

namespace ExpenseSample.UI.Process
{
    public interface ISubmitterUserProcess  
    {
        bool CancelExpense(Expense expense);
        string[] LoadCategories();
        List<ExpenseLog> LoadExpenseLogs(long expenseID);
        List<ExpenseReview> LoadExpenseReviews(long expenseID);
        List<Expense> LoadExpenses(string employeeID);
        void ResetDatabase();
        void SubmitExpense(Expense expense);
    }
}
