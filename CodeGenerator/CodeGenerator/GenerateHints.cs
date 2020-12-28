using System;
using System.Collections.Generic;

namespace CodeGenerator
{
    public class Hints
    {
        //fields
        public List<string> _hintCodes;
        private Random _rnd = new Random();
        private List<int> _codeDigits;


        public Hints(string code)
        {
            _codeDigits = GetCodeDigits(code);

            _hintCodes = new List<string>();
            //Instantiate _hintCodes
            for (int i = 0; i < 5; i++)
            {
                string validated = CreateHintCode(_codeDigits, i + 1);
                while(CheckForRepeatingHints(validated))
                {
                    validated = CreateHintCode(_codeDigits, i + 1);
                }
                _hintCodes.Add(validated);
            }
        }

        private List<int> GetCodeDigits(string code)
        {
            List<int> digits = new List<int>();
            foreach(char digit in code)
            {
                string dig = digit.ToString();
                digits.Add(int.Parse(dig));
            }
            return digits;
        }


        private string CreateHintCode(List<int> codeDigits, int i)
        {
            string hintNumber = ""; //Will return 000 for everything until conditional hints are set in switch case

            switch (i)
            {
                case 1:
                    hintNumber = GenerateFirstHint();
                    break;

                case 2:
                    hintNumber = GenerateSecondFifthHint();
                    break;

                case 3:
                    hintNumber = GenerateThirdHint();
                    break;

                case 4:
                    hintNumber = GenerateFourthHint();
                    break;

                case 5:
                    hintNumber = GenerateSecondFifthHint();
                    break;
            }

            return hintNumber;
        }

        private bool CheckForRepeatingHints(string toValidate)
        {
            if(_hintCodes.Contains(toValidate))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Hint generators

        private string GenerateFirstHint()
        {
            int[] codeHintDigits = { 11, 11, 11 };
            int index1 = GetRndIndex();
            int index2 = GetRndIndex(index1);
            int index3 = GetRndIndex(index1, index2);
            codeHintDigits[index1] = _codeDigits[index1];
            while ((codeHintDigits[index2] == _codeDigits[index2] || codeHintDigits[index2] == 11) || (codeHintDigits[index2] == codeHintDigits[index1] || _codeDigits.Contains(codeHintDigits[index2])))
            {
                codeHintDigits[index2] = _rnd.Next(0, 10);
            }
            while ((codeHintDigits[index3] == _codeDigits[index3] || codeHintDigits[index3] == codeHintDigits[index2]) || (codeHintDigits[index3] == 11 || codeHintDigits[index3] == codeHintDigits[index1]) || _codeDigits.Contains(codeHintDigits[index3]))
            {
                codeHintDigits[index3] = _rnd.Next(0, 10);
            }

            
            return FormatHintString(codeHintDigits);
        }


        private string GenerateSecondFifthHint()
        {
            int[] codeHintDigits = { 11, 11, 11 };
            //-Randomize the index of the correct number, and randomize it's placement index, other than the original
            //(GetRndCorrectIndex)
            //(SetIndex(otherThan)
            //- Grab both other indexes, and set random values ensuring no repeating numbers,
            //[figure out how to select other two indexes]
            //(RandomizeValue())
            //(SetValue())
            int index1 = GetRndIndex();
            int index2 = GetRndIndex(index1);
            codeHintDigits[index2] = _codeDigits[index1];
            while ((codeHintDigits[index1] == _codeDigits[index1] || codeHintDigits[index1] == codeHintDigits[index2]) || codeHintDigits[index1] == 11 || _codeDigits.Contains(codeHintDigits[index1]))
            {
                codeHintDigits[index1] = _rnd.Next(0, 9);
            }

            int index3 = GetRndIndex(index1, index2);
            while ((codeHintDigits[index3] == _codeDigits[index3] || codeHintDigits[index3] == codeHintDigits[index2]) || (codeHintDigits[index3] == codeHintDigits[index1] || codeHintDigits[index3] == 11) || _codeDigits.Contains(codeHintDigits[index3]))
            {
                codeHintDigits[index3] = _rnd.Next(0, 9);
            }

            return FormatHintString(codeHintDigits);
        }

        private string GenerateThirdHint()
        {
            int[] codeHintDigits = { 11, 11, 11 };
            //-Randomize the index of the first correct number, and randomize it's placement index, and set, other than the original
            //(GetRndCorrectIndex)
            //(SetIndex(otherThan))
            //(RandomizeValue)
            //(SetValue)
            //- Randomize the index of the second correct number, except the first.Then randomize it's placement index, and set, other than the original or first
            //(GetRndCorrectIndex(otherThan))
            //(SetIndex(otherThan, first))
            //(RandomizeValue)
            //(SetValue)
            //- Randomize the remaining index's value, ensuring no repeating numbers
            //[figure out how to fetch remaining variable]
            //(RandomizeValue)
            //(SetValue)
            int index1 = GetRndIndex();
            int index2 = GetRndIndex(index1);
            codeHintDigits[index2] = _codeDigits[index1];
            codeHintDigits[index1] = _codeDigits[index2];
            int index3 = GetRndIndex(index1, index2);
            while ((codeHintDigits[index3] == _codeDigits[index3] || codeHintDigits[index3] == codeHintDigits[index2]) || (codeHintDigits[index3] == codeHintDigits[index1] || codeHintDigits[index3] == 11) || _codeDigits.Contains(codeHintDigits[index3]))
            {
                codeHintDigits[index3] = _rnd.Next(0, 9);
            }

            return FormatHintString(codeHintDigits);

        }

        private string GenerateFourthHint()
        {
            int[] codeHintDigits = { 11, 11, 11 };
            //-Rndomize all three indexes, ensuring no repeating numbers or values contained in the correct code
            //[use loop to iterate though each string element, limiting to 3 iterations]
            //(RandomizeValue)
            //(SetValue)
            int index1 = GetRndIndex();
            int index2 = GetRndIndex(index1);
            int index3 = GetRndIndex(index1, index2);
            while ((codeHintDigits[index1] == _codeDigits[index1] || codeHintDigits[index1] == 11) || _codeDigits.Contains(codeHintDigits[index1]))
            {
                codeHintDigits[index1] = _rnd.Next(0, 9);
            }
            while ((codeHintDigits[index2] == _codeDigits[index2] || codeHintDigits[index2] == codeHintDigits[index1]) || (codeHintDigits[index2] == 11 || _codeDigits.Contains(codeHintDigits[index2])))
            {
                codeHintDigits[index2] = _rnd.Next(0, 9);
            }
            while ((codeHintDigits[index3] == _codeDigits[index3] || codeHintDigits[index3] == codeHintDigits[index2]) || (codeHintDigits[index3] == codeHintDigits[index1] || codeHintDigits[index3] == 11) || _codeDigits.Contains(codeHintDigits[index3]))
            {
                codeHintDigits[index3] = _rnd.Next(0, 9);
            }

            return FormatHintString(codeHintDigits);
        }


        private string FormatHintString(int[] hintDigits)
        {
            string hint = "";
            foreach(int digit in hintDigits)
            {
                hint += digit;
            }
            return hint;
        }

        


        //Resuable tasks

        private int GetRndIndex(int otherThan = 111, int otherThan2 = 111)
        {
            //Needs to get a random index
            //Needs to accept up to two arguments to validate the random index against
            //Validate in a while loop
            //Use conditional if otherthan2 != 111 then return the remaining index
            int index = 4;


            do { index = _rnd.Next(0, 3); }
            while (index == otherThan || index == otherThan2);
            

            return index;
        }
    }
}
