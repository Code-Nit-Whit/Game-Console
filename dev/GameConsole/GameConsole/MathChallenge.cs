using System;
using System.Collections.Generic;

namespace GameConsole
{
    public class MathChallenge : OnePlayerGame
    {
        private readonly new List<string> _instructions = new List<string>{
            "Are you good at math? Put your wits to the test! The game is simple...",
            "You will be provided a math problem. Answer correctly and move to the next level",
            "Solutions are rounded down",
            "Points are awarded based on number of correct answers"
        };

        private int _level;
        private int _score;
        private Problem _problem;
        private int _answer;
        


        public MathChallenge(User player) : base(player, "Math Challenge")
        {
            _player = player;
            _level = 0;
            _score = 0;
        }

        public override void Play()
        {
            bool keepPlaying = true;
            while(keepPlaying)
            {
                //Until wrong answer is given...
                bool answerCorrect = true;
                while (answerCorrect)
                {
                    //Instantiate a Problem object
                    _problem = new Problem();
                    UpdateGameDisplay();
                    //Request and answer
                    string question = "What is the answer to this problem? ";
                    _answer = Validation.GetValidatedInt(question);
                    //Compare answer to problem's solution
                    answerCorrect = CheckWinner();
                }
                keepPlaying = PlayAgain();
            }
        }

        protected override void UpdateGameDisplay()
        {
            UI.DisplayTitle(_title);
            foreach(string instruction in _instructions)
            {
                UI.DisplayInfo(instruction);
            }
            Console.WriteLine("\r\n\r\n");
            Console.WriteLine(_problem.Expression);
        }

        protected override bool CheckWinner()
        {
            if (_answer == _problem.Solution)
            {
                // If correct: Increase the level and use a method to recalculate score
                _level++;
                _score += 150;
                UI.DisplaySuccess("Correct!");
                UI.Continue();
                return true;
            }
            else
            {
                //If incorrect, the game is over. Let the user know and display the score
                UI.DisplayError($"You got the wrong answer. Correct Answer: {_problem.Solution}. Game Over.\r\n" +
                                $"Level: {_level}\r\nScore: {_score} ");
                UI.Continue();
                DisplayWinner(false);
                return false;
            }
        }
    }//end of class
}
