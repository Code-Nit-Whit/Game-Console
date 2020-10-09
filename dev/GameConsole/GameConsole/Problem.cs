using System;


// Name: Whitaker, Codie
// Date: September 11th, 2020
// Course: APD
// Synopsis: CE05: Milestone 2


namespace GameConsole
{
    public class Problem
    {

        //Fields
        private readonly char[] _operators = { '+', '-', '*', '/', '%' };
        private char _operator;
        private int _term1;
        private int _term2;

        //Properties
        public string Expression { get; set; }
        public int Solution { get; set; }

        //Constructor
        public Problem()
        {
            //Randomly set value of each field and property,
            //Create random object
            Random random = new Random();

            //Set limits of random number for operator to the index of the _operators array
            //Use this random number to select an operator from the array
            _operator = _operators[random.Next(0, _operators.Length)];

            //Use the same random object to generate random numbers (no bounds), but with different seed values (whatever I want)
            //Use each of these random numbers as the 2 terms on either side of the operator
            //Don't allow zeros. This will cause the random generators to eventually cause the console to try to divide by zero, which throws an error
            _term1 = random.Next(2, 100);
            _term2 = random.Next(1, 100);

            //Use methods to concatenate the expression and calculate the solution
            //Call method to concatenate problem for output to user
            Expression = ConcatProblem();
            //Call method to solve the randomized problem
            Solution = SolveProblem();

        }

        //Concatinate the Expression
        public string ConcatProblem()
        {
            string expression = $"{_term1} {_operator} {_term2} = ";

            return expression;
        }

        //Solve the problem and return the solution
        public int SolveProblem()
        {
            decimal solution = 0;
            switch (_operator)
            {
                case '+':
                    solution = _term1 + _term2;
                    break;

                case '-':
                    solution = _term1 - _term2;
                    break;

                case '*':
                    solution = _term1 * _term2;
                    break;

                case '/':
                    solution = _term1 / _term2;
                    break;

                case '%':
                    solution = _term1 % _term2;
                    break;
            }
            int roundedSolution = (int)Math.Floor(solution);
            return roundedSolution;
        }




    }//end class
}

