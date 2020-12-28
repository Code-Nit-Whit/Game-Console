using System;
using System.Collections.Generic;

namespace GameConsole
{
    public class Menu
    {
        //Fields
        private string _title;
        private Dictionary<int, string> _menuItems = new Dictionary<int, string>();
        private string _returnOption;

        public int NumItems { get { return _menuItems.Count;  } }

        public Menu(string title, string returnOption = null)
        {
            _title = title;
            if (returnOption != null)
            {
                _returnOption = returnOption;
            }
        }

        public int GetMenuSize()
        {
            return _menuItems.Count;
        }

        //Used to update private member fields _title and _menuItems
        public void AddMenuItems(string[] menuData)
        {
            for (int i = 0; i < menuData.Length; i++)
            {
                _menuItems.Add(_menuItems.Count + 1, menuData[i]);
            }
        }

        public void AddMenuItem(string item)
        {
            _menuItems.Add(_menuItems.Count + 1, item);
        }

        //Prints menu title and list of menu options to the console
        public void Display(bool withTitle = false)
        {
            if (withTitle)
            {
                //Display Menu title
                UI.DisplayTitle(_title);
            }
            //Display menu options- use a for loop
            foreach (KeyValuePair<int, string> kvp in _menuItems)
            {
                Console.WriteLine($"[{kvp.Key}] {kvp.Value}");
            }
            if (_returnOption != null)
            {
                Console.WriteLine($"\r\n[{0}] {_returnOption}");
            }
        }


    }
}