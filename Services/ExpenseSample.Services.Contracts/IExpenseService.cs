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

using ExpenseSample.Business.Entities;

namespace ExpenseSample.Services.Contracts
{
    [ServiceContract(
    Namespace = "http://serena-yeoh//LayerSample/Expense/2007/08",
    SessionMode = SessionMode.Allowed)]
    public interface IExpenseService 
    {
        [OperationContract]
        [FaultContract(typeof(ProcessExecutionFault))]
        void Purge();

        [OperationContract]
        [FaultContract(typeof(ProcessExecutionFault))]
        List<Expense> ListActiveExpenses();

        [OperationContract]
        [FaultContract(typeof(ProcessExecutionFault))]
        List<Expense> ListExpensesForEmployee(string employeeID);

        [OperationContract]
        [FaultContract(typeof(ProcessExecutionFault))]
        List<Expense> ListExpensesForApproval(string reviewerID);

        [OperationContract]
        [FaultContract(typeof(ProcessExecutionFault))]
        List<ExpenseReview> ListExpenseReviews(long expenseID);

        [OperationContract]
        [FaultContract(typeof(ProcessExecutionFault))]
        List<ExpenseLog> ListExpenseLogs(long expenseID);

    }


}
