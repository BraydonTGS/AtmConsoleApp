using System;
using ATMConsoleApplication.Accounts;
using static System.Console;
namespace ATMConsoleApplication
{
    public class Printing
    {
        // Title //
        public static void Title()
        {
            Clear();
            ConsoleColor previousColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Green;
            WriteLine("=================================");
            WriteLine("=================================");
            WriteLine("==== Welcome to No Money ATM ====");
            WriteLine("=================================");
            WriteLine("=================================");
            ForegroundColor = previousColor;

        }

        // Logged In //
        public static void LoggedIn(User user)
        {
            ConsoleColor previousColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Green;
            WriteLine();
            WriteLine($"> Logged in as {user.FirstName}, {user.LastName} <");
            ForegroundColor = previousColor;
        }

        // Atm Selection //
        public static void AtmSelection()
        {
            WriteLine("\n> Please select one of the following options...");
            WriteLine("\t\n1. Deposit");
            WriteLine("\t\n2. Withdraw");
            WriteLine("\t\n3. Show Balance");
            WriteLine("\n4. Transfer to Savings Account");
            WriteLine("\t\n5. Exit");
        }

        // Atm Greeting //
        public static void AtmGreeting(User user)
        {
            Title();
            ConsoleColor previousColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Green;
            WriteLine($"\n> Welcome {user.FirstName}, {user.LastName}. ");
            Write("\n> Press Enter to Continue ");
            ForegroundColor = previousColor;
            ReadKey();
            Clear();
        }

        // User Validation //
        public static void UserValidationText(int attempts)
        {
            Printing.Title();
            ConsoleColor previousColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Red;
            WriteLine("\n> Security Check < ");
            if (attempts > 1)
            {
                ForegroundColor = previousColor;
                ForegroundColor = ConsoleColor.Green;
                WriteLine($"\n> Number of Attempts: {attempts}");
            }
            else
            {
                ForegroundColor = previousColor;
                ForegroundColor = ConsoleColor.Red;
                WriteLine($"\n> Number of Attempts: {attempts}");
            }

            ForegroundColor = previousColor;
            Write("\n> Please Confirm Your Pin Before Continuing: ");


        }

        // Invalid Pin //
        public static void InvalidPinNumber()
        {
            ConsoleColor previousColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Red;
            WriteLine("\n> Warning Invalid Pin Number: ");
            ForegroundColor = previousColor;
            Write("\n> Press Enter to Continue. ");
            ReadKey();
        }

        // Out of Attempts //
        public static void NoMoreAttemptsLeft()
        {
            Clear();
            Loading();
            ConsoleColor previousColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Red;
            Thread.Sleep(3000);
            Clear();
            WriteLine("**************************************************");
            WriteLine("**************************************************");
            WriteLine("******************** WARNING *********************");
            WriteLine("**** YOU HAVE BEEN LOCKED OUT OF YOUR ACCOUNT **** ");
            WriteLine("** PLEASE CONTACT YOUR BANK MANAGER TO CONTINUE ** ");
            WriteLine("**************************************************");
            WriteLine("**************************************************");
            ForegroundColor = previousColor;
            Thread.Sleep(1800);
        }

        // Thank User //
        public static void ThankUser(User user)
        {
            ConsoleColor previousColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Green;
            WriteLine($"\n> Thank you {user.FirstName}");
            ForegroundColor = previousColor;
        }

        // Insufficient Funds //
        public static void InsufficientFunds()
        {
            ConsoleColor previousColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Red;
            WriteLine("\n> You have Insufficient Funds. ");
            WriteLine("\n> Please Select a new ammount. ");
            Write("\n> Press Enter to Continue: ");
            ReadKey();
            ForegroundColor = previousColor;
        }

        // Print Current Balance //
        public static void PrintCurrentBalance(Account myAccount)
        {
            ConsoleColor previousColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Green;
            WriteLine($"\n> Your Current Balance is {myAccount.GetBalance():C2}");
            WriteLine($"\n> Press Enter to Continue ");
            ReadKey();
            ForegroundColor = previousColor;

        }

        // Balance After Transaction //
        public static void PrintBalanceAfterTransaction(Account myAccount)
        {
            ConsoleColor previousColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Green;
            WriteLine($"\n> {myAccount.Name}");
            WriteLine($"\n> Your new Balance is {myAccount.GetBalance():C2}");
            ForegroundColor = previousColor;
            Write("\n> Press Enter to Continue: ");
            ReadKey();
        }

        // Loading //
        public static void Loading()
        {
            ConsoleColor previousColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Green;
            WriteLine("\n> Loading Please Wait... ... ...  ");
            ForegroundColor = previousColor;
            Thread.Sleep(1800);
        }

        // Invalid Selection //
        public static void InvalidSelection()
        {
            Title();
            ConsoleColor previousColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Red;
            WriteLine("\n> Plesase Enter a Valid Selection! ");
            ForegroundColor = previousColor;
            Write("\n> Press Enter to Continue: ");
            ReadKey();
        }
    }
}

