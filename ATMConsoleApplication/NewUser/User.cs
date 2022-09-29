using System;
using static System.Console;
using ATMConsoleApplication.Accounts;

namespace ATMConsoleApplication
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private List<Account> Accounts = new List<Account>();


        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

        }

        public CheckingAccount GetChecking(User user, CheckingAccount checking)
        {
            foreach (var accounts in user.Accounts)
            {
                if (accounts is CheckingAccount myChecking)
                {
                    return myChecking;
                }
            }
            return checking;

        }

        public SavingsAccount GetSavings(User user, SavingsAccount savings)
        {
            foreach (var accounts in user.Accounts)
            {
                if (accounts is SavingsAccount mySavings)
                {
                    return mySavings;
                }
            }
            return savings;
        }

        public void AddNewAccountToList(Account account)
        {
            Accounts.Add(account);
        }

    }
}

