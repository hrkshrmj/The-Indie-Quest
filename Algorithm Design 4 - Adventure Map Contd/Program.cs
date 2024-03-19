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
                DrawMap(100, 30);

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
            var river = GenerateVerticalCurve(fourthQuarter, height, 2);

            // Generate wall
            var wall = GenerateVerticalCurve(firstQuarter, height, 25);

            // Generate road

            var road = new List<int>();
            int roadStartY = height / 2;

            for (int x = 0; x < width; x++)
            {
                road.Add(roadStartY);

                // Are we away from the river AND wall?
                if (x < river[roadStartY] - 3 || x > river[roadStartY] + 5)
                    if (x < wall[roadStartY] - 2 || x > wall[roadStartY] + 4)
                        {
                        // Move the road slightly.
                        int direction = random.Next(7);
                        if (direction == 0)
                        {
                            if (roadStartY > 0)
                                roadStartY--;
                        }
                        if (direction == 1)
                        {
                            if (roadStartY < height - 1)
                                roadStartY++;
                        }
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

                    // Draws Borders
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

                    // Draw Title
                    if (y == 1 && x == titleX)
                    {
                        Console.Write(title);
                        x += title.Length - 1;
                        continue;
                    }

                    

                    //Draws bridge if one up and one down, and 3 left and 5 right of river
                    if ((y == road[x] - 1 || y == road[x] + 1) && (x > river[road[x]] - 3 && x < river[road[x]] + 5))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("=");
                        continue;
                    }

                    // Draws Road
                    if (y == road[x])
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("#");
                        continue;
                    }


                    // Draws River Road
                    int riverRoad = river[y] - 5;
                    if (y > roadIntersectionY && x == riverRoad)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("#");
                        continue;
                    }

                    // Draw Wall TURRETS
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                    if (y == road[x] + 1 && x == wall[y] || y == road[x] - 1 && x == wall[y])
                    {
                        Console.Write("[");
                        continue;
                    }

                    if (y == road[x] + 1 && x == wall[y] + 1 || y == road[x] - 1 && x == wall[y] + 1)
                    {
                        Console.Write("]");
                        continue;
                    }

                    // Draws Wall
                    if (x >= wall[y] && x < wall[y] + 2)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;

                        DrawVerticalCurve(wall, x, y);
                        continue;
                        
                    }

                    // Draws River
                    if (x >= river[y] && x < river[y] + 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;

                        int direction = river[y + 1] - river[y];

                        DrawVerticalCurve(river, x, y);
                        continue;
                    }

                    // Draws Forest
                    if (x < firstQuarter) 
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

                Console.Write(' ');

                }
                Console.WriteLine();

            }
            Console.WriteLine();

        }

        static List<int> GenerateVerticalCurve(int startX, int startY, int curveChance) // startY is always height
        {
            var curve = new List<int>();
            int curveStartX = startX;
            var random = new Random();

            for (int y = 0; y < startY; y++)
            {
                curve.Add(curveStartX);
                int direction = random.Next(curveChance);
                if (direction == 0 && curveStartX > startX) curveStartX--;
                if (direction == 1) curveStartX++;
            }

            return curve;
        }

        static void DrawVerticalCurve(List<int> curve, int x, int y)
        {
                int direction = curve[y + 1] - curve[y];

                if (direction == -1)
                {
                    Console.Write("/");
                }

                else if (direction == 0)
                {
                    Console.Write("|");
                }

                else
                {
                    Console.Write("\\");
                }

        }
    }
}
