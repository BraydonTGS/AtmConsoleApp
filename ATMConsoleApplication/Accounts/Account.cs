using System;
using System.Security.Principal;

namespace ATMConsoleApplication.Accounts
{
    public abstract class Account
    {
        public string Name { get; set; }
        private decimal _balance { get; set; }
        protected int _pin { get; set; }


        public Account()
        {

        }

        public Account(decimal balance, int pin)
        {
            _balance = balance;
            _pin = pin;
        }


        public decimal GetBalance() => _balance;

        public decimal SetNewBalance(decimal value)
        {
            return _balance = value;
        }

        public int GetAccountPin()
        {
            return _pin;
        }

        public decimal Deposit(Account account, decimal amount)
        {
            var newAmount = account.GetBalance() + amount;
            return account.SetNewBalance(newAmount);
        }

        public decimal Transfer(User user, Account checking, Account savings, decimal amount)
        {
            if (checking.GetBalance() < amount)
            {
                Printing.Title();
                Printing.InsufficientFunds();
                ATM.AtmUserWithdraw(user, checking, savings);
            }

            else
            {
                var answer = checking.GetBalance() - amount;
                checking.SetNewBalance(answer);
                return savings.Deposit(savings, amount);
            }
            return 0;
        }

        public decimal Withdrawl(User user, Account checking, Account savings, decimal amount)
        {
            if (checking.GetBalance() < amount)
            {
                Printing.Title();
                Printing.InsufficientFunds();
                ATM.AtmUserWithdraw(user, checking, savings);
            }

            else
            {
                var answer = checking.GetBalance() - amount;
                return checking.SetNewBalance(answer);
            }
            return 0;
        }

    }
}

