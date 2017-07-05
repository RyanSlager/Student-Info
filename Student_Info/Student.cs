using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Info
{
    class Student
    {
        public string name;
        public int age;
        public string hometown;
        public string food;

        public Student()
        {
            this.name = SetName();
            this.hometown = SetHome();
            this.food = SetFood();
            this.age = SetAge();

        }

        public string SetName()
        {
            string name;

            Console.WriteLine("Please enter a students name: \n");
            name = Console.ReadLine();

            return name;
        }

        public string SetHome()
        {
            string home;

            Console.WriteLine($"Please enter {name}'s hometown: \n");
            home = Console.ReadLine();

            return home;
        }

        public string SetFood()
        {
            string food;

            Console.WriteLine($"Please enter {name}'s favorite food: \n");
            food = Console.ReadLine();

            return food;
        }

        public int SetAge()
        {
            string age;
            int parsedAge;

            Console.WriteLine($"Please enter {name}'s age: \n");
            age = Console.ReadLine();

            while (!Int32.TryParse(age, out parsedAge) || parsedAge < 0)
            {
                Console.WriteLine($"Please enter a positive integer for {name}'s age: \n");
                age = Console.ReadLine();
            }

            return parsedAge;
        }

        public string GetName()
        {
            return name;
        }

        public string GetFood()
        {
            return food;
        }

        public string GetHome()
        {
            return hometown;
        }

        public int GetAge()
        {
            return age;
        }
    }
}
