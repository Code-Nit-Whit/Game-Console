using System;

namespace GameConsole
{
    public class GameConsole
    {
        private bool _keepGoing = true;

        private User User { get; set; }

        public GameConsole()
        {
        }

        public void Init() // Main Menu
        {
            User = User.LogIn();
            UI.DisplayTitle($"Hello, {User.Username}! Welcome To...\r\n\r\n         The Game Console!");
            string[] mainMenuArr = { "Game Console- Main Menu", "Games", "User Menu", "Exit" };
            Menu mainMenu = new Menu();
            mainMenu.Init(mainMenuArr);
            bool keepGoing = true;
            while(keepGoing)
            {
                mainMenu.Display(mainMenuArr[0]);
                string question = "Please select a menu from the options above [1,2]... ";
                int[] range = { 0, mainMenuArr.Length-1};
                int selection = Validation.GetValidatedRange(question, range);
                if(selection == 0)
                {
                    keepGoing = false;
                }
                HandleMainMenuSelection(selection);
            }

           //List<string> userOptions = new List<string> { "User" };
            //Menu userMenu = new Menu("User", userOptions);

            //List<string> systemOptions = new List<string> { "Exit Game" };
            //Menu system = new Menu("System", systemOptions);

            // List<Menu> mainMenu = new List<Menu> { games, userMenu, system };

        }

        //MENU SELECTION HANDLING
        //
        //
        private void HandleMainMenuSelection(int selection)
        {
            switch(selection)
            {
                case 1: //Games
                    GamesMenu();
                    break;

                case 2: //User Menu
                    UserMenu();
                    break;

                case 0: //Exit
                    ExitProgram();
                    break;
            }
        }
        private void HandleGameMenuSelection(int response)
        {
            bool keepPlaying = true;
            switch (response)
            {
                case 1: //TicTacToe
                    while (keepPlaying)
                    {
                        TicTacToe game1 = new TicTacToe(User);
                        game1.Play();
                        keepPlaying = PlayAgain();
                    }
                    break;

                case 2: //High Low
                    while (keepPlaying)
                    {
                        HighLow game2 = new HighLow(User);
                        game2.Play();
                        keepPlaying = PlayAgain();
                    }
                    break;

                case 3: //Mastermind
                    while (keepPlaying)
                    {
                        Mastermind game3 = new Mastermind(User);
                        game3.Play();
                        keepPlaying = PlayAgain();
                    }
                    break;

                case 4: //Math Challenge
                    while (keepPlaying)
                    {
                        MathChallenge game4 = new MathChallenge(User);
                        game4.Play();
                        keepPlaying = PlayAgain();
                    }
                    break;

                case 5: //Hangman
                    while (keepPlaying)
                    {
                        Hangman game5 = new Hangman(User);
                        game5.Play();
                        keepPlaying = PlayAgain();
                    }
                    break;

                case 6: //Crack the Code
                    while (keepPlaying)
                    {
                        CrackTheCode game6 = new CrackTheCode(User);
                        game6.Play();
                        keepPlaying = PlayAgain();
                    }
                    break;

                case 7: //Display User Profile-Menu
                    User.DisplayProfile();
                    break;


                case 0: //Back
                    break;
            }
        }
        private bool PlayAgain()
        {
            string question = "Would you like to play again? [y,n]... ";
            string[] conditionals = { "y", "n" };
            UI.AskQuestion(question);
            string response = Validation.GetValidatedConditional(question, conditionals);
            return response == "y" ? true : false;
        }
        private void HandleUserMenuSelection(int selection)
        {
            switch (selection)
            {
                case 1: //Create New User
                    SaveNewUser();
                    break;

                case 2: //Change Username
                    UI.ComingSoon();
                    //ChangeUsername();
                    break;

                case 3: //Change Password
                    UI.ComingSoon();
                    //ChangePassword();
                    break;

                case 4: //Change Theme
                    ChangeTheme();
                    break;

                case 0: //Back
                    break;
            }
        }



        //MENU CREATION
        //
        //
        private void GamesMenu()
        {
            string[] gamesMenuArr = { "Game Console- Game Menu", "Tic-Tac-Toe", "High-Low", "Mastermind", "Math Challenge", "Hangman", "Crack the Code", "Back" };
            Menu gamesMenu = new Menu();
            gamesMenu.Init(gamesMenuArr);
            bool keepGoing = true;
            while(keepGoing)
            {
                gamesMenu.Display(gamesMenuArr[0]);
                string question = "Please select a game from the options above [1,2,3]... ";
                int[] range = { 0, gamesMenuArr.Length - 1 };
                int selection = Validation.GetValidatedRange(question, range);
                if(selection == 0)
                {
                    keepGoing = false;
                }
                HandleGameMenuSelection(selection);
            }
        }
        private void UserMenu()
        {
            string[] userMenuaArr = { "Game console- User Menu", "Create User", "Change Username", "Change Password", "Change Theme", "Back" };
            Menu userMenu = new Menu();
            userMenu.Init(userMenuaArr);
            bool keepGoing = true;
            while(keepGoing)
            {
                userMenu.Display(userMenuaArr[0]);
                string question = "Please select an option from the menu above [1,2,3]... ";
                int[] range = { 0, userMenuaArr.Length-1};
                int selection = Validation.GetValidatedRange(question, range);
                if(selection == 0)
                {
                    keepGoing = false;
                }
                HandleUserMenuSelection(selection);
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
