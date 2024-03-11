using System.Collections.Concurrent;
using System.Resources;

namespace Data_Structures___Arrays_Practice
{
    internal class Program
    {
        private static Random random;



        static void Main(string[] args)
        {
            static void Part1(string[] args)
            {
                string[] week = [" Mon", " Tue", " Wed", " Thu", " Fri", " Sat", " Sun"];
                Console.Write($"The days of the week are: {string.Join(",", week)}");

                //-----

                int d = 4; // Enter index value of week item that matches first day of the desired month
                int m = 31; // switch between 30 or 31;
                string[] thisMonth = new string[m];

                for (int i = 0; i < thisMonth.Length; i++)
                {
                    int mod = (d + i) % 7;
                    thisMonth[i] = " " + Convert.ToString(i + 1) + ":" + week[mod];

                }

                Console.WriteLine();
                Console.WriteLine($"The days this month are: {string.Join(",", thisMonth)}");

                //-----

                var random = new Random();
                double[] randInts = new double[random.Next(5, 11)];
                for (int i = 0; i < randInts.Length; i++)
                {
                    randInts[i] = random.Next(1, 11);
                }

                Console.WriteLine();
                Console.WriteLine($"{randInts.Length} random numbers are: {string.Join(",", randInts)}");

                //-----

                double[] interInts = new double[randInts.Length * 2 - 1];
                interInts[0] = randInts[0];
                for (int i = 1; i < randInts.Length; i++)
                {
                    double inter = (randInts[i] + randInts[i - 1]) / 2;
                    interInts[i * 2] = randInts[i];
                    interInts[i * 2 - 1] = inter; // found the solution formula from Matej's code

                }
                Console.WriteLine();
                Console.WriteLine($"Interpolated numbers are: {string.Join(",", interInts)}");
            }

        }
    }
}
   



