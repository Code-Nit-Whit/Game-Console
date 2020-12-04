using System;
namespace GameConsole
{
    public abstract class OnePlayerGame : Game
    {
        public OnePlayerGame(User player, string title) : base(player, title)
        {
        }

        protected abstract bool CheckWinner();

        protected virtual void DisplayWinner(bool didWin)
        {
            UI.DisplayTitle("Game Results...");
            if (didWin)
            {
                UI.DisplaySuccess($"Winner!");
                UI.Continue();
            }
            else
            {
                UI.DisplayError($"Loser :(");
                UI.Continue();
            }
        }
    }
}