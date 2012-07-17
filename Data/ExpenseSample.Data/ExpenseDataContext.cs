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
using System.Data.Objects;
using ExpenseSample.Business.Entities;

namespace ExpenseSample.Data
{
    internal class ExpenseDataContext : ObjectContext
    {
        private ObjectSet<Expense> _expenses;
        private ObjectSet<ExpenseReview> _reviews;
        private ObjectSet<ExpenseLog> _logs;

        public ExpenseDataContext()
            : base("name=ExpenseEntities", "ExpenseEntities")  
        {
            this.ContextOptions.LazyLoadingEnabled = false;
            this.ContextOptions.ProxyCreationEnabled = false;
        }

        public ExpenseDataContext(string connectionString)
            : base(connectionString, "ExpenseEntities")
         {
             this.ContextOptions.LazyLoadingEnabled = false;
             this.ContextOptions.ProxyCreationEnabled = false;
         }


        public ObjectSet<Expense> Expenses
        {
            get 
            {
                return _expenses ?? (_expenses = base.CreateObjectSet<Expense>());

            }
        }

        public ObjectSet<ExpenseReview> ExpenseReviews
        {
            get
            {
                return _reviews ?? (_reviews = base.CreateObjectSet<ExpenseReview>());
            }
        }

        public ObjectSet<ExpenseLog> ExpenseLogs
        {
            get
            {
                return _logs ?? (_logs = base.CreateObjectSet<ExpenseLog>());
            }
        }
    }
}
