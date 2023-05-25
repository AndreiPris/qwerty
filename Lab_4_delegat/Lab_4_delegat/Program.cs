using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_delegat
{
    class Athletes
    {
        public int Weight { get; set; }
        public int Strength { get; set; }

        public static List<Athletes> AthleteList = new List<Athletes>();
        private static object _lockObject = new object();



        public void FindStrongestAtleteInColumn(object columnIndex)
        {
            int column = (int)columnIndex;

            Athletes[,] Matrix = new Athletes[3, 4]
            {
            { new Athletes { Weight = 80, Strength = 6}, new Athletes { Weight = 75, Strength = 8}, new Athletes { Weight = 90, Strength = 9}, 
                    new Athletes { Weight = 100, Strength = 8} },
            { new Athletes { Weight = 77, Strength = 10}, new Athletes { Weight = 120, Strength = 9}, new Athletes { Weight = 65, Strength = 7}, 
                    new Athletes { Weight = 98, Strength = 4} },
            { new Athletes { Weight = 59, Strength = 3}, new Athletes { Weight = 150, Strength = 10}, new Athletes { Weight = 104, Strength = 9},
                    new Athletes { Weight = 145, Strength = 1} }
            };

            Athletes Strongest = null;

            for (int row = 0; row < Matrix.GetLength(0); row++)
            {
                Athletes currentAtlete = Matrix[row, column];

                if (Strongest == null || currentAtlete.Strength > Strongest.Strength)
                {
                    Strongest = currentAtlete;
                }
            }

            lock (_lockObject)
            {
                // Выводим информацию о самой тяжелой звезде на экран
                Console.WriteLine($"Самая тяжелая звезда в колонке {column + 1}:");
                Console.WriteLine($"Вес: {Strongest.Weight}");
                Console.WriteLine($"Сила: {Strongest.Strength}");

                // Добавляем самую тяжелую звезду в глобальный список
                AthleteList.Add(Strongest);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Thread[] columnThreads = new Thread[4];

            for (int column = 0; column < columnThreads.Length; column++)
            {
                Athletes star = new Athletes();

                columnThreads[column] = new Thread(star.FindStrongestAtleteInColumn);
                columnThreads[column].Start(column);
            }

            // Дожидаемся завершения всех потоков
            foreach (Thread thread in columnThreads)
            {
                thread.Join();
            }

            Athletes heaviest = null;

            // Находим звезду с минимальным числом планет в глобальном списке
            foreach (Athletes athlete in Athletes.AthleteList)
            {
                if (heaviest == null || athlete.Weight < heaviest.Weight)
                {
                    heaviest = athlete;
                }
            }

            Console.WriteLine("\nЗвезда с минимальным числом планет:");
            Console.WriteLine($"Вес: {heaviest.Weight}");
            Console.WriteLine($"Сила {heaviest.Strength}");
            Console.ReadLine();
        }
    }
}
