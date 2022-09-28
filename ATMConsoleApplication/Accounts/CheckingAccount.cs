using System;
namespace ATMConsoleApplication.Accounts
{
    public class CheckingAccount : Account
    {
        public CheckingAccount(decimal balance, string accountNumber, int pin) : base(balance, accountNumber, pin)
        {
        }
    }
}

