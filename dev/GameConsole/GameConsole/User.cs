using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;

namespace GameConsole
{
    public class User
    {

        
        private int _age;
        private string _password;


        public Theme Theme {get; set;}
        public string Username {  get; set; }
       
        

        public User(string name, string password, int age, string theme)
        {
            Username = name;
            _age = age;
            _password = password;
            Theme = new Theme(theme);
            
        }


        //Display user profile
        public void DisplayProfile()
        {
            //Display the Profile
            List<string> userOptions = new List<string>() { "Create New User", "Change Username", "Change Password", "Change Theme" };
            Menu userMenu = new Menu("User Menu", userOptions);

            List<string> additionalOptions = new List<string>() { "Back" };
            Menu userAdditionalMenu = new Menu("Additional User Menu", additionalOptions);

            List<Menu> menus = new List<Menu>() { userMenu, userAdditionalMenu };

            bool keepGoing = true;
            while (keepGoing)
            {
                UI.Header("USER PROFILE");
                Console.WriteLine("");

                List<string> userInfo = new List<string>() { $"Username: {Username}", $"Age: {_age.ToString()}", $"Theme: {Theme.Name }" };
                UI.DisplayInstructions(userInfo);

                Menu.DisplayMenu(menus);
                int userResponse = Menu.GetMenuSelection(menus);
                keepGoing = HandleUserResponse(userResponse);
            }

            
        }



        public static User LogIn()
        {
            List<string> usernames = new List<string>();
            List<string> passwords = new List<string>();
            List<int> ages = new List<int>();
            List<string> themes = new List<string>();
            using (StreamReader sr = new StreamReader("../../../Users.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    char[] splitters = { ':' };
                    string[] userInfo = line.Split(splitters);
                    usernames.Add(userInfo[0]);
                    passwords.Add(userInfo[1]);
                    ages.Add(int.Parse(userInfo[2]));
                    themes.Add(userInfo[3]);
                }
            }

            UI.Header("LOGIN");
            string promptPassword = "[Password]: ";
            UI.Separator();
            Console.Write("[Username]: ");
            string username = Validation.ValidateWhitelist(Console.ReadLine(), usernames);
            UI.Separator();
            Console.Write(promptPassword);
            string password = Validation.StringValidation(Console.ReadLine(), promptPassword);
            while (password != passwords[usernames.FindIndex(a => a.Contains(username))])
            {
                Console.WriteLine("");
                UI.SetErrorForeground("Incorrect Password.");
                Console.Write(promptPassword);
                password = Validation.StringValidation(Console.ReadLine(), promptPassword);
            }
            Console.WriteLine("");
            UI.SetSpecialForeground("Login Successful!");
            Thread.Sleep(1500);

            User user = new User(username, password, ages[usernames.FindIndex(a => a.Contains(username))], themes[usernames.FindIndex(a => a.Contains(username))]);
            return user;

        }

        

        private void SaveNewUser()
        {
            List<string> usernames = new List<string>();
            List<string> passwords = new List<string>();
            List<int> ages = new List<int>();
            List<string> themes = new List<string>();
            using (StreamReader sr = new StreamReader("../../../Users.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] userInfo = line.Split(':');
                    usernames.Add(userInfo[0]);
                    passwords.Add(userInfo[1]);
                    ages.Add(int.Parse(userInfo[2]));
                    themes.Add(userInfo[3]);
                }
            }

            UI.Header("REGISTER NEW USER");

            List<string> addingUserInstructions = new List<string>() { "Here we can add a user.", "First, type in a username. It must be unique.", "Next, select a password.", "Then, enter your age.", "Finally, choose a theme." };
            UI.DisplayInstructions(addingUserInstructions);

            //Prompt for a username
            UI.Separator();
            Console.Write("\r\n[Username]: ");
            string question = "What would you like your username to be? ";
            string username = Validation.StringValidation(Console.ReadLine(), question);
            //Check that username isn't taken
            while (usernames.Contains(username))
            {
                UI.SetErrorForeground("That username is already taken. Please try again.");
                Console.Write(question);
                username = Validation.StringValidation(Console.ReadLine(), question);
            }

            //Promp for password
            question = "What would you like your password to be? ";
            UI.Separator();
            Console.Write("[Password]: ");
            string password = Validation.StringValidation(Console.ReadLine(), question);

            //Prompt for age
            question = "What is your age? ";
            UI.Separator();
            Console.Write("[Age]: ");
            int age = Validation.IntergerValidation(Console.ReadLine(), question);

            //Prompts for preffered theme
            question = "Which theme do you want? [Light/Dark] ";
            UI.Separator();
            Console.Write("[Light/Dark]: ");
            string theme = Validation.StringValidation(Console.ReadLine(), question).ToLower();
            while(theme != "light" && theme != "dark")
            {
                UI.SetErrorForeground(" Please only select one of the provided theme options.");
                Console.Write(question);
                theme = Validation.StringValidation(Console.ReadLine(), question).ToLower();
            }

            //Add user to list
            string addingUser = $"{username}:{password}:{age}:{theme}";
            using (StreamWriter sw = File.AppendText("../../../Users.txt"))
            {
                sw.WriteLine(addingUser);
            }
        }

