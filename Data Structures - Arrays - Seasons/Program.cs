using System.Linq;

class Program
{
    private static Random random;
    static void Main(string[] args)
    {
        static void CreateDayDescription(int day, int season, int year)
        {
            string[] SeasonsArray = { "Spring", "Summer", "Autumn", "Winter" };
            Console.WriteLine($"Day {day} of {SeasonsArray[season]} in the year {year}");
        }

        random = new Random();
        CreateDayDescription((random.Next(1, 366)), (random.Next(0,4)) ,(random.Next(0, 2024)));























    }
}