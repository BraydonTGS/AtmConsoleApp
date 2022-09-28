using System;
namespace ATMConsoleApplication.Accounts
{
    public class CheckingAccount : Account
    {
        private int _accountNumber { get; set; }

        public CheckingAccount()
        {

        }

        public CheckingAccount(decimal balance, int pin) : base(balance, pin)
        {
            Random rnd = new Random();
            _accountNumber = rnd.Next(10000000, 1000000000);
        }

        public int GetAccountNumber()
        {
            return _accountNumber;
        }

        public int GetAccountPin()
        {
            return _pin;
        }

        // Deposit //
        public decimal Deposit(CheckingAccount checking, decimal amount)
        {
            var newAmount = checking.GetBalance() + amount;
            return checking.SetNewBalance(newAmount);
        }

        // Withdrawl //
        public decimal Withdrawl(User user, CheckingAccount checking, decimal amount)
        {
            if (checking.GetBalance() < amount)
            {
                Printing.Title();
                Printing.InsufficientFunds();
                ATM.AtmUserWithdraw(user, checking);
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

