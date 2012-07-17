namespace ExpenseSample.UI
{
    partial class ApproverForm
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
            this.components = new System.ComponentModel.Container();
            this.approveButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.roleBox = new System.Windows.Forms.ComboBox();
            this.rejectButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.remarksBox = new System.Windows.Forms.TextBox();
            this.autoBox = new System.Windows.Forms.CheckBox();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.statusLabel = new System.Windows.Forms.Label();
            this.selectAllButton = new System.Windows.Forms.Button();
            this.expenseGrid = new System.Windows.Forms.DataGridView();
            this.ExpenseIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpenseDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssignedToColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateSubmittedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateModifiedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsCompletedColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.expenseGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // approveButton
            // 
            this.approveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.approveButton.Location = new System.Drawing.Point(405, 217);
            this.approveButton.Name = "approveButton";
            this.approveButton.Size = new System.Drawing.Size(75, 23);
            this.approveButton.TabIndex = 1;
            this.approveButton.Text = "A&pprove";
            this.approveButton.UseVisualStyleBackColor = true;
            this.approveButton.Click += new System.EventHandler(this.approveButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshButton.Location = new System.Drawing.Point(485, 10);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 7;
            this.refreshButton.Text = "&Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Role:";
            // 
            // roleBox
            // 
            this.roleBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roleBox.FormattingEnabled = true;
            this.roleBox.Location = new System.Drawing.Point(71, 12);
            this.roleBox.Name = "roleBox";
            this.roleBox.Size = new System.Drawing.Size(121, 21);
            this.roleBox.TabIndex = 9;
            this.roleBox.SelectedIndexChanged += new System.EventHandler(this.roleBox_SelectedIndexChanged);
            // 
            // rejectButton
            // 
            this.rejectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rejectButton.Location = new System.Drawing.Point(485, 217);
            this.rejectButton.Name = "rejectButton";
            this.rejectButton.Size = new System.Drawing.Size(75, 23);
            this.rejectButton.TabIndex = 10;
            this.rejectButton.Text = "R&eject";
            this.rejectButton.UseVisualStyleBackColor = true;
            this.rejectButton.Click += new System.EventHandler(this.rejectButton_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Remarks:";
            // 
            // remarksBox
            // 
            this.remarksBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.remarksBox.Location = new System.Drawing.Point(69, 219);
            this.remarksBox.Name = "remarksBox";
            this.remarksBox.Size = new System.Drawing.Size(249, 20);
            this.remarksBox.TabIndex = 12;
            // 
            // autoBox
            // 
            this.autoBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.autoBox.AutoSize = true;
            this.autoBox.Location = new System.Drawing.Point(396, 14);
            this.autoBox.Name = "autoBox";
            this.autoBox.Size = new System.Drawing.Size(83, 17);
            this.autoBox.TabIndex = 13;
            this.autoBox.Text = "Auto refresh";
            this.autoBox.UseVisualStyleBackColor = true;
            this.autoBox.CheckedChanged += new System.EventHandler(this.autoBox_CheckedChanged);
            // 
            // refreshTimer
            // 
            this.refreshTimer.Interval = 5000;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // statusLabel
            // 
            this.statusLabel.Location = new System.Drawing.Point(209, 15);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(149, 18);
            this.statusLabel.TabIndex = 14;
            // 
            // selectAllButton
            // 
            this.selectAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.selectAllButton.Location = new System.Drawing.Point(324, 217);
            this.selectAllButton.Name = "selectAllButton";
            this.selectAllButton.Size = new System.Drawing.Size(75, 23);
            this.selectAllButton.TabIndex = 15;
            this.selectAllButton.Text = "Select &All";
            this.selectAllButton.UseVisualStyleBackColor = true;
            this.selectAllButton.Click += new System.EventHandler(this.selectAllButton_Click);
            // 
            // expenseGrid
            // 
            this.expenseGrid.AllowUserToAddRows = false;
            this.expenseGrid.AllowUserToDeleteRows = false;
            this.expenseGrid.AllowUserToOrderColumns = true;
            this.expenseGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.expenseGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.expenseGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.expenseGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ExpenseIDColumn,
            this.EmployeeColumn,
            this.DescriptionColumn,
            this.AmountColumn,
            this.ExpenseDateColumn,
            this.CategoryColumn,
            this.StatusColumn,
            this.AssignedToColumn,
            this.DateSubmittedColumn,
            this.DateModifiedColumn,
            this.IsCompletedColumn});
            this.expenseGrid.Location = new System.Drawing.Point(13, 37);
            this.expenseGrid.Name = "expenseGrid";
            this.expenseGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.expenseGrid.Size = new System.Drawing.Size(547, 175);
            this.expenseGrid.TabIndex = 19;
            // 
            // ExpenseIDColumn
            // 
            this.ExpenseIDColumn.DataPropertyName = "ExpenseID";
            this.ExpenseIDColumn.HeaderText = "ExpenseID";
            this.ExpenseIDColumn.Name = "ExpenseIDColumn";
            this.ExpenseIDColumn.ReadOnly = true;
            this.ExpenseIDColumn.Width = 84;
            // 
            // EmployeeColumn
            // 
            this.EmployeeColumn.DataPropertyName = "Employee";
            this.EmployeeColumn.HeaderText = "Employee";
            this.EmployeeColumn.Name = "EmployeeColumn";
            this.EmployeeColumn.ReadOnly = true;
            this.EmployeeColumn.Width = 78;
            // 
            // DescriptionColumn
            // 
            this.DescriptionColumn.DataPropertyName = "Description";
            this.DescriptionColumn.HeaderText = "Description";
            this.DescriptionColumn.Name = "DescriptionColumn";
            this.DescriptionColumn.ReadOnly = true;
            this.DescriptionColumn.Width = 85;
            // 
            // AmountColumn
            // 
            this.AmountColumn.DataPropertyName = "Amount";
            this.AmountColumn.HeaderText = "Amount";
            this.AmountColumn.Name = "AmountColumn";
            this.AmountColumn.ReadOnly = true;
            this.AmountColumn.Width = 68;
            // 
            // ExpenseDateColumn
            // 
            this.ExpenseDateColumn.DataPropertyName = "ExpenseDate";
            this.ExpenseDateColumn.HeaderText = "Expense Date";
            this.ExpenseDateColumn.Name = "ExpenseDateColumn";
            this.ExpenseDateColumn.ReadOnly = true;
            this.ExpenseDateColumn.Width = 99;
            // 
            // CategoryColumn
            // 
            this.CategoryColumn.DataPropertyName = "Category";
            this.CategoryColumn.HeaderText = "Category";
            this.CategoryColumn.Name = "CategoryColumn";
            this.CategoryColumn.ReadOnly = true;
            this.CategoryColumn.Width = 74;
            // 
            // StatusColumn
            // 
            this.StatusColumn.DataPropertyName = "Status";
            this.StatusColumn.HeaderText = "Status";
            this.StatusColumn.Name = "StatusColumn";
            this.StatusColumn.ReadOnly = true;
            this.StatusColumn.Width = 62;
            // 
            // AssignedToColumn
            // 
            this.AssignedToColumn.DataPropertyName = "AssignedTo";
            this.AssignedToColumn.HeaderText = "AssignedTo";
            this.AssignedToColumn.Name = "AssignedToColumn";
            this.AssignedToColumn.ReadOnly = true;
            this.AssignedToColumn.Width = 88;
            // 
            // DateSubmittedColumn
            // 
            this.DateSubmittedColumn.DataPropertyName = "DateSubmitted";
            this.DateSubmittedColumn.HeaderText = "DateSubmitted";
            this.DateSubmittedColumn.Name = "DateSubmittedColumn";
            this.DateSubmittedColumn.ReadOnly = true;
            this.DateSubmittedColumn.Width = 102;
            // 
            // DateModifiedColumn
            // 
            this.DateModifiedColumn.DataPropertyName = "DateModified";
            this.DateModifiedColumn.HeaderText = "DateModified";
            this.DateModifiedColumn.Name = "DateModifiedColumn";
            this.DateModifiedColumn.ReadOnly = true;
            this.DateModifiedColumn.Width = 95;
            // 
            // IsCompletedColumn
            // 
            this.IsCompletedColumn.DataPropertyName = "IsCompleted";
            this.IsCompletedColumn.HeaderText = "IsCompleted";
            this.IsCompletedColumn.Name = "IsCompletedColumn";
            this.IsCompletedColumn.ReadOnly = true;
            this.IsCompletedColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsCompletedColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsCompletedColumn.Width = 90;
            // 
            // ApproverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 248);
            this.Controls.Add(this.expenseGrid);
            this.Controls.Add(this.selectAllButton);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.autoBox);
            this.Controls.Add(this.remarksBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rejectButton);
            this.Controls.Add(this.roleBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.approveButton);
            this.MinimumSize = new System.Drawing.Size(580, 180);
            this.Name = "ApproverForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expense Sample 4.0: Approver";
            this.Load += new System.EventHandler(this.ApproverForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.expenseGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button approveButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox roleBox;
        private System.Windows.Forms.Button rejectButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox remarksBox;
        private System.Windows.Forms.CheckBox autoBox;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button selectAllButton;
        private System.Windows.Forms.DataGridView expenseGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpenseIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpenseDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssignedToColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateSubmittedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateModifiedColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsCompletedColumn;
    }
}

