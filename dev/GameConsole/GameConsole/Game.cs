using System;
using System.Collections.Generic;

namespace GameConsole
{
    public abstract class Game
    {
        protected User _player;
        protected readonly string _title;
        protected List<string> _instructions;

        public Game(User player, string title)
        {
            _player = player;
            _title = title;
        }

        public abstract void Play();
        protected abstract string CheckWinner();
        protected abstract void UpdateGameDisplay();

        protected virtual void Display2PWinner(string winner)
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
        protected virtual void Display1PWinner(bool didWin)
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
