using System;
namespace ATMConsoleApplication.Accounts
{
    public class SavingsAccount : Account
    {
        private int _accountNumber { get; set; }

        public SavingsAccount()
        {

        }

        public SavingsAccount(decimal balance, int pin) : base(balance, pin)
        {
            Random rnd = new Random();
            _accountNumber = rnd.Next(10000000, 1000000000);
        }

        public int GetAccountNumber()
        {
            return _accountNumber;
        }
    }
}

