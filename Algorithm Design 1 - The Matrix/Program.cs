using System;

namespace Algorithm_Design_1___The_Matrix
{
    internal class Program
    {
        private static Random random;
        static void Main(string[] args)
        {
            var random = new Random();
            var streams = new List<int> { };
            var symbols = "!@#$%^&*()_+-=[];'\\,./~{}:|<>?";


            for (int i = 0; i < 10; i++)
            {
                streams.Add(random.Next(0, 80));
            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            while (true)
            {
                for (int x = 0; x < 40; x++)
                {
                    Console.Write(streams.Contains(x) ? symbols[random.Next(symbols.Length)] : ' ');
                }

                Console.WriteLine();
                Thread.Sleep(50);

                if (random.Next(3) == 0 || streams.Count == 0) streams.Add(random.Next(0, 40)); // switched Add to above Remove, since index was going out of range. Then checked Matej's code to find extra OR statement.
                if (random.Next(3) == 0) streams.RemoveAt(random.Next(streams.Count));

            }

        }
    }
}
