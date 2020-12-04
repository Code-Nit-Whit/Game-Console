/*using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameConsole
{
    public class Hangman
    {
        //Fields
        private User _player;
        private string _title = "HANGMAN";
        private List<string> _instructions = new List<string>() { };
        private Random _rnd = new Random();
        private Dictionary<string, string> _dictionary = new Dictionary<string, string>();

        public Hangman(User player)
        {
            _player = player;

            using (StreamReader sr = new StreamReader("../../../Dictionary.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] splitElements = line.Split(':');
                    
                    _dictionary.Add(splitElements[0], splitElements[1]);
                    
                }
            }
        }

        public /*static void Play()
        {
            //Validation.ComingSoon();

            //Rndomly choose word from dictionary... Need to research method that work like an index w/ dictionaries
            int index = _rnd.Next(0, _dictionary.Count - 1);

            string word = _dictionary.ElementAt(index).Key;
            string definition = _dictionary.ElementAt(index).Value;


            //Instantiate a gallows object, passing in the word and definition
            Gallows gallows = new Gallows(word, definition);

            //Call a method from this object that actually plays the game...
            gallows.ReallyPlay(_title);
        }

    }//end of class
}*/
