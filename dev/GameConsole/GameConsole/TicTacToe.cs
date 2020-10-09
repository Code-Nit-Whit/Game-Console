using System;
using System.Linq;
using System.Collections.Generic;

// Name: Whitaker, Codie
// Date: September 11th, 2020
// Course: APD
// Synopsis: CE05: Milestone 2



namespace GameConsole
{
    public class TicTacToe
    {


        private User _player;
        private readonly string _title = "Tic-Tac-Toe";
        private readonly List<string> _instructions = new List<string>{
            "Get ready to beat your opponent!",
            "In this two player game, you will take turns placing a marker on the game board.",
            "The first player to get three of their markers in a row (horizontal, vertical, or diagonal), wins!",
            "To place a marker, simply enter the number of the space where you would like to place it." };


        public TicTacToe(User player)
        {

            _player = player;

        }

        // Play
        public void Play()
        {

                //Local variables
                string[] spaces = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                string winner = null;
                bool stalemate = false;

                string player;
                string marker;

                

                //Display Board
                DisplayBoard(spaces);

                //Play until someone wins
                int turns = 1;
                while (winner == null && !stalemate)
                {
                    //Select Player
                    player = (turns % 2 == 0) ? "Player 2" : "Player 1";
                    marker = (turns % 2 == 0) ? "O" : "X";

                    //Chose space and validate
                    string chooseSpacePrompt = $" [{player}]: Please choose a space... ";
                    int space = ValidateSpace(spaces, chooseSpacePrompt) - 1;
                    spaces[space] = marker;

                    //Refresh Board
                    DisplayBoard(spaces);

                    //Check for winners
                    winner = CheckWinner(spaces, marker);
                    stalemate = CheckStalemate(spaces, winner);


                    turns++;
                }

                //Display winner
                if (winner != null)
                {
                    string textOutput = $"Winner: {winner}";
                    UI.Header(textOutput);
                }
                else if (stalemate)
                {
                    string textOutput = "Oops, looks like a Stalemate!";
                    UI.Header(textOutput);
                }

        }








        //Game board
        private void DisplayBoard(string[] spaces)
        {

            //Header
            UI.Header(_title);

            //Display Instructions
            UI.DisplayInstructions(_instructions);

            //Instructions
            Console.WriteLine(" ");

            //Board
            Console.WriteLine($"     |     |     ");
            Console.WriteLine($"  {spaces[0]}  |  {spaces[1]}  |  {spaces[2]}  ");
            Console.WriteLine($"_____|_____|_____");
            Console.WriteLine($"     |     |     ");
            Console.WriteLine($"  {spaces[3]}  |  {spaces[4]}  |  {spaces[5]}  ");
            Console.WriteLine($"_____|_____|_____");
            Console.WriteLine($"     |     |     ");
            Console.WriteLine($"  {spaces[6]}  |  {spaces[7]}  |  {spaces[8]}  ");
            Console.WriteLine($"     |     |     ");
            Console.WriteLine("");

        }







        //Check Lines (Check Winner)
        private string CheckWinner(string[] spaces, string marker)
        {
            string winner = null;
            if (
                //Horizontals
                (spaces[0] == spaces[1] && spaces[1] == spaces[2])
                || (spaces[3] == spaces[4] && spaces[4] == spaces[5])
                || (spaces[6] == spaces[7] && spaces[7] == spaces[8])

                //Verticals
                || (spaces[0] == spaces[3] && spaces[3] == spaces[6])
                || (spaces[1] == spaces[4] && spaces[4] == spaces[7])
                || (spaces[2] == spaces[5] && spaces[5] == spaces[8])

                //Diagonals
                || (spaces[0] == spaces[4] && spaces[4] == spaces[8])
                || (spaces[2] == spaces[4] && spaces[4] == spaces[6])
                )
            {
                winner = marker;
            }

            return winner;
        }






        //Check for stalemate
        private bool CheckStalemate(string[] spaces, string winner)
        {
            bool stalemate = false;
            if (winner == null && spaces.Distinct().Count() == 2)
            {
                stalemate = true;
            }

            return stalemate;
        }








        //Validate Space
        private int ValidateSpace(string[] spaces, string message)
        {
            UI.Separator(message);
            string input = Console.ReadLine();
            int guess;

            while (!Int32.TryParse(input, out guess) || guess < 0 || guess > 9 || spaces[guess - 1] == "X" || spaces[guess - 1] == "O")
            {
                string errorMessage = " Invalid input, Please try again: ";
                UI.Separator(errorMessage);
                input = Console.ReadLine();
            }

            return guess;
        }
    }
}
