using System;
using System.Collections.Generic;

namespace GameConsole
{
    public class GameConsole
    {
        private static bool _keepGoing = true;

        public static User User { get; set; }

        public GameConsole()
        {
        }

        public void Init() // Main Menu
        {
            User = User.LogIn();
            UI.DisplayTitle($"Hello, {User.Username}! Welcome To...\r\n\r\n         The Game Console!");
            string[] mainMenuArr = { "Game Console- Main Menu", "Games", "User Menu", "System", "Exit" };
            Menu mainMenu = new Menu();
            mainMenu.Init(mainMenuArr);
            bool keepGoing = true;
            while(keepGoing)
            {
                mainMenu.Display(mainMenuArr[0]);
                string question = "Please select a game from the options above [1,2,3]... ";
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

                case 3: // System Menu
                    SystemMenu();
                    break;

                case 0: //Exit
                    ExitProgram();
                    break;
            }
        }
        private static void HandleGameMenuSelection(int response)
        {
            bool keepPlaying = true;
            switch (response)
            {
                case 1: //TicTacToe
                    while (keepPlaying)
                    {
                        TicTacToe game1 = new TicTacToe(User);
                        game1.Play();
                        keepPlaying = Validation.PlayAgain();
                    }
                    break;

                case 2: //High Low
                    while (keepPlaying)
                    {
                        HighLow game2 = new HighLow(User);
                        game2.Play();
                        keepPlaying = Validation.PlayAgain();
                    }
                    break;

                case 3: //Mastermind
                    while (keepPlaying)
                    {
                        Mastermind game3 = new Mastermind(User);
                        game3.Play();
                        keepPlaying = Validation.PlayAgain();
                    }
                    break;

                case 4: //Math Challenge
                    while (keepPlaying)
                    {
                        MathChallenge game4 = new MathChallenge(User);
                        game4.Play();
                        keepPlaying = Validation.PlayAgain();
                    }
                    break;

                case 5: //Hangman
                    while (keepPlaying)
                    {
                        Hangman game5 = new Hangman(User);
                        game5.Play();
                        keepPlaying = Validation.PlayAgain();
                    }
                    break;

                case 6: //Crack the Code
                    while (keepPlaying)
                    {
                        CrackTheCode game6 = new CrackTheCode(User);
                        game6.Play();
                        keepPlaying = Validation.PlayAgain();
                    }
                    break;

                case 7: //Display User Profile-Menu
                    User.DisplayProfile();
                    break;


                case 0: //Back
                    break;
            }
        }
        private void HandleUserMenuSelection()
        {

        }
        private void HandleSystemMenuSelection()
        {

        }



        //MENU CREATION
        //
        //
        private void GamesMenu()
        {
            string[] gamesMenuArr = { "Game Console Main Menu", "Tic-Tac-Toe", "High-Low", "Mastermind", "Math Challenge", "Hangman", "Crack the Code", "Back" };
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
            
        }

        private void SystemMenu()
        {

        }






        private void ExitProgram()
        {
            //Say goodbye
            UI.DisplayTitle("Exiting...");
            UI.DisplaySuccess("Thank you for playing!! See you soon.");
        }
    }
}
