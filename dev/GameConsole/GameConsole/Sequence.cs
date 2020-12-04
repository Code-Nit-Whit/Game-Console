using System;
using System.Collections.Generic;

namespace GameConsole
{
    public class Sequence
    {
        private Random _random = new Random();
        private readonly string[] _colors = { "RED", "BLUE", "GREEN", "YELLOW" };
        private List<string> _solution = new List<string>();

        //Properties
        public int Size { get; set; }

        //Constructor
        public Sequence(int length)
        {
            Size = length;
            for (int i = 0; i < Size; i++)
            {
                string color = _colors[_random.Next(0, _colors.Length)];
                _solution.Add(color);
            }
        }

        //Display sequence (guess optional)
        public int Display(string[] guess = null)
        {
            int correct = 0;
            //Display
            Console.WriteLine("");
            for (int i = 0; i < _solution.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                if (guess != null && _solution[i] == guess[i].ToUpper())
                {
                    correct++;
                    Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), _solution[i], true);
                }
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.Write(" \u2588\u2588 ");
            }
            Console.WriteLine("");
            //Reset colors to user setting
            UI.SetColors();
            //Return number of correct items
            return correct;
        }
    }
}
