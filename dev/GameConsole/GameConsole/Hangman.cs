using System;
using System.Collections.Generic;
using System.Linq;

namespace GameConsole
{
    public class Hangman : OnePlayerGame
    {
        //Fields
        private readonly new List<string> _instructions = new List<string>() { };
        private string _filePath = "../../Dictionaries.txt";
        private Dictionary<string, string> _availableDictionaries;
        private Random _rnd = new Random();
        private Dictionary<string, string> _currentDictionary = new Dictionary<string, string>();
        private Gallows _currentGallows;

        public Hangman(User player) : base(player, "Hangman")
        {
        }

        public override void Play()
        {
            _availableDictionaries = FileIO.LoadAvailableDictionaries(_filePath);
            string[] dictMenuArr = new string[_availableDictionaries.Count + 1];
            int i = 1;
            foreach(KeyValuePair<string, string> kvp in _availableDictionaries)
            {
                dictMenuArr[i] = kvp.Key;
                i++;
            }
            Menu dictionariesMenu = new Menu();
            dictionariesMenu.Init(dictMenuArr);
            bool keepGoing = true;
            while(keepGoing)
            {
                dictionariesMenu.Display(dictMenuArr[0]);
                string question = "Please select a themed dictionary from the list above [1,2,3]... ";
                int[] range = { 0, dictMenuArr.Length - 1 };
                int selection = Validation.GetValidatedRange(question, range);
                _currentDictionary = FileIO.LoadDictionary(_availableDictionaries);
            }
        }

        protected override void UpdateGameDisplay()
        {
            bool keepPlaying = true;
            while (keepPlaying)
            {
                dictionariesMenu.Display(dictMenuArr[0]);
                HandleMenuSelection();
                int index = _rnd.Next(0, _dictionary.Count - 1);
                string word = _dictionary.ElementAt(index).Key;
                string definition = _dictionary.ElementAt(index).Value;
                Gallows gallows = new Gallows(word, definition);
                gallows.ComenceHanging();
            }
        }

        protected override bool CheckWinner()
        {

        }

    }//end of class
}
