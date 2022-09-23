using System;
namespace ATMConsoleApplication
{
    public class Transactions
    {
        public static decimal Deposit(User user, decimal amount)
        {
            return user.SetUserBalance(amount);
        }

        public static decimal Withdrawl(User user, decimal amount)
        {
            return 0;
        }


    }
}

