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

        public CheckingAccount GetChecking(User user)
        {
            foreach (var accounts in user.Accounts)
            {
                if (accounts is CheckingAccount myChecking)
                {
                    return myChecking;
                }
                else
                {
                    WriteLine("> Account Not Found, Something Went Wrong. ");
                    ReadKey();
                    break;
                }
            }
            return GetChecking(user);

        }

        public void AddNewCheckingtToList(CheckingAccount account)
        {
            Accounts.Add(account);
        }

        public void AddNewAccountToList(Account account)
        {
            Accounts.Add(account);
        }

    }
}

