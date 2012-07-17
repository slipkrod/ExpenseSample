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
using System.Windows.Forms;
using ExpenseSample.Business.Entities;
using ExpenseSample.UI.Process;

namespace ExpenseSample.UI.Win
{
    public partial class SubmissionForm : Form
    {
        private const string FORM_TITLE = "Expense Sample 4.0: Submitter";

        // Keep a local cache of expenses.
        private List<Expense> _expenseList = null;
        private BindingSource _source = null;

        SubmitterUserProcess _upc = null;

        public SubmissionForm()
        {
            InitializeComponent();
            expenseGrid.AutoGenerateColumns = false;

            _upc = new SubmitterUserProcess();

            this.Text = FORM_TITLE; 

            cancelButton.Enabled = false;
            historyButton.Enabled = false;
            logButton.Enabled = false;

            _expenseList = new List<Expense>();
            _source = new BindingSource();

            LoadExpenses();
        }

        private void LoadExpenses()
        {
            try
            {
               _expenseList = _upc.LoadExpenses(Environment.UserName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Loading Expenses", MessageBoxButtons.OK,
                    MessageBoxIcon.Error); 
            }

            _source.DataSource = _expenseList;
            _source.ResetBindings(false);

            expenseGrid.DataSource = _source;

        }

        private void SubmitExpense()
        {
            try
            {
                // Validate amount.
                Double amountValue;
                if (!Double.TryParse(amount.Text, out amountValue))
                {
                    MessageBox.Show(this, "Amount must be numeric", "Invalid Data",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    amount.Focus();
                    return;
                }

                // Create a new Expense entity.
                Expense expense = new Expense();
                expense.ExpenseDate = expenseDate.Value.Date;
                expense.Employee = Environment.UserName;
                expense.Amount = amountValue;
                expense.Category = (ExpenseCategory)category.SelectedIndex;
                expense.Description = description.Text;
                expense.DateModified = DateTime.Now;

                _upc.SubmitExpense(expense);

                statusLabel.Text = "Expense submitted.";

                amount.Text = (new Random()).Next(250, 5000).ToString();
                description.Text = "Yet another expense claim.";
                amount.Focus();
            }
            catch (FaultException faultEx)
            {
                MessageBox.Show(faultEx.Message, "Error Submitting Expense", MessageBoxButtons.OK,
                         MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Submitting Expense", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }

            LoadExpenses();

        }

        private void CancelExpense()
        {
            if (MessageBox.Show(this, "Are you sure you want to cancel this expense record?",
                    "Confirm Expense Cancellation", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    foreach (DataGridViewRow row in expenseGrid.SelectedRows)
                    {
                        Expense expense = (Expense)row.DataBoundItem;
                        _upc.CancelExpense(expense);
                    }

                    statusLabel.Text =
                        (expenseGrid.SelectedRows.Count <= 1 ? "Expense" : "Expenses") +
                    " cancelled.";
                    cancelButton.Enabled = false;
                }
                catch (FaultException faultEx)
                {
                    MessageBox.Show(faultEx.Message, "Error Cancelling Expense", MessageBoxButtons.OK,
                             MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Cancelling Expense", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                LoadExpenses();

            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            SubmitExpense();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            LoadExpenses();
            statusLabel.Text = string.Empty;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            CancelExpense();
        }

        private void expenseGrid_SelectionChanged(object sender, System.EventArgs e)
        {
            SetButtonStatus((expenseGrid.SelectedRows.Count > 0));

            // Enable cancel button for non-approved expenses.
            foreach (DataGridViewRow row in expenseGrid.SelectedRows)
            {
                Expense expense = (Expense)row.DataBoundItem;
                if (expense.IsCompleted == false)
                {
                    cancelButton.Enabled = true;
                    return;
                }
            }

            cancelButton.Enabled = false;
        }

        private void SetButtonStatus(bool status)
        {
            historyButton.Enabled = status;
            logButton.Enabled = status;
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

        private void purgeLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                _upc.ResetDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Reseting Database", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }

            LoadExpenses();
            statusLabel.Text = string.Empty;
        }

        private void historyButton_Click(object sender, EventArgs e)
        {
            if (expenseGrid.SelectedRows.Count > 0)
            {
                // Only pick first item.
                DataGridViewRow row = expenseGrid.SelectedRows[0];
                Expense expense = (Expense)row.DataBoundItem;

                ApprovalHistoryForm historyForm = 
                    new ApprovalHistoryForm(_upc, expense.ExpenseID);

                historyForm.ShowDialog();
            }
            
            statusLabel.Text = string.Empty;
        }

        private void amountBox_TextChanged(object sender, EventArgs e)
        {
            submitButton.Enabled = (amount.Text.Length > 0);
        }

        private void logButton_Click(object sender, EventArgs e)
        {
            if (expenseGrid.SelectedRows.Count > 0)
            {
                // Only pick first item.
                DataGridViewRow row = expenseGrid.SelectedRows[0];
                Expense expense = (Expense)row.DataBoundItem;

                TransitionLogForm logForm = new TransitionLogForm(_upc, expense.ExpenseID);
                logForm.ShowDialog();
            }

            statusLabel.Text = string.Empty;
        }

        private void category_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((ExpenseCategory)category.SelectedIndex)
            {
                case ExpenseCategory.LocalTravel:
                    description.Text = "Local Travel Expenses";
                    break;
                case ExpenseCategory.OverseasTravel:
                    description.Text = "Overseas Travel Expenses";
                    break;
                case ExpenseCategory.Medical:
                    description.Text = "Medical Expenses";
                    break;
                case ExpenseCategory.Entertainment:
                    description.Text = "Entertainment Expenses";
                    break;
                default:
                    description.Text = "Miscellaneous Expenses";
                    break;
            }
        }

        private void SubmissionForm_Load(object sender, EventArgs e)
        {
            category.DataSource = Enum.GetNames(typeof(ExpenseCategory));
        }

        
    }
}
