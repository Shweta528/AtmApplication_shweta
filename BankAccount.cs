using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmApplication_shweta
{
    
    /// Represents a bank account with basic functionalities.
  
  
        public class BankAccount
        {
            public int AccountNumber { get; private set; }
            public decimal Balance { get; private set; }
            public double InterestRate { get; private set; }
            public string AccountHolderName { get; private set; }

            private List<string> Transactions { get; set; }

            
            /// Initializes a new instance of the BankAccount class.
            
            /// <param name="accountNumber">The account number.</param>
            /// <param name="initialBalance">The initial balance.</param>
            /// <param name="interestRate">The annual interest rate.</param>
            /// <param name="accountHolderName">The name of the account holder.
            public BankAccount(int accountNumber, decimal initialBalance, double interestRate, string accountHolderName)
            {
                AccountNumber = accountNumber;
                Balance = initialBalance;
                InterestRate = interestRate;
                AccountHolderName = accountHolderName;
                Transactions = new List<string> { $"Account created with balance {initialBalance:C}" };
            }

           
            /// Deposits a specified amount into the account.
           
            /// <param name="amount">The amount to deposit.</param>
            public void Deposit(decimal amount)
            {
                if (amount <= 0)
                {
                    throw new ArgumentException("Deposit amount must be positive.", nameof(amount));
                }

                Balance += amount;
                Transactions.Add($"Deposit: +{amount:C}");
            }

            /// Withdraws a specified amount from the account.
             
            /// <param name="amount">The amount to withdraw.</param>
            
            public bool Withdraw(decimal amount)
            {
                if (amount <= 0)
                {
                    throw new ArgumentException("Withdrawal amount must be positive.", nameof(amount));
                }

                if (amount <= Balance)
                {
                    Balance -= amount;
                    Transactions.Add($"Withdrew: {amount:C}");
                    return true;
                }
                else
                {
                    throw new InvalidOperationException("Insufficient funds.");
                }
            }

           
            /// Gets the transaction history of the account.
         
            public List<string> GetTransactions()
            {
                return new List<string>(Transactions); // Return a copy to prevent external modification
            }

           
            /// Calculates the interest based on the current balance and interest rate.
           
            public decimal CalculateInterest()
            {
                return Balance * (decimal)(InterestRate / 100);
            }
        }
    }

