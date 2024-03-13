namespace Algorithm_Design_2___Party_Shuffle
{
    internal class Program
    {
        private static Random random;
        static void Main(string[] args)
        {
            var names = new List<string> { "Hari", "Raiza", "Aqil", "Shinja", "Shubham", "Anjum", "Rushabh", "Nikita" };
           
            Console.Write("Signed up participants: ");
            Console.Write(string.Join(", ",names));

            Console.WriteLine();
            Console.WriteLine("ENTER to randomize");
            Console.ReadLine();

            static void ShuffleList(List<string> items)
            {
                var random = new Random();
                for (int i = items.Count - 1; i > 0; i--)
                {
                    int j = random.Next(items.Count);
                    //(items[j], items[i]) = (items[i], items[j]); used a touple
                    var temp = items[j];
                    items[j] = items[i];
                    items[i] = temp;                    
                }

                Console.WriteLine("Generating random order...");
                Console.WriteLine(string.Join(", ", items));
            }

            ShuffleList(names);

           
        }
    }
}
