using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab_2_console
{
    interface Imathtest
    {
        void count();
    }

    interface Igoal 
    {
        void goal();
    }


    abstract class sports
    {
        public int strength; // 50 - 100
        public double speed; // 50 - 100
        public float weight; // 50 - 200
        public int iq; // 0 - 200
        public static string[] mastery = { "beginer", "master", "intermediate", "fullTrash" };
        //public string name;

        public sports()
        {
            Random rand = new Random();
            strength = rand.Next(50, 100);
            speed = rand.NextDouble();
            weight = rand.Next(50, 100);
            iq = rand.Next(50, 200);
        }


        public sports(int strength, double speed, float weight, int iq)
        {
            this.strength = strength;
            this.speed = speed;
            this.weight = weight;
            this.iq = iq;
        }

        public virtual void input()
        {
            Console.WriteLine("Enter values");
            while (true)
            {
                Console.Write("Strength: ");
                string strengthInput = Console.ReadLine();
                if (int.TryParse(strengthInput, out int strength))
                {
                    this.strength = strength;
                    break;
                }
                else
                {
                    Console.WriteLine("Try again");
                }
            }

            while (true)
            {
                Console.Write("Speed: ");
                string speedInput = Console.ReadLine();
                if (double.TryParse(speedInput, out double speed))
                {
                    this.speed = speed;
                    break;
                }
                else
                {
                    Console.WriteLine("Try again");
                }
            }


            while (true)
            {
                Console.Write("Weight: ");
                string weightInput = Console.ReadLine();
                if (int.TryParse(weightInput, out int weight))
                {
                    this.weight = weight;
                    break;
                }
                else
                {
                    Console.WriteLine("Try again");
                }
            }

            while (true)
            {
                Console.Write("Weight: ");
                string iqInput = Console.ReadLine();
                if (int.TryParse(iqInput, out int iq))
                {
                    this.iq = iq;
                    break;
                }
                else
                {
                    Console.WriteLine("Try again");
                }
            }
        }

        public virtual void print()
        {
            Console.WriteLine("Strength: {0}, Speed: {1}, iq: {2}, weight: {3}",
                strength, speed, iq, weight);
        }
        public abstract void giveAge();

        public virtual void Sealed()
        {
            Console.WriteLine("I am a athlete");
        }
        public virtual void writeFile(string filename)
        {
            StreamWriter sw = new StreamWriter(filename);
            sw.WriteLine(strength);
            sw.WriteLine(speed);
            sw.WriteLine(weight);
            sw.Close();
        }
    }


    class mmaFighter : sports, Imathtest
    {
        double record;
        int striking;
        int grappling;
        const int answer = 4;

        public mmaFighter() : base()
        {
            Random rand = new Random();
            striking = rand.Next(50, 100);
            record = rand.NextDouble();
            grappling = rand.Next(50, 100);

        }
        public mmaFighter(double record, int striking, int grappling) : base()
        {
            this.record = record;
            this.striking = striking;
            this.grappling = grappling;
        }
        public override void print()
        {
            Console.WriteLine("MMAFighter");
            Console.WriteLine("Strength: {0}, Speed: {1}, iq: {2}, weight: {3}",
               strength, speed, iq, weight);
            Console.WriteLine("Record: {0}, Striking: {1}, Grappling: {2}", record, striking, grappling);
            Console.WriteLine("--------------------------------------------------");
        }

        public void count()
        {
            Console.WriteLine("2 + 2 = ?");
            int n = Console.Read();
            if (n == answer)
            {
                Console.WriteLine("Insain!!!");
            }
            else
            {
                Console.WriteLine("Get out of here");
            }
        }

        public override void input()
        {
            base.input();
            Console.WriteLine("Enter values");
            while (true)
            {
                Console.Write("Record: ");
                string recordInput = Console.ReadLine();
                if (double.TryParse(recordInput, out double record))
                {
                    this.record = record;
                    break;
                }
                else
                {
                    Console.WriteLine("Try again");
                }
            }

            while (true)
            {
                Console.Write("striking: ");
                string strikingInput = Console.ReadLine();
                if (int.TryParse(strikingInput, out int striking))
                {
                    this.striking = striking;
                    break;
                }
                else
                {
                    Console.WriteLine("Try again");
                }
            }


            while (true)
            {
                Console.Write("Weight: ");
                string grapplingInput = Console.ReadLine();
                if (int.TryParse(grapplingInput, out int grappling))
                {
                    this.grappling = grappling;
                    break;
                }
                else
                {
                    Console.WriteLine("Try again");
                }
            }

        }

        public override void giveAge()
        {
            Console.Write("Enter Fighter age: ");
            int age = int.Parse(Console.ReadLine());
            if (age is 19)
            {
                Console.WriteLine("We are the same age");
            }
            Console.WriteLine("FighterAge: {0}", age);
        }

        sealed public override void Sealed()
        {
            Console.WriteLine("I am an mmaFighter");
        }
        public override void writeFile(string filename)
        {
            StreamWriter sw = new StreamWriter(filename);
            sw.WriteLine(strength);
            sw.WriteLine(speed);
            sw.WriteLine(weight);
            sw.WriteLine(record);
            sw.WriteLine(striking);
            sw.WriteLine(grappling);
            sw.Close();
        }   

    }
    class footballPlayer : sports, Igoal
    {
        int rating;
        int number;
        public footballPlayer() : base()
        {
            Random rand = new Random();
            rating = rand.Next(50, 100);
            number = rand.Next(1, 11);
        }
        public footballPlayer(int rating, int number) : base()
        {
            this.rating = rating;
            this.number = number;   
        }
        public override void print()
        {
            Console.WriteLine("FootballPlayer");
            Console.WriteLine("Strength: {0}, Speed: {1}, iq: {2}, weight: {3}",
               strength, speed, iq, weight);
            Console.WriteLine("Rating: {0}, PlayerNumber: {1}", rating, number);
            Console.WriteLine("--------------------------------------------------");
        }

        public void goal()
        {
            Console.WriteLine("GOLL!!!");
        }

        public override void giveAge()
        {
            Console.Write("Enter Player age: ");
            int age = int.Parse(Console.ReadLine());
            if (age is 19)
            {
                Console.WriteLine("We are the same age");
            }
            Console.WriteLine("PlayerAge: {0}", age);
        }
        public override void input()
        {
            base.input();
            while (true)
            {
                Console.Write("Record: ");
                string ratingInput = Console.ReadLine();
                if (int.TryParse(ratingInput, out int rating))
                {
                    this.rating = rating;
                    break;
                }
                else
                {
                    Console.WriteLine("Try again");
                }
            }

            while (true)
            {
                Console.Write("Record: ");
                string numberInput = Console.ReadLine();
                if (int.TryParse(numberInput, out int number))
                {
                    this.number = number;
                    break;
                }
                else
                {
                    Console.WriteLine("Try again");
                }
            }
        }


        public override void writeFile(string filename)
        {
            StreamWriter sw = new StreamWriter(filename);
            sw.WriteLine(strength);
            sw.WriteLine(speed);
            sw.WriteLine(weight);
            sw.WriteLine(rating);
            sw.WriteLine(number);
            sw.Close();
        }
    }
    sealed class powerlifter : sports
    {
        float benchPress;
        float deadlift;
        float squat;

        public powerlifter() : base()
        {
            Random rand = new Random();
            benchPress = rand.Next(100, 335);
            deadlift = rand.Next(100, 500);
            squat = rand.Next(100, 500);

        }

        public powerlifter(int strength, double speed, float weight, int iq, float squat) : base(strength, speed, weight, iq)
        {
            benchPress = 150;
            deadlift = 200;
            this.squat = squat;
           
        }
        public override void print()
        {
            Console.WriteLine("PowerLifter");
            Console.WriteLine("Strength: {0}, Speed: {1}, iq: {2}, weight: {3}",
                strength, speed, iq, weight);
            Console.WriteLine("BenchPress: {0}, dedlift: {1}, squat: {2}.", benchPress, deadlift, squat);
            Console.WriteLine("--------------------------------------------------");
        }
        public override void giveAge()
        {
            Console.Write("Enter Lifter age: ");
            int age = int.Parse(Console.ReadLine());
            if (age is 19)
            {
                Console.WriteLine("We are the same age");
            }
            Console.WriteLine("LifterAge: {0}", age);
        }

        public override void input()
        {
            base.input();
            while (true)
            {
                Console.Write("Record: ");
                string benchPressInput = Console.ReadLine();
                if (float.TryParse(benchPressInput, out float benchPress))
                {
                    this.benchPress = benchPress;
                    break;
                }
                else
                {
                    Console.WriteLine("Try again");
                }
            }
            while (true)
            {
                Console.Write("Record: ");
                string deadliftInput = Console.ReadLine();
                if (float.TryParse(deadliftInput, out float deadlift))
                {
                    this.deadlift = deadlift;
                    break;
                }
                else
                {
                    Console.WriteLine("Try again");
                }
            }
            while (true)
            {
                Console.Write("Record: ");
                string squatInput = Console.ReadLine();
                if (float.TryParse(squatInput, out float squat))
                {
                    this.squat = squat;
                    break;
                }
                else
                {
                    Console.WriteLine("Try again");
                }
            }

        }
        public override void writeFile(string filename)
        {
            StreamWriter sw = new StreamWriter(filename);
            sw.WriteLine(strength);
            sw.WriteLine(speed);
            sw.WriteLine(weight);
            sw.WriteLine(benchPress);
            sw.WriteLine(deadlift);
            sw.WriteLine(squat);
            sw.Close();
        }
    }

    class General
    {
        public static void Main()
        {

            sports[] Vector = new sports[6];
            Vector[0] = new powerlifter();
            Vector[1] = new powerlifter(150, 100, 100, 100, 100);
            Vector[2] = new footballPlayer();
            Vector[3] = new footballPlayer(66, 5);
            Vector[4] = new mmaFighter();
            Vector[5] = new mmaFighter(0.5, 77, 74);

            Vector[0].print();
            Vector[0].input();
            Vector[0].print();
            Vector[2].print();
            Vector[4].print();


            Vector[1].writeFile("D:\\qwerty\\Lab_2_console\\file.txt");
        }
    }
}