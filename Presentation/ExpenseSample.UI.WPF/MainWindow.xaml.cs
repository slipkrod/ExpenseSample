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
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ExpenseSample.Business.Entities;
using ExpenseSample.UI.Process;

namespace ExpenseSample.UI.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Expense> _expenseList = null;
        SubmitterUserProcess _upc = null;

        public MainWindow()
        {
            InitializeComponent();

            _upc = new SubmitterUserProcess();
            _expenseList = new List<Expense>();

            expenseDate.SelectedDate = DateTime.Today;

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
                MessageBox.Show(ex.Message, "Error Loading Expenses", MessageBoxButton.OK,
                     MessageBoxImage.Error);
            }

            expenseGrid.ItemsSource = _expenseList;
        }

        private void SubmitExpense()
        {
            try
            {
                // Validate amount.
                Double amountValue;
                if (!Double.TryParse(amount.Text, out amountValue))
                {
                    MessageBox.Show("Amount must be numeric", "Invalid Data",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    amount.Focus();
                    return;
                }

                // Create a new Expense entity.
                Expense expense = new Expense();
                expense.ExpenseDate = expenseDate.SelectedDate.GetValueOrDefault();
                expense.Employee = Environment.UserName;
                expense.Amount = amountValue;
                expense.Category = (ExpenseCategory)category.SelectedIndex;
                expense.Description = description.Text;
                expense.DateModified = DateTime.Now;

                _upc.SubmitExpense(expense);

                statusLabel.Content = "Expense submitted.";

                amount.Text = string.Empty;
                description.Text = string.Empty;
                amount.Focus();
            }
            catch (FaultException faultEx)
            {
                MessageBox.Show(faultEx.Message, "Error Submitting Expense", MessageBoxButton.OK,
                     MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Submitting Expense", MessageBoxButton.OK,
                     MessageBoxImage.Error);
            }

            LoadExpenses();

        }

        private void CancelExpense()
        {
            if (MessageBox.Show("Are you sure you want to cancel this expense record?",
                    "Confirm Expense Cancellation", MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    foreach (Expense expense in expenseGrid.SelectedItems)
                    {
                        //Expense expense = (Expense)row.DataBoundItem;
                        _upc.CancelExpense(expense);
                    }

                    statusLabel.Content =
                        (expenseGrid.SelectedItems.Count <= 1 ? "Expense" : "Expenses") +
                    " cancelled.";
                    cancel.IsEnabled = false;
                }
                catch (FaultException faultEx)
                {
                    MessageBox.Show(faultEx.Message, "Error Cancelling Expense", MessageBoxButton.OK,
                         MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Cancelling Expense", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                }

                LoadExpenses();

            }
        }

        private void SetButtonStatus(bool status)
        {
            history.IsEnabled = status;
            log.IsEnabled = status;
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void CloseCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            SubmitExpense();
        }

        private void category_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            category.ItemsSource = Enum.GetNames(typeof(ExpenseCategory)).ToList();
            category.SelectedIndex = 0;
        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            LoadExpenses();
            statusLabel.Content = string.Empty;
        }

        private void expenseGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetButtonStatus((expenseGrid.SelectedItems.Count > 0));

            // Enable cancel button for non-approved expenses.
            foreach (Expense expense in expenseGrid.SelectedItems)
            {
                //Expense expense = (Expense)row.DataBoundItem;
                if (expense.IsCompleted == false)
                {
                    cancel.IsEnabled = true;
                    return;
                }
            }

            cancel.IsEnabled = false;
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            CancelExpense();
        }

        private void log_Click(object sender, RoutedEventArgs e)
        {
            if (expenseGrid.SelectedItems.Count > 0)
            {
                // Only pick first item.
                Expense expense = expenseGrid.SelectedItems[0] as Expense;

                LogWindow logWindow = new LogWindow(_upc, expense.ExpenseID);
                logWindow.ShowDialog();
            }

            statusLabel.Content = string.Empty;
        }

        private void history_Click(object sender, RoutedEventArgs e)
        {
            if (expenseGrid.SelectedItems.Count > 0)
            {
                // Only pick first item.
                Expense expense = expenseGrid.SelectedItems[0] as Expense;

                HistoryWindow historyWindow = new HistoryWindow(_upc, expense.ExpenseID);
                historyWindow.ShowDialog();
            }

            statusLabel.Content = string.Empty;
        }
    }
}
