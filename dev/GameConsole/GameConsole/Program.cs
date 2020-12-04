using System;
using System.Collections.Generic;

namespace GameConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            GameConsole gc = new GameConsole();
            gc.Init();
        }

        public static void RestartConsole()
        {
            GameConsole newGC = new GameConsole();
            newGC.Init();
        }
    }// end of class
}
