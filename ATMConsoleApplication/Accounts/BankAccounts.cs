using System;
namespace ATMConsoleApplication
{
    public class BankAccounts
    {
        private List<User> _newUsers;

        public BankAccounts()
        {
            _newUsers = new List<User>();
        }

        public void AddNewUserToList(User newUser)
        {
            _newUsers.Add(newUser);
        }
    }
}

