using System;
namespace ATMConsoleApplication
{
    public class Transactions
    {
        public decimal Deposit(User user, decimal amount) => user.GetUserBalance() + amount;

        public decimal Withdrawl(User user, decimal amount)
        {
            return 0;
        }


    }
}

