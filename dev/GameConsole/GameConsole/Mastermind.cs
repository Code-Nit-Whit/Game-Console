using System;
using System.Collections.Generic;


// Name: Whitaker, Codie
// Date: September 11th, 2020
// Course: APD
// Synopsis: CE05: Milestone 2


namespace GameConsole
{
    public class Mastermind
    {

        private User _player;
        private string _title = "MASTERMIND";
        private List<string> _instructions = new List<string> { " What's the sequence of colors? ",
            " Each item can either be RED, BLUE, GREEN, or YELLOW. ",
            " Please type in the color's full name to select that color. ",
            " Type colors in sequence, using spaces to separate each color. ",
            " Do not use special characters, number, or colors not in the above list. " };

        private bool _solved;
        private int _numTries;



        public Mastermind(User player)
        {
            _player = player;
            _solved = false;
            _numTries = 1;

        }

        public void Play()
        {
            UI.Header(_title);

            //Display instructions
            UI.DisplayInstructions(_instructions);

            //Generate sequence
            string textOutput = " How many colors should the sequence contain? ";
            UI.Separator(textOutput);
            int size = Validation.IntergerValidation(Console.ReadLine(), textOutput);

            Sequence sequence = new Sequence(size, _player);
            sequence.Display();

            //Play until soved
            while (_solved == false)
            {
                textOutput = " Please guess the color of each box, separating each color with a space...";
                UI.Separator(textOutput);
                string response = Validation.StringValidation(Console.ReadLine().ToUpper(), textOutput);
                string[] guess = response.Split();

                //Compare sequence to guess
                int numCorrect = sequence.Display(guess);
                if (numCorrect < sequence.Size)
                {
                    Console.WriteLine($"  {numCorrect} Correct, try again. ");
                    UI.Separator();
                    Console.WriteLine("");
                    _numTries++;
                }
                else
                {

                    _solved = true;
                }
            }

            //Solved message
            textOutput = $"  Congrats, you've solved the sequence!\r\n  Score: {Score(sequence)} ";
            UI.Header(textOutput);
        }

        //Calculate Score
        public int Score(Sequence sequence)
        {

            int points = (sequence.Size * 100) / _numTries;

            return points;

        }

        
    }
}
