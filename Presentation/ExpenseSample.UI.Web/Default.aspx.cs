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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ExpenseSample.UI.Process;
using ExpenseSample.Business.Entities;

namespace ExpenseSample.UI.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        SubmitterUserProcess _upc = null;

        #region Page and control events
        protected void Page_Load(object sender, EventArgs e)
        {
            _upc = new SubmitterUserProcess();

            if (!IsPostBack)
            {
                userLabel.Text = Environment.UserName;
                expenseDate.Text = DateTime.Now.ToShortDateString();

                category.DataSource = Enum.GetNames(typeof(ExpenseCategory));
                category.DataBind();
                LoadExpenses();
            }
        }

        protected void expenseGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            expenseGrid.PageIndex = e.NewPageIndex;
            LoadExpenses();
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            SubmitExpense();
        }

        protected void historyButton_Click(object sender, EventArgs e)
        {
            LoadReviewHistory();
        }

        protected void logButton_Click(object sender, EventArgs e)
        {
            LoadTransitionHistory();
        }

        protected void refreshButton_Click(object sender, EventArgs e)
        {
            LoadExpenses();
            statusLabel.Text = string.Empty;
        }

        protected void purgeButton_Click(object sender, EventArgs e)
        {
            ResetDatabase();
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            CancelExpense();
        }

        protected void refreshTimer_Tick(object sender, EventArgs e)
        {
            // WARNING: This is for convenience of demo only.
            //          Do not do this for real-life applications as it is bad for performance.
            LoadExpenses();
        }

        protected void autoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            refreshTimer.Enabled = autoRefresh.Checked;
        }
        #endregion

        private void SubmitExpense()
        {
            Expense expense = new Expense();
            expense.Employee = Environment.UserName;
            expense.ExpenseDate = Convert.ToDateTime(expenseDate.Text).Date;
            expense.Amount = Convert.ToDouble(expenseAmount.Text);
            expense.Category = (ExpenseCategory)category.SelectedIndex;
            expense.Description = description.Text;

            try
            {
                _upc.SubmitExpense(expense);

                statusLabel.Text = "Expense submitted successfully.";
                expenseAmount.Text = string.Empty;


                LoadExpenses();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        private void CancelExpense()
        {
            int i = 0;

            try
            {
                foreach (GridViewRow row in expenseGrid.Rows)
                {
                    if (((CheckBox)row.FindControl("selectBox")).Checked)
                    {
                        // NOTE: I don't really like this part because it is reconstructing
                        //       the entity from scratch. Any ideas or advice would be appreciated.
                        Expense expense = new Expense();

                        DataKey key = expenseGrid.DataKeys[row.RowIndex];
                        expense.ExpenseID = (long)key.Values[0];
                        expense.WorkflowID = (Guid)key.Values[1];

                        expense.Employee = Environment.UserName;
                        expense.Category = (ExpenseCategory)
                            Enum.Parse(typeof(ExpenseCategory), row.Cells[2].Text);
                        expense.Description = row.Cells[3].Text;
                        expense.Amount = Convert.ToDouble(row.Cells[4].Text);
                        expense.ExpenseDate = Convert.ToDateTime(row.Cells[5].Text);
                        expense.Status = (ExpenseStatus)
                            Enum.Parse(typeof(ExpenseStatus), row.Cells[6].Text);
                        expense.DateSubmitted = Convert.ToDateTime(row.Cells[7].Text);
                        expense.DateModified = Convert.ToDateTime(row.Cells[8].Text);
                        expense.AssignedTo = row.Cells[9].Text;
                        // End of Expense entity reconstruction.

                        if (_upc.CancelExpense(expense))
                            i++;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

            if (i > 0)
            {
                infoLabel.Text = (i <= 1 ? "Expense" : "Expenses") + " cancelled.";
            }
            else
            {
                infoLabel.Text = "No pending expenses available for cancellation.";
            }

            LoadExpenses();

        }

        private void LoadExpenses()
        {
            try
            {
                expenseGrid.DataSource = _upc.LoadExpenses(Environment.UserName);
                expenseGrid.DataBind();

                HideGridViews();
                SetButtonStatus();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        private void LoadTransitionHistory()
        {
            bool hasRecords = false;
            bool isSelected = false;

            try
            {
                foreach (GridViewRow row in expenseGrid.Rows)
                {
                    if (((CheckBox)row.FindControl("selectBox")).Checked)
                    {
                        DataKey key = expenseGrid.DataKeys[row.RowIndex];
                        long expenseID = (long)key.Values[0];

                        infoLabel.Text = "Transition History for ExpenseID " + expenseID.ToString();
                        logGrid.DataSource = _upc.LoadExpenseLogs(expenseID);
                        logGrid.DataBind();
                        logGrid.Visible = true;
                        reviewGrid.Visible = false;
                        hasRecords = (logGrid.Rows.Count > 0);
                        isSelected = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

            if (!isSelected)
            {
                infoLabel.Text = "Please select an expense to view its Transition History.";
            }
            else if (!hasRecords)
            {
                infoLabel.Text = "Expense has no Transition History.";
            }

        }

        private void LoadReviewHistory()
        {
            bool hasRecords = false;
            bool isSelected = false;

            try
            {
                foreach (GridViewRow row in expenseGrid.Rows)
                {
                    if (((CheckBox)row.FindControl("selectBox")).Checked)
                    {
                        DataKey key = expenseGrid.DataKeys[row.RowIndex];
                        long expenseID = (long)key.Values[0];

                        infoLabel.Text = "Approval History for ExpenseID " + expenseID.ToString();
                        reviewGrid.DataSource = _upc.LoadExpenseReviews(expenseID);
                        reviewGrid.DataBind();
                        reviewGrid.Visible = true;
                        logGrid.Visible = false;
                        hasRecords = (reviewGrid.Rows.Count > 0);
                        isSelected = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

            if (!isSelected)
            {
                infoLabel.Text = "Please select an expense to view its Approval History.";
            }
            else if (!hasRecords)
            {
                infoLabel.Text = "Expense has no Approval History.";
            }
        }

        private void ResetDatabase()
        {
            try
            {
                _upc.ResetDatabase();
                LoadExpenses();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

            statusLabel.Text = "Data in database has been purged.";
        }

        private void HideGridViews()
        {
            infoLabel.Text = string.Empty;
            logGrid.DataSource = null;
            logGrid.DataBind();
            reviewGrid.DataSource = null;
            reviewGrid.DataBind();
        }

        private void SetButtonStatus()
        {
            if (expenseGrid.Rows.Count > 0)
            {
                statusLabel.Text = string.Empty;
                cancelButton.Enabled = true;
                historyButton.Enabled = true;
                logButton.Enabled = true;
            }
            else
            {
                statusLabel.Text = "You have not submitted any expenses.";
                cancelButton.Enabled = false;
                historyButton.Enabled = false;
                logButton.Enabled = false;
            }
        }


    }
}
