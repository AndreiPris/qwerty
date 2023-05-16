using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    class Student
    {
        public int averageMark;
        public double iq;
        public int exams;
        public int[] marks;



        public Student()
        {
            averageMark = 3;
            iq = 199;
        }

        public Student(int averageMark, int iq)
        {

            this.averageMark = averageMark;
            this.iq = iq;
        }

        public void Ex()
        {
            try
            {
                float caf = (float)averageMark / (float)iq;
                Console.WriteLine($"Коофицент успеваемости: {caf}");
                
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Возникла ошибка при делении: {ex.Message}");
            }
        }

        public void inputEx()
        {
            bool b = false;
            Console.WriteLine("Enter values");
            do
            {
                b = false;
                try
                {
                    Console.WriteLine("Enter avgMark: ");
                    averageMark = int.Parse(Console.ReadLine());
                    if (averageMark <= 0 || averageMark > 10)
                    {
                        throw new ParsEx(averageMark);
                    }
                }
                catch (ParsEx ex)
                {
                    ex.obrabotkaMark();
                    b = true;
                }

            } while (b == true);

            do
            {
                b = false;
                try
                {
                    Console.WriteLine("Enter iq: ");
                    iq = int.Parse(Console.ReadLine());
                    if (iq < 100 || iq > 200)
                    {
                        throw new ParsEx(iq);
                    }
                }
                catch (ParsEx ex)
                {
                    ex.obrabotkaIq();
                    b = true;
                }

            } while (b == true);
        }

        public void inputAvg()
        {
            Console.WriteLine("Enter avgMark: ");
            averageMark = int.Parse(Console.ReadLine());
            if (averageMark <= 0 || averageMark > 10)
            {
                throw new ParsEx(averageMark);
            }
        }

        public void inputIq()
        {
            Console.WriteLine("Enter iq: ");
            iq = int.Parse(Console.ReadLine());
            if (iq < 100 || iq > 200)
            {
                throw new ParsEx(iq);
            }
        }

        public void inputAll()
        {
            bool a = false;
            do
            {
                a = false;
                try
                {
                    inputAvg();
                }
                catch (ParsEx ex)
                {
                    ex.obrabotkaIq();
                    a = true;
                }

            } while (a == true);

            do
            {
                a = false;
                try
                {
                    inputIq();
                }
                catch (ParsEx ex)
                {
                    ex.obrabotkaIq();
                    a = true;
                }

            } while (a == true);
        }


        public void Trytry()
        {
            try
            {
                try
                {
                    exams = Console.Read();
                }
                catch (ArgumentException e)
                {
                    throw new ParsEx(e);
                }
            }
            catch (ParsEx p)
            {
                p.obrabotkaObjects();
            }
            try
            {
                try
                {
                    exams = Console.Read();
                }
                catch (ArgumentOutOfRangeException e)
                {
                    throw new ParsEx(e);
                }
            }
            catch (ParsEx p)
            {
                p.obrabotkaObjects();
            }
            try
            {
                try
                {
                    marks = new int[exams];
                    for (int i = 0; i < exams; i++)
                    {
                        marks[i] = 5;
                    }
                }
                catch (IndexOutOfRangeException e)
                {
                    throw new ParsEx(e);
                }
            }
            catch (ParsEx p)
            {
                p.obrabotkaObjects();
            }
        }

        public void print()
        {
            Console.WriteLine("avg mark(0, 10): {0}, IQ(100 - 200): {1}", averageMark, iq);
        }
    }

    public class ParsEx : Exception
    {
        public int errMark = 0;
        public double errIq = 0;

        Exception programErr;
        public ParsEx(int x) { errMark = x; }
        public ParsEx(double x) { errIq = x; }
        public ParsEx(Exception x) { programErr = x; }

        public void obrabotkaMark()
        {
            if (errMark <= 0)
            {
                Console.WriteLine("Avg Mark can not be less or equal to zero, try again");
            }
            else if (errMark > 10)
            {
                Console.WriteLine("Avg Mark can not be bigger then ten, try again");
            }


        }
        public void obrabotkaIq()
        {
            if (errIq < 100)
            {
                Console.WriteLine("We don't have such stupid students, try again");
            }
            else if (errIq > 200)
            {
                Console.WriteLine("We don't have such clever students, try again");
            }
        }
        public void obrabotkaObjects()
        {
            if (programErr is ArgumentException) { }
            if (programErr is ArgumentOutOfRangeException) { }
            if (programErr is IndexOutOfRangeException) { }
            if (programErr is NullReferenceException) { }
        }
    }
    class General
    {
        public static void Main()
        {
            Student s = new Student(5, 0);
            Student sEx = new Student();
            Student sAll = new Student();
            s.print();
            s.Ex();

            //s.inputEx();
            //s.print();

            sAll.inputAll();
            sAll.print();

        }
    }
}
