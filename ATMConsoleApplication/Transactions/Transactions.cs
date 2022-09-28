//using System;
//using ATMConsoleApplication.Accounts;
//using static System.Console;
//namespace ATMConsoleApplication
//{
//    public class Transactions
//    {
//        // Deposit //
//        public static decimal Deposit(CheckingAccount checking, decimal amount)
//        {
//            var newAmount = checking.GetAccountPin() + amount;
//            return checking.SetNewBalance(newAmount); 
//        }

//        // Withdrawl //
//        public static decimal Withdrawl(CheckingAccount checking, decimal amount)
//        {
//            if (user.GetUserBalance() < amount)
//            {
//                Printing.Title();
//                Printing.InsufficientFunds();
//                ATM.AtmUserWithdraw(user);
//            }

//            else
//            {
//                var answer = user.GetUserBalance() - amount;
//                return user.SetNewBalance(answer);
//            }
//            return 0;
//        }


//    }
//}

