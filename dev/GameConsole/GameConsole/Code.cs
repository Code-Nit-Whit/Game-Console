using System;
using System.Collections.Generic;

namespace GameConsole
{
    public class Code
    {
        


        public List<int> CodeDigits  { get; }


        public Code(int length)
        {
            //Construct the random code
            //No repeating numers
            //Make code length dynamic for future updates (different levels)
            //Use private method for easy reading and privacy of code
            CodeDigits = new List<int>() { 11,11,11 };
            
            for (int i = 0; i < length; i++)
            {
                CodeDigits[i] = AddDigit();
            }
        }

        private int AddDigit()
        {
            Random rnd = new Random();
            int randomDigit = rnd.Next(0, 10);
            while(CodeDigits.Contains(randomDigit))
            {
                randomDigit = rnd.Next(0,10);
            }
            return randomDigit;
        }
    }
}
