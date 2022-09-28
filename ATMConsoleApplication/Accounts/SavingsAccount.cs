using System;
namespace ATMConsoleApplication.Accounts
{
    public class SavingsAccount : Account
    {
        private int _accountNumber { get; set; }

        public SavingsAccount()
        {

        }

        public SavingsAccount(decimal startingBalance)
        {
            Random rnd = new Random();
            _accountNumber = rnd.Next(10000000, 1000000000);
            Name = "Savings Account";
            SetNewBalance(startingBalance);
        }


        public int GetAccountNumber()
        {
            return _accountNumber;
        }
    }
}

