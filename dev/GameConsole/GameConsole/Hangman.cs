using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameConsole
{
    public class Hangman : OnePlayerGame
    {
        //Fields
        private List<string> _instructions = new List<string>() { };
        private string _filePath = "";
        private Dictionary<string, Dictionary<string, string>> _availableDictionaries;
        private Random _rnd = new Random();
        private Dictionary<string, string> _currentDictionary = new Dictionary<string, string>();
        private Gallows _currentGallows;

        public Hangman(User player) : base(player, "Hangman")
        {
        }

        public override void Play()
        {
            _availableDictionaries = FileIO.LoadDictionaries();
            string[] dictMenuArr = new string[_availableDictionaries.Count + 1];
            int i = 1;
            foreach(KeyValuePair<string, Dictionary<string, string>> kvp in _availableDictionaries)
            {
                dictMenuArr[i] = kvp.Key;
                i++;
            }
            Menu dictionariesMenu = new Menu();
            dictionariesMenu.Init(dictMenuArr);
            bool keepPlaying = true;
            while(keepPlaying)
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

        private void HandleMenuSelection()
        {
            string question = "Which dictionary would you like to use? They are listed by topic... ";
            int[] range = { 0, _availableDictionaries.Count };
            string selection = 
            _currentDictionary = _availableDictionaries[selection - 1];
        }

        protected override void UpdateGameDisplay()
        {

        }

        protected override bool CheckWinner()
        {

        }

    }//end of class
}
