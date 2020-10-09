using System;
using System.Collections.Generic;

// Name: Whitaker, Codie
// Date: September 11th, 2020
// Course: APD
// Synopsis: CE05: Milestone 2


namespace GameConsole
{
    public class MathChallenge
    {


        private User _player;
        private readonly string _title = "MATH CHALLENGE";
        private int _level;
        private int _score;
        private readonly List<string> _instructions = new List<string>{
            "Are you good at math? Put your wits to the test! The game is simple...",
            "You will be provided a math problem. Answer correctly and move to the next level",
            "Solutions are rounded down",
            "Points are awarded based on number of correct answers" };


        public MathChallenge(User player)
        {
            _player = player;
            _level = 0;
            _score = 0;
        }

        public void Play()
        {
            Console.Clear();

            //Display title
            //Header
            UI.Header(_title);

            //Use method to display each of the instructions
            UI.DisplayInstructions(_instructions);

            //Until wrong answer is given...
            bool answerCorrect = true;
            while (answerCorrect)
            {

                //Instantiate a Problem object
                Problem problem = new Problem();

                //Display the problem Expression
                UI.Separator();
                Console.WriteLine(problem.Expression);

                //Request and answer
                string textOutput = " What is the answer to this problem? ";
                Console.Write(textOutput);

                //Use a method to validate, asking again is necessary
                int answer = Validation.IntergerValidation(Console.ReadLine(), textOutput);

                //Compare answer to problem's solution
                if (answer == problem.Solution)
                {
                    // If correct: Increase the level and use a method to recalculate score
                    Console.WriteLine("  Correct!");
                    _level++;
                    _score += 150;
                }
                else
                {
                    //If incorrect, the game is over. Let the user know and display the score
                    textOutput = $"  You got the wrong answer. Correct Answer: {problem.Solution}. Game Over.\r\n" +
                        $"     Level: {_level}\r\n     Score: {_score} ";
                    UI.Footer(textOutput);
                    answerCorrect = false;
                }

            }


        }


    }//end of class
}
