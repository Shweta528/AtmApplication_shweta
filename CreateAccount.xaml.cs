using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AtmApplication_shweta
{
  
    /// Interaction logic for CreateAccount.xaml
  

        public partial class CreateAccount : UserControl
        {
            private AtmApplication atmApp;

            public CreateAccount()
            {
                InitializeComponent();
            }

            // Pass the AtmApplication instance to this control
            public void SetAtmApplication(AtmApplication atmApp)
            {
                this.atmApp = atmApp;
            }

            private void Submit_Click(object sender, RoutedEventArgs e)
            {
                // Clear previous error message
                ErrorMessageTextBlock.Visibility = Visibility.Collapsed;
                ErrorMessageTextBlock.Text = string.Empty;

                // Validate inputs
                if (int.TryParse(AccountNumberTextBox.Text, out int accountNumber) &&
                    decimal.TryParse(InitialBalanceTextBox.Text, out decimal initialBalance) &&
                    double.TryParse(InterestRateTextBox.Text, out double interestRate) &&
                    !string.IsNullOrWhiteSpace(AccountHolderNameTextBox.Text))
                {
                    if (initialBalance < 0 || interestRate < 0)
                    {
                        ErrorMessageTextBlock.Text = "Initial balance and interest rate must be non-negative.";
                        ErrorMessageTextBlock.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        // Create and add the new account to the bank
                        if (atmApp != null)
                        {
                            atmApp.CreateAccount(accountNumber, initialBalance, interestRate, AccountHolderNameTextBox.Text);
                            MessageBox.Show("Account created successfully!");
                            ClearFields();
                            this.Visibility = Visibility.Collapsed;
                        }
                        else
                        {
                            MessageBox.Show("Application instance is not set.");
                        }
                    }
                }
                else
                {
                    ErrorMessageTextBlock.Text = "Please enter valid data for all fields.";
                    ErrorMessageTextBlock.Visibility = Visibility.Visible;
                }
            }

            private void Cancel_Click(object sender, RoutedEventArgs e)
            {
                // Clear fields and hide the control
                ClearFields();
                MessageBox.Show("Account creation canceled.");
                this.Visibility = Visibility.Collapsed;
            }

            private void ClearFields()
            {
                AccountNumberTextBox.Text = string.Empty;
                InitialBalanceTextBox.Text = string.Empty;
                InterestRateTextBox.Text = string.Empty;
                AccountHolderNameTextBox.Text = string.Empty;
            }
        }
    }

