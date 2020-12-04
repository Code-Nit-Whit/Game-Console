using System;
using System.Collections.Generic;

namespace GameConsole
{
    public class Theme
    {
        //Fields

        //Properties
        public string Name { get; }
        private ConsoleColor _text;
        private ConsoleColor _background;
        private ConsoleColor _title;
        private ConsoleColor _success;
        private ConsoleColor _error;
        private ConsoleColor _info;


        public Theme(string name, string text, string background, string title, string success, string error, string info)
        {
            Name = name;
            //Figure out how to convert a string to console color
            _text = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), text);
            _background = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), background);
            _title = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), title);
            _success = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), success);
            _error = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), error);
            _info = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), info);
        }

        public List<ConsoleColor> GetColors()
        {
            List<ConsoleColor> toReturn = new List<ConsoleColor>{ _text, _background, _title, _success, _error, _info};
            return toReturn;
        }
    }
}
