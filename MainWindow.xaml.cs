using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AtmApplication_shweta
{
    
    /// Interaction logic for MainWindow.xaml
   

        public partial class MainWindow : Window
        {
            private AtmApplication atmApp;
            private BankAccount currentAccount;

            public MainWindow()
            {
                InitializeComponent();
                atmApp = new AtmApplication(); 
            CreateAccount.SetAtmApplication(atmApp);
            }

        private void CreateAccountButton_Click(object sender, RoutedEventArgs e)
        {
            // Show the CreateAccountUserControl
            CreateAccount.Visibility = Visibility.Visible;
        }

        private void CreateAccount_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    string input = Microsoft.VisualBasic.Interaction.InputBox("Enter account number, initial balance, annual interest rate, and account holder name, separated by commas:", "Create Account");
                    string[] inputs = input.Split(',');

                    if (inputs.Length == 4 &&
                        int.TryParse(inputs[0].Trim(), out int accountNumber) &&
                        decimal.TryParse(inputs[1].Trim(), out decimal initialBalance) &&
                        double.TryParse(inputs[2].Trim(), out double interestRate))
                    {
                        string accountHolderName = inputs[3].Trim();
                        BankAccount newAccount = new BankAccount(accountNumber, initialBalance, interestRate, accountHolderName);
                        atmApp.GetBank().AddAccount(newAccount);
                        MessageBox.Show("Account created successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please enter valid data.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }

        private void SelectAccountButton_Click(object sender, RoutedEventArgs e)
        {
            // Logic for selecting an account
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter account number to select:", "Select Account");
            if (int.TryParse(input, out int accountNumber))
            {
                currentAccount = atmApp.SelectAccount(accountNumber);
                if (currentAccount != null)
                {
                    MainTabControl.SelectedItem = accountMenuTab;
                }
                else
                {
                    MessageBox.Show("Account not found!");
                }
            }
            else
            {
                MessageBox.Show("Invalid account number.");
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            // Logic for exiting the application
            Application.Current.Shutdown();
        }

        private void CheckBalance_Click(object sender, RoutedEventArgs e)
            {
                if (currentAccount != null)
                {
                    txtResult.Text = $"Current Balance: {currentAccount.Balance:C}";
                }
                else
                {
                    txtResult.Text = "No account selected.";
                }
            }

            private void DepositMoney_Click(object sender, RoutedEventArgs e)
            {
                if (currentAccount != null)
                {
                    try
                    {
                        string input = Microsoft.VisualBasic.Interaction.InputBox("Enter amount to deposit:", "Deposit Money");
                        if (decimal.TryParse(input, out decimal amount))
                        {
                            currentAccount.Deposit(amount);
                            txtResult.Text = $"Deposited {amount:C}. New Balance: {currentAccount.Balance:C}";
                        }
                        else
                        {
                            txtResult.Text = "Invalid deposit amount.";
                        }
                    }
                    catch (Exception ex)
                    {
                        txtResult.Text = $"An error occurred: {ex.Message}";
                    }
                }
                else
                {
                    txtResult.Text = "No account selected.";
                }
            }

            private void WithdrawMoney_Click(object sender, RoutedEventArgs e)
            {
                if (currentAccount != null)
                {
                    try
                    {
                        string input = Microsoft.VisualBasic.Interaction.InputBox("Enter amount to withdraw:", "Withdraw Money");
                        if (decimal.TryParse(input, out decimal amount))
                        {
                            if (currentAccount.Withdraw(amount))
                            {
                                txtResult.Text = $"Withdrew {amount:C}. New Balance: {currentAccount.Balance:C}";
                            }
                            else
                            {
                                txtResult.Text = "Insufficient funds.";
                            }
                        }
                        else
                        {
                            txtResult.Text = "Invalid withdrawal amount.";
                        }
                    }
                    catch (Exception ex)
                    {
                        txtResult.Text = $"An error occurred: {ex.Message}";
                    }
                }
                else
                {
                    txtResult.Text = "No account selected.";
                }
            }

            private void DisplayTransactions_Click(object sender, RoutedEventArgs e)
            {
                if (currentAccount != null)
                {
                    txtResult.Text = "Transaction History:\n" + string.Join("\n", currentAccount.GetTransactions());
                }
                else
                {
                    txtResult.Text = "No account selected.";
                }
            }

        private void ExitAccount_Click(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 0;
            currentAccount = null;
        }
    }
    }

