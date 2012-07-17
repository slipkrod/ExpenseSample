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
using System.Runtime.Serialization;
using System.Data;
using System.ComponentModel;

// NOTE:
//
// This sample uses ADO.NET Entity Framework (EF) to generate the Business Entity
// classes. Business Entity classes are responsible for carrying data across the
// layers. It is also used as the Data Contracts for Services.
//
// Try to avoid having business logic embedded inside Business Entity classes.
// As a practice, externalize all business logic into Business Component classes.

namespace ExpenseSample.Business.Entities
{
    [DataContract]
    [Serializable]
    public partial class ExpenseLog
    {

        [DataMember]
        public Int64 LogID { get; set; }

        [DataMember]
        public Int64 ExpenseID { get; set; }

        [DataMember]
        public DateTime DateCreated { get; set; }

        [DataMember]
        private byte StatusID { get; set; }

        [DataMember]
        public Expense Expense { get; set; }

        public ExpenseStatus Status
        {
            get { return (ExpenseStatus)this.StatusID; }
            set { this.StatusID = (byte)value; }
        }

 
    }
}
