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
using System.Windows;
using ExpenseSample.UI.Process;

namespace ExpenseSample.UI.WPF
{
    /// <summary>
    /// Interaction logic for LogWindow.xaml
    /// </summary>
    public partial class LogWindow : Window
    {
        private long _expenseID;
        private SubmitterUserProcess _upc;

        public LogWindow(SubmitterUserProcess userProcessComponent, long expenseID)
        {
            InitializeComponent();
            logGrid.AutoGenerateColumns = false;

            this._upc = userProcessComponent;
            this._expenseID = expenseID;
        }

        private void LoadLogs(long expenseID)
        {
            try
            {
                logGrid.ItemsSource = _upc.LoadExpenseLogs(expenseID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadLogs(this._expenseID);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
