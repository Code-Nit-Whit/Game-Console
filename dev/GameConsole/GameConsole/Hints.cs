using System;
using System.Collections.Generic;






namespace GameConsole
{
    public class Hints
    {


        //fields
        private List<string> _hintTexts = new List<string>() { "One is correct, and in the right spot.", "One is correct, and in the wrong spot.", "Two are correct, and in the wrong spots.", "Nothing is correct.", "One is correct, and in the wrong spot." }; 
        private List<int[]> _hintCodes;
        private Random _rnd = new Random();
        private List<int> _codeDigits;

        public Dictionary<int[], string> HintsList  { get; }

        



        public Hints(List<int> codeDigits)
        {
            _codeDigits = codeDigits;

            _hintCodes = new List<int[]>();
            //Instantiate _hintCodes
            for (int i = 0; i < _hintTexts.Count; i++)
            {
                _hintCodes.Add(CreateHintCode(_codeDigits, i + 1));
            }

            HintsList = new Dictionary<int[], string>();
            //Instantiate Hints List
            for (int i = 0; i < _hintTexts.Count; i++)
            {
                HintsList.Add(_hintCodes[i], _hintTexts[i]);
            }
        }


        private int[] CreateHintCode(List<int> codeDigits, int i)
        {
            int[] hintNumber = { 12, 12, 12 }; //Will return 000 for everything until conditional hints are set in switch case

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

        //Hint generators

        private int[] GenerateFirstHint()
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

            
            return codeHintDigits;
        }


        private int[] GenerateSecondFifthHint()
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

            return codeHintDigits;
        }

        private int[] GenerateThirdHint()
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

            return codeHintDigits;

        }

        private int[] GenerateFourthHint()
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

            return codeHintDigits;
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

        
    }//end of class
}










/*

FIELDS
//set within the constructor (SetValue)

--list with individual codes, originally set to 1111 changed by index
--list with verbal hints, by index, hard coded.
--User



PROPERTIES
//set within constructor -Add to dictionary

Dictionary<int code, string hint> Hints






 
 HINT LOGIC/NOTES (switch statement within a for loop) (within constructor)

Hint()

1.  One is correct, and in the right spot.
    -Randomize the index of the correct number and set. (GetRndCorrectIndex)
    -Randomize both other indexes, ensuring no repeating numbers
    -Add to dictionary


2.  One is correct, and in the wrong spot.
    -Randomize the index of the correct number, and randomize it's placement index, other than the original
        (GetRndCorrectIndex)
        (SetIndex(otherThan)
    -Grab both other indexes, and set random values ensuring no repeating numbers,
        [figure out how to select other two indexes]
        (RandomizeValue())
        (SetValue())
    -Add to dictionary


3.  Two are correct, and in the wrong spots.
    -Randomize the index of the first correct number, and randomize it's placement index, and set, other than the original
        (GetRndCorrectIndex)
        (SetIndex(otherThan))
        (RandomizeValue)
        (SetValue)
    -Randomize the index of the second correct number, except the first. Then randomize it's placement index, and set, other than the original or first
        (GetRndCorrectIndex(otherThan))
        (SetIndex(otherThan, first))
        (RandomizeValue)
        (SetValue)
    -Randomize the remaining index's value, ensuring no repeating numbers
        [figure out how to fetch remaining variable]
        (RandomizeValue)
        (SetValue)
    -Add to dictionary


4.  Nothing is correct.
    -Rndomize all three indexes, ensuring no repeating numbers or values contained in the correct code
        [use loop to iterate though each string element, limiting to 3 iterations]
            (RandomizeValue)
            (SetValue)
    -Add to dictionary



5.  One is correct, and in the wrong spot.
    -Reuse hint 2 (just copy and paste)
        [while loop validation that no index values match between this and hint2]
            [use loop to iterate though each string element, limiting to 3 iterations]
                (RandomizeValue)
                (SetValue)
    -Add to dictionary







PRIVATE METHODS
//only methods with optional parameters have arguments listed above, to simplify
 
GetRndCorrectIndex(int otherThan = null, int otherThan2 = null)

SetIndex(int otherThan, int first = null) //first considers the first number's

RandomizeValue() //Ensure it doesnt match any values in the code so far

SetValue(int index, int value)



 */