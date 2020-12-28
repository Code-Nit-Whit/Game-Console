using System;
using System.IO;

using System.Collections.Generic;

namespace CodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> codes = new List<string>();
            for(int i = 12; i <= 987; i++)
            {
                string toAdd = FormatCode(i);
                if (!CheckForRepeatDigits(toAdd))
                {
                    codes.Add(toAdd);
                }
            }

            //Generate Hints
            List<List<string>> allHints = new List<List<string>>();
            foreach(string code in codes)
            {
                Hints hints = new Hints(code);
                allHints.Add(hints._hintCodes);
            }
            
            Dictionary<string, List<string>> codesAndHints= new Dictionary<string, List<string>>();
            for (int i = 0; i < codes.Count; i++)
            {
                codesAndHints.Add(codes[i], allHints[i]);
            }

            Console.WriteLine($"There are {codes.Count} codes. Save?... [Hit Enter to save]");

            //Save the list to a txt file
            string filePath = "../../../CodesHintsDict.txt";
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach(KeyValuePair<string, List<string>> kvp in codesAndHints)
                {
                    string toAdd = FormatSaveData(kvp.Key, kvp.Value);
                    sw.WriteLine(toAdd);
                }
            }
        }

        private static bool CheckForRepeatDigits(string number)
        {
            bool hasRepeats = false;
            foreach(char digit in number)
            {
                int first = number.IndexOf(digit);
                int last = number.LastIndexOf(digit);
                if (first != last)
                {
                    hasRepeats = true;
                }
            }
            return hasRepeats;
        }


        private static string FormatCode(int number)
        {
            string num = number.ToString();
            while(num.Length < 3)
            {
                num = "0" + num;
            }
            return num;
        }

        private static string FormatSaveData(string code, List<string> hints)
        {
            string returner = $"{code}:{hints[0]}:{hints[1]}:{hints[2]}:{hints[3]}:{hints[4]}";
            return returner;
        }
    }
}
