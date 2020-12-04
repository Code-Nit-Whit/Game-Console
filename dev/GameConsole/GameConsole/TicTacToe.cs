using System;
using System.Linq;
using System.Collections.Generic;

namespace GameConsole
{
    public class TicTacToe : Game
    {

        private new List<string> _instructions = new List<string>{
            "Get ready to beat your opponent!",
            "In this two player game, you will take turns placing a marker on the game board.",
            "The first player to get three of their markers in a row (horizontal, vertical, or diagonal), wins!",
            "To place a marker, simply enter the number of the space where you would like to place it."
        };

        public TicTacToe(User player) : base(player, "Tic-Tac-Toe")
        {
            
        }

        // Play
        public override void Play()
        {
            bool keepGoing = true;
            while(keepGoing)
            {
                //Local variables
                string[] spaces = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                string winner = null;
                bool stalemate = false;
                string player;
                string marker;

                //Display Board
                UpdateGameDisplay(spaces);

                //Play until someone wins
                int turns = 1;
                while (winner == null && !stalemate)
                {
                    //Select Player
                    player = (turns % 2 == 0) ? "Player 2" : "Player 1";
                    marker = (turns % 2 == 0) ? "O" : "X";

                    //Chose space and validate
                    int space = ValidateSpace(spaces, player) - 1;
                    spaces[space] = marker;

                    //Refresh Board
                    UpdateGameDisplay(spaces);

                    //Check for winners
                    winner = CheckWinner(spaces, marker);
                    turns++;
                }
                Display2PWinner(winner);
            }
        }

        //Game board
        protected override void UpdateGameDisplay(string[] spaces)
        {
            //Header
            UI.DisplayTitle(_title);
            //Display Instructions
            foreach(string instruction in _instructions)
            {
                UI.DisplayInfo(instruction);
            }

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
        protected override string CheckWinner(string[] spaces, string marker)
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
            else if(winner == null && spaces.Distinct().Count() == 2)
            {
                winner = "stalemate";
            }
            return winner;
        }
        
        //Validate Space
        private int ValidateSpace(string[] spaces, string player)
        {
            string question = $" [{player}]: Please choose a space... ";
            int[] range = { 0, 9 };
            int guess = Validation.GetValidatedRange(question, range);
            while (spaces[guess - 1] == "X" || spaces[guess - 1] == "O")
            {
                UI.DisplayError("Invalid input, Please try again");
                guess = Validation.GetValidatedRange(question, range);
            }

            return guess;
        }
    }
}
