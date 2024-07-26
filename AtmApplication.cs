using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AtmApplication_shweta
{
      
        /// Main logic for interacting with the bank and accounts.
    
        public class AtmApplication
        {
            private readonly Bank bank;

            public AtmApplication()
            {
                bank = new Bank();
            }

          
            /// Creates a new bank account and adds it to the bank.
        
            /// <param name="accountNumber">The account number of the new account.</param>
            /// <param name="initialBalance">The initial balance of the new account.</param>
            /// <param name="interestRate">The annual interest rate of the new account.</param>
            /// <param name="accountHolderName">The name of the account holder.</param>
            public void CreateAccount(int accountNumber, decimal initialBalance, double interestRate, string accountHolderName)
            {
                try
                {
                    if (bank.RetrieveAccount(accountNumber) != null)
                    {
                        throw new InvalidOperationException("Account with this number already exists.");
                    }

                    BankAccount account = new BankAccount(accountNumber, initialBalance, interestRate, accountHolderName);
                    bank.AddAccount(account);
                }
                catch (Exception ex)
                {
                    // Log the exception or notify the user
                    Console.WriteLine($"Error creating account: {ex.Message}");
                }
            }

          
            /// Selects an account based on the account number.
          
            /// <param name="accountNumber">The account number of the account to select.</param>
            public BankAccount SelectAccount(int accountNumber)
            {
                try
                {
                    return bank.RetrieveAccount(accountNumber);
                }
                catch (Exception ex)
                {
                    // Log the exception or notify the user
                    Console.WriteLine($"Error selecting account: {ex.Message}");
                    return null;
                }
            }

        public Bank GetBank()
        {
            return bank;
        }
    }
    }
