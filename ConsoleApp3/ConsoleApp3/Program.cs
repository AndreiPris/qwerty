using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{

    class Student
    {
        public string name = "";
        public float laziness;
        public double iq;
        public byte exams;
        public int[] marks;
        static int students = 3;


        public Student()
        {
            name = "LILPip";
            laziness = 0.9f;
            iq = 199;
            exams = 4;
            marks = new int[10] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
        }

        public Student(string name, float laziness, double iq, byte exams, int[] marks)
        {
            this.name = name;
            this.laziness = laziness;
            this.iq = iq;
            this.exams = exams;
            this.marks = marks;
        }

        public Student(Student clon)
        {
            name = clon.name;
            laziness = clon.laziness;
            iq = clon.iq;
            exams = clon.exams;
            marks = clon.marks;
        }

        public void print()
        {
            Console.WriteLine("Name: {0}, level of laziness(0, 1): {1}, IQ(100 - 200): {2}, amount of exams: {3}", name, laziness, iq, exams);
            for (int i = 0; i < marks.Length; i++)
            {
                Console.WriteLine("Mark {0}: {1}", i, marks[i]);
            }
            Console.WriteLine("All Students: {0}", students);
        }

        public void input()
        {
            Console.WriteLine("Name: ");
            name = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("level of laziness(float(0, 1)): ");
                string lazinessInput = Console.ReadLine();

                if (float.TryParse(lazinessInput, out float laziness) && laziness <= 1 && laziness > 0)
                {
                    this.laziness = laziness;
                    break;
                }
                else
                {
                    Console.WriteLine("Try again");
                }
            }

            while (true)
            {
                Console.WriteLine("IQ(100 - 200): ");
                string iqInput = Console.ReadLine();

                if (double.TryParse(iqInput, out double iq) && iq <= 200 && iq >= 100)
                {
                    this.iq = iq;
                    break;
                }
                else
                {
                    Console.WriteLine("Try again");
                }
            }
            while (true)
            {
                Console.WriteLine("amount of exams: ");
                string examsInput = Console.ReadLine();

                if (byte.TryParse(examsInput, out byte exams))
                {
                    this.exams = exams;
                    break;
                }
                else
                {
                    Console.WriteLine("Try again");
                }
            }
            while (true)
            {
                for (int i = 0; i < exams; i++)
                {
                    Console.WriteLine("Marks(1 - 10): ");
                    string marksInput = Console.ReadLine();
                    if (int.TryParse(marksInput, out int marks) && marks <= 10 && marks > 0)
                    {
                        this.marks[i] = marks;
                        //break;
                    }
                    else
                    {
                        Console.WriteLine("Try again");
                    }
                }
                break;
            }
        }
        public void Random()
        {

        }
        public static void Main()
        {
            Student student = new Student();
            student.input();
            student.print();
        }

    }

}
