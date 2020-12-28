using System;
using System.Collections.Generic;

namespace GameConsole
{
    public static class UI
    {

        
        //Fields
        private static string _themesFilePath = "../../../themes.txt";
        private static List<Theme> _availableThemes;
        private static Theme _currentTheme;
        private static List<ConsoleColor> _currentColors;


        //THEME MANAGEMENT
        //
        //
        public static void LoadThemes()
        {
            _availableThemes = FileIO.LoadThemes(_themesFilePath);
        }

        public static Theme FindTheme(string theme)
        {
            Theme newTheme = null;
            for(int i = 0; i < _availableThemes.Count; i++)
            {
                if(theme == _availableThemes[i].Name)
                {
                    newTheme = _availableThemes[i];
                }
            }
            return newTheme;
        }

        public static void SetTheme(Theme newTheme)
        {
            _currentTheme = newTheme;
            _currentColors = newTheme.GetColors();
            SetColors();
        }

        public static Theme SelectThemeMenu()
        {
            //NEED TO MAKE DYNAMIC
            //Make it a menu
            string[] themeMenuArr = new string[_availableThemes.Count];
            for(int i = 0; i < _availableThemes.Count; i++)
            {
                themeMenuArr[i] = _availableThemes[i].Name;
            }
            Menu themeMenu = new Menu("Select a Theme", "Back");
            themeMenu.AddMenuItems(themeMenuArr);
            themeMenu.Display(true);
            string question = "Please select a theme from above [1,2]... ";
            int[] range = { 0, themeMenu.NumItems };
            int selection = Validation.GetValidatedRange(question, range);
            return HandleSelection(selection);
        }
        private static Theme HandleSelection(int selection)
        {
            if(selection != 0)
            {
                return _availableThemes[selection - 1];
            }
        }


        //COLOR & FORMATTING
        //
        //
        //Set Colors
        public static void SetColors()
        {
            Console.ForegroundColor = _currentColors[0];
            Console.BackgroundColor = _currentColors[1];
        }

        //Display a title
        public static void DisplayTitle(string text)
        {
            SetColors();
            Console.Clear();
            Console.ForegroundColor = _currentColors[2];
            Console.WriteLine("==============================");
            Console.WriteLine($"       {text}   ");
            Console.WriteLine("==============================\r\n\r\n");
            SetColors();
        }

        public static void DisplaySuccess(string text)
        {
            Console.ForegroundColor = _currentColors[3];
            Console.WriteLine(text);
            SetColors();
        }

        public static void DisplayError(string text)
        {
            Console.ForegroundColor = _currentColors[4];
            Console.WriteLine("");
            Console.WriteLine(text);
            SetColors();
        }
        public static void DisplayInfo(string str)
        {
            Console.WriteLine("");
            Console.ForegroundColor = _currentColors[5];
            Console.Write(str);
            SetColors();
        }




        //MISC USER INTERACTIVITY- Getting user input
        //
        //
        public static void Continue()
        {
            AskQuestion("Press enter to continue... ");
            Console.ReadLine();
        }
        //A way of taking user input without any validation
        public static void AskQuestion(string question)
        {
            Console.WriteLine("\r\n\r\n---------------------");
            Console.Write(question);
        }
        //Coming Soon!!!
        public static void ComingSoon()
        {
            DisplayTitle("Coming Soon!!");
            DisplaySuccess("This page is currently under sonstruction. Thank you for your patience.");
            Continue();
        }





        //SPECIAL FORMATTING
        //
        //

