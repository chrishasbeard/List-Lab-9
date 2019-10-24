using System;
using System.Collections.Generic;

namespace Lab9_List_of_the_students
{
    class Program
    {
        static List<string> students = new List<string>
        {{"1) Sandy Walters" },{ "2) June Boggard"},{ "3) Dave Imhoff"},{"4) Howard McDuck"}, {"5) Spiro Vamvakas"} };
        static List<string> age = new List<string>
        { {"23"},{ "31"},{ "19"},{"24"},{"45"} };
        static List<string> occupation = new List<string>
        { {"Continual Improvements Sprecialist"},{"Mechanical Engineer"},{"Materials Specialist"},{"Bartender"},{"Club Owner"} };
        static List<string> dreamjob = new List<string>
        { {"Site Coordinator"},{"Director of New Business Development"},{"Senior Engineer"},{"Club Owner"},{"Unemployed Billionaire"}};
        static List<string> iceCream = new List<string>();

        static string addName = string.Empty;
        static string addAge = string.Empty;
        static string job = string.Empty;
        static string dreamJob = string.Empty;
        static string iceCream2 = string.Empty;
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Welcome to my small college classroom, of my 5 students which would you like to know more about? ");
                for (int i = 0; i < students.Count; i++)
                {
                    Console.WriteLine(students[i]);
                }

                int index = ValidateRange("Which student would you like to know more about? Enter a number 1 - 5", 0, students.Count);
                index--;

                Console.WriteLine($" Ah, yes. My student {students[index]}");

                MoreStudentInfo(index);
                FavoriteIceCream(iceCream);

            } while (KeepQuestioning("Do you want to learn about another student? (y/n):"));
        }

        public static List<string> FavoriteIceCream(List <string> dairy)
        {
            for (int i = 0; i < 5; i++)
            {
               dairy.Add(GetUserInput($"what is {students[i]} favorite ice cream?"));
            }
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{students[i]} likes {dairy[i]}");
            }
                return dairy;
        }
        public static void AddStudent()
        {
            GetUserInput("What is the student's name?");
            students.Add(addName);
            GetUserInput("What is the students age?");
            age.Add(addAge);
            GetUserInput("What is the student's occupation?");
            occupation.Add(job);
            GetUserInput("What is the student's dream job?");
            dreamjob.Add(dreamJob);
            GetUserInput("what is there favorite flavor of ice cream?");
            iceCream.Add(iceCream2);          
        }

        public static void MoreStudentInfo(int index)
        {
            string question = GetUserInput("Would you like to learn about the student? (Enter either age, occupation, dream job, add student, or 'no')");
            switch (question)
            {
                case "age":
                    Console.WriteLine(age[index]);
                    MoreStudentInfo(index);
                    break;
                case "occupation":
                    Console.WriteLine(occupation[index]);
                    MoreStudentInfo(index);
                    break;
                case "dream job":
                    Console.WriteLine(dreamjob[index]);
                    MoreStudentInfo(index);
                    break;
                case "no":
                    break;
                case "add student":
                    AddStudent();
                    break;
                default:
                    Console.WriteLine("Sorry invalid!");
                    MoreStudentInfo(index);
                    break;
            }

        } // make a method or something to store the input for new user and new field

        public static bool KeepQuestioning(string question)
        {
            string answer = GetUserInput(question);
            if (answer == "y")
            {
                Console.Clear();
                return true;
            }
            else if (answer == "n")
            {
                return false;
            }
            else
            {
                return KeepQuestioning(question);
            }
        }

        public static int ValidateRange(string message, int min, int max)
        {
            int number = ParseString(message);
            if (number > min && number <= max)
            {
                return number;
            }
            else
            {
                return ValidateRange(message, min, max);
            }
        }

        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();
            return input;
        }

        public static int ParseString(string message)
        {
            try
            {
                string input = GetUserInput(message);
                int number = int.Parse(input);
                return number;
            }
            catch
            {
                return ParseString(message);
            }
        }
    }
}


