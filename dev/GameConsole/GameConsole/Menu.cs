using System;
using System.Collections.Generic;

namespace GameConsole
{
    public class Menu
    {
        //Fields
        private string _title;
        private List<string> _menuItems;

        public Menu()
        {
        }

        //Used to update private member fields _title and _menuItems
        public void Init(string[] menuData)
        {
            //Set title field
            _title = menuData[0];
            //Add menu options to lsit
            _menuItems = new List<string>();
            for (int i = 1; i < menuData.Length; i++)
            {
                _menuItems.Add(menuData[i]);
            }
        }

        //Two Overloads
        //Prints menu title and list of menu options to the console
        public void Display()
        {
            //Display menu options- use a for loop
            for (int i = 0; i < _menuItems.Count; i++)
            {
                if (_menuItems[i] == "Exit" || _menuItems[i] == "Back")
                {
                    Console.WriteLine($"\r\n[{0}] {_menuItems[i]}\r\n");
                }
                else
                {
                    Console.WriteLine($"[{i + 1}] {_menuItems[i]}");
                }
            }
        }
        public void Display(string name)
        {
            //Display Menu title
            UI.DisplayTitle(name);

            //Display menu options- use a for loop
            for (int i = 0; i < _menuItems.Count; i++)
            {
                if (_menuItems[i] == "Exit" || _menuItems[i] == "Back")
                {
                    Console.WriteLine($"\r\n[{0}] {_menuItems[i]}\r\n");
                }
                else
                {
                    Console.WriteLine($"[{i + 1}] {_menuItems[i]}");
                }
            }
        }


    }
}