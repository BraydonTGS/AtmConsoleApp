using System;
using System.Net.NetworkInformation;
using System.Security.Principal;
using ATMConsoleApplication.Accounts;
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
            string firstName = ReadLine().Trim() ?? "Unknown";
            Write("\n> Please Enter Your Last Name: ");
            string lastName = ReadLine().Trim() ?? "Unknown";
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
            var newUser = new User(firstName, lastName);
            CheckingAccount checking = new CheckingAccount(balance, pin);
            SavingsAccount savings = new SavingsAccount(0.0m);
            bank.AddNewUserToList(newUser);
            newUser.AddNewAccountToList(checking);
            newUser.AddNewAccountToList(savings);
            var userChecking = newUser.GetChecking(newUser);
            var userSavings = newUser.GetSavings(newUser);
            WriteLine("\n> We have automatically generated you a Checking & Savings Account.");
            Thread.Sleep(1500);
            WriteLine("\n> Please Write this Number Down: ");
            Thread.Sleep(1500);
            ConsoleColor previousColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Green;
            WriteLine($"\n> Authentic Number: * {userChecking.GetAccountNumber()} *");
            ForegroundColor = previousColor;
            Thread.Sleep(1500);
            Write("\n> Press Enter to Continue: ");
            ReadKey();
            UserValidation(newUser, userChecking, userSavings);
        }

        // Validating the User //
        public static void UserValidation(User user, Account checking, Account savings)
        {
            bool confirmed = false;
            int numberOfAttempts = 3;
            Printing.UserValidationText(numberOfAttempts);
            while (!confirmed)
            {
                if (numberOfAttempts > 0)
                {
                    bool parse1 = int.TryParse(ReadLine(), out int userResponse);
                    if (!parse1 || userResponse != checking.GetAccountPin())
                    {
                        numberOfAttempts--;
                        Printing.InvalidPinNumber();
                        Printing.UserValidationText(numberOfAttempts);
                    }

                    if (userResponse == checking.GetAccountPin())
                    {
                        confirmed = true;
                        Printing.Loading();
                        Printing.AtmGreeting(user);
                        AtmMenu(user, checking, savings);
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
        public static void AtmMenu(User user, Account checking, Account savings)
        {
            Printing.Title();
            Printing.Loading();
            Printing.Title();
            Printing.LoggedIn(user);
            Printing.AtmSelection();
            string userSelection = ReadLine().Trim();
            switch (userSelection)
            {
                case "1":
                    AtmUserDeposit(user, checking, savings);
                    break;
                case "2":
                    AtmUserWithdraw(user, checking, savings);
                    break;
                case "3":
                    AtmUserBalance(user, checking, savings);
                    break;
                case "4":
                    AtmSavingsAccount(user, checking, savings);
                    break;
                case "5":
                    Exit();
                    break;
                default:
                    Printing.InvalidSelection();
                    AtmMenu(user, checking, savings);
                    break;
            }

        }

        // ATM Deposit //
        public static void AtmUserDeposit(User user, Account myChecking, Account savings)
        {
            Printing.Title();
            Printing.Loading();
            Printing.Title();
            Printing.LoggedIn(user);
            decimal deposit = 0;
            bool confirmed = false;
            while (!confirmed)
            {
                WriteLine($"\n> Your Current Balance is {myChecking.GetBalance():C2}");
                Write("\n> How much would you like to deposit: ");
                bool parse = decimal.TryParse(Console.ReadLine(), out decimal num);
                if (!parse)
                {
                    Printing.InvalidSelection();
                    myChecking.Deposit(myChecking, num);
                }
                ConsoleColor previousColor = ForegroundColor;
                ForegroundColor = ConsoleColor.Green;
                WriteLine($"\n> You entered * {num:C2} *");
                ForegroundColor = previousColor;

                Write("\n> Are you sure you want to procede (Yes/No) ");
                string userResponse = ReadLine().ToLower().Trim();
                if (userResponse == "yes")
                {
                    Printing.Loading();
                    WriteLine("\n> Please Wait While we Confirm the Transaction.");
                    Write("\n> Press Enter to Continue: ");
                    deposit = num;
                    confirmed = true;
                }
                else if (userResponse == "no")
                {
                    Printing.Loading();
                    WriteLine("\n> Transaction Canceled. Returing to Main Menu. ");
                    AtmMenu(user, myChecking, savings);
                }
                else
                {
                    Printing.Loading();
                    Printing.Title();
                    Printing.InvalidSelection();
                    AtmUserDeposit(user, myChecking, savings);
                }
            }
            myChecking.Deposit(myChecking, deposit);
            Printing.Title();
            WriteLine($"\n> Thank you {user.FirstName}");
            Printing.PrintBalanceAfterTransaction(myChecking);
            AtmMenu(user, myChecking, savings);
        }

        // ATM Withdraw //
        public static void AtmUserWithdraw(User user, Account checking, Account savings)
        {
            Printing.Title();
            Printing.Loading();
            Printing.Title();
            Printing.LoggedIn(user);
            decimal withdrawl = 0;
            bool confirmed = false;
            while (!confirmed)
            {
                WriteLine($"\n> Your Current Balance is {checking.GetBalance():C2}");
                Write("\n> How much would you like to withdrawl: ");
                bool parse = decimal.TryParse(ReadLine(), out decimal num);
                if (!parse)
                {
                    Printing.InvalidSelection();
                    checking.Withdrawl(user, checking, savings, num);
                }
                ConsoleColor previousColor = ForegroundColor;
                ForegroundColor = ConsoleColor.Green;
                WriteLine($"\n> You entered * {num:C2} *");
                ForegroundColor = previousColor;

                Write("\n> Are you sure you want to procede? (Yes/No) ");
                string userResponse = ReadLine().ToLower().Trim();
                if (userResponse == "yes")
                {
                    Printing.Loading();
                    WriteLine("\n> Please Wait While we Confirm the Transaction.");
                    Write("\n> Press Enter to Continue: ");
                    withdrawl = num;
                    confirmed = true;
                }
                else if (userResponse == "no")
                {
                    Printing.Loading();
                    WriteLine("\n> Transaction Canceled. Returing to Main Menu. ");
                    AtmMenu(user, checking, savings);
                }
                else
                {
                    Printing.Loading();
                    Printing.Title();
                    Printing.InvalidSelection();
                    AtmUserWithdraw(user, checking, savings);
                }
            }
            checking.Withdrawl(user, checking, savings, withdrawl);
            Printing.Title();
            WriteLine($"\n> Thank you {user.FirstName}");
            Printing.PrintBalanceAfterTransaction(checking);
            AtmMenu(user, checking, savings);
        }

        // ATM Balance //
        public static void AtmUserBalance(User user, Account checking, Account savings)
        {
            Printing.Title();
            Printing.Loading();
            Printing.Title();
            Printing.LoggedIn(user);
            Printing.PrintCurrentBalance(checking);
            AtmMenu(user, checking, savings);
        }

        // ATM Open Savings Account //
        public static void AtmSavingsAccount(User user, Account checking, Account savings)
        {
            Printing.Title();
            Printing.Loading();
            Printing.Title();
            Printing.LoggedIn(user);
            decimal withdrawl = 0;
            bool confirmed = false;
            while (!confirmed)
            {
                WriteLine($"\n> Your Current Checking Account Balance is {checking.GetBalance():C2}");
                WriteLine($"\n> Your Current Savings Account Balance is {savings.GetBalance():C2}");
                Write("\n> How much would you like to transfer: ");
                bool parse = decimal.TryParse(ReadLine(), out decimal num);
                if (!parse)
                {
                    Printing.InvalidSelection();
                    savings.Transfer(user, checking, savings, num);
                }
                ConsoleColor previousColor = ForegroundColor;
                ForegroundColor = ConsoleColor.Green;
                WriteLine($"\n> You entered * {num:C2} *");
                ForegroundColor = previousColor;

                Write("\n> Are you sure you want to procede? (Yes/No) ");
                string userResponse = ReadLine().ToLower().Trim();
                if (userResponse == "yes")
                {
                    Printing.Loading();
                    WriteLine("\n> Please Wait While we Confirm the Transfer.");
                    Write("\n> Press Enter to Continue: ");
                    withdrawl = num;
                    confirmed = true;
                }
                else if (userResponse == "no")
                {
                    Printing.Loading();
                    WriteLine("\n> Transaction Canceled. Returing to Main Menu. ");
                    AtmMenu(user, checking, savings);
                }
                else
                {
                    Printing.Loading();
                    Printing.Title();
                    Printing.InvalidSelection();
                    AtmSavingsAccount(user, checking, savings);
                }
            }
            savings.Transfer(user, checking, savings, withdrawl);
            Printing.Title();
            WriteLine($"\n> Thank you {user.FirstName}");
            Printing.PrintBalanceAfterTransaction(savings);
            AtmMenu(user, checking, savings);
        }

        public static void Exit()
        {
            Printing.Loading();
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




