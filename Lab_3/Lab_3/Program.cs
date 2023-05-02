using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
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
            exams = 5;
            marks = new int[5] { 5, 5, 5, 5, 5 };
            students++;
        }

        public Student(string name, float laziness, double iq, byte exams, int[] marks)
        {
            this.name = name;
            this.laziness = laziness;
            this.iq = iq;
            this.exams = exams;
            this.marks = marks;
            students++;
        }

        public Student(Student clon)
        {
            name = clon.name;
            laziness = clon.laziness;
            iq = clon.iq;
            exams = clon.exams;
            marks = clon.marks;
            students++;
        }


    public void print()
        {
            Console.WriteLine("Name: {0}, level of laziness(0, 1): {1}, IQ(100 - 200): {2}, amount of exams: {3}", name, laziness, iq, exams);
            for (int i = 0; i < marks.Length; i++)
            {
                Console.WriteLine("Mark {0}: {1}", i + 1, marks[i]);
            }
            //Console.WriteLine("All Students: {0}", students);
        }
    }
}
