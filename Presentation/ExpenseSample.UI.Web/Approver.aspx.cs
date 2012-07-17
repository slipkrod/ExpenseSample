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
    public partial class Approver : System.Web.UI.Page
    {
        ApproverUserProcess _upc = null;

        #region "Page and control events"
        protected void Page_Load(object sender, EventArgs e)
        {
            _upc = new ApproverUserProcess();

            if (!IsPostBack)
            {
                // Populate roles.
                string[] roles = _upc.GetRoles();
                for (int i = 0; i < roles.Length; i++)
                {
                    roleBox.Items.Insert(i, roles[i].ToString());
                }

                LoadExpenses();
            }
        }

        protected void expenseGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            expenseGrid.PageIndex = e.NewPageIndex;
            LoadExpenses();
        }

        protected void refreshButton_Click(object sender, EventArgs e)
        {
            LoadExpenses();
        }

        protected void roleBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadExpenses();

            approveButton.Text = string.Compare(roleBox.Text, "Financial Controller", true) == 0 ?
                "Disburse" : "Approve";

        }

        protected void approveButton_Click(object sender, EventArgs e)
        {
            ApproveExpense(true);
        }

        protected void rejectButton_Click(object sender, EventArgs e)
        {
            ApproveExpense(false);
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


        private void LoadExpenses()
        {
            bool hasRows;
            try
            {
                expenseGrid.DataSource = _upc.LoadExpenses(roleBox.SelectedValue);
                expenseGrid.DataBind();

                hasRows = (expenseGrid.Rows.Count > 0);
                SetControlStatus(hasRows);

                statusLabel.Text = hasRows ?
                    string.Empty : "No pending expenses available for review or approval.";
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        private void SetControlStatus(bool status)
        {
            approveButton.Enabled = status;
            rejectButton.Enabled = status;
            remarksBox.Enabled = status;
        }

        private void ApproveExpense(bool approved)
        {
            int i = 0;

            try
            {
                foreach (GridViewRow row in expenseGrid.Rows)
                {
                    if (((CheckBox)row.FindControl("selectBox")).Checked)
                    {
                        // NOTE: I don't really like this part because it is reconstructing
                        //       the entity. Any ideas or advice would be appreciated.
                        Expense expense = new Expense();

                        DataKey key = expenseGrid.DataKeys[row.RowIndex];
                        expense.ExpenseID = (long)key.Values[0];
                        expense.WorkflowID = (Guid)key.Values[1];

                        expense.Employee = row.Cells[2].Text;
                        expense.Category = (ExpenseCategory)
                            Enum.Parse(typeof(ExpenseCategory), row.Cells[3].Text);
                        expense.Description = row.Cells[4].Text;
                        expense.Amount = Convert.ToDouble(row.Cells[5].Text);
                        expense.ExpenseDate = Convert.ToDateTime(row.Cells[6].Text);
                        expense.Status = (ExpenseStatus)
                            Enum.Parse(typeof(ExpenseStatus), row.Cells[7].Text);
                        expense.DateSubmitted = Convert.ToDateTime(row.Cells[8].Text);
                        expense.DateModified = Convert.ToDateTime(row.Cells[9].Text);
                        // End of Expense entity reconstruction.

                        ExpenseReview review = new ExpenseReview();
                        review.ExpenseID = expense.ExpenseID;
                        review.Reviewer = roleBox.SelectedValue;
                        review.IsApproved = approved;
                        review.Remarks = remarksBox.Text;

                        _upc.ApproveExpense(expense, review);

                    }
                    i++;
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

            LoadExpenses();

            string term = string.Compare(roleBox.Text, "Financial Controller", true) == 0 ?
                    "disbursed. " : "approved. ";

            if (i > 0)
            {
                statusLabel.Text = (i > 1 ? "Expenses " : "Expense ") +
                    (approved ? term : " rejected.") +
                    (expenseGrid.Rows.Count > 0 ? string.Empty :
                        "There are no more pending expenses available for review or approval.");
            }
        }


    }
}
