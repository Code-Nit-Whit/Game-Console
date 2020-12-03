using System;

namespace GameConsole
{
    public class Validation
    {
        //Validate string response is not left empty
        public static string GetValidatedString(string question, string response = null)
        {
            if (response == null)
            {
                UI.AskQuestion(question);
                response = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(response))
            {
                UI.DisplayError("\r\nPlease do not leave this empty!");
                response = GetValidatedString(question);
            }

            return response;
        }

        //Valdate response is an interger
        public static int GetValidatedInt(string question, string response = null)
        {
            if (response == null)
            {
                UI.AskQuestion(question);
                response = Console.ReadLine();
            }
            int number;
            while (!int.TryParse(response, out number))
            {
                UI.DisplayError("\r\nPlease enter a valid whole number!");
                UI.AskQuestion(question);
                response = Console.ReadLine();
            }

            return number;
        }

        public static decimal GetValidatedDecimal(string question, string response = null)
        {
            if (response == null)
            {
                UI.AskQuestion(question);
                response = Console.ReadLine();
            }
            decimal number;
            while (!decimal.TryParse(response, out number))
            {
                UI.DisplayError("\r\nPlease enter a valid decimal number!");
                UI.AskQuestion(question);
                response = Console.ReadLine();
            }
            return number;
        }

        //Validate Range of numbers, send in high and low
        public static int GetValidatedRange(string question, int[] range, string response = null)
        {
            if (response == null)
            {
                UI.AskQuestion(question);
                response = Console.ReadLine();
            }
            int number = GetValidatedInt(question, response);
            while (number < range[0] || number > range[1])
            {
                UI.DisplayError($"Please choose a number between {range[0]} and {range[1]}! ");
                number = GetValidatedInt(question);
            }

            return number;
        }

        //Validate a condition
        public static string GetValidatedConditional(string question, string[] conditionals, string response = null)
        {
            if (response == null)
            {
                UI.AskQuestion(question);
                response = GetValidatedString(question, Console.ReadLine());
            }
            while (response.ToLower() != conditionals[0].ToLower() && response.ToLower() != conditionals[1].ToLower())
            {
                UI.DisplayError($"Please only enter {conditionals[0]} or {conditionals[1]}!");
                response = GetValidatedString(question);
            }

            return response.ToLower();
        }

    }
}