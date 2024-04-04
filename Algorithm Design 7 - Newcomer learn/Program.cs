using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace Chart
{
    class Program
    {
        private static Random random;
        static void Main(string[] args)
        {
            var data = new List<double>();

            var random = new Random();

            for (int i = 0; i < 20; i++)
            {
                data.Add(random.Next(21));
                DisplayData(data);
            }
        }

        static void DisplayData(List<double> data)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);

            for (int y = 20; y >= 0; y--)
            {
                if (y % 5 == 0)
                {
                    Console.Write($"{y,3} |");
                }
                else
                {
                    Console.Write("    |");
                }

                for (int x = 0; x < data.Count; x++)
                {
                    if (y == 0)
                    {
                        Console.Write("-");
                        continue;
                    }

                    Console.Write(y <= data[x] ? "H" : " "); // Unicode for Box: \u2592
                }

                Console.WriteLine();
            }

            Thread.Sleep(10);
        }
    }
}
