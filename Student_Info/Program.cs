using System;
using System.Collections.Generic;

namespace Student_Info
{
    class Program
    {
        static void Main(string[] args)
        {   
            // continue bool is set to true, and an empty dictionary with int keys and Student values is declared
            bool cont = true;
            Dictionary<int, Student> students = new Dictionary<int, Student>();

            // this loop will continue until the user enters either 3 or "n" when prompted
            while (cont == true)
            {
                // choice and parChoice are declared
                string choice;
                int parChoice;

                // Menu is printed and the user is prompted for input, and that input is validated
                Console.WriteLine("Hello, please make a selection: \n1) Add Students\n2) Get Student Info\n3) Quit\n");
                choice = Console.ReadLine();

                while (!Int32.TryParse(choice, out parChoice) && parChoice != 1 && parChoice != 2 && parChoice != 3)
                {
                    Console.WriteLine("Invalid entry. Please make a selection: \n1) Add Students\n2) Get Student Info\n3) Quit\n");
                    choice = Console.ReadLine();
                }

                // depending on the user input, a method is ran or the program quits
                if (parChoice == 1)
                {
                    // student builder is called, and the user can populate the dictionary with students
                    students = StudentBuilder(students);
                }
                else if (parChoice == 2)
                {
                    // studentChoice is determined based on user input in the getStudentChoice method, and then info for that student is displayed
                    int studentChoice = getStudentChoice(students);
                    displayInfo(students[studentChoice]);
                }
                else
                {
                    // application quits
                    break;
                }
                // cont is checked
                cont = Continue();
            }

        }

        public static Dictionary<int, Student> StudentBuilder(Dictionary<int, Student> students = null)
        {
            // if the dictionary passed in is not null, the stuLeng is set to the size of the dictionary, else it is set to 0
            int stuLeng;
            if(students != null)
            {
                stuLeng = students.Count;
            }
            else
            {
                stuLeng = 0;
            }
            string c;
            int cParsed;

            // user provides the number of students that will be created and that input is validated
            Console.WriteLine("How many students would you like to create? \n");
            c = Console.ReadLine();

            while (!Int32.TryParse(c, out cParsed) || cParsed < 0)
            {
                Console.WriteLine("Please enter a positive integer: \n");
                c = Console.ReadLine();
            }

            // a new Student is created every loop and is added to the dictionary at key i
            for (int i = stuLeng; i < stuLeng + cParsed; i++)
            {
                Student student = new Student();
                students.Add(i, student);
            }

            return students;
        }

        public static int getStudentChoice(Dictionary<int, Student> students)
        {
            // if the length of the dictionary provided is 0, the method warns the user and returns out
            if(students.Count == 0)
            {
                Console.WriteLine("There is no data for any students. Please add data for students and then return.\n");
                return 0;
            }

            // count is set to the size of the dictionary, and choice vars are declared
            int count = students.Count;
            string strChoice;
            int choice;

            // the user is prompted for a choice that corresponds to the student that they want info about, and then the menu is printed by iterating through the 
            // dictionary. User input is validated
            Console.WriteLine("Please select a student you want info about by typing their number: \n");
            for(int i = 0; i < count; i++)
            {
                string name = students[i].GetName();
                Console.WriteLine($"{i + 1}) {name}\n");
            }

            strChoice = Console.ReadLine();

            while(!Int32.TryParse(strChoice, out choice) || choice < 1 || choice > count)
            {
                Console.WriteLine($"Invalid entry. Please enter a number between 1 and {count} to get info about the corresponding student.");
                strChoice = Console.ReadLine();
            }

            // choice - 1 is returned, because 1 is added to make the student list non-zero indexed
            return choice - 1;
        }

        public static void displayInfo(Student student)
        {

            // data is retrieved from the Student object, formatted and printed
            int age = student.GetAge();
            string name = student.GetName();
            string food = student.GetFood();
            string home = student.GetHome();

            Console.WriteLine($"{name} is from {home}, and is {age}. Their favorite food is {food}");

            return;
        }

        public static bool Continue()
        {   
            // user is prompted for confirmation to continue or quit
            string answer;
            bool cont;

            Console.WriteLine("Continue?\ny/n");
            answer = Console.ReadLine();

            while(answer != "y" && answer != "Y" && answer != "n" && answer != "N")
            {
                Console.WriteLine("Invalid entry.\nPlease enter y to continue or n to quit.\n");
                answer = Console.ReadLine();
            }

            if(answer == "n" || answer == "N")
            {
                cont = false;
                return cont;
            }
            else
            {
                cont = true;
                return cont;
            }
        }
    }
}
