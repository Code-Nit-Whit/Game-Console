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
        protected abstract void UpdateGameDisplay();

        protected bool PlayAgain()
        {
            string question = "Would you like to play again? [y,n]... ";
            string[] conditionals = { "y", "n" };
            string response = Validation.GetValidatedConditional(question, conditionals);
            return response == "y" ? true : false;
        }
    }
}
