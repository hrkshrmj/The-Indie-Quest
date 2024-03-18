using System.Collections.Generic; 
namespace Algorithm_Design_4___Adventure_Map_Contd_

{
    class Program
    {
        //private static Random random;
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                DrawMap(120, 20);

                var keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Escape) break;
            }
        }
        static void DrawMap(int width, int height)
        {
            int firstQuarter = width / 4;
            int fourthQuarter = width * 3 / 4;
            var random = new Random();

            // Generate river
            var river = new List<int>();
            int riverStartX = fourthQuarter;
        
            for (int y = 0; y < height; y++)
            {
                river.Add(riverStartX);
                int direction = random.Next(3);
                if (direction == 0 && riverStartX > fourthQuarter) riverStartX--;
                if (direction == 2) riverStartX++;
            }

            // Generate road

            var road = new List<int>();
            int roadStartY = height / 2;

            for (int x = 0; x < width; x++)
            {
                road.Add(roadStartY);

                if (x < river[roadStartY] - 2 || x > river[roadStartY] + 5)
                {
                    int direction = random.Next(7);
                    if (direction == 0) roadStartY--;
                    if (direction == 1) roadStartY++;
                }
            }

            // Find intersection

            int roadIntersectionX = 0;
            for (int x = 0; x < width; x++)
            {
                if (x > river[road[x]] - 5)
                {
                    roadIntersectionX = x;
                    break;
                }
            }
            int roadIntersectionY = road[roadIntersectionX];

            // Title
            var title = "ADVENTURE MAP";
            var titleX = (width - title.Length) / 2;

            // Draw Map

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    bool verticalBorder = x == 0 || x == width-1;
                    bool horizontalBorder = y == 0 || y == height-1;

                    Console.ForegroundColor = ConsoleColor.Yellow;

                    if (verticalBorder && horizontalBorder)
                    {
                        Console.Write("+");
                        continue;
                    }

                    else if (horizontalBorder)
                    {
                        Console.Write("-");
                        continue;
                    }

                    else if (verticalBorder)
                    {
                        Console.Write("|");
                        continue;
                    }

                  

                    if (y == 1 && x == titleX)
                    {
                        Console.Write(title);
                        x += title.Length - 1;
                        continue;
                    }

                    if ((y == road[x] - 1 || y == road[x] + 1) && (x > river[road[x]] - 3 && x < river[road[x]] + 5))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("=");
                        continue;
                    }

                    if (y == road[x])
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("#");
                        continue;
                    }

                    int riverRoad = river[y] - 5;
                    if (y < roadIntersectionY && x == riverRoad)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("#");
                        continue;
                    }

                    if (x >= river[y] && x < river[y] + 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;

                        int direction = river[y + 1] - river[y];

                        if (direction == -1)
                        {
                            Console.Write("{");
                           
                        }

                        else if (direction == 0)
                        {
                            Console.Write("S");
                            
                        }

                        else
                        {
                            Console.Write("}");
                            
                        }
                        continue;
                    }

                    if (x < firstQuarter) // draw Forest
                    {
                        int forestInverseChance = x - 1;
                        if (random.Next(forestInverseChance) <8)
                        {
                            // Draw one of the trees.
                            var trees = "xX****%";

                            if (random.Next(2) == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                            }

                            Console.Write(trees[random.Next(trees.Length)]);
                            continue;
                        }

                    }

                Console.Write('.');

                }
                Console.WriteLine();

            }
            Console.WriteLine();

        }
        
    }
}
