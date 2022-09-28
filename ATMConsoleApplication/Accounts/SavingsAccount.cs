using System;
namespace ATMConsoleApplication.Accounts
{
    public class SavingsAccount : Account
    {
        public int _accountNumber { get; set; }

        public SavingsAccount(decimal balance, int pin) : base(balance, pin)
        {
            Random rnd = new Random();
            _accountNumber = rnd.Next(10000000, 1000000000);
        }
    }
}

