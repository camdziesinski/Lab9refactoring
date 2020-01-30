using System;
using System.Collections.Generic;

namespace Lab9RefactoringLab8
{
    class Program
    {
        static void Main(string[] args)
        {
            bool again = true;
            int i = -1;
            List<string> students = new List<string>
            {
                "James", "Shamita", "Erwin"
            };
            List<string> college = new List<string>
            {
                "MSU", "Wayne State", "Lawrence Tech"
            };
            List<string> themeSong = new List<string>
            {
                "Long, Long Way from Home by Foreigner", "Survivor by Destiny's Child", "Get Ready by The Temptations"
            };
            List<string> gender = new List<string>
            {
                "male", "female", "male"
            };
            List<string> colors = new List<string>
            {
                "black", "blue", "orange"
            };
            while (again)
            {

                while (i == -1)
                {
                    string input = GetUserInput($"Which student would you like to know about?\n{PrintList(students)}");

                    try
                    {
                        i = int.Parse(input);
                        if (i <= students.Count && i >= 1)
                        {
                            i = int.Parse(input) -1;
                        }
                        else
                        {
                            i = -1;
                        }
                    }
                    catch
                    {
                        try
                        {
                            for (int x = 0; x < students.Count + 1; x++)
                            {
                                if (input == students[x])
                                {
                                    i = x;
                                    break;
                                }
                            }
                        }
                        catch
                        {
                            i = -1;
                        }

                    }
                }
                while (again)
                {

                    int caseSwitch = 0;
                    while (caseSwitch == 0)
                    {
                        Console.WriteLine($"What would you like to know about {students[i]}?");
                        try
                        {
                            caseSwitch = int.Parse(GetUserInput("1. College 2. Theme Song 3. Gender 4. Fav Color"));
                            if (caseSwitch <= 4 && caseSwitch >= 1)
                            {
                                switch (caseSwitch)
                                {
                                    case 1:
                                        Console.WriteLine($"{students[i]} attended {college[i]}.");
                                        break;
                                    case 2:
                                        Console.WriteLine($"{students[i]} choice {themeSong[i]} as their theme song.");
                                        break;
                                    case 3:
                                        Console.WriteLine($"{students[i]} is a {gender[i]}.");
                                        break;
                                    case 4:
                                        Console.WriteLine($"{students[i]} favorite color is {colors[i]}.");
                                        break;
                                }
                            }
                            else
                            {
                                caseSwitch = 0;
                                Console.WriteLine("That number is outside of the 4 options");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Invalid Input. Please enter 1-4");
                        }
                    }
                    
                    again = AnswerYesOrNO($"Would you like to know more about {students[i]}?","y","n");
                }
                i = -1;
                again = AnswerYesOrNO("Would you like to know about another student?","y","n");
            }

        }
        // Display a message and return user's input
        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        // returns bool for one or the other.
        public static bool AnswerYesOrNO(string message, string yes, string no)
        {
            string input = GetUserInput($"{message}? [{yes}/{no}]").ToLower();

            while (input != yes && input != no)
            {
                Console.WriteLine($"Please enter [{yes}/{no}].");
                input = Console.ReadLine();
            }
            if(input == yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // will make a string of list so I can display in a message
        public static string PrintList(List<string> list)
        {
            string listprint = ""; 
            for (int i = 0; i < list.Count; i++)
            {
                listprint += $"{i+1} {list[i]} ";
            }
            return listprint;
        }
    }
}
