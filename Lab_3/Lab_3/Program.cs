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
        public int exams = 0;
        public int[] marks;



        public Student()
        {
            averageMark = 3;
            iq = 199;
            exams = 1;
            marks = new int[exams];
        }

        public Student(int averageMark, int iq, int exams, int[] marks)
        {

            this.averageMark = averageMark;
            this.iq = iq;
            this.exams = exams;
            this.marks = marks;
        }

        //public void Ex()
        //{
        //    try
        //    {
        //        float caf = (float)averageMark / (float)iq;
        //        Console.WriteLine($"Коофицент успеваемости: {caf}");
                
        //    }
        //    catch(Exception ex)
        //    {
        //        Console.WriteLine($"Возникла ошибка при делении: {ex.Message}");
        //    }
        //}

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


        public void trytry()
        {
            try
            {
                try
                {
                    Console.WriteLine("Введите колиличиство экзаменов: ");
                    exams = int.Parse(Console.ReadLine());
                    marks = new int[exams];
                    for (int i = 0; i < exams; i++)
                    {
                        marks[i] = 10;
                    }
                }
                catch (ArgumentException e)
                {
                    throw new ParsEx(e);
                }
                catch (IndexOutOfRangeException e)
                {
                    throw new ParsEx(e);
                }
                catch (InvalidCastException e)
                {
                    throw new ParsEx(e);
                }
                catch (NullReferenceException e)
                {
                    throw new ParsEx(e);
                }
                catch (OverflowException e)
                {
                    throw new ParsEx(e);
                }
                catch (FormatException e)
                {
                    throw new ParsEx(e);
                }
                catch (DivideByZeroException e)
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

        public void printExams()
        {
            Console.WriteLine("Количество экзаменов: {0}", exams);
            Console.WriteLine("Оценки: ");
            for (int i = 0; i < exams; i++)
            {
                Console.WriteLine("Экзамен N:{0} - {1}", i, marks[i]); 
            }

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
            if (programErr is ArgumentException)//генерируется, если в метод для параметра передается некорректное значение
            { Console.WriteLine(programErr.Message + " ArgumentException"); }
            if (programErr is ArgumentOutOfRangeException)//генерируется, если значение аргумента находится вне диапазона допустимых значений
            { Console.WriteLine(programErr.Message + " ArgumentOutOfRangeException"); }
            if (programErr is IndexOutOfRangeException)//генерируется, если индекс элемента массива или коллекции находится вне диапазона допустимых значений
            { Console.WriteLine(programErr.Message + " IndexOutOfRangeException"); }
            if (programErr is NullReferenceException)//генерируется при попытке обращения к объекту, который равен null (то есть по сути неопределен)
            { Console.WriteLine(programErr.Message + " NullReferenceException"); }
            if (programErr is DivideByZeroException)//представляет исключение, которое генерируется при делении на ноль
            { Console.WriteLine(programErr.Message + " DivideByZeroException"); }
            if (programErr is InvalidCastException)//генерируется при попытке произвести недопустимые преобразования типов
            { Console.WriteLine(programErr.Message + " InvalidCastException"); }
            if (programErr is OverflowException)
            { Console.WriteLine(programErr.Message + " OverflowException"); }
            if (programErr is FormatException)
            { Console.WriteLine(programErr.Message + " FormatException"); }
        }
    }
    class General
    {
        public static void Main()
        {
            Student sEx = new Student();
            Student sAll = new Student();
            Student strytry = new Student();


            sAll.inputAll();
            sAll.print();

            strytry.trytry();
            strytry.printExams();

        }
    }
}
