/*using System;
using System.Collections.Generic;





namespace GameConsole
{
    public class CrackTheCode
    {
        

        //fields
        private string _title = "Crack the Code";
        private int _guesses;
        private bool _ready = true;
        private List<string> _instructions = new List<string>() { "Think you have what it takes to be a master code cracker?", "Let's find out!", "Using the hints to the right, try to figure out the correct code.", "-Hint: The code doesn't have any repeating numbers.-"};
        private Hints _hints;

        public Code Code { get; set; } 
        public User Player { get; set; }

        public CrackTheCode(User player)
        {
            if (_ready)
            {
                _guesses = 0;
                Player = player;
                Code = new Code(3);
                _hints = new Hints(Code.CodeDigits);
                
            }
        }






        public void Play()
        {
            
            
            
                UI.Header(_title);

                UI.DisplayInstructions(_instructions);

                UI.Separator();


                string report = "";
                bool keepGuessing = true;
                while (keepGuessing)
                {
                    DisplayHints();

                //Prompt for a guess
                    Console.WriteLine("");
                    Console.WriteLine("");
                    UI.Separator();
                    Console.WriteLine(report);
                    string codePrompt = " What is the code? ";

                    
                    Console.Write(codePrompt);
                    int guess = ValidateResponse(Console.ReadLine(), codePrompt);

                    //Check guess- use a method
                    keepGuessing = CheckGuess(guess);
                    if (keepGuessing)
                    {
                        report = "  Incorrect, try again";
                    }
                }
            
        }





        private void DisplayHints()
        {
            //Use a consistent background and foreground color formatting for the sample codes (a method
            //Use color formatting on the forground of the hint text
            Console.Clear();
            foreach (KeyValuePair<int[], string> kvp in _hints.HintsList)
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

        private bool CheckGuess(int guess)
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
}*/
