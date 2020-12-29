using System;
using System.Collections.Generic;

namespace GameConsole
{
    public class War : TwoPlayerGame
    {
        private readonly new List<string> _instructions = new List<string>{
            "Welcome to the card game, War!",
            "In this game, two players split a deck of cards in half.",
            "Plyers take turns pulling one card at a time and comparing values until their hands are empty.",
            "For each round, the player with the highest value card gets a point.",
            "The player with the most points at the end of the game wins!!"
        };
        private DeckOfCards _currentDeck;
        private List<Card> _pOneCards;
        private int _pOneScore = 0;
        private List<Card> _pTwoCards;
        private int _pTwoScore = 0;


        public War(User player) : base (player, "War")
        {
            
        }
        public override void Play()
        {
            _currentDeck = new DeckOfCards();
            Dictionary<string, List<Card>> deckHalves = DeckOfCards.DivideDeck(_currentDeck.Deck);
            _pOneCards = deckHalves["first_half"];
            _pTwoCards = deckHalves["second_half"];
            // Announce the two players by name
            UI.DisplayTitle(_title);
            foreach (string instruction in _instructions)
            {
                UI.DisplayInfo(instruction);
            }
            Console.WriteLine($"\r\nFor this match, we have {_player.Username} versus {_playerTwo.Username}!");
            string question = "Would you like to engage in War?! (y,n)...";
            string[] conditionals = { "y", "n" };
            string response;
            int numRounds = 25;
            do
            {
                response = Validation.GetValidatedConditional(question, conditionals);
                if (response == "y")
                {
                    UpdateGameDisplay();
                    Round();
                    numRounds -= 1;
                }
            } while (response == "y" && numRounds > 0);
            // When this loop is over you should call the EndGame() method.
            DisplayWinner(CheckWinner());
            if (PlayAgain())
            {
                Play();
            }
        }

        protected override void UpdateGameDisplay()
        {
            UI.DisplayTitle(_title);
            //Remaining cards, current scores, etc.
            string column1 = $"{_player.Username}'s Score: {_pOneScore} with {_pOneCards.Count} left";
            string column2 = $"{_playerTwo.Username}'s Score: {_pTwoScore} with {_pTwoCards.Count} left";
            string[] data = { column1, column2 };
            string[] splitters = { "Score:" };
            List<string> formattedGameData = UI.DisplayColumns(data, splitters);
            foreach (string dataPoint in formattedGameData)
            {
                UI.DisplayInfo(dataPoint);
            }
            Console.WriteLine("\r\n");
        }

        public void Round()
        {
            // Draw a card from each player's hand. Be sure to remove it entirely.
            // Evaluate who won the round using the cards, adjust the score, and
            // display it using the DisplayScore method
            List<Card> pair = new List<Card>();
            pair.Add(_pOneCards[0]);
            _pOneCards.Remove(pair[0]);
            pair.Add(_pTwoCards[0]);
            _pTwoCards.Remove(pair[1]);
            string winner = "";

            if ((pair[0].Value > pair[1].Value && pair[1].Value != 1) || (pair[0].Value == 1 && pair[1].Value != 1))
            {
                winner = $"{_player.Username.ToUpper()}!!";
                _pOneScore += 1;
            }
            else if (pair[0].Value == pair[1].Value)
            {
                winner = "TIE!";
            }
            else if ((pair[0].Value < pair[1].Value && pair[0].Value != 1) || (pair[1].Value == 1 && pair[0].Value != 1))
            {
                winner = $"{_playerTwo.Username.ToUpper()}!!";
                _pTwoScore += 1;
            }
            DisplayRoundResults(winner, pair[0], pair[1]);
        }
        public void DisplayRoundResults(string winner, Card p1Card, Card p2Card)
        {
            string p1Str = p1Card.DisplayValue();
            string p2Str = p2Card.DisplayValue();
            Console.WriteLine($"{_player.Username} pulled a {p1Str}");
            Console.WriteLine($"{_playerTwo.Username} pulled a {p2Str}");
            string message1 = "Good Match";
            string message2 = "The round goes to...";
            // Display each player's name and score and how many cards are left in
            // each player's hand
            Console.WriteLine("");
            UI.DisplaySuccess(message1);
            UI.DisplaySuccess($"{message2} {winner}");
        }

        protected override string CheckWinner()
        {
            if (_pOneScore > _pTwoScore)
            {
                _player.AddAPoint("War");
                return _player.Username.ToUpper();
            }
            else if (_pOneScore == _pTwoScore)
            {
                return "TIE!";
            }
            else
            {
                _playerTwo.AddAPoint("War");
                return _playerTwo.Username.ToUpper();
            }
        }
    }
}