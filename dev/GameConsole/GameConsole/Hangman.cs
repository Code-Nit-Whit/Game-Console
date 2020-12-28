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
        private List<string> _availableDictionaries; //dictionary name
        private List<string> _availableDictFilePaths;
        private Gallows _currentGallows;

        private Random _rnd = new Random();
        private Dictionary<string, string> _currentDictionary = new Dictionary<string, string>();

        public Hangman(User player) : base(player, "Hangman")
        {
            InitializeDictionaries();
        }

        public override void Play()
        {
            SelectCurrentDictionary();
            UpdateGameDisplay();
            bool winner = CheckWinner();
            DisplayWinner(winner);
            if (PlayAgain() == true)
            {
                Play();
            }
            else
            {
                //Exit method
            }
        }
    

        private void InitializeDictionaries()
        {
            List<string> dataUnformatted = FileIO.LoadAvailableDictionaries(_filePath);
            for (int j = 0; j < dataUnformatted.Count; j++)
            {
                string[] data = dataUnformatted[j].Split(":");
                _availableDictFilePaths.Add(data[1]);
                _availableDictionaries.Add(data[0]);
            }
        }

        private int SelectCurrentDictionary()
        {
            string[] dictMenuArr = new string[_availableDictionaries.Count + 1];
            dictMenuArr[0] = "Available Dictionaries";
            int i = 1;
            foreach (string dictName in _availableDictionaries)
            {
                dictMenuArr[i] = dictName;
                i++;
            }
            dictMenuArr[dictMenuArr.Length - 1] = "Back";
            Menu dictionariesMenu = new Menu();
            dictionariesMenu.Init(dictMenuArr);
            dictionariesMenu.Display(dictMenuArr[0]);
            string question = "Please select a themed dictionary from the list above [1,2,3]... ";
            int[] range = { 0, dictMenuArr.Length - 1 };
            int selection = Validation.GetValidatedRange(question, range);
            if (selection != 0)
            {
                _currentDictionary = FileIO.LoadDictionary(_availableDictFilePaths[selection - 1]);
                return -1;
            }
            else
            {
                return selection;
            }
        }

        protected override void UpdateGameDisplay()
        {
            int index = _rnd.Next(0, _currentDictionary.Count - 1);
            string word = _currentDictionary.ElementAt(index).Key;
            string definition = _currentDictionary.ElementAt(index).Value;
            _currentGallows = new Gallows(word, definition);
            _currentGallows.ComenceHanging();
        }

        protected override bool CheckWinner()
        {
            return _currentGallows.Winner ? true : false;
        }

    }//end of class
}
