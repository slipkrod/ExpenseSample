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
using System.Text;

namespace ExpenseSample.Business.Entities
{
    [Serializable]
    public enum ExpenseStatus
    {
        Pending = 0,
        Cancelled = 1,
        Reviewed = 2,
        Escalated = 3,
        Approved = 4,
        Rejected = 5,
        Expired = 6,
        Disbursed = 7
    }
}
