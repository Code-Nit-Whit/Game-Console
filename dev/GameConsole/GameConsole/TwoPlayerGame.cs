using System;
using System.Collections.Generic;

namespace GameConsole
{
    public abstract class TwoPlayerGame : Game
    {
        protected User _playerTwo;

        public TwoPlayerGame(User player, string title) : base(player, title)
        {
        }

        public void LogInSecondPlayer()
        {
            UI.DisplaySuccess("\r\nYou need to log in with a second user to play a two player game.");
            UI.Continue();
            _playerTwo = User.LogIn();
            UI.DisplayTitle("Player 2 Loaded");
            UI.DisplaySuccess($"Welcome, {_playerTwo.Username}, you are Player Two!");
            DisplayUserStats();
        }

        protected void DisplayUserStats()
        {
            string[] playerOneData = _player.GetPlayerData(_title);
            string[] playerTwoData = _playerTwo.GetPlayerData(_title);
            //display each username, age, total score, and game specific score
            string[] playersData = {
                $"Player One|Player Two",
                $"{playerOneData[0]}|{playerTwoData[0]}",
                $"Age: {playerOneData[1]}|Age: {playerTwoData[1]}",
                $"Total Wins: {playerOneData[2]}|Total Wins: {playerTwoData[2]}",
                $"Total {_title} Wins: {playerOneData[3]}|Total {_title} Wins: {playerTwoData[3]}"
            };
            string[] splitters = { "|" };
            List<string> formattedPlayersData = UI.DisplayColumns(playersData, splitters);

            UI.DisplayTitle("Versus Scorecard");
            foreach(string dataPoint in formattedPlayersData)
            {
                UI.DisplayInfo(dataPoint);
            }
            UI.Continue();
        }

        protected abstract string CheckWinner();

        protected virtual void DisplayWinner(string winner)
        {
            UI.DisplayTitle("Match Results...");
            //Display winner
            if (winner != "stalemate")
            {
                UI.DisplaySuccess($"Winner: {winner}!");
                UI.Continue();
            }
            else if (winner == "stalemate")
            {
                UI.DisplayError("Oops, looks like a Stalemate!");
                UI.Continue();

            }
            DisplayUserStats();
        }
    }
}
