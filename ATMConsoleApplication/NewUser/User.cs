using System;
using ATMConsoleApplication.Accounts;

namespace ATMConsoleApplication
{
    public class User
    {
        private int _accountNumber;
        private decimal _balance;
        private int _pin;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Account> Accounts;

        public User(string firstName, string lastName, decimal amount, int pin)
        {
            Random rnd = new Random();
            new List<Account>();
            _accountNumber = rnd.Next(10000000, 1000000000);
            _balance = amount;
            _pin = pin;

            FirstName = firstName;
            LastName = lastName;

        }

        public Account GetChecking(User user)
        {
            foreach (var accounts in user.Accounts)
            {
                if (accounts is CheckingAccount myChecking)
                {
                    return myChecking;
                }
            }
            //  return GetChecking(user); 

        }

        public decimal SetNewBalance(decimal value)
        {
            return _balance = value;
        }

        public decimal GetUserBalance()
        {
            return _balance;
        }

        public int GetUserCardNum()
        {
            return _accountNumber;
        }

        public int GetUserPin()
        {
            return _pin;
        }

        public void AddNewAccouuntToList(Account account)
        {
            Accounts.Add(account);
        }

    }
}

