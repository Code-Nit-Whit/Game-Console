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



            //DICTIONARY
            //
            //
            //Load Dictionary


    }//end of class
}

/*
 using System;
using System.Collections.Generic;
using System.IO;

//Name: Codie Whitaker
//Date: December 3rd, 2020
//Class: Application Architecture
//Assignment: 2.3 Code Exercise

namespace EmployeeTracker
{
    public static class FileIO
    {
        public static List<Employee> LoadEmployees(string filePath)
        {
            List<Employee> employees = new List<Employee>();
            if (!File.Exists(filePath))
            {
                return employees;
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
                        string address = lineSplit[1];
                        decimal hoursWorked = decimal.Parse(lineSplit[3]);
                        decimal rateOfPay = decimal.Parse(lineSplit[2]);

                        FullTime newEmployee = new FullTime(name, address, rateOfPay, 40, hoursWorked);
                        employees.Add(newEmployee);
                    }

                    return employees;
                }
            }
        }

        public static void SaveEmployees(string filePath, List<Employee> employees)
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
                for (int i = 0; i < employees.Count; i++)
                {
                    if (employees[i] is FullTime)
                    {
                        string[] saveData = ((FullTime)employees[i]).GetSaveData();
                        //string toWrite = $"{saveData[0]}:{saveData[1]}:{saveData[2]}:{saveData[3]}";
                        string toWrite = "";
                        foreach (string dataPoint in saveData)
                        {
                            if(toWrite == "")
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
        }
    }
}

 */
