using System;
using static System.Console;
namespace ATMConsoleApplication
{
    public class Printing
    {
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

        public static void AtmSelection(User user)
        {
            ConsoleColor previousColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Green;
            WriteLine();
            WriteLine($"> Logged in as {user.FirstName}, {user.LastName} <");
            WriteLine();
            ForegroundColor = previousColor;
            Console.WriteLine("\n> Please select one of the following options...");
            Console.WriteLine("\t\n1. Deposit");
            Console.WriteLine("\t\n2. Withdraw");
            Console.WriteLine("\t\n3. Show Balance");
            Console.WriteLine("\t\n4. Exit");
        }

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

        public static void InvalidPinNumber()
        {
            ConsoleColor previousColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Red;
            WriteLine("\n> Warning Invalid Pin Number: ");
            ForegroundColor = previousColor;
            Write("\n> Press Enter to Continue. ");
            ReadKey();
        }

        public static void NoMoreAttemptsLeft()
        {
            Clear();
            Loading();
            ConsoleColor previousColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Red;
            Thread.Sleep(1800);
            Clear();
            WriteLine("**************************************************");
            WriteLine("******************** WARNING *********************");
            WriteLine("**** YOU HAVE BEEN LOCKED OUT OF YOUR ACCOUNT **** ");
            WriteLine("** PLEASE CONTACT YOUR BANK MANAGER TO CONTINUE ** ");
            WriteLine("**************************************************");
            ForegroundColor = previousColor;
            ReadKey();


        }

        public static void Loading()
        {
            ConsoleColor previousColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Green;
            WriteLine("\n> Loading Please Wait... ");
            ForegroundColor = previousColor;
            Thread.Sleep(1800);
        }

        public static void InvalidSelection()
        {
            Title();
            ConsoleColor previousColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Red;
            WriteLine("\n> Plesase Enter a Valid Selection! ");
            ForegroundColor = previousColor;
            Write("\n> Press Enter to Continue. ");
            ReadKey();
        }
    }
}

