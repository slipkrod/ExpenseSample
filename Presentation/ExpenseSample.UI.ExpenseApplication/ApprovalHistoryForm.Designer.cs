//--------------------------------------------------------------------------------
// Developed by: Serena Yeoh
// 
//--------------------------------------------------------------------------------
// THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//--------------------------------------------------------------------------------
namespace ExpenseSample.UI
{
    partial class ApprovalHistoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.reviewGrid = new System.Windows.Forms.DataGridView();
            this.acceptButton = new System.Windows.Forms.Button();
            this.ReviewIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReviewerColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RemarksColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsApprovedColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DateApprovedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.reviewGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // reviewGrid
            // 
            this.reviewGrid.AllowUserToAddRows = false;
            this.reviewGrid.AllowUserToDeleteRows = false;
            this.reviewGrid.AllowUserToOrderColumns = true;
            this.reviewGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.reviewGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.reviewGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reviewGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ReviewIDColumn,
            this.ReviewerColumn,
            this.RemarksColumn,
            this.IsApprovedColumn,
            this.DateApprovedColumn});
            this.reviewGrid.Location = new System.Drawing.Point(12, 12);
            this.reviewGrid.Name = "reviewGrid";
            this.reviewGrid.ReadOnly = true;
            this.reviewGrid.Size = new System.Drawing.Size(420, 182);
            this.reviewGrid.TabIndex = 0;
            // 
            // acceptButton
            // 
            this.acceptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.acceptButton.Location = new System.Drawing.Point(357, 203);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 1;
            this.acceptButton.Text = "O&K";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // ReviewIDColumn
            // 
            this.ReviewIDColumn.DataPropertyName = "ReviewID";
            this.ReviewIDColumn.HeaderText = "ReviewID";
            this.ReviewIDColumn.Name = "ReviewIDColumn";
            this.ReviewIDColumn.ReadOnly = true;
            this.ReviewIDColumn.Width = 79;
            // 
            // ReviewerColumn
            // 
            this.ReviewerColumn.DataPropertyName = "Reviewer";
            this.ReviewerColumn.HeaderText = "Reviewer";
            this.ReviewerColumn.Name = "ReviewerColumn";
            this.ReviewerColumn.ReadOnly = true;
            this.ReviewerColumn.Width = 77;
            // 
            // RemarksColumn
            // 
            this.RemarksColumn.DataPropertyName = "Remarks";
            this.RemarksColumn.HeaderText = "Remarks";
            this.RemarksColumn.Name = "RemarksColumn";
            this.RemarksColumn.ReadOnly = true;
            this.RemarksColumn.Width = 74;
            // 
            // IsApprovedColumn
            // 
            this.IsApprovedColumn.DataPropertyName = "IsApproved";
            this.IsApprovedColumn.HeaderText = "IsApproved";
            this.IsApprovedColumn.Name = "IsApprovedColumn";
            this.IsApprovedColumn.ReadOnly = true;
            this.IsApprovedColumn.Width = 67;
            // 
            // DateApprovedColumn
            // 
            this.DateApprovedColumn.DataPropertyName = "DateApproved";
            this.DateApprovedColumn.HeaderText = "DateApproved";
            this.DateApprovedColumn.Name = "DateApprovedColumn";
            this.DateApprovedColumn.ReadOnly = true;
            this.DateApprovedColumn.Width = 101;
            // 
            // ApprovalHistoryForm
            // 
            this.AcceptButton = this.acceptButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 235);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.reviewGrid);
            this.Name = "ApprovalHistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Approval History";
            this.Load += new System.EventHandler(this.ApprovalHistoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reviewGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView reviewGrid;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReviewIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReviewerColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RemarksColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsApprovedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateApprovedColumn;
    }
}