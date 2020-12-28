using System;
using System.Collections.Generic;

namespace GameConsole
{
    public class User
    {
        private string _username;
        public string Username { get { return _username; } }
        private string _password;
        private int _age;
        private Theme _theme;
        private int _userScore;
        

        private static string _filePath = "../../../users.txt";
        private static List<User> _availableUsers;

       
        public User(string username, string password, int age, string theme, int userScore)
        {
            _username = username;
            _password = password;
            _age = age;
            _theme = UI.FindTheme(theme);
            _userScore = userScore;
        }

        public static User LogIn()
        {
            _availableUsers = FileIO.LoadUsers(_filePath);
            User returnUser = null;
            bool loggedIn = false;
            while(!loggedIn)
            {
                UI.DisplayTitle("Log In");
                string question = "[Username]: ";
                string username = Validation.GetValidatedString(question);
                question = "[Password]: ";
                string password = Validation.GetValidatedString(question);
                bool successful = false;
                for(int i = 0; i < _availableUsers.Count; i++)
                {
                    loggedIn = _availableUsers[i].CheckUserPassword(username, password);
                    if(loggedIn)
                    {
                        returnUser = _availableUsers[i];
                        successful = true;
                        break;
                    }
                }
                if(!successful)
                
                {
                    UI.DisplayError("Login Failed :( Please try again...");
                    UI.Continue();
                }
            }
            UI.DisplaySuccess("\r\nLogin Successful!");
            UI.Continue();
            UI.SetTheme(returnUser._theme);
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
            string[] saveData = { Username, _password, _age.ToString(), _theme.Name, _userScore.ToString()};
            return saveData;
        }

        public void DisplayUserProfile()
        {
            UI.ComingSoon(true);
        }

        public static void CreateUser()
        {
            bool keepGoing = true;
            while(keepGoing)
            {
                UI.DisplayTitle("Create User");
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
                User newUser = new User(username, password, age, theme, 0);
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
            UI.DisplayTitle("Change Username");
            string question = "Please enter your new username... ";
            string username = Validation.GetValidatedString(question);
            _username = username;
            for (int i = 0; i < _availableUsers.Count; i++)
            {
                if (_availableUsers[i].Username == _username)
                {
                    _availableUsers[i]._username = username;
                }
            }
            FileIO.SaveEmployees(_filePath, _availableUsers);
            UI.DisplaySuccess($"Username Changed to {Username}!!");
            UI.Continue();
        }

        public void ChangePassword()
        {
            UI.DisplayTitle("Change Password");
            string question = "Please enter any combination of letters and numbers as a new password... ";
            string password = Validation.GetValidatedString(question);
            _password = password;
            for (int i = 0; i < _availableUsers.Count; i++)
            {
                if (_availableUsers[i].Username == Username)
                {
                    _availableUsers[i]._password = password;
                }
            }
            FileIO.SaveEmployees(_filePath, _availableUsers);
            UI.DisplaySuccess("Password Changed!!");
            UI.Continue();
        }

        public void ChangeTheme()
        {
            Theme newTheme = UI.SelectThemeMenu();
            if (newTheme != null && newTheme != _theme)
            {
                for (int i = 0; i < _availableUsers.Count; i++)
                {
                    if (_availableUsers[i].Username == Username)
                    {
                        _availableUsers[i]._theme = newTheme;
                    }
                }
                FileIO.SaveEmployees(_filePath, _availableUsers);
                UI.DisplaySuccess($"Theme changed to {newTheme.Name}!");
                UI.Continue();
                UI.SetTheme(newTheme);
            }
            else if (newTheme == _theme)
            {
                UI.DisplayError("This is already your current theme!");
                UI.Continue();
            }
        }

        public static void DeleteAUser(User user)
        {
            for (int i = 0; i < _availableUsers.Count; i++)
            {
                if (_availableUsers[i].Username == user.Username)
                {
                    _availableUsers.RemoveAt(i);
                }
            }
            FileIO.SaveEmployees(_filePath, _availableUsers);
        }

        public void AddPoint()
        {
            _userScore += 1;
        }

    }//end of class
}
