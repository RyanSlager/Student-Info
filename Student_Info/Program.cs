using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Info
{
    class Program
    {
        static void Main(string[] args)
        { 

            //Dictionary<int, Student> students = StudentBuilder();

            //Student stu = students[1];

            //int age = stu.GetAge();
            //string name = stu.GetName();
            //string food = stu.GetFood();
            //string home = stu.GetHome();

            //Console.WriteLine($"{name} is from {home}, and is {age}. Their favorite food is {food}");
            
            bool cont = true;
            Dictionary<int, Student> students = null;
            while (cont == true)
            {
                string choice;
                int parChoice;
                

                Console.WriteLine("Hello, please make a selection: \n1) Add Students\n2) Get Student Info\n3) Quit\n");
                choice = Console.ReadLine();

                while (!Int32.TryParse(choice, out parChoice) && parChoice != 1 && parChoice != 2 && parChoice != 3)
                {
                    Console.WriteLine("Invalid entry. Please make a selection: \n1) Add Students\n2) Get Student Info\n3) Quit\n");
                    choice = Console.ReadLine();
                }

                if (parChoice == 1)
                {
                    students = StudentBuilder();
                }
                else if (parChoice == 2)
                {
                    Console.WriteLine(students.Count);
                    int studentChoice = getStudentChoice(students);
                    displayInfo(students[studentChoice]);

                }
                else
                {
                    break;
                }
                cont = Continue();
            }

        }

        public static Dictionary<int, Student> StudentBuilder()
        {
            Dictionary<int, Student> students = new Dictionary<int, Student>();
            string c;
            int cParsed;

            Console.WriteLine("How many students would you like to create? \n");
            c = Console.ReadLine();

            while (!Int32.TryParse(c, out cParsed) || cParsed < 0)
            {
                Console.WriteLine("Please enter a positive integer: \n");
                c = Console.ReadLine();
            }


            for (int i = 0; i < cParsed; i++)
            {
                Student student = new Student();
                students.Add(i, student);
            }

            return students;
        }

        public static int getStudentChoice(Dictionary<int, Student> students)
        {
            if(students.Count == 0)
            {
                Console.WriteLine("There is no data for any students. Please add data for students and then return.\n");
                return 0;
            }
            int count = students.Count;
            string strChoice;
            int choice;

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

            return choice - 1;
        }

        public static void displayInfo(Student student)
        {
            int age = student.GetAge();
            string name = student.GetName();
            string food = student.GetFood();
            string home = student.GetHome();

            Console.WriteLine($"{name} is from {home}, and is {age}. Their favorite food is {food}");

            return;
        }

        public static bool Continue()
        {
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
