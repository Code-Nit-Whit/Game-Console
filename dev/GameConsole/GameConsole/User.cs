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
        private Dictionary<string, int> _userScores; //Total, HighLow, Mastermind, MathChallenge, CrackTheCode, Hangman, TicTacToe


        private static string _filePath = "../../../users.txt";
        private static List<User> _availableUsers;

        public Theme TheTheme { get { return _theme; } }

        public User(string username, string password, int age, string theme)
        {
            _username = username;
            _password = password;
            _age = age;
            _theme = UI.FindTheme(theme);
        }

        public void SetUserScores(Dictionary<string, int> userScores = null)
        {
            if (userScores == null)
            {
                userScores = new Dictionary<string, int>();
                userScores.Add("Total", 0);
                userScores.Add("High-Low", 0);
                userScores.Add("Mastermind", 0);
                userScores.Add("Math Challenge", 0);
                userScores.Add("Crack the Code", 0);
                userScores.Add("Hangman", 0);
                userScores.Add("Tic-Tac-Toe", 0);
            }
            _userScores = userScores;
        }

        public static User LogIn()
        {
            _availableUsers = FileIO.LoadPlayers(_filePath);
            User returnUser = null;
            bool loggedIn = false;
            while (!loggedIn)
            {
                UI.DisplayTitle("Log In");
                string question = "[Username]: ";
                string username = Validation.GetValidatedString(question);
                question = "[Password]: ";
                string password = Validation.GetValidatedString(question);
                bool successful = false;
                for (int i = 0; i < _availableUsers.Count; i++)
                {
                    loggedIn = _availableUsers[i].CheckUserPassword(username, password);
                    if (loggedIn)
                    {
                        returnUser = _availableUsers[i];
                        successful = true;
                        break;
                    }
                }
                if (!successful)

                {
                    UI.DisplayError("Login Failed :( Please try again...");
                    UI.Continue();
                }
            }
            UI.DisplaySuccess("\r\nLogin Successful!");
            UI.Continue();
            return returnUser;
        }
        private bool CheckUserPassword(string username, string password)
        {
            if (username == Username && password == _password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string[] GetSaveData()
        {
            string[] saveData = new string[11];
            //{ Username, _password, _age.ToString(), _theme.Name, _userScore.ToString()};
            saveData[0] = Username;
            saveData[1] = _password;
            saveData[2] = _age.ToString();
            saveData[3] = _theme.Name;
            int i = 4;
            foreach (KeyValuePair<string, int> kvp in _userScores)
            {
                saveData[i] = kvp.Value.ToString();
                i++;
            }
            return saveData;
        }

        public static void SavePlayers(string sucMessage = null)
        {
            FileIO.SavePlayers(_filePath, _availableUsers);
            if (sucMessage != null)
            {
                UI.DisplaySuccess(sucMessage);
            }
        }

        public void DisplayUserProfile()
        {
            UI.DisplayTitle($"{Username}'s Profile");
            //Display demographic info
            Console.WriteLine("Personal Information");
            string[] personalData = {
                $"Username: {Username}",
                $"Age: {_age}",
                $"Theme: {_theme.Name}"
            };
            string[] splitters = { ":" };
            List<string> formattedPersData = UI.DisplayColumns(personalData, splitters);
            foreach (string dataPoint in formattedPersData)
            {
                UI.DisplayInfo(dataPoint);
            }
            //Display scoring info
            Console.WriteLine("\r\n\r\nScoreboard");
            string[] scoreData = {
                $"Total: {_userScores["Total"]}",
                $"High-Low: {_userScores["High-Low"]}",
                $"Mastermind: {_userScores["Mastermind"]}",
                $"Math Challenge: {_userScores["Math Challenge"]}",
                $"Crack the Code: {_userScores["Crack the Code"]}",
                $"Hangman: {_userScores["Hangman"]}",
                $"Tic-Tac-Toe: {_userScores["Tic-Tac-Toe"]}"
            };
            List<string> formattedScoreData = UI.DisplayColumns(scoreData, splitters);
            foreach(string dataPoint in formattedScoreData)
            {
                UI.DisplayInfo(dataPoint);
            }
            UI.Continue();
        }

        public static void CreateUser()
        {
            bool keepGoing = true;
            while (keepGoing)
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
                User newUser = new User(username, password, age, theme);
                newUser.SetUserScores();
                _availableUsers.Add(newUser);
                string successMessage = $"{username} Created!!!";
                SavePlayers(successMessage);
                question = "would you like to create another user? [y,n]... ";
                conditionals = new string[] { "y", "n" };
                string response = Validation.GetValidatedConditional(question, conditionals);
                if (response == "n")
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
            string oldUser = _username;
            _username = username;
            for (int i = 0; i < _availableUsers.Count; i++)
            {
                if (_availableUsers[i].Username == oldUser)
                {
                    _availableUsers[i]._username = username;
                }
            }
            string successMessage = $"Username Changed to {Username}!!";
            SavePlayers(successMessage);
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
            string successMessage = "Password Changed!!";
            SavePlayers(successMessage);
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
                string successMessage = $"Theme changed to {newTheme.Name}!";
                SavePlayers(successMessage);
                UI.Continue();
                UI.SetTheme(newTheme);
            }
            else if (newTheme == _theme)
            {
                UI.DisplayError("This is already your current theme!");
                UI.Continue();
            }
        }

        public static void DeleteThisUser(User user)
        {
            for (int i = 0; i < _availableUsers.Count; i++)
            {
                if (_availableUsers[i].Username == user.Username)
                {
                    _availableUsers.RemoveAt(i);
                }
            }
            SavePlayers();
        }

        public void AddAPoint(string game)
        {
            //Update loaded user profile
            _userScores["Total"] += 1;
            _userScores[game] += 1;
            //Update user save info in user list
            for (int i = 0; i < _availableUsers.Count; i++)
            {
                if (_availableUsers[i].Username == Username)
                {
                    _availableUsers[i]._userScores["Total"] = _userScores["Total"];
                    _availableUsers[i]._userScores[game] = _userScores[game];
                }
            }
            SavePlayers();
        }
    }//end of class
}
