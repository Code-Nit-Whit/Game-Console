using System;

namespace GameConsole
{
    public class Card
    {
        // Create a private field for the card's suit (This should be an integer)
        // It will eventually store a number from 0 to 3
        private int _suit;

        // Create a public property for the value of the card. This will hold a
        // number from 1 to 13
        public int Value { get; set; }
        // Create a constructor that accepts suit and value in parameters and
        // sets the value and suit classmember variables accordingly
        public Card(int suit, int value)
        {
            _suit = suit;
            Value = value;
        }
        //Create a method to display the value of the card. This should return a string.
        // Assume a suit of 0 is Spades, 1 is Hearts, 2 is Diammonds & 3 is Clubs
        // If the card value is 12 and suit is 0 the card
        // then this method should return "The Queen of Spades"

        public string DisplayValue()
        {
            string suitStr = "";
            switch (_suit)
            {
                case 0:
                    suitStr = "Spades";
                    break;

                case 1:
                    suitStr = "Hearts";
                    break;

                case 2:
                    suitStr = "Diamonds";
                    break;

                case 3:
                    suitStr = "Clubs";
                    break;
            }

            string valueStr = "";
            if (Value > 10 || Value == 1)
            {
                switch (Value)
                {
                    case 11:
                        valueStr = "Jack";
                        break;

                    case 12:
                        valueStr = "Queen";
                        break;

                    case 13:
                        valueStr = "King";
                        break;

                    case 1:
                        valueStr = "Ace";
                        break;
                }
            }
            else
            {
                valueStr = Value.ToString();
            }

            string cardValue = $"{valueStr} of {suitStr}";

            return cardValue;
        }
    }
}
