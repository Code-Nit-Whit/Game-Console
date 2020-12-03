using System;
using System.Collections.Generic;

namespace GameConsole
{
    class Program
    {
        private static bool _keepGoing = true;

        public static User User { get; set; } 

        

        static void Main(string[] args)
        {
            User = User.LogIn();

            UI.SetDefaultTheme();

            //Output for Header Formatting
            string textOutput = $"Hello, {User.Username}! Welcome To...\r\n\r\n         The Game Console!";

            //Instantiate 3 menus
            List<string> gamesOptions = new List<string> { "Tic-Tac-Toe", "High-Low", "Mastermind", "Math Challenge", "Hangman", "Crack the Code"};
            Menu games = new Menu("Games", gamesOptions);

            List<string> userOptions = new List<string> { "User" }; 
            Menu userMenu = new Menu("User", userOptions);

            List<string> systemOptions = new List<string> { "Exit Game" };
            Menu system = new Menu("System", systemOptions);

            List<Menu> mainMenu = new List<Menu> { games, userMenu, system};

            
            while (_keepGoing)
            {
                UI.Header(textOutput);
                Menu.DisplayMenu(mainMenu);
                int userResponse = Menu.GetMenuSelection(mainMenu);
                MenuSelection(User, userResponse);
            }
        }


        private static void MenuSelection(User player, int response)
        {

            bool keepPlaying = true;

            //Conditional block to handle response
            switch (response)
            {
                case 1: //TicTacToe
                    while (keepPlaying)
                    {
                        TicTacToe game1 = new TicTacToe(player);
                        game1.Play();
                        keepPlaying = Validation.PlayAgain();
                    }
                    break;

                case 2: //High Low
                    while (keepPlaying)
                    {
                        HighLow game2 = new HighLow(player);
                        game2.Play();
                        keepPlaying = Validation.PlayAgain();
                    }
                    break;

                case 3: //Mastermind
                    while (keepPlaying)
                    {
                        Mastermind game3 = new Mastermind(player);
                        game3.Play();
                        keepPlaying = Validation.PlayAgain();
                    }
                    break;

                case 4: //Math Challenge
                    while (keepPlaying)
                    {
                        MathChallenge game4 = new MathChallenge(player);
                        game4.Play();
                        keepPlaying = Validation.PlayAgain();
                    }
                    break;

                case 5: //Hangman
                    while (keepPlaying)
                    {
                        Hangman game5 = new Hangman(player);
                        game5.Play();
                        keepPlaying = Validation.PlayAgain();
                    }
                    break;

                case 6: //Crack the Code
                    while (keepPlaying)
                    {
                        CrackTheCode game6 = new CrackTheCode(player);
                        game6.Play();
                        keepPlaying = Validation.PlayAgain();
                    }
                    break;

                case 7: //Display User Profile-Menu
                    player.DisplayProfile();
                    break;


                case 0: //Exit
                    _keepGoing = false;
                    ExitProgram();
                    break;
            }

        }


        private static void ExitProgram()
        {
            //Say goodbye
            string textOutput = "Goodbye";
            UI.Footer(textOutput);
        }


    }// end of class
}
