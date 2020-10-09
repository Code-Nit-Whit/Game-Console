using System;
using System.Threading;
using System.Collections.Generic;


// Name: Whitaker, Codie
// Date: September 11th, 2020
// Course: APD
// Synopsis: CE05: Milestone 2

namespace GameConsole
{
    public class Validation
    {
        
        //Checks that something was entered- use after question has been asked 1 time
        //Need the original question to restate
        public static string StringValidation(string response, string question)
        {
            while(String.IsNullOrWhiteSpace(response))
            {
                //Error message and restated question
                UI.SetErrorForeground($"\r\nPlease do not leave this empty. {question}...");
                response = Console.ReadLine();
            }

            return response;
        }

        //Checks that response is an interger- use after question has been asked 1 time
        //Needs the original question to restate
        public static int IntergerValidation(string response, string question)
        {
            int number;
            while (!int.TryParse(response, out number))
            {
                //Error message and restated question
                UI.SetErrorForeground($"\r\nPlease enter a valid, whole number.");
                Console.Write(question);
                response = Console.ReadLine();
            }

            return number;
        }

        //Checks that number is within range
        //Takes string respone, calles IntergerValidation() method to convert to int
        //Takes min and max int range, checks that returned int value is within that range
        //Returns int that is within range when the user finally selects one
        public static int RangeValidation(int lowLimit, int highLimit, string response, string question)
        {
            int responseNumber = IntergerValidation(response, question);
            while(responseNumber > highLimit || responseNumber < lowLimit)
            {
                //Error message and restated question
                UI.SetErrorForeground($"\r\nPlease enter a valid selection. [1, 2, 3, ...] \r\n ");
                responseNumber = IntergerValidation(Console.ReadLine(), question);
            }

            return responseNumber;
        }



        public static string ValidateWhitelist(string response, List<string> correctAnswers)
        {
            while (!correctAnswers.Contains(response))
            {
                UI.SetErrorForeground("Invalid response.");
                Console.Write("Try again... ");
                response = Console.ReadLine();
            }

            return response;
        }

        public static int ValidateHighestNumber(List<int> numbers)
        {
            numbers.Sort();
            int highestNumber = numbers[numbers.Count - 1];

            return highestNumber;
        }






        //Allow user to run application again
        //Allows user to choose whether to play again
        //Returns bool true to Pllay() method is user wants to play again
        //Calls Thanks() method ["Thanks for playing"] is user selects no
        public static bool PlayAgain()
        {
            string textOutput = "Would you like to start another game? [Y/N]: ";
            UI.Separator(textOutput);

            string response = ValidateYesNo(Console.ReadLine(), textOutput);


            bool keepPlaying = false;
            switch (response.ToUpper())
            {
                case "Y":
                    keepPlaying = true;
                    break;

                case "N":
                    Thanks();
                    keepPlaying = false;
                    break;
            }
            return keepPlaying;
        }


        //Validate a yes or no response
        public static string ValidateYesNo(string response, string question)
        {
            //Validate Yes or No response
            while (response.ToUpper() != "Y" && response.ToUpper() != "N")
            {
                //Error message and restated question
                UI.SetErrorForeground("Please respond with a Y or a N. \r\n");
                Console.Write(question);
                //Re-Catch Response
                response = Console.ReadLine();
            }

            return response;
        }


        //Thanks the user for playing
        //Plays for 1.5 seconds before allowing the main while loop to display the menu again. 
        public static void Thanks()
        {
            string thanks = "Thank you for playing!";
            UI.Footer(thanks);
            Thread.Sleep(1500);
        }
    }
}
