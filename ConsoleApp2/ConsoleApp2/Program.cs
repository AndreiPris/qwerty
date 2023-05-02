using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {
        int age;
        double money;
        Program()
        {
            age = 19;
            money = 200;
        }

        Program(int age, double money)
        {

        }

        public void test()
        {
            int x = 0, y = 0;
            try
            {
                try {
                    int[] v = new int[x];
                    v[y] = 10;
                }
                catch (ArgumentException e)
                {
                    throw new ParsEx(e);
                }
            }
            catch (ParsEx p)
            {
                p.obrabotka();
            }
        }

        public void InputAge()
        {
            try
            {
                Console.WriteLine("Enter age: ");
                age = Convert.ToInt32(Console.ReadLine());
                if (age <= 0)
                {
                    throw new ParsEx(age);
                }
            }
            catch (ParsEx ex)
            {
                ex.obrabotka();
            }
        }
        public void InputMoney()
        {
            try
            {
                Console.WriteLine("Enter age: ");
                money = Convert.ToInt32(Console.ReadLine());
                if (money <= 0)
                {
                    throw new ParsEx(money);
                }
            }
            catch (ParsEx ex)
            {
                ex.obrabotka();
            }
        }
    }

    public class ParsEx: Exception
       {
            public int errAge = 0;
            public double errMoney = 0;
            Exception programErr;
            public ParsEx(int x) { errAge = x; }
            public ParsEx(double x) { errMoney = x; }
            public ParsEx(Exception x) { programErr = x; }

            public void obrabotka()
            {
                if (errAge <= 0) { }//...
                if (errMoney <= 0) { }
                if (programErr is ArgumentException) { }
            }
        } 
}

//bool flag = false;//была ли ошибка
//do{
//  flag = false;
//  try
//  {
//      //
//  }
//  catch(...)
//  {
//      flag = true;
//  }
//{while()

