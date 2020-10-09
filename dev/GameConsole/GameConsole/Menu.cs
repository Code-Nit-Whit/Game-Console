using System;
using System.Collections.Generic;

// Name: Whitaker, Codie
// Date: September 11th, 2020
// Course: APD
// Synopsis: CE05: Milestone 2


namespace GameConsole
{
    public class Menu
    {

        //Fields
        private string _menuName;
        private List<string>  _menuOptions;

        //Properties
        //public List<string> MenuOptions { get; set; }
        
        //Constructor
        public Menu(string name, List<string> options)
        {
            _menuName = name;

            _menuOptions = options;
        }


        public static void DisplayMenu(List<Menu> menus)
        {
            //Loop to output menu
            int iteratorAdder = 0;
            foreach (Menu menu in menus)
            {
                //Use a variable to control the iterator value between menu's
                //This should allow for dynamic numbering of multiple menus
                
                for (int i = 0; i < menu._menuOptions.Count; i++)
                {
                    if (menu._menuOptions[i] == "Exit Game" || menu._menuOptions[i] == "Back" || menu._menuOptions[i] == "Cancel")
                    {
                        Console.WriteLine($"[0]: {menu._menuOptions[i]} ");
                    }
                    else
                    {
                        Console.WriteLine($"[{i + iteratorAdder + 1}]: {menu._menuOptions[i]} ");//+1 to get out of indexing numbering, adding the menu option count to a variable, which gets added to the "option number" to help with dynamic numbering
                    }
                }
                Console.WriteLine("");
                iteratorAdder += menu._menuOptions.Count;
            }

        }

        public static int GetMenuSelection(List<Menu> menus)
        {
            //Store menu options in dictionary?
            List<int> menuNumberedOptions = new List<int>();
            //Loop to instantiate dictionary
            int iteratorAdder = 0;
            foreach (Menu menu in menus)
            {
                //Use a variable to control the iterator value between menu's
                //This should allow for dynamic numbering of multiple menus

                for (int i = 0; i < menu._menuOptions.Count; i++)
                {
                    if (menu._menuOptions[i] == "Exit" || menu._menuOptions[i] == "Back" || menu._menuOptions[i] == "Cancel")
                    {
                        menuNumberedOptions.Add(0);
                    }
                    else
                    {
                        menuNumberedOptions.Add(i + iteratorAdder + 1);//+1 to get out of indexing numbering, adding the menu option count to a variable, which gets added to the "option number" to help with dynamic numbering
                    }
                }
                iteratorAdder += menu._menuOptions.Count;
            }

            //Determine range (highest number)
            //Sort? Enumerable methods? List Methods? Need biggest number. Make a Validation Class Method
            int maxLimit = Validation.ValidateHighestNumber(menuNumberedOptions);

            //Prompt user for input
            string question = "Please choose a menu option [1, 2, 3, ...] ";
            UI.Separator();
            Console.Write(question);
            //Validate using range validation
            int response = Validation.RangeValidation(0, maxLimit, Console.ReadLine(), question);

            return response;
        }

    }
}