using System;
namespace ATMConsoleApplication.Accounts
{
    public abstract class Account
    {
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


        // Deposit //
        public decimal Deposit(Account account, decimal amount)
        {
            var newAmount = account.GetBalance() + amount;
            return account.SetNewBalance(newAmount);
        }

        // Withdrawl //
        public decimal Withdrawl(User user, Account account, decimal amount)
        {
            if (account.GetBalance() < amount)
            {
                Printing.Title();
                Printing.InsufficientFunds();
                // ATM.AtmUserWithdraw(user, account);
            }

            else
            {
                var answer = account.GetBalance() - amount;
                return account.SetNewBalance(answer);
            }
            return 0;
        }

    }
}

