using System;
using System.Collections.Generic;
using System.IO;

namespace GameConsole
{
    public static class FileIO
    {
        //USERS
        //
        //
        //Load Users
        public static List<User> LoadUsers(string filePath)
        {
            List<User> users = new List<User>();
            if (!File.Exists(filePath))
            {
                return users;
            }
            else
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] lineSplit = line.Split(":");
                        string name = lineSplit[0];
                        string password = lineSplit[1];
                        int age = int.Parse(lineSplit[2]);
                        string theme = lineSplit[3];

                        User newUser = new User(name, password, age, theme);
                        users.Add(newUser);
                    }
                    return users;
                }
            }
        }
        //Save Users
        public static void SaveEmployees(string filePath, List<User> users)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                //Research how to do this conditionally based of the Employee's type.
                //Pretty sure this is built in somewhere with inheritance and abstract methods
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                for (int i = 0; i < users.Count; i++)
                {
                    string[] saveData = users[i].GetSaveData();
                    //string toWrite = $"{saveData[0]}:{saveData[1]}:{saveData[2]}:{saveData[3]}";
                    string toWrite = "";
                    foreach (string dataPoint in saveData)
                    {
                        if (toWrite == "")
                        {
                            toWrite = dataPoint;
                        }
                        else
                        {
                            toWrite = $"{toWrite}:{dataPoint}";
                        }

                    }
                    sw.WriteLine(toWrite);
                }
            }
        }
        



        //THEMES
        //
        //
        //Load Themes
        public static List<Theme> LoadThemes(string filePath)
        {
            List<Theme> themes = new List<Theme>();
            if (!File.Exists(filePath))
            {
                return themes;
            }
            else
            {
                using(StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] lineSplit = line.Split(":");
                        Theme newTheme = new Theme(lineSplit[0], lineSplit[1], lineSplit[2], lineSplit[3], lineSplit[4], lineSplit[5], lineSplit[6]);
                        themes.Add(newTheme);
                    }
                }
                return themes;
            }
        }


        //GAMES
        //
        //
        //Crack the Code
        public static List<Code> LoadCodes(string filePath)
        {
            List<Code> codes = new List<Code>();
            if (!File.Exists(filePath))
            {
                Console.WriteLine("No such file!");
                Console.ReadLine();
                return codes;
            }
            else
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] lineSplit = line.Split(":");
                        Code newCode = new Code(lineSplit);
                        codes.Add(newCode);
                    }
                }
                return codes;
            }
        }

        //Hangman
        public static Dictionary<string, string> LoadAvailableDictionaries(string filePath) //<descript, filePath>
        {
            Dictionary<string, string> dictionaries = new Dictionary<string, string>();
            if (!File.Exists(filePath))
            {
                Console.WriteLine("No such file!");
                Console.ReadLine();
                return dictionaries;
            }
            else
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] lineSplit = line.Split(":");
                        dictionaries.Add(lineSplit[0], lineSplit[1]);
                    }
                }
                return dictionaries;
            }
        }
        public static Dictionary<string, string> LoadDictionary(string filePath)
        {
            Dictionary<string, string> theDictionary = new Dictionary<string, string>();
            if (!File.Exists(filePath))
            {
                Console.WriteLine("No such file!");
                Console.ReadLine();
                return theDictionary;
            }
            else
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] lineSplit = line.Split(":");
                        theDictionary.Add(lineSplit[0], lineSplit[1]);
                    }
                }
                return theDictionary;
            }
        }
    }//end of class
}