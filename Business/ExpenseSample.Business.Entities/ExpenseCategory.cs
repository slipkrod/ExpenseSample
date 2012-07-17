//--------------------------------------------------------------------------------
// Developed by: Serena Yeoh
// 
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
    public enum ExpenseCategory
    {
        LocalTravel = 0,
        OverseasTravel = 1,
        Entertainment = 2,
        Medical = 3,
        Others = 4
    }
}
