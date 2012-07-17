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
    public class Expense
    {

        [DataMember]
        public Int64 ExpenseID { get; set; }

        [DataMember]
        public Guid WorkflowID { get; set; }
        
        [DataMember]
        public string Employee { get; set; }
        
        [DataMember]
        public DateTime ExpenseDate { get; set; }
        
        [DataMember]
        public double Amount { get; set; }
        
        [DataMember]
        public string Description { get; set; }
        
        [DataMember]
        public string AssignedTo { get; set; }
        [DataMember]
        
        public bool IsCompleted { get; set; }
        [DataMember]
        public DateTime DateSubmitted { get; set; }
        
        [DataMember]
        public DateTime DateModified { get; set; }

        [DataMember]
        private byte CategoryID { get; set; }

        [DataMember]
        private byte StatusID { get; set; }

        [DataMember]
        public virtual List<ExpenseLog> ExpenseLogs { get; set; }

        [DataMember]
        public virtual List<ExpenseReview> ExpenseReviews { get; set; }

        [DataMember]
        public ExpenseStatus Status
        {
            get { return (ExpenseStatus)this.StatusID; }
            set { this.StatusID = (byte)value; }
        }

        [DataMember]
        public ExpenseCategory Category
        {
            get { return (ExpenseCategory)this.CategoryID; }
            set { this.CategoryID = (byte)value; }
        }

        public override string ToString()
        {
            return string.Format("Expense:\n\tWorkflowID={0}\n\tExpenseID={1}\n\tEmployee={2}\n\tDescription={3}\n\tAmount={4}\n\tCategory={5}\n\tExpenseDate={6}\n\tDateSubmitted={7}\n\tStatus={8}\n\tAssignedTo={9}\n\tIsCompleted={10}\n\tDateModified={11}\n",
                this.WorkflowID, this.ExpenseID, this.Employee, this.Description, this.Amount, this.Category, this.ExpenseDate, this.DateSubmitted, this.Status, this.AssignedTo, this.IsCompleted, this.DateModified);
        }
    }
}
