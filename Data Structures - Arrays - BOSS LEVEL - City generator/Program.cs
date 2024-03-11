class Program
{
    private static Random random;
    static void Main(string[] args)
    {
        int width = 30;
        int height = 30;
        var roads = new bool[width, height];

        var random = new Random();
        //int x = random.Next(0, roads.GetLength(0));
        //int y = random.Next(0, roads.GetLength(1));


        static void GenerateRoad(bool[,] roads, int startX, int startY, int dir)
        {
            int width = roads.GetLength(0);
            int height = roads.GetLength(1);

           while ((0 <= startX < width) && (0 <= startY < height))
            {
                Console.Write("#");
                roads[startX, startY] = true;

                if (dir == 0) startX++;
                if (dir == 1) startY++;
                if (dir == 2) startX--;
                if (dir == 3) startY--;
                
            }
        }

        for (int i = 0; i < roads.GetLength(0); i++)
        {
            for (int j = 0; j < roads.GetLength(1); j++)
            {
                if (roads[x, y])
                {
                    bool up = roads[x, y + 1];
                    bool down = roads[x, y - 1];
                    bool right = roads[x + 1, y];
                    bool left = roads[x - 1, y];

                    //GenerateRoad(roads, x, y, random.Next(4));
                }
            }
        }






















    }




}