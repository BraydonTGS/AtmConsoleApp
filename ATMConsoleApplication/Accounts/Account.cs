using System;
namespace ATMConsoleApplication.Accounts
{
    public abstract class Account
    {
        public decimal _balance { get; private set; }
        public int _pin { get; set; }

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


    }
}

