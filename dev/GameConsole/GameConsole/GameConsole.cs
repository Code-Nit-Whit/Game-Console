using System;

namespace GameConsole
{
    public class GameConsole
    {
        private User _user;

        public GameConsole()
        {
        }

        public void Init() // Main Menu
        {
            UI.LoadThemes();
            Theme defaultTheme = UI.FindTheme("light");
            UI.SetTheme(defaultTheme);
            _user = User.LogIn();
            UI.DisplayTitle($"Hello, {_user.Username}! Welcome To The Game Console!");
            string[] mainMenuArr = { "Game Console- Main Menu", "Games", "User Menu", "Exit" };
            Menu mainMenu = new Menu();
            mainMenu.Init(mainMenuArr);
            bool keepGoing = true;
            while(keepGoing)
            {
                mainMenu.Display(mainMenuArr[0]);
                string question = "Please select a menu from the options above [1,2]... ";
                int[] range = { 0, mainMenuArr.Length-2};
                int selection = Validation.GetValidatedRange(question, range);
                if(selection == 0)
                {
                    keepGoing = false;
                }
                HandleMainMenuSelection(selection);
            }
        }

        //MENU CREATION
        //
        //
        private void OpenGamesMenu()
        {
            string[] gamesMenuArr = { "Game Console- Game Menu", "Tic-Tac-Toe", "High-Low", "Mastermind", "Math Challenge", "Hangman", "Crack the Code", "Back" };
            Menu gamesMenu = new Menu();
            gamesMenu.Init(gamesMenuArr);
            bool keepGoing = true;
            while (keepGoing)
            {
                gamesMenu.Display(gamesMenuArr[0]);
                string question = "Please select a game from the options above [1,2,3]... ";
                int[] range = { 0, gamesMenuArr.Length - 2 };
                int selection = Validation.GetValidatedRange(question, range);
                if (selection == 0)
                {
                    keepGoing = false;
                }
                HandleGameMenuSelection(selection);
            }
        }
        private void OpenUserMenu()
        {
            string[] userMenuaArr = { "Game Console- User Menu", "Display User Profile", "Create User", "Change Username", "Change Password", "Change Theme", "Delete This User", "Log Out", "Back" };
            Menu userMenu = new Menu();
            userMenu.Init(userMenuaArr);
            bool keepGoing = true;
            while (keepGoing)
            {
                userMenu.Display(userMenuaArr[0]);
                string question = "Please select an option from the menu above [1,2,3]... ";
                int[] range = { 0, userMenuaArr.Length - 2 };
                int selection = Validation.GetValidatedRange(question, range);
                if (selection == 0)
                {
                    keepGoing = false;
                }
                HandleUserMenuSelection(selection);
            }
        }

        //MENU SELECTION HANDLING
        //
        //
        private void HandleMainMenuSelection(int selection)
        {
            switch(selection)
            {
                case 1: //Games
                    OpenGamesMenu();
                    break;

                case 2: //User Menu
                    OpenUserMenu();
                    break;

                case 0: //Exit
                    ExitProgram();
                    break;
            }
        }
        private void HandleGameMenuSelection(int response)
        {
            //bool keepPlaying = true;
            switch (response)
            {
                case 1: //TicTacToe
                    TicTacToe ttt = new TicTacToe(_user);
                    ttt.Play();
                    break;

                case 2: //High Low
                    HighLow hl = new HighLow(_user);
                    hl.Play();
                    break;

                case 3: //Mastermind
                    Mastermind mm = new Mastermind(_user);
                    mm.Play();
                    break;

                case 4: //Math Challenge
                    MathChallenge mc = new MathChallenge(_user);
                    mc.Play();
                    break;

                case 5: //Hangman
                    //Hangman hm = new Hangman(_user);
                    //hm.Play();
                    UI.ComingSoon();
                    break;

                case 6: //Crack the Code
                    //CrackTheCode ctc = new CrackTheCode();
                    //ctc.Play();
                    UI.ComingSoon();
                    break;

                case 0: //Back
                    break;
            }
        }
        
        private void HandleUserMenuSelection(int selection)
        {
            switch (selection)
            {
                case 1: //Display User Profile
                    _user.DisplayUserProfile();
                    break;

                case 2: //Create New User
                    User.CreateUser();
                    break;

                case 3: //Change Username
                    _user.ChangeUsername();
                    break;

                case 4: //Change Password
                    _user.ChangePassword();
                    break;

                case 5: //Change Theme
                    _user.ChangeTheme();
                    break;

                case 6: //Delete This User
                    string question = "Are you sure you want to delete your account? This cant be undone [y,n]... ";
                    string[] conditionals = { "y", "n" };
                    string response = Validation.GetValidatedConditional(question, conditionals);
                    if (response == "y")
                    {
                        User.DeleteAUser(_user);
                        UI.DisplaySuccess("Your account has been deleted.");
                        UI.Continue();
                        Program.RestartConsole();
                    }
                    break;

                case 7: //LogOut (restart console)
                    UI.DisplaySuccess("Logged Out");
                    UI.Continue();
                    Program.RestartConsole();
                    break;

                case 0: //Back
                    break;
            }
        }


        private void ExitProgram()
        {
            //Say goodbye
            UI.DisplayTitle("Exiting...");
            UI.DisplaySuccess("Thank you for playing!! See you soon.");
        }
    }
}
