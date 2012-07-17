namespace ExpenseSample.UI.Win
{
    partial class SubmissionForm
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
            this.submitButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.category = new System.Windows.Forms.ComboBox();
            this.logButton = new System.Windows.Forms.Button();
            this.historyButton = new System.Windows.Forms.Button();
            this.expenseDate = new System.Windows.Forms.DateTimePicker();
            this.purgeLink = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.TextBox();
            this.amount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.expenseGrid = new System.Windows.Forms.DataGridView();
            this.ExpenseIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpenseDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssignedToColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateSubmittedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateModifiedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsCompletedColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.refreshTimer = new System.Windows.Forms.Timer();
            this.autoBox = new System.Windows.Forms.CheckBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expenseGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(15, 81);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(74, 23);
            this.submitButton.TabIndex = 8;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.statusLabel.Location = new System.Drawing.Point(12, 146);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(333, 16);
            this.statusLabel.TabIndex = 17;
            // 
            // category
            // 
            this.category.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.category.FormattingEnabled = true;
            this.category.Location = new System.Drawing.Point(448, 45);
            this.category.Name = "category";
            this.category.Size = new System.Drawing.Size(121, 21);
            this.category.TabIndex = 7;
            this.category.SelectedIndexChanged += new System.EventHandler(this.category_SelectedIndexChanged);
            // 
            // logButton
            // 
            this.logButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.logButton.Location = new System.Drawing.Point(184, 356);
            this.logButton.Name = "logButton";
            this.logButton.Size = new System.Drawing.Size(80, 23);
            this.logButton.TabIndex = 16;
            this.logButton.Text = "Transitions";
            this.logButton.UseVisualStyleBackColor = true;
            this.logButton.Click += new System.EventHandler(this.logButton_Click);
            // 
            // historyButton
            // 
            this.historyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.historyButton.Location = new System.Drawing.Point(98, 356);
            this.historyButton.Name = "historyButton";
            this.historyButton.Size = new System.Drawing.Size(80, 23);
            this.historyButton.TabIndex = 15;
            this.historyButton.Text = "Approvals";
            this.historyButton.UseVisualStyleBackColor = true;
            this.historyButton.Click += new System.EventHandler(this.historyButton_Click);
            // 
            // expenseDate
            // 
            this.expenseDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.expenseDate.Location = new System.Drawing.Point(96, 19);
            this.expenseDate.Name = "expenseDate";
            this.expenseDate.Size = new System.Drawing.Size(105, 20);
            this.expenseDate.TabIndex = 10;
            // 
            // purgeLink
            // 
            this.purgeLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.purgeLink.AutoSize = true;
            this.purgeLink.Location = new System.Drawing.Point(515, 361);
            this.purgeLink.Name = "purgeLink";
            this.purgeLink.Size = new System.Drawing.Size(82, 13);
            this.purgeLink.TabIndex = 14;
            this.purgeLink.TabStop = true;
            this.purgeLink.Text = "Reset database";
            this.purgeLink.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.purgeLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.purgeLink_LinkClicked);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.Cornsilk;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(96, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(473, 36);
            this.label5.TabIndex = 9;
            this.label5.Text = "Submit a medical expense or an expense with an amount greater than 2000 to test a" +
                "lternate workflows.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(383, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Category:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.expenseDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.category);
            this.groupBox1.Controls.Add(this.submitButton);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.description);
            this.groupBox1.Controls.Add(this.amount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(585, 120);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enter the details of your expense";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(383, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Amount:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Expense Date:";
            // 
            // description
            // 
            this.description.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.description.Location = new System.Drawing.Point(96, 45);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(252, 20);
            this.description.TabIndex = 5;
            this.description.Text = "Travel Expenses";
            // 
            // amount
            // 
            this.amount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.amount.Location = new System.Drawing.Point(448, 19);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(121, 20);
            this.amount.TabIndex = 3;
            this.amount.Text = "250";
            this.amount.TextChanged += new System.EventHandler(this.amountBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Description:";
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
            this.expenseGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.expenseGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.expenseGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ExpenseIDColumn,
            this.DescriptionColumn,
            this.AmountColumn,
            this.ExpenseDateColumn,
            this.CategoryColumn,
            this.StatusColumn,
            this.AssignedToColumn,
            this.DateSubmittedColumn,
            this.DateModifiedColumn,
            this.IsCompletedColumn});
            this.expenseGrid.Location = new System.Drawing.Point(12, 175);
            this.expenseGrid.MultiSelect = false;
            this.expenseGrid.Name = "expenseGrid";
            this.expenseGrid.ReadOnly = true;
            this.expenseGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.expenseGrid.Size = new System.Drawing.Size(585, 175);
            this.expenseGrid.TabIndex = 18;
            this.expenseGrid.SelectionChanged += new System.EventHandler(this.expenseGrid_SelectionChanged);
            // 
            // ExpenseIDColumn
            // 
            this.ExpenseIDColumn.DataPropertyName = "ExpenseID";
            this.ExpenseIDColumn.HeaderText = "ExpenseID";
            this.ExpenseIDColumn.Name = "ExpenseIDColumn";
            this.ExpenseIDColumn.ReadOnly = true;
            this.ExpenseIDColumn.Width = 84;
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
            // refreshTimer
            // 
            this.refreshTimer.Interval = 5000;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // autoBox
            // 
            this.autoBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.autoBox.AutoSize = true;
            this.autoBox.Location = new System.Drawing.Point(433, 150);
            this.autoBox.Name = "autoBox";
            this.autoBox.Size = new System.Drawing.Size(83, 17);
            this.autoBox.TabIndex = 11;
            this.autoBox.Text = "Auto refresh";
            this.autoBox.UseVisualStyleBackColor = true;
            this.autoBox.CheckedChanged += new System.EventHandler(this.autoBox_CheckedChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelButton.Location = new System.Drawing.Point(12, 356);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(80, 23);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshButton.Location = new System.Drawing.Point(522, 146);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 13;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // SubmissionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 388);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.logButton);
            this.Controls.Add(this.historyButton);
            this.Controls.Add(this.purgeLink);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.expenseGrid);
            this.Controls.Add(this.autoBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.refreshButton);
            this.MinimumSize = new System.Drawing.Size(546, 405);
            this.Name = "SubmissionForm";
            this.Text = "Expense Sample 4.0: Submitter";
            this.Load += new System.EventHandler(this.SubmissionForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expenseGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ComboBox category;
        private System.Windows.Forms.Button logButton;
        private System.Windows.Forms.Button historyButton;
        private System.Windows.Forms.DateTimePicker expenseDate;
        private System.Windows.Forms.LinkLabel purgeLink;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.TextBox amount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.CheckBox autoBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.DataGridView expenseGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpenseIDColumn;
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