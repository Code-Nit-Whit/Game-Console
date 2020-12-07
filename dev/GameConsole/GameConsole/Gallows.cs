﻿using System;
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

        public Gallows(string word, string definition)
        {
            _word = word;
            _definition = definition;
        }

        public void ComenceHanging()
        {
            //Loop- until user wins or misses 6 times
            bool winner = false;
            while (!winner && _misses.Count < 6)
            {
                UI.DisplayTitle(_title);
                Console.WriteLine($"Definition: {_definition}\r\n\r\n");
                DisplayWord();
                DisplayMisses();
                winner = PromptGuess();
            }
            //Display Win/Lost Hangman Message
            DisplayWinLoseResult(winner);
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

        private bool PromptGuess()
        {
            UI.Separator();
            Console.Write(" Choose a Letter: ");
            string response = Console.ReadLine();
            char[] word = _word.ToCharArray();
            char[] resp = response.ToUpper().ToCharArray();
            bool winner = false;
            while ((resp.Length > 1 || resp.Length < 1) || _guesses.Contains(resp[0]))
            {
                UI.Separator();
                Console.WriteLine("  Please only enter one letter, avoiding letters you've already guessed.");
                Console.Write(" Please choose a letter: ");
                response = Console.ReadLine();
                resp = response.ToUpper().ToCharArray();
            }

            _guesses.Add(resp[0]);


            if (!_word.Contains(resp[0]))
            {
                _misses.Add(resp[0]);

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
            }

            return winner;
        }

        private void DisplayWinLoseResult(bool winner)
        {
            char[] word = _word.ToCharArray();

            //If misses = 6, Lose
            if (_misses.Count == 6)
            {

                Console.WriteLine("You Lost.");
                Console.WriteLine($"The word was: {_word}.");
                Console.WriteLine("Maybe next time.");
            }
            else
            {
                UI.Footer("You Won!");
                Console.WriteLine($"The word was: {_word}.");
                //Display the answer?

                Console.ReadLine();
            }

        }
    }
}