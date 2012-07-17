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
    /// Interaction logic for HistoryWindow.xaml
    /// </summary>
    public partial class HistoryWindow : Window
    {
        private long _expenseID;
        private SubmitterUserProcess _upc;

        public HistoryWindow(SubmitterUserProcess userProcessComponent, long expenseID)
        {
            InitializeComponent();
            reviewsGrid.AutoGenerateColumns = false;

            this._upc = userProcessComponent;
            this._expenseID = expenseID;
        }

        private void LoadReviews(long expenseID)
        {
            try
            {
                reviewsGrid.ItemsSource = _upc.LoadExpenseReviews(expenseID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadReviews(this._expenseID);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
