using System;
using System.Collections.Generic;

namespace GameConsole
{
    public class Mastermind : OnePlayerGame
    {
        private readonly new List<string> _instructions = new List<string> { " What's the sequence of colors? ",
            " Each item can either be RED, BLUE, GREEN, or YELLOW. ",
            " Please type in the color's full name to select that color. ",
            " Type colors in sequence, using spaces between colors. ",
            " Do not use special characters, number, or colors not in the above list. " };

        private bool _solved;
        private int _numTries;
        private Sequence _sequence;
        private string[] _guess;



        public Mastermind(User player) : base(player, "Mastermind")
        {
            _player = player;
        }

        public override void Play()
        {
            
            _solved = false;
            _numTries = 1;
            UpdateGameDisplay();
            //Generate sequence
            string question = "How many colors should the sequence contain?... ";
            int size = Validation.GetValidatedInt(question);
            _sequence = new Sequence(size);
            _sequence.Display();
            //Play until soved
            while (_solved == false)
            {
                _guess = ValidateGuess();
                //Compare sequence to guess
                _solved = CheckWinner();
            }
            //Solved message
            UI.DisplaySuccess($"Congrats, you've solved the sequence!\r\n\r\nScore: {Score(_sequence)}");
            if (PlayAgain())
            {
                Play();
            }
        }

        protected override bool CheckWinner()
        {
            int numberCorrect = _sequence.Display(_guess);
            if(numberCorrect == _sequence.Size)
            {
                _player.AddAPoint();
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override void UpdateGameDisplay()
        {
            UI.DisplayTitle(_title);
            foreach (string instruction in _instructions)
            {
                UI.DisplayInfo(instruction);
            }
        }

        //Calculate Score
        private int Score(Sequence sequence)
        {
            int points = (sequence.Size * 100) / _numTries;
            return points;
        }

        private string[] ValidateGuess()
        {
            string question = "Please guess the color of each box, separating each color with a space... ";
            string response = Validation.GetValidatedString(question).ToUpper();
            string[] guess = response.Split(" ");
            while(guess.Length != _sequence.Size)
            {
                response = Validation.GetValidatedString(question).ToUpper();
                guess = response.Split(" ");
            }
            return guess;
        }
    }
}
