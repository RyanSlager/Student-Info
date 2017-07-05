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
            Dictionary<int, Student> students = StudentBuilder();

            Student stu = students[1];

            int age = stu.GetAge();
            string name = stu.GetName();
            string food = stu.GetFood();
            string home = stu.GetHome();

            Console.WriteLine($"{name} is from {home}, and is {age}. Their favorite food is {food}");
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
    }
}
