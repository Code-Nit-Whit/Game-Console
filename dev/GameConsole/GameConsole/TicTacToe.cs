using System;
using System.Linq;
using System.Collections.Generic;

namespace GameConsole
{
    public class TicTacToe : TwoPlayerGame
    {
        private readonly new List<string> _instructions = new List<string>{
            "Get ready to beat your opponent!",
            "In this two player game, you will take turns placing a marker on the game board.",
            "The first player to get three of their markers in a row (horizontal, vertical, or diagonal), wins!",
            "To place a marker, simply enter the number of the space where you would like to place it."
        };
        private string[] _spaces = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        private string _marker = "";

        public TicTacToe(User player) : base(player, "Tic-Tac-Toe")
        {
            
        }

        // Play
        public override void Play()
        {
            string winner = null;
            string player;
            //Display Board
            UpdateGameDisplay();
            //Play until someone wins
            int turns = 1;
            while (winner == null)
            {
                //Select Player
                player = (turns % 2 == 0) ? "Player 2" : "Player 1";
                _marker = (turns % 2 == 0) ? "O" : "X";
                //Chose space and validate
                int space = ValidateSpace(_spaces, player) - 1;
                //Refresh Board
                UpdateGameDisplay();
                //Check for winners
                winner = CheckWinner();
                turns++;
            }
            DisplayWinner(winner);
            if (PlayAgain())
            {
                Play();
            }
            else
            {
                //Exit option
            }
        }

        //Game board
        protected override void UpdateGameDisplay()
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
            Console.WriteLine($"  {_spaces[0]}  |  {_spaces[1]}  |  {_spaces[2]}  ");
            Console.WriteLine($"_____|_____|_____");
            Console.WriteLine($"     |     |     ");
            Console.WriteLine($"  {_spaces[3]}  |  {_spaces[4]}  |  {_spaces[5]}  ");
            Console.WriteLine($"_____|_____|_____");
            Console.WriteLine($"     |     |     ");
            Console.WriteLine($"  {_spaces[6]}  |  {_spaces[7]}  |  {_spaces[8]}  ");
            Console.WriteLine($"     |     |     ");
            Console.WriteLine("");
        }

        //Check Lines (Check Winner)
        protected override string CheckWinner()
        {
            string winner = null;
            if (
                //Horizontals
                (_spaces[0] == _spaces[1] && _spaces[1] == _spaces[2])
                || (_spaces[3] == _spaces[4] && _spaces[4] == _spaces[5])
                || (_spaces[6] == _spaces[7] && _spaces[7] == _spaces[8])
                //Verticals
                || (_spaces[0] == _spaces[3] && _spaces[3] == _spaces[6])
                || (_spaces[1] == _spaces[4] && _spaces[4] == _spaces[7])
                || (_spaces[2] == _spaces[5] && _spaces[5] == _spaces[8])
                //Diagonals
                || (_spaces[0] == _spaces[4] && _spaces[4] == _spaces[8])
                || (_spaces[2] == _spaces[4] && _spaces[4] == _spaces[6])
                )
            {
                winner = _marker;
            }
            else if(winner == null && _spaces.Distinct().Count() == 2)
            {
                winner = "stalemate";
            }
            return winner;
        }
        
        //Validate Space
        private int ValidateSpace(string[] spaces, string player)
        {
            string question = $"[{player}]: Please choose a space... ";
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