        private void ChangeUsername()
        {
            //Display Current Username
            //Prompt new username
            //Yes or no confirmation
        }

        private void ChangePassword()
        {
            //Prompt for current password
            //Prompt for new password
            //Yes or no confirmation
        }

        private void ChangeTheme()
        {
            string path = "../../../Users.txt";

            Dictionary<string, User> userDictionary = new Dictionary<string, User>();
            //Read Users.txt into a dictionary of usernames and user objects
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] userData = line.Split(':');
                    string username = userData[0];

                    string password = userData[1];
                    int age = Int32.Parse(userData[2]);
                    string theme = userData[3];
                    User user = new User(username, password, age, theme);

                    userDictionary.Add(username, user);
                }
            }

            bool keepGoing = true;
            while (keepGoing)
            {
                Console.Clear();

                //Display Header
                string header = "Change Theme";
                UI.Header(header);

                //Display available themes- menu
                List<string> availableThemesOptions = new List<string>() { "Light", "Dark" };
                Menu availableThemes = new Menu("Available Options", availableThemesOptions);
                List<string> extraThemesOptions = new List<string>() { "Cancel" };
                Menu extraThemes = new Menu("Extra", extraThemesOptions);
                List<Menu> menus = new List<Menu>() { availableThemes, extraThemes };
                Menu.DisplayMenu(menus);

                //Prompt user to select a theme- menu static method
                int userSelection = Menu.GetMenuSelection(menus);

                string theme = "";
                if(userSelection == 1) { theme = "light"; }
                else if(userSelection == 2) { theme = "dark"; }
                else {
                    theme = "Not Changed";
                    keepGoing = false; };
                
                //conditional Search for current user in dictionary's currnet theme
                if(theme == Theme.Name)
                {
                    //if it's already the current theme, display message instead of replacing anything
                    UI.SetSpecialForeground($"You're theme is already set to {theme}!");
                    Thread.Sleep(1500);
                }
                else
                {
                    //else confirm(y/n, display changes) yes makes keepGoing false
                    UI.Separator();
                    UI.SetSpecialForeground($"Theme changed to: {theme}");

                    string question = "Would you like to save these changes? [Y/N] ";
                    Console.Write(question);
                    string response = Validation.ValidateYesNo(Console.ReadLine(), question);
                    if (response.ToUpper() == "Y")
                    {
                        keepGoing = false;
                        //Replace user object value with the new value in dictionary
                        Theme = new Theme(theme);
                        userDictionary[Username] = new User(Username, _password, _age, Theme.Name);
                    }
                }
            }
            
            //Write dictionary into replacement of Users file
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (KeyValuePair<string, User> kvp in userDictionary)
                {
                    string username = kvp.Value.Username;
                    string password = kvp.Value._password;
                    string age = kvp.Value._age.ToString();
                    string theme = kvp.Value.Theme.Name;
                    string userData = $"{username}:{password}:{age}:{theme}";

                    sw.WriteLine(userData);
                }
            }

            UI.SetDefaultTheme();
        }

    }//end of class
}
