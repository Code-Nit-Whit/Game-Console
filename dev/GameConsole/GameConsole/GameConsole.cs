using System;

namespace GameConsole
{
    public class GameConsole
    {
        private User _user;
        private Menu _mainMenu;
        //private Menu _gameMenu;
        private Menu _onePlayerGameMenu;
        private Menu _twoPlayerGameMenu;
        private Menu _userMenu;

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
            //Create Main Menu
            string[] mainMenuArr = { "1 Player Games", "2 Player Gmaes", "User Menu" };
            _mainMenu = new Menu("Game Console- Main Menu", "Exit");
            _mainMenu.AddMenuItems(mainMenuArr);
            //Create Games Menu
            /*string[] gamesMenuArr = { "Tic-Tac-Toe", "High-Low", "Mastermind", "Math Challenge", "Hangman", "Crack the Code" };
            _gameMenu = new Menu("Game Console- Game Menu", "Back");
            _gameMenu.AddMenuItems(gamesMenuArr);*/
            string[] onePGamesMenuArr = { "High-Low", "Mastermind", "Math Challenge", "Hangman", "Crack the Code" };
            _onePlayerGameMenu = new Menu("Game Console- 1 Player Games", "Back");
            _onePlayerGameMenu.AddMenuItems(onePGamesMenuArr);
            string[] twoPGamesMenuArr = { "Tic-Tac-Toe" };
            _twoPlayerGameMenu = new Menu("Game Console- 2 Player Games", "Back");
            _twoPlayerGameMenu.AddMenuItems(twoPGamesMenuArr);
            //Create User Menu
            string[] userMenuaArr = { "Display User Profile", "Create User", "Change Username", "Change Password", "Change Theme", "Delete This User", "Log Out" };
            _userMenu = new Menu("Game Console- User Menu", "Back");
            _userMenu.AddMenuItems(userMenuaArr);
            //Start first menu
            OpenMainMenu();
            ExitProgram();
        }

        //RUN MENUS
        //
        //
        private void OpenMainMenu()
        {
            _mainMenu.Display(true);
            string question = "Please select a menu from the options above [1,2]... ";
            int[] range = { 0, _mainMenu.NumItems };
            int selection = Validation.GetValidatedRange(question, range);
            if (selection != 0)
            {
                HandleMainMenuSelection(selection);
                OpenMainMenu();
            }
        }

        private void Open1PGamesMenu()
        {
            _onePlayerGameMenu.Display(true);
            string question = "Please select a game from the options above [1,2,3]... ";
            int[] range = { 0, _onePlayerGameMenu.NumItems };
            int selection = Validation.GetValidatedRange(question, range);
            if (selection != 0)
            {
                HandleGameMenuSelection(selection);
                Open1PGamesMenu();
            }
        }

        private void Open2PGamesMenu()
        {
            _twoPlayerGameMenu.Display(true);
            string question = "Please select a game from the options above [1,2,3]... ";
            int[] range = { 0, _twoPlayerGameMenu.NumItems };
            int selection = Validation.GetValidatedRange(question, range);
            if (selection != 0)
            {
                HandleGameMenuSelection(selection, true);
                Open2PGamesMenu();
            }
        }

        private void OpenUserMenu()
        {
            _userMenu.Display(true);
            string question = "Please select an option from the menu above [1,2,3]... ";
            int[] range = { 0, _userMenu.NumItems };
            int selection = Validation.GetValidatedRange(question, range);
            if (selection != 0)
            {
                HandleUserMenuSelection(selection);
                OpenUserMenu();
            }
        }

        //MENU SELECTION HANDLING
        //
        //
        private void HandleMainMenuSelection(int selection)
        {
            switch(selection)
            {
                case 1: //1 Player Games
                    Open1PGamesMenu();
                    break;

                case 2: //2 Player Games
                    Open2PGamesMenu();
                    break;

                case 3: //User Menu
                    OpenUserMenu();
                    break;
            }
        }
        private void HandleGameMenuSelection(int response, bool twoPlayer = false)
        {
            if (!twoPlayer)
            {
                switch (response)
                {
                    case 1: //High Low
                        HighLow hl = new HighLow(_user);
                        hl.Play();
                        break;

                    case 2: //Mastermind
                        Mastermind mm = new Mastermind(_user);
                        mm.Play();
                        break;

                    case 3: //Math Challenge
                        MathChallenge mc = new MathChallenge(_user);
                        mc.Play();
                        break;

                    case 4: //Hangman
                        Hangman hm = new Hangman(_user);
                        hm.Play();
                        break;

                    case 5: //Crack the Code
                        CrackTheCode ctc = new CrackTheCode(_user);
                        ctc.Play();
                        break;

                    case 0: //Back
                        break;
                }
            }
            else
            {
                switch (response)
                {
                    case 1: //TicTacToe
                        TicTacToe ttt = new TicTacToe(_user);
                        ttt.Play();
                        break;

                    case 0: //Back
                        break;
                }
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
