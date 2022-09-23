﻿using System;
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
        private List<Account> Accounts { get; set; } = new List<Account>();

        public User(string firstName, string lastName, decimal amount, int pin)
        {
            Random rnd = new Random();

            _accountNumber = rnd.Next(10000000, 1000000000);
            _balance = amount;
            _pin = pin;

            FirstName = firstName;
            LastName = lastName;

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

    }
}
