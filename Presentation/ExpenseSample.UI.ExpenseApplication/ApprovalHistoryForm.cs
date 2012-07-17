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
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;

using ExpenseSample.Business.Entities;
using ExpenseSample.UI.Process;

namespace ExpenseSample.UI
{
    public partial class ApprovalHistoryForm : Form
    {
        private long _expenseID;
        private SubmitterUserProcess _upc;

        public ApprovalHistoryForm(SubmitterUserProcess userProcessComponent, long expenseID)
        {
            InitializeComponent();
            reviewGrid.AutoGenerateColumns = false;

            this._upc = userProcessComponent;
            this._expenseID = expenseID;
        }

        private void LoadReviews(long expenseID)
        {
            try
            {
                reviewGrid.DataSource = _upc.LoadExpenseReviews(expenseID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ApprovalHistoryForm_Load(object sender, EventArgs e)
        {
            LoadReviews(this._expenseID);
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}