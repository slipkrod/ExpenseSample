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
using ExpenseSample.Business.Entities;
using System.Collections.Generic;
namespace ExpenseSample.UI.Process
{
    public interface IApproverUserProcess
    {
        void ApproveExpense(Expense expense, ExpenseReview review);
        string[] GetRoles();
        List<Expense> LoadExpenses(string role);
    }
}
