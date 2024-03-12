using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Data_Structures___Dictionaries
{
    internal class Program
    {
        private static Random random;
        static void Main(string[] args)
        {
            var hosts = new Dictionary<int, string>()
            {
                { 2000, "Australia" },
                { 2004, "Athens"},
                { 2008, "China" },
                { 2012, "United Kingdom" },
                { 2016, "Brazil" },
                { 2020, "Japan" },
                { 2024, "France" },
                { 2028, "United States" },
                { 2032, "Australia" }

            };

            var random = new Random();
            //int year = 2000 + random.Next(hosts.Count) * 4;

            //Console.WriteLine($"Which country hosted the Summer Olympic Games in {year}?");
            //string country = Console.ReadLine();
            //if (country == hosts[year]) Console.WriteLine("Correct!");
            //else Console.WriteLine($"Incorrect. It was {hosts[year]}");

            //------------------------

            //do
            //{
            //    var CountriesAndCapitals = new SortedList<string, string>()
            //{
            //    {"Ethiopia", "Addis Ababa"},
            //    {"Jordan", "Amman" },
            //    {"Netherlands", "Amsterdam" },
            //    {"Turkey", "Ankara" },
            //    {"Iraq", "Baghdad" },
            //    {"Azerbaijan", "Baku" },
            //    {"Belize", "Belmopan" },
            //    {"Kyrgystan", "Bishkek" },
            //    {"Slovakia", "Bratislava" },
            //    {"Venezuela", "Caracas" },
            //    {"Senegal", "Dakar" },
            //    {"Syria", "Damascus" },
            //    {"Tajikistan", "Dushanbe" },
            //    {"Croatia", "Zagreb" }

            //};
            //    var countries = new List<string>(CountriesAndCapitals.Keys);
            //    var capitals = new List<string>(CountriesAndCapitals.Values);

           

            //    int rndCountry = random.Next(countries.Count - 1);

            //    Console.WriteLine($"What is the capital of {countries[rndCountry]}?");
            //    string answer = Console.ReadLine();
            //    if (answer == capitals[rndCountry]) Console.WriteLine("Correct!");
            //    else Console.WriteLine($"Incorrect. It is {capitals[rndCountry]}");

            //} while (true);

            // readline ask for winner name V
            // create and increment score variable, if readline == dictionary item V
            // writeline rankings, with names and scores
            // with dictionary sorted by score

            // ContainKey to check if player has score V
            // dictionary to list to array, then array sort/reverse


            var scoreboard = new Dictionary<string, int>();
            
            do
            {
                Console.WriteLine("Who won this round?");
                string winner = Console.ReadLine();

                if (winner.Length == 0)
                    break;

                if (scoreboard.ContainsKey(winner))
                {
                    scoreboard[winner] += 1;
                }
                else scoreboard.Add(winner, 1);

                Console.WriteLine("RANKINGS");
                foreach (var add in scoreboard)
                {
                    Console.WriteLine($"{add.Key} {add.Value}");
                }
                


            } while (true);

            var names = new List<string>(scoreboard.Keys).ToArray();
            var scores = new List<int>(scoreboard.Values).ToArray();
            Array.Sort(scores, names);
            Array.Reverse(names);

            Console.WriteLine("FINAL RANKINGS");
            foreach (string player in names)
            {
                Console.WriteLine($"{player} {scoreboard[player]}");
            }



        }
    }
}
