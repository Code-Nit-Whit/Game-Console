using System;
using System.Collections.Generic;
using System.IO;

namespace GameConsole
{
    public class Theme
    {
        //Fields
        private List<ConsoleColor> ThemeColorList;

        //Properties
        public string Name { get; set; }
        public ConsoleColor MainForeground { get; set; }
        public ConsoleColor InstructionsForeground { get; set; }
        public ConsoleColor MainBackground { get; set; }


        public Theme(string theme)
        {
            Name = theme;

            if (theme == "light")
            {
                GetThemeColorList(0);
            }
            else if (theme == "dark")
            {
                GetThemeColorList(1);
            }

            MainForeground = ThemeColorList[0];
            InstructionsForeground = ThemeColorList[1];
            MainBackground = ThemeColorList[2];
        }

        private void GetThemeColorList(int iterator)
        {
            string correctLine = "";

            string path = "../../../Themes.txt";
            using (StreamReader sr = new StreamReader(path))
            {
                
                string line;
                int lineNumber = 0;
                while ((line = sr.ReadLine()) != null && correctLine == "")
                {
                    if (iterator == lineNumber)
                    {
                        correctLine = line;
                    }
                    else
                    {
                        lineNumber++;
                    }
                }
            }

            string[] data = correctLine.Split(':');
            ThemeColorList = new List<ConsoleColor>();
            for (int i = 0; i < data.Length; i++)
            {
                ThemeColorList.Add((ConsoleColor)Enum.Parse(typeof(ConsoleColor), data[i]));
            }
            
        }
    }
}
