using System;
using System.Collections.Generic;

namespace GameConsole
{
    public class CrackTheCode : OnePlayerGame
    {
        private readonly new List<string> _instructions = new List<string>() { "Think you have what it takes to be a master code cracker?", "Let's find out!", "Using the hints to the right, try to figure out the correct code.", "-Hint: The code doesn't have any repeating numbers.-" };
        private string _filePath = "../../../CodesHintsDict.txt";
        private int _guesses;
        private string _guess;
        private List<Code> _availableCodes;
        private Random _rnd = new Random();
        private Code _currentCode;
        private bool _winner = false;

        public CrackTheCode(User player) : base(player, "Crack the Code")
        {
            _availableCodes = FileIO.LoadCodes(_filePath);
        }

        public override void Play()
        {
            SetACode();
            while(!_winner)
            {
                UpdateGameDisplay();
                //Prompt for a guess
                string question = "What is your guess?... ";
                _guess = Validation.GetValidatedString(question);
                _guesses += 1;
                //Check guess- use a method
                if (CheckWinner())
                {
                    DisplayWinner(true);
                    _winner = true;
                }
                else 
                {
                    DisplayWinner(false);
                    //Try again
                }
            }
            if (PlayAgain())
            {
                Play();
            }
            else
            {
                //Exit option
            }
        }

        private void SetACode()
        {
            _currentCode = _availableCodes[_rnd.Next(0, _availableCodes.Count - 1)];
            _guesses = 0;
        }

        protected override void UpdateGameDisplay()
        {
            //Use a consistent background and foreground color formatting for the sample codes (a method
            //Use color formatting on the forground of the hint text
            UI.DisplayTitle(_title);
            foreach(string instruction in _instructions)
            {
                UI.DisplayInfo(instruction);
            }
            //Add in total guesses display!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Console.WriteLine($"\r\n\r\nNumber of guesses: {_guesses}");
            //also figure out a neat display for both codes and hints
            Console.WriteLine("\r\n");
            Console.WriteLine(_currentCode.CodeName);
            DisplaySpecial("____   ____   ____");
            Console.WriteLine("\r\n");
            for (int i = 0; i < _currentCode.Hints.Count; i++)
            {
                DisplaySpecial(_currentCode.Hints[i]);
                Console.Write($": {_currentCode.HintBodies[i]}");
                Console.WriteLine("");
            }
        }

        protected override bool CheckWinner()
        {
            if (_guess == _currentCode.CodeName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Cool Formatting method for 3 digit code displays
        private void DisplaySpecial(string code)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(code);
            UI.SetColors();
        }
    }
}
