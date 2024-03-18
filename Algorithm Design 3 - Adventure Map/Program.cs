namespace Algorithm_Design_3___Adventure_Map
{
    internal class Program
    {
        private static Random random;
        static void Main(string[] args)
        {
            static void Map(int width, int height)
            {
                var random = new Random();
                string symbols = "!@#$%^&*()_+-=[];'\\,./~{}:|<>?";

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (x == 0 && y == 0 || x == width-1 && y == 0 || x == 0 && y == height-1 || x == width-1 && y == height-1) // draw Border Corner
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write('+');
                            continue;
                        }
                        else if (x > 0 && y == 0 || x > 0 && y == height-1) // draw Horizontal Border
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write('-');
                            continue;
                        }
                        else if (x == 0 && y > 0 || x == width-1 && y > 0) // draw Vertical border
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write('|');
                            continue;
                        }
                        if (x < width / 4) // draw Forest
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            if (random.Next(x) < 2)
                            {
                                Console.Write($"{symbols[random.Next(symbols.Length)]}");
                                continue;
                            }
                            else Console.Write(' ');
                        }
                        else // draw Empty space
                        {
                            Console.Write(' ');
                        }

                            

                    }
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            Map(80, 20);
        }
    }
}
