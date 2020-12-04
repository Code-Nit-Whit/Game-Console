using System;

namespace GameConsole
{
    public class Theme
    {
        //Fields

        //Properties
        public string Name { get; }
        private static ConsoleColor _text;
        private static ConsoleColor _background;
        private static ConsoleColor _title;
        private static ConsoleColor _success;
        private static ConsoleColor _error;
        private static ConsoleColor _info;


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

        public ConsoleColor[] GetColors()
        {
            ConsoleColor[] toReturn = { _text, _background, _title, _success, _error, _info};
            return toReturn;
        }

    }
}
