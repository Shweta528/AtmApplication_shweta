using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmApplication_shweta
{
   
        public class Bank
        {
            private readonly List<BankAccount> accounts;

            public Bank()
            {
                accounts = new List<BankAccount>();
                // Create 10 default accounts with account numbers 100 to 109
                for (int i = 100; i < 110; i++)
                {
                    accounts.Add(new BankAccount(i, 100m, 3.0, $"Holder {i}"));
                }
            }

            
            /// Adds a new bank account to the collection.
            
            /// <param name="account">The bank account to be added.</param>
            public void AddAccount(BankAccount account)
            {
                if (accounts.Any(a => a.AccountNumber == account.AccountNumber))
                {
                    throw new InvalidOperationException("An account with this number already exists.");
                }

                accounts.Add(account);
            }

          
            /// Retrieves a bank account based on the account number.
            
            /// <param name="accountNumber">The account number of the account to retrieve.</param>
          
            public BankAccount RetrieveAccount(int accountNumber)
            {
                return accounts.FirstOrDefault(account => account.AccountNumber == accountNumber);
            }
        }
    }

