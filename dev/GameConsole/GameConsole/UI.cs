using System;
using System.Collections.Generic;


// Name: Whitaker, Codie
// Date: September 11th, 2020
// Course: APD
// Synopsis: CE05: Milestone 2


namespace GameConsole
{
    public class UI
    {
        public UI()
        {
        }



        //header- takes in a string and formats output
        public static void Header(string textOutput, bool lowerCase = false)
        {
            
                //Convert text to uppercase and have double lines above and below it
                Console.Clear();

                if (!lowerCase)
                {
                    textOutput = textOutput.ToUpper();
                }

                textOutput = $"\r\n========================================\r\n" +
                             $"      {textOutput}  " +
                             $"\r\n========================================\r\n\r\n";

                Console.Write(textOutput);

           
        }

        //footer- takes in a string and formats output
        public static void Footer(string textOutput)
        {
            Console.Clear();

            textOutput = $"\r\n========================================\r\n      {textOutput}  \r\n";

            SetSpecialForeground(textOutput);
        }

        //separator with text- takes in a string and formats output
        public static void Separator(string textOutput = null)
        {
            Console.WriteLine("\r\n\r\n------------------------");
            if (textOutput != null)
            {
                Console.WriteLine(textOutput);
            }
        }


        //Instructions- changes foreground color for instructions and then changes it back to the user's theme
        // once instructions are printed.
        public static void DisplayInstructions(List<string> instructions)
        {
            foreach (string instruction in instructions)
            {
                SetInstructionsForeground($"{instruction}");
            }
            Console.WriteLine("");
        }

        //Used to set main colors for user's theme 
        public static void SetDefaultTheme()
        {
            if (Program.User != null)
            {
                Console.ResetColor();
                Console.ForegroundColor = Program.User.Theme.MainForeground;
                Console.BackgroundColor = Program.User.Theme.MainBackground;
            }
            else 
            {
                Console.ResetColor();
            }
        }

        public static void SetSpecialForeground(string output)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(output);
            SetDefaultTheme();
        }

        public static void SetErrorForeground(string output)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(output);
            SetDefaultTheme();
        }

        public static void SetInstructionsForeground(string output)
        {
            Console.ForegroundColor = Program.User.Theme.InstructionsForeground;
            Console.WriteLine(output);
            SetDefaultTheme();
        }






        //For games not completed
        //Replace the call to this with the code to play the game
        public static void ComingSoon()
        {
            //Coming Soon Message
            string comingSoon = "Coming Soon!";
            string toExit = "Press any key to exit...";

            //Thanks
            UI.Header(comingSoon);
            Console.WriteLine("\r\nThank you for your patience...\r\n");


            //any key to exit
            UI.Separator();
            UI.SetErrorForeground(toExit);
            Console.ReadLine();

        }

    }
}
