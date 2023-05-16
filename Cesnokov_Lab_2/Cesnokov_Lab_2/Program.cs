using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesnokov_Lab_2
{
    interface IgiveDevineShild
    {
        void DevineShild();
    }

    interface IgiveTount
    {
        void Tount();
    }
    abstract class heartstone
    {
        public int hp;
        public float attack;
        public double winRate;
        public heartstone() 
        {
            Random rand = new Random();
            hp = rand.Next(1, 10);
            attack = rand.Next(1, 15);
            winRate = rand.Next(0, 100);
        }
        public heartstone (int hp, float attack, double winRate)
        {
            this.hp = hp;
            this.attack = attack;
            this.winRate = winRate;
        }

        public virtual void print()
        {
            Console.WriteLine("hp: {0}, attack: {1}, winRate: {2}", hp, attack, winRate);
        }
        public virtual void input()
        {
            Console.WriteLine("Enter values");
            Console.Write("hp: ");
            hp = int.Parse(Console.ReadLine());
            Console.Write("attack: ");
            attack = float.Parse(Console.ReadLine());
            Console.Write("winRate: ");
            winRate = double.Parse(Console.ReadLine());
        }
        public abstract void Spawn();
        public virtual void writeFile(string filename)
        {
            StreamWriter write = new StreamWriter(filename);
            write.WriteLine(hp);
            write.WriteLine(attack);
            write.WriteLine(winRate);
            write.Close();
        }

    }
    class Murlok : heartstone, IgiveDevineShild
    {
        public int poison;
        public bool merzkii;

        public Murlok() : base()
        {
            Random rand = new Random();
            poison = rand.Next(0, 23);
            merzkii = rand.Next(2) == 1;
        }
        public Murlok(int poison, bool merzkii, int hp, float attack, double winRate) : base(hp, attack, winRate)
        {
            this.poison = poison;
            this.merzkii = merzkii;
        }
        public override void print()
        {
            Console.WriteLine("Murlok");
            base.print();
            Console.WriteLine("poison: {0}, merzkii: {1}", poison, merzkii);
            Console.WriteLine("--------------------------------------------------");
        }
        public override void input()
        {
            Console.WriteLine("Enter values");
            Console.Write("poison: ");
            poison = int.Parse(Console.ReadLine());
            Console.Write("merzkii: ");
            merzkii = bool.Parse(Console.ReadLine());
        }
        public override void Spawn() {}
        public void DevineShild() {}
        public override void writeFile(string filename)
        {
            StreamWriter write = new StreamWriter(filename);
            write.WriteLine(poison);
            write.WriteLine(merzkii);
            write.Close();
        }

    }
    class Elemental : heartstone, IgiveTount
    {
        public int speed;
        public bool windFury;
        public Elemental(): base()
        {
            Random rand = new Random();
            speed = rand.Next(1, 55);
            windFury = rand.Next(2) == 1;
        }
        public Elemental(int speed, bool windFury, int hp, float attack, double winRate) : base(hp, attack, winRate)
        {
            this.speed = speed;
            this.windFury = windFury;
        }
        public override void print()
        {
            Console.WriteLine("Elemental");
            base.print();
            Console.WriteLine("speed: {0}, windFury: {1}", speed, windFury);
            Console.WriteLine("--------------------------------------------------");
        }
        public override void input()
        {
            Console.WriteLine("Enter values");
            Console.Write("speed: ");
            speed = int.Parse(Console.ReadLine());
            Console.Write("windFury: ");
            windFury = bool.Parse(Console.ReadLine());
        }
        public override void Spawn() {}
        public void Tount () {}
        public override void writeFile(string filename)
        {
            StreamWriter write = new StreamWriter(filename);
            write.WriteLine(speed);
            write.WriteLine(windFury);
            write.Close();
        }

    }
    class Pirat : heartstone
    {
        public int money;
        public bool deathRattle;
        public Pirat(): base()
        {
            Random rand = new Random();
            money = rand.Next(0, 66);
            deathRattle = rand.Next(2) == 1;
        }
        public Pirat(int money, bool deathRattle, int hp, float attack, double winRate) : base(hp, attack, winRate)
        {
            this.money = money;
            this.deathRattle = deathRattle;
        }
        public override void print()
        {
            Console.WriteLine("Pirat");
            base.print();
            Console.WriteLine("money: {0}, deathRatte: {1}", money, deathRattle);
            Console.WriteLine("--------------------------------------------------");
        }
        public override void input()
        {
            Console.WriteLine("Enter values");
            Console.Write("money: ");
            money = int.Parse(Console.ReadLine());
            Console.Write("deathRatte: ");
            deathRattle = bool.Parse(Console.ReadLine());
        }
        public override void Spawn() {}
        public override void writeFile(string filename)
        {
            StreamWriter write = new StreamWriter(filename);
            write.WriteLine(money);
            write.WriteLine(deathRattle);
            write.Close();
        }

    }
    class General
    {
        public static void Main() 
        {
            heartstone[] Vector = new heartstone[3];
            Vector[0] = new Murlok();
            Vector[1] = new Elemental();
            Vector[2] = new Pirat();

            Vector[0].print();
            //Vector[0].input();
            //Vector[0].print();
            //Vector[1].print();
            //Vector[1].input();
            //Vector[1].print();
            //Vector[2].print();
            //Vector[2].input();
            //Vector[2].print();

            Vector[0].writeFile("D:\\qwerty\\Cesnokov_Lab_2\\file.txt");
        }
    } 
}
