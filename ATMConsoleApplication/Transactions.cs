using System;
using static System.Console;
namespace ATMConsoleApplication
{
    public class Transactions
    {
        public static decimal Deposit(User user, decimal amount)
        {
            var newAmount = user.GetUserBalance() + amount;
            return user.SetNewBalance(newAmount);
        }

        public static decimal Withdrawl(User user, decimal amount)
        {
            if (user.GetUserBalance() < amount)
            {
                Printing.Title();
                Printing.InsufficientFunds();
                ATM.AtmUserWithdraw(user);
            }

            else
            {
                var answer = user.GetUserBalance() - amount;
                return user.SetNewBalance(answer);
            }
            return 0;
        }


    }
}

