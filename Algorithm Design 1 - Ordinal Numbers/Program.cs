namespace Algorithm_Design_1___Ordinal_Numbers
{
    internal class Program
    {
        private static Random random;
        static void Main(string[] args)
        {

            static string GetOrdinal(int x)
            {
                var lastDigit = x % 10;
                var secondLastDigit = 0;
                if (x > 10)
                {
                    secondLastDigit = (x / 10) % 10;
                }

                if (secondLastDigit == 1) return Convert.ToString(x) + "th";
                if (lastDigit == 1) return Convert.ToString(x) + "st";
                if (lastDigit == 2) return Convert.ToString(x) + "nd";
                if (lastDigit == 3) return Convert.ToString(x) + "rd";
                else
                    return Convert.ToString(x) + "th";
            }

            var random = new Random();
            Console.WriteLine(GetOrdinal(random.Next(1, 1000)));
        }
    }
}
