using System;
using System.Collections.Generic;

namespace GameConsole
{
    public class Gallows
    {
        private string _title = "Hangman- The Gallows";
        private string _word;
        private string _definition;
        private List<char> _guesses = new List<char>();
        private List<char> _misses = new List<char>();
        private bool _winner = false;
        private bool _loser = false;

        public bool Winner { get { return _winner; } }

        public Gallows(string word, string definition)
        {
            _word = word;
            _definition = definition;
        }

        public void ComenceHanging()
        {
            UI.DisplayTitle(_title);
            Console.WriteLine($"Definition: {_definition}\r\n\r\n");
            //User gets 6 misses before they lose
            while (!_loser && !_winner)
            {
                DisplayWord();
                DisplayMisses();
                char guess = PromptGuess();
                CheckGuess(guess);
            }
        }
        private void DisplayWord()
        {
            char[] word = _word.ToCharArray();
            for (int i = 0; i < word.Length; i++)
            {
                if (!_guesses.Contains(word[i]))
                {
                    Console.Write("_ ");
                }
                else
                {
                    Console.Write($"{word[i]} ");
                }
            }
        }
        private void DisplayMisses()
        {
            Console.Write("\r\nUsed Letters: ");
            foreach (char miss in _misses)
            {
                Console.Write($"{miss}, ");
            }
        }

        private char PromptGuess()
        {
            string question = "Choose a Letter: ";
            string response = Validation.GetValidatedString(question);
            char[] resp = response.ToUpper().ToCharArray();
            while ((resp.Length > 1 || resp.Length < 1) || _guesses.Contains(resp[0]))
            {
                UI.DisplayError("Please only enter one letter, avoiding letters you've already guessed.");
                response = Validation.GetValidatedString(question);
                resp = response.ToUpper().ToCharArray();
            }
            _guesses.Add(resp[0]);
            return resp[0];
        }

        private void CheckGuess(char c)
        {
            if (!_word.Contains(_guesses[_guesses.Count-1]))
            {
                _misses.Add(_guesses[_guesses.Count - 1]);
                if (_misses.Count == 6)
                {
                    _loser = true;
                }

            }
            else
            {
                bool winner = true;
                for (int i = 0; i < _word.Length; i++)
                {
                    if (!_guesses.Contains(_word[i]))
                    {
                        winner = false;
                    }
                }
                _winner = winner;
            }
        }
    }
}