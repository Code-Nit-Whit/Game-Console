using System;
namespace GameConsole
{
    public abstract class TwoPlayerGame : Game
    {
        protected User _playerTwo;

        public TwoPlayerGame(User player, User playerTwo, string title) : base(player, title)
        {
            _playerTwo = playerTwo;
        }

        protected void DisplayUserStats()
        {
            UI.ComingSoon();
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
        }
    }
}
