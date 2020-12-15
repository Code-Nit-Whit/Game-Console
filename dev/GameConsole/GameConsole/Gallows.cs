using System;
using System.Collections.Generic;

namespace GameConsole
{
    public class Gallows
    {
        private string _title = "The Gallows";
        private string _word;
        private string _definition;
        private List<char> _guesses = new List<char>();
        private List<char> _misses = new List<char>();
        private bool _winner = false;
        private bool _loser = false;

        public bool Winner { get { return _winner; } }
        public bool Loser { get { return _loser; } }

        public Gallows(string word, string definition)
        {
            _word = word;
            _definition = definition;
        }

        public void ComenceHanging()
        {
            UI.DisplayTitle(_title);
            Console.WriteLine($"Definition: {_definition}\r\n\r\n");
            DisplayWord();
            DisplayMisses();
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
            UI.Separator();
            Console.Write("\r\nUsed Letters: ");
            foreach (char miss in _misses)
            {
                Console.Write($"{miss}, ");
            }
        }

        public char PromptGuess()
        {
            string question = "Choose a Letter: ";
            UI.AskQuestion(question);
            string response = Validation.GetValidatedString(question);
            char[] resp = response.ToUpper().ToCharArray();
            while ((resp.Length > 1 || resp.Length < 1) || _guesses.Contains(resp[0]))
            {
                UI.DisplayError("Please only enter one letter, avoiding letters you've already guessed.");
                UI.AskQuestion(question);
                response = Validation.GetValidatedString(question);
                resp = response.ToUpper().ToCharArray();
            }
            _guesses.Add(resp[0]);
            return resp[0];
        }

        public void CheckGuess(char c)
        {
            /*if (!_word.Contains(_guesses[_guesses.Count-1]))
            {
                _misses.Add([_guesses.Count - 1]);

            }
            else
            {

                winner = true;
                for (int i = 0; i < word.Length; i++)
                {
                    if (!_guesses.Contains(word[i]))
                    {
                        winner = false;
                    }
                }
            }*/

            return winner;
        }
    }
}