using System;
using System.Threading;
using System.Collections.Generic;

// Name: Whitaker, Codie
// Date: September 11th, 2020
// Course: APD
// Synopsis: CE05: Milestone 2


namespace GameConsole
{
    public class HighLow
    {


        private User _player;
        private readonly string _title = "High-Low";
        private int _score;
        private readonly List<string> _instructions = new List<string>{
            "The game is simple! You will be asked to guess a number.",
            "You get to set the range of possible numbers to guess from.",
            "If incorrect, you'll get a hint and be given another guess.",
            "A score will be calculated based on how many guesses you take.",
            "I'll calculate the required number of moves based on the maxumum number you enter.",
            "Each guess you make will lower the amount of points you add to your score.",
            "If you take more than the require guesses, you will lose points on your score.",
            "You can win by reaching 1000 points."};


        public HighLow(User player)
        {
            _player = player;
            _score = 0;
        }

        public void Play()
        {
            //Local variables
            bool keepPlaying = true; //Controls whether you play again
            bool keepGuessing; //Controls whether you guess again
            int correctNumber;
            int guessedNumber;
            int numberOfMoves;

            while (keepPlaying) //This game (because of my scoring, game win setup) requires mutiple playsto win. You accumulate a score over time.
            {
                //Display game title and instructions
                UI.Header(_title);
                Console.WriteLine($"Player Score: {_score}");
                UI.DisplayInstructions(_instructions);

                numberOfMoves = 0;

                //Request a Maximum Number
                Console.WriteLine("");
                string maxNumPrompt = " Please select a maximum number... ";
                UI.Separator();
                Console.Write(maxNumPrompt);
                int maximumNumber = Validation.IntergerValidation(Console.ReadLine(), maxNumPrompt);

                //Create a method to validate this method, asking again if necessary
                //int maximumNumber = Validation.IntergerValidation(response, maxNumPrompt);

                //Generate a random number between 1 and the maximum for the user to guess
                Random rnd = new Random();
                correctNumber = rnd.Next(1, maximumNumber + 1);

                //Report back to user
                string haveSelected = $"  Ok I have selected a number between 1 and {maximumNumber}  ";
                UI.Separator(haveSelected);

                //Until the user has won, keep guessing and hinting
                keepGuessing = true;
                while (keepGuessing)
                {

                    //Prompt user for a guess.. reuse previously created method to validate
                    string guessPrompt = " What is your guess?... ";
                    Console.Write(guessPrompt);
                    guessedNumber = Validation.IntergerValidation(Console.ReadLine(), guessPrompt);

                    // Create another method to compare player's guess to generated random number. If incorrect, provide the user a hint of :"too low" or "too high"
                    keepGuessing = CheckNumber(guessedNumber, correctNumber);


                    numberOfMoves += 1;
                }


                //Create one more method to calculate the score
                _score += CalculateScore(numberOfMoves, maximumNumber, _score);


                if (_score < 1000)
                {
                    //Keep Trying?
                    Console.WriteLine();
                    string textOutput = " Keep playing? You need 1000 points to win... [Y/N] ";
                    UI.Separator();
                    Console.Write(textOutput);
                    string response = Validation.ValidateYesNo(Console.ReadLine(), textOutput);
                    keepPlaying = (response.ToUpper() == "N") ? false:true;
                }
                else
                {
                    keepPlaying = false;
                }
            }

        }//end of play method


        

        



        //Check Number
        private bool CheckNumber(int guessedNumber, int correctNumber)
        {
            bool keepGuessing = true;

            //Use conditional block
            if (guessedNumber < correctNumber)
            {
                UI.Separator("  You guessed too low. ");
            }
            else if (guessedNumber > correctNumber)
            {
                UI.Separator("  You guessed too high. "); 
            }
            else
            {
                
                UI.Header("  That's it!");
                keepGuessing = false;
            }

            return keepGuessing;

        }





        //Calculate Score

        //I there 1 or 2 left?
        //  1: Add one      2: Add two
        //This is total required moves
        //
        //Multiply this by 100 add 100 to total possible score
        //Multiply total moves by 100 to get substracted
        //Score = total possible - actual score
        //
        //Allow foe the adding of a savable overall score tally later
        private int CalculateScore(int totalMoves, int maximumNumber, int score)
        {
            //How many times can you cut maxNumber down by half before there are only 1 or 2 options left?
            int requiredMoves = 0;
            while (maximumNumber > 2)
            {
                maximumNumber /= 2;
                requiredMoves += 1;
            }
            //How many additional required?
            int additionalMoves = (maximumNumber % 2 == 0) ? 2 : 1;
            requiredMoves += additionalMoves;

            //Calculate total possible score
            int totalPossibleAddition = requiredMoves * 100;

            //Calculate player's score
            int scoreAdjustment = totalPossibleAddition - (totalMoves * 100);
            score += scoreAdjustment;


            //If they reached 1000 points, they won
            if (score >= 1000)
            {
                //Pause for 1 second, 1000 miliseconds
                Thread.Sleep(1000);
                string textOutput = "You Win!";
                UI.Header(textOutput);
            }



            //Output user score
            Console.WriteLine($"  There were, at max, {requiredMoves} necessary to guess the right number. ");
            Console.WriteLine($"  The highest possible score adjustment was +{totalPossibleAddition} points. ");
            Console.WriteLine($"  Score adjustment: {scoreAdjustment} points. ");
            Console.WriteLine($"  Total guesses: {totalMoves}");
            Console.WriteLine($"  Your score: {score} ");
            Console.WriteLine("");

            //return adjustment for score tracking
            return scoreAdjustment;


        }
    }//end of class
}
