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
        public static List<User> LoadPlayers(string filePath)
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
                        int userScore = int.Parse(lineSplit[4]);
                        int hlScore = int.Parse(lineSplit[5]);
                        int mmScore = int.Parse(lineSplit[6]);
                        int mcScore = int.Parse(lineSplit[7]);
                        int ctcScore = int.Parse(lineSplit[8]);
                        int hmScore = int.Parse(lineSplit[9]);
                        int tttScore = int.Parse(lineSplit[10]);
                        int wScore = int.Parse(lineSplit[11]);

                        Dictionary<string, int> userScores = new Dictionary<string, int>();
                        userScores.Add("Total", userScore);
                        userScores.Add("High-Low", hlScore);
                        userScores.Add("Mastermind", mmScore);
                        userScores.Add("Math Challenge", mcScore);
                        userScores.Add("Crack the Code", ctcScore);
                        userScores.Add("Hangman", hmScore);
                        userScores.Add("Tic-Tac-Toe", tttScore);
                        userScores.Add("War", wScore);

                        User newUser = new User(name, password, age, theme);
                        newUser.SetUserScores(userScores);
                        users.Add(newUser);
                    }
                    return users;
                }
            }
        }
        //Save Users
        public static void SavePlayers(string filePath, List<User> users)
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
        public static List<string> LoadAvailableDictionaries(string filePath) //<descript, filePath>
        {
            List<string> dictionaries = new List<string>();
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
                        dictionaries.Add(line);
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