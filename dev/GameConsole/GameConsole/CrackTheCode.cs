using System;
using System.Collections.Generic;

namespace GameConsole
{
    public class CrackTheCode : OnePlayerGame
    {
        private readonly new List<string> _instructions = new List<string>() { "Think you have what it takes to be a master code cracker?", "Let's find out!", "Using the hints to the right, try to figure out the correct code.", "-Hint: The code doesn't have any repeating numbers.-" };
        private string _filePath = "../../../CodesAndHintsDict.txt";
        private int _guesses;
        private List<string> _hints;
        private string _guess;
        private List<Code> _availableCodes;
        private Random _rnd = new Random();

        public Code CurrentCode { get; set; } 
        public User Player { get; set; }

        public CrackTheCode(User player) : base(player, "Crath the Code")
        {
            _availableCodes = FileIO.LoadCodes(_filePath);
            _guesses = 0;
            CurrentCode = _availableCodes[_rnd.Next(0, _availableCodes.Count-1)];
        }

        public override void Play()
        {
            UpdateGameDisplay();


            string report = "";
            bool keepGuessing = true;
            while (keepGuessing)
            {
                UpdateGameDisplay();

            //Prompt for a guess
                Console.WriteLine("");
                Console.WriteLine("");
                UI.Separator();
                Console.WriteLine(report);
                string codePrompt = " What is the code? ";

                    
                Console.Write(codePrompt);
                int guess = ValidateResponse(Console.ReadLine(), codePrompt);

                //Check guess- use a method
                keepGuessing = CheckWinner(guess);
                if (keepGuessing)
                {
                    report = "  Incorrect, try again";
                }
            }
            
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
            Console.WriteLine("\r\n\r\n");
            foreach (/*hint in list*/)
            {
                Console.Write("\r\n");
                foreach (int digit in kvp.Key)
                {
                    Console.Write($"{digit} ");
                }
                Console.Write($": {kvp.Value}");
            }
            
        }

        private int ValidateResponse(string response, string question)
        {
            int number = Validation.IntergerValidation(response, question);
            while (number < 012 || number > 987) //The lowest and max you could go without repeating numbers
            {
                Console.WriteLine("  Please enter a three digit number like the hints. The code cannot have repeating numbers...");
                Console.WriteLine(question);
                number = Validation.IntergerValidation(Console.ReadLine(), question);
            }

            return number;
        }

        protected override bool CheckWinner()
        {


            if(guess == ConvertingList())
            {
                UI.Header($"Congrats! You got it! The code was... ");
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(Code.CodeDigits[i]);
                }
                Console.WriteLine("");
                Console.WriteLine($"Number of Guesses: {_guesses}");

                
            }
            else
            {
                UI.Separator("  Not quite. Try again!");
               
                _guesses++;
            }

            return (guess == ConvertingList()) ? false : true;
        }

        private int ConvertingList()
        {
            string codeString = "";
            int codeNumber = 0;
            foreach(int digit in Code.CodeDigits)
            {
                codeString = $" {codeString}{digit.ToString()}";
                
            }
            codeString.Trim();
            codeNumber = Int32.Parse(codeString);

            return codeNumber;
        }
    }
}
