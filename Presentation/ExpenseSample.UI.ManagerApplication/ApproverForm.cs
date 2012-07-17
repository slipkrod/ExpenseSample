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

using ExpenseSample.Business.Entities;

using ExpenseSample.UI.Process;
using System.ServiceModel;

namespace ExpenseSample.UI
{
    public partial class ApproverForm : Form
    {
        private const string FORM_TITLE = "Expense Sample 4.0: Approver";
        private ApproverUserProcess _upc = null;

        public ApproverForm()
        {
            InitializeComponent();
            expenseGrid.AutoGenerateColumns = false;
            _upc = new ApproverUserProcess();

            this.Text = string.Format(FORM_TITLE); 

            roleBox.Items.AddRange(_upc.GetRoles());

            LoadExpenses();
        }

        private void LoadExpenses()
        {
            try
            {
                expenseGrid.DataSource = _upc.LoadExpenses(roleBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Loading Expenses", MessageBoxButtons.OK,
                        MessageBoxIcon.Error); 
            }

        }

        private void ApproveExpense(bool approved)
        {
            try
            {
                foreach (DataGridViewRow row in expenseGrid.SelectedRows)
                {
                    Expense expense = (Expense)row.DataBoundItem;

                    // Create a new review object.
                    // NOTE: For simplicity, we just use Role as ApproverID.
                    ExpenseReview review = new ExpenseReview();
                    review.ExpenseID = expense.ExpenseID;
                    review.Reviewer = roleBox.Text;
                    review.IsApproved = approved;
                    review.Remarks = remarksBox.Text;

                    _upc.ApproveExpense(expense, review);

                }

            }
            catch (FaultException faultEx)
            {
                MessageBox.Show(faultEx.Message, "Error Processing Expense", MessageBoxButtons.OK,
                         MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Processing Expense", MessageBoxButtons.OK,
                        MessageBoxIcon.Error); ;
            }

            string term = string.Compare(roleBox.Text, "Financial Controller", true) == 0 ?
                            "disbursed" : "approved";

            statusLabel.Text = string.Format(
                (expenseGrid.SelectedRows.Count <= 1 ? "Expense {0}." : "Expenses {0}."),
                approved ? term : "rejected");

            LoadExpenses();
        }

        private void ApproverForm_Load(object sender, EventArgs e)
        {
            roleBox.SelectedIndex = 0;
        }

        private void approveButton_Click(object sender, EventArgs e)
        {
            ApproveExpense(true);
        }

        private void rejectButton_Click(object sender, EventArgs e)
        {
            ApproveExpense(false);
        }


        private void refreshButton_Click(object sender, EventArgs e)
        {
            LoadExpenses();
            statusLabel.Text = string.Empty;
        }

        private void expenseGrid_SelectionChanged(object sender, System.EventArgs e)
        {
            foreach (DataGridViewRow row in expenseGrid.SelectedRows)
            {
                Expense expense = (Expense)row.DataBoundItem;
                if (expense.Status == ExpenseStatus.Cancelled ||
                    expense.Status == ExpenseStatus.Disbursed ||
                    expense.Status == ExpenseStatus.Expired ||
                    expense.Status == ExpenseStatus.Rejected)
                {
                    SetButtonStatus(false);
                    return;
                }
            }

            SetButtonStatus(true);
        }

        private void SetButtonStatus(bool status)
        {
            approveButton.Enabled = status;
            rejectButton.Enabled = status;
        }

        private void roleBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            approveButton.Text = string.Compare(roleBox.Text, "Financial Controller", true) == 0 ?
                "Disburse" : "Approve";

            LoadExpenses();
            statusLabel.Text = string.Empty;

        }
        private void autoBox_CheckedChanged(object sender, EventArgs e)
        {
            // WARNING: This is for convenience of demo only.
            //          Do not do this for real-life applications as it is bad for performance.
            refreshTimer.Enabled = autoBox.Checked;
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            // WARNING: This is for convenience of demo only.
            //          Do not do this for real-life applications as it is bad for performance.
            LoadExpenses();
        }

        private void selectAllButton_Click(object sender, EventArgs e)
        {
            expenseGrid.SelectAll();
        }

        
    }
}