        //Each of these overloads are available to use independently, and are
        //recursively called in reverse order. Basically you can jump into these overloads
        //with any number of strings to columnize, or any number of splits that need
        //to happen with each string.
        //
        //
        //The first overload will take 2 strings and add space to the front of
        //the shorter one, if they're not equal
        //
        //The second overload takes in a list of string outputs, finds the one
        //with the largest index, and adds whitespace to the front of the rest
        //until they are all the same length. It recursively utilizes the first
        //overload to add the whitespace each time
        //
        //The third takes an array of strings and an array of splitters. It
        //cycles through each splitter, spliting each output string with it and
        //sending a list of the first substring of each split to be columnized
        //by the second overload (reccursion). It then adds the columnized strings
        //into a list to return back. It does this with each splitter, concatenating
        //the result of each recurssion of overload #2 to its respective string in
        //the return list. Took some work to keep this code from jumbling up strings...
        //
        //
        //Would be cool to give this method dynamic alignment functionality...
        //like passing in Center, Left, or Right to adjust where the whitespace is added.
        //but not this week.
        public static List<string> DisplayColumns(string str1, string str2)
        {
            if (str1.Length == str2.Length)
            {
                List<string> returnList = new List<string>() { str1, str2 };
                return returnList;
            }
            else
            {
                string largestString = str1.Length > str2.Length ? str1 : str2;
                string smallestString = str1.Length > str2.Length ? str2 : str1;
                int difference = largestString.Length - smallestString.Length;
                List<string> returnList = new List<string>();
                returnList.Add(largestString);
                for (int i = 1; i <= difference; i++)
                {
                    smallestString = " " + smallestString;
                }
                returnList.Add(smallestString);
                return returnList;
            }
        }
        public static List<string> DisplayColumns(List<string> outputs)
        {
            List<string> newOutputs = new List<string>();
            int largestStrIndex = FindLargestString(outputs);
            if (largestStrIndex != -1)
            {
                string largestString = outputs[largestStrIndex];
                //newOutputs.Add(largestString);
                outputs.RemoveAt(largestStrIndex);
                for (int i = 0; i < outputs.Count; i++)
                {
                    List<string> toAdd = DisplayColumns(largestString, outputs[i]);
                    newOutputs.Add(toAdd[1]);
                }
                //Try adding the largest array at a specific index here, shifting the rest
                newOutputs.Insert(largestStrIndex, largestString);
                return newOutputs;
            }
            else
            {
                return outputs;
            }
        }
        public static List<string> DisplayColumns(string[] outputs, string[] splitters)
        {
            List<string> finishedStrings = new List<string>();
            for (int i = 0; i < outputs.Length; i++)
            {
                finishedStrings.Add("");
            }
            string[] workingOutputs = (string[])outputs.Clone();
            //For each splitter + 1
            for (int i = 0; i <= splitters.Length; i++)
            {
                List<string> toColumize = new List<string>();
                //If we havent used all the splitters
                if (i < splitters.Length)
                {
                    //Split each string 
                    for (int j = 0; j < workingOutputs.Length; j++)
                    {
                        string[] splitString = workingOutputs[j].Split(splitters[i], 2);
                        toColumize.Add(splitString[0]);
                        workingOutputs[j] = splitString[1];
                    }
                }
                else
                {
                    for (int j = 0; j < workingOutputs.Length; j++)
                    {
                        toColumize.Add(workingOutputs[j]);
                    }
                }
                //columnize the first half of each string
                List<string> columnized = DisplayColumns(toColumize);
                //Add the columns to the output
                for (int j = 0; j < columnized.Count; j++)
                {
                    if (i < splitters.Length)
                    {
                        finishedStrings[j] = finishedStrings[j] + columnized[j] + splitters[i];
                    }
                    else
                    {
                        finishedStrings[j] = finishedStrings[j] + columnized[j];
                    }
                }
            }
            return finishedStrings;
        }
        private static int FindLargestString(List<string> outputs)
        {
            int index = -1;
            bool same = true;

            //Find the longest string in the array and return the index of it
            //Used by the second overload of DisplayColumns
            for (int i = 0; i < outputs.Count; i++)
            {

                if (i > 0)
                {
                    index = outputs[i].Length > outputs[index].Length ? i : index;
                    same = (outputs[i].Length == outputs[i - 1].Length && !same == false);
                }
                else
                {
                    index = i;
                }
            }

            return same ? -1 : index;
        }
    }
}