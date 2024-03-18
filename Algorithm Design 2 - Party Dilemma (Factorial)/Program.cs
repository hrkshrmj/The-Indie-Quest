namespace Algorithm_Design_2___Party_Dilemma__Factorial_
{
    internal class Program
    {
        static void Main(string[] args)
        {
           var list = new List<string> { "Miyamoto","Meier","Kojima","Carmack","Newell","Molyneux","Sawyer", "Sakurai" };
            Console.WriteLine($"Starting participants: {string.Join(",",list)}");
            WriteAllPermutations(list);
        }

        static List<string> ShuffleList(List<string> items)
        {
            Random random = new Random();
            for (int i = items.Count - 1; i > 0; i--)
            {
                int j = random.Next(items.Count);
                //(items[j], items[i]) = (items[i], items[j]); used a tuple
                var temp = items[j];
                items[j] = items[i];
                items[i] = temp;
            }
            return items;
        }
        static double Factorial(double n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return (n * Factorial(n - 1));
            }
        }
        static void WriteAllPermutations(List<string> items)
        {
            double permutations = Factorial(items.Count);
            Console.WriteLine("Starting orders:");
            for (int i = 0; i < permutations; i++)
            {
                ShuffleList(items);
                Console.WriteLine(i + 1 + "." + string.Join(",",items));
            }
            
        }
    }
}
