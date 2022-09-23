﻿using System;
using static System.Console;
namespace ATMConsoleApplication
{
    public class ATM
    {
        // Start of the Program //
        public static void Run()
        {

            ForegroundColor = ConsoleColor.White;
            Printing.Title();
            Write("\n> Would You Like to Create a New Account? (Yes/No) ");
            string userResponse = Console.ReadLine().ToLower().Trim();

            switch (userResponse)
            {
                case "yes":
                    GetUserInformation();
                    break;
                case "no":
                    Exit();
                    break;
                default:
                    Error();
                    break;
            }
        }
        // Grabbing User Information //
        public static void GetUserInformation()
        {
            Printing.Title();

            Write("\n> Please Enter Your First Name: ");
            string firstName = ReadLine().ToLower().Trim() ?? "Unknown";
            Write("\n> Please Enter Your Last Name: ");
            string lastName = ReadLine().ToLower().Trim() ?? "Unknown";
            Write("\n> Please Enter Your Starting Balance: ");
            bool parse = decimal.TryParse(ReadLine(), out decimal balance);
            if (!parse)
            {
                Printing.InvalidSelection();
                GetUserInformation();
            }

            bool confirmed = false;
            int pin = 0;
            while (!confirmed)
            {
                Printing.Title();
                Write("\n> Please Create a Secret Pin: ");
                bool parse2 = int.TryParse(ReadLine(), out int num);
                if (!parse2)
                {
                    Printing.InvalidSelection();
                    GetUserInformation();
                }

                ConsoleColor previousColor = ForegroundColor;
                ForegroundColor = ConsoleColor.Green;
                WriteLine($"\n> You entered * {num} *");
                ForegroundColor = previousColor;

                Write("\n> Are you sure you want this as your pin? (Yes/No) ");
                string userResponse = ReadLine().ToLower().Trim();
                if (userResponse == "yes")
                {
                    Printing.Loading();
                    WriteLine("\n> Your Secret Pin is Confirmed. ");
                    Write("\n> Press Enter to Continue: ");
                    pin = num;
                    confirmed = true;
                }
            }
            CreateUser(firstName, lastName, balance, pin);
        }

        // Creating the User Object //
        public static void CreateUser(string firstName, string lastName, decimal balance, int pin)
        {
            Printing.Title();
            BankAccounts bank = new BankAccounts();
            User newUser = new User(firstName, lastName, balance, pin);
            bank.AddNewUserToList(newUser);
            WriteLine("\n> We have automatically generated you an Account Number.");
            Thread.Sleep(1500);
            WriteLine("\n> Please Write this Number Down: ");
            Thread.Sleep(1500);
            ConsoleColor previousColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Green;
            WriteLine($"\n> Authentic Number: * {newUser.GetUserCardNum()} *");
            ForegroundColor = previousColor;
            Thread.Sleep(1500);
            Write("\n> Press Enter to Continue: ");
            ReadKey();
            UserValidation(newUser);
        }
        // Validating the User //
        public static void UserValidation(User user)
        {
            bool confirmed = false;
            int numberOfAttempts = 3;
            Printing.UserValidationText(numberOfAttempts);
            while (!confirmed)
            {
                if (numberOfAttempts > 0)
                {
                    bool parse1 = int.TryParse(ReadLine(), out int userResponse);
                    if (!parse1 || userResponse != user.GetUserPin())
                    {
                        numberOfAttempts--;
                        Printing.InvalidPinNumber();
                        Printing.UserValidationText(numberOfAttempts);
                    }

                    if (userResponse == user.GetUserPin())
                    {
                        confirmed = true;
                        Printing.Loading();
                        Printing.AtmGreeting(user);
                        AtmMenu(user);
                        break;
                    }
                }
                else
                {
                    Printing.NoMoreAttemptsLeft();
                    Exit();

                }
            }

        }

        // ATM Selection Menu //
        public static void AtmMenu(User user)
        {

            Printing.Title();
            Printing.Loading();
            Printing.Title();
            Printing.AtmSelection(user);
            string userSelection = ReadLine().Trim();
            switch (userSelection)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    Exit();
                    break;
                default:
                    Printing.InvalidSelection();
                    AtmMenu(user);
                    break;
            }

        }

        public static void Exit()
        {
            WriteLine("\n> Thank you and Please Come Again!");
            Thread.Sleep(1300);
            Environment.Exit(0);
        }

        public static void Error()
        {
            Printing.InvalidSelection();
            Run();
        }


    }


}




