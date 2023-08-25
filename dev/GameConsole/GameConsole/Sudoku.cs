using System;
using System.Collections.Generic;

// Name: Whitaker, Codie
// Date: September 11th, 2020
// Course: APD
// Synopsis: CE05: Milestone 2


namespace GameConsole
{
	public class Sudoku : OnePlayerGame
	{
		private readonly new List<string> _instructions = new List<string>{
			"The game is simple! You will be asked to guess a number.",
			"You get to set the range of possible numbers to guess from.",
			"If incorrect, you'll get a hint and be given another guess.",
			"A score will be calculated based on how many guesses you take.",
			"I'll calculate the required number of moves based on the maxumum number you enter.",
			"Each guess you make will lower the amount of points you add to your score.",
			"If you take more than the require guesses, you will lose points on your score.",
			"You can win by reaching 1000 points."
		};
		private int _score;
		private int _numberOfMoves;
		private int _guessedNumber;
		private int _correctNumber;
		private int _maximumNumber;

		public Sudoku(User player) : base(player, "Sudoku")
		{
			_score = 0;
		}

		public override void Play()
		{
			_numberOfMoves = 0;
			UpdateGameDisplay();
			string question = "Please select a maximum number... ";
			_maximumNumber = Validation.GetValidatedInt(question);
			//Generate a random number between 1 and the maximum for the user to guess
			Random rnd = new Random();
			_correctNumber = rnd.Next(1, _maximumNumber + 1);
			UI.DisplaySuccess($" Ok, I have selected a number between 1 and {_maximumNumber}");

			//Until the user has won, keep guessing and hinting
			while (_guessedNumber != _correctNumber)
			{
				//Prompt user for a guess.. reuse previously created method to validate
				question = "What is your guess?... ";
				int[] range = { 0, _maximumNumber };
				_guessedNumber = Validation.GetValidatedRange(question, range);
				// Create another method to compare player's guess to generated random number. If incorrect, provide the user a hint of :"too low" or "too high"
				CheckGuess();
				_numberOfMoves += 1;
			}
			_score += CalculateScore();
			if (!CheckWinner())
			{
				//Keep Trying?
				question = "Keep playing? You need 1000 points to win... [Y/N] ";
				string[] conditionals = { "y", "n" };
				string response = Validation.GetValidatedConditional(question, conditionals);
				if (response == "Y")
				{
					Play();
				}
			}
			else
			{
				DisplayWinner(true);
				if (PlayAgain())
				{
					HighLow newGame = new HighLow(_player);
					newGame.Play();
				}
			}


		}//end of play method

		protected override void UpdateGameDisplay()
		{
			UI.DisplayTitle(_title);
			UI.DisplayInfo($"Player Score: {_score}");
			foreach (string instruction in _instructions)
			{
				UI.DisplayInfo(instruction);
			}
		}

		protected override bool CheckWinner()
		{
			if (_score >= 400)
			{
				_player.AddAPoint("High-Low");
			}
			return _score >= 400;
		}

		private void CheckGuess()
		{
			//Use conditional block
			if (_guessedNumber < _correctNumber)
			{
				UI.DisplayError("You guessed too low.");
			}
			else if (_guessedNumber > _correctNumber)
			{
				UI.DisplayError("You guessed too high.");
			}
			else
			{
				UI.DisplaySuccess("That's it!");
			}
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
		private int CalculateScore()
		{
			//How many times can you cut maxNumber down by half before there are only 1 or 2 options left?
			int requiredMoves = 0;
			int maxNum = _maximumNumber;
			while (maxNum > 2)
			{
				maxNum /= 2;
				requiredMoves += 1;
			}
			//How many additional required?
			int additionalMoves = (maxNum % 2 == 0) ? 2 : 1;
			requiredMoves += additionalMoves;
			//Calculate total possible score
			int totalPossibleAddition = requiredMoves * 100;
			//Calculate player's score
			int scoreAdjustment = totalPossibleAddition - (_numberOfMoves * 100);
			_score += scoreAdjustment;
			//Output user score
			Console.WriteLine($"  There were, at max, {requiredMoves} necessary to guess the right number. ");
			Console.WriteLine($"  The highest possible score adjustment was +{totalPossibleAddition} points. ");
			Console.WriteLine($"  Score adjustment: {scoreAdjustment} points. ");
			Console.WriteLine($"  Total guesses: {_numberOfMoves}");
			Console.WriteLine($"  Your score: {_score} ");
			Console.WriteLine("");
			UI.Continue();
			//return adjustment for score tracking
			return scoreAdjustment;
		}
	}//end of class
}