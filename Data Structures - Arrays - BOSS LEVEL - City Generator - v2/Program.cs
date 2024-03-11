namespace Data_Structures___Arrays___BOSS_LEVEL___City_Generator___v2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int height = 20;
            int width = 60;                     
            var roads = new bool[height, width]; 
            
            static void GenerateRoad(bool[,] roads, int startX, int startY, int dir)
            {
                while (0 <= startX && startX < roads.GetLength(0) && 0 <= startY && startY < roads.GetLength(1))
                {
                    roads[startX, startY] = true;

                    if (dir == 0) startY++; //right
                    if (dir == 1) startX++; //down
                    if (dir == 2) startY--; //left
                    if (dir == 3) startX--; //up                             

                }
            } // Creates invisible bool array of roads

            //GenerateRoad(roads, 10, 25, 2);
            //GenerateRoad(roads, 0, 15, 1);
            //GenerateRoad(roads, 15, 10, 0);
            //GenerateRoad(roads, 10, 55, 3);
                   
            static void GenerateIntersection(bool[,] roads, int x, int y)
            {
                var random = new Random();

                for (int i = 0; i < 4; i++)
                {
                    int odds = random.Next(0, 11);
                    if (odds < 7) GenerateRoad(roads, x, y, i);                    
                }                             
                
            }

            GenerateIntersection(roads, 15, 25);
            GenerateIntersection(roads, 10, 30);
            GenerateIntersection(roads, 5, 10);

            for (int i = 0; i < roads.GetLength(0); i++)
            {
                for (int j = 0; j < roads.GetLength(1); j++)
                {
                    if (roads[i, j]) Console.Write("#");
                    else Console.Write(" ");
                }
                Console.WriteLine();
            }
                            



                //static void GenerateCity(int width, int height)
                //{
                //    var random = new Random();
                //    bool[,] roads = new bool[width, height];

                //    GenerateIntersection(roads, random.Next(width), random.Next(height));

                //    for (int j = 0; j < width; j++)
                //    {
                //        for (int i = 0; i < height; i++)
                //        {

                //            if (roads[i, j])
                //            {
                //                bool right = roads[i, j + 1];
                //                bool down = roads[i + 1, j];
                //                bool left = roads[i, j - 1];
                //                bool up = roads[i - 1, j];



                //                if (up && down && left)
                //                {
                //                    Console.Write("╬");
                //                    continue;
                //                }

                //                if (up && down && left)
                //                {
                //                    Console.Write("╣");
                //                    continue;
                //                }

                //                if (up && down && right)
                //                {
                //                    Console.Write("╠");
                //                    continue;
                //                }

                //                if (up && left && right)
                //                {
                //                    Console.Write("╩");
                //                    continue;
                //                }

                //                if (down && left && right)
                //                {
                //                    Console.Write("╦");
                //                    continue;
                //                }

                //                if (left && up)
                //                {
                //                    Console.Write("╝");
                //                    continue;
                //                }

                //                if (left && down)
                //                {
                //                    Console.Write("╗");
                //                    continue;
                //                }

                //                if (up && right)
                //                {
                //                    Console.Write("╚");
                //                    continue;
                //                }

                //                if (right && down)
                //                {
                //                    Console.Write("╔");
                //                    continue;
                //                }

                //                if (up || down)
                //                {
                //                    Console.Write("║");
                //                    continue;
                //                }

                //                Console.Write("═");
                //                continue;



                //            }
                //            else Console.Write(" ");
                //        }
                //        Console.WriteLine();
                //    } // // Places character at true indices

                //}
                //GenerateCity(50, 20);
                // Tried to integrate Bonus part, but failed to figure out the index out of range during bool check
        }
    }
}
