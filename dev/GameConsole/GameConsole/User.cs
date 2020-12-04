using System;
using System.Collections.Generic;

namespace GameConsole
{
    public class User
    {
        public string Username { get; set; }
        private string _password;
        private int _age;
        private Theme _theme;

        private static string _filePath = "../../../users.txt";
        private static List<User> _availableUsers;

       
        public User(string username, string password, int age, string theme)
        {
            Username = username;
            _password = password;
            _age = age;
            _theme = UI.FindTheme(theme);
        }

        public static User LogIn()
        {
            _availableUsers = FileIO.LoadUsers(_filePath);
            User returnUser = null;
            bool loggedIn = false;
            while(!loggedIn)
            {
                string question = "[Username]: ";
                string username = Validation.GetValidatedString(question);
                question = "[Passowrd]: ";
                string password = Validation.GetValidatedString(question);
                for(int i = 0; i < _availableUsers.Count; i++)
                {
                    loggedIn = _availableUsers[i].CheckUserPassword(username, password);
                    if(loggedIn)
                    {
                        returnUser = _availableUsers[i];
                    }
                }
            }
            UI.SetTheme(returnUser._theme);
            UI.DisplaySuccess("Login Successful!");
            UI.Continue();
            return returnUser;
        }
        private bool CheckUserPassword(string username, string password)
        {
            if(username == Username && password == _password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Display user profile
        public string[] GetSaveData()
        {
            string[] saveData = { Username, _password, _age.ToString(), _theme.Name};
            return saveData;
        }

        public void DisplayUserProfile()
        {

        }

        public static void CreateUser()
        {
            bool keepGoing = true;
            while(keepGoing)
            {
                string question = "What would you like your username to be?... ";
                string username = Validation.GetValidatedString(question);
                question = $"What should {username}'s password be?... ";
                string password = Validation.GetValidatedString(question);
                question = $"How old is {username}?... ";
                int[] ageRange = { 0, 200 };
                int age = Validation.GetValidatedRange(question, ageRange);
                string[] conditionals = { "light", "dark" };
                question = $"Would you like the light or dark theme? Please type in your preference [{conditionals[0]}, {conditionals[1]}]... ";
                string theme = Validation.GetValidatedConditional(question, conditionals);
                User newUser = new User(username, password, age, theme);
                _availableUsers.Add(newUser);
                FileIO.SaveEmployees(_filePath, _availableUsers);
                UI.DisplaySuccess($"{username} Created!!!");
                question = "would you like to create another user? [y,n]... ";
                conditionals = new string[] { "y", "n" };
                string response = Validation.GetValidatedConditional(question, conditionals);
                if(response == "n")
                {
                    keepGoing = false;
                }
            }
        }

        public void ChangeUsername()
        {
            //Display Current Username
            //Prompt new username
            //Yes or no confirmation
        }

        public void ChangePassword()
        {
            //Prompt for current password
            //Prompt for new password
            //Yes or no confirmation
        }

        public void ChangeTheme()
        {
            
        }

    }//end of class
}
