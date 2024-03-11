namespace Data_Structures___Array_Practice___Part_2
{
    internal class Program
    {
        private static Random random;
        static void Main(string[] args)
        {
            var random = new Random();
            int matrixI = random.Next(2, 6);
            int matrixJ = random.Next(2, 6);

            int[,] ints2d = new int[matrixI, matrixJ];

            static void Fill2DArray(int[,] arr) {
                var random = new Random();
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        arr[i, j] = random.Next(10);
                    }
                }
            }        

            static void Print2DArray(int[,] arr)
            {
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        Console.Write(string.Join(",", arr[i, j]));
                    }
                    Console.WriteLine();
                }
            }
            
            static void Print2DTranspose(int[,] arr)
            {
                for (int i = 0; i < arr.GetLength(1); i++)
                {
                    for (int j = 0; j < arr.GetLength(0); j++)
                    {
                        Console.Write(arr[j, i]);
                    }
                    Console.WriteLine();
                }
            }

            Fill2DArray(ints2d);

            Print2DArray(ints2d);
            Console.WriteLine(); // Linebreak
            Print2DTranspose(ints2d);

            //---------------------------

            int factor = 5;
            int multiple = 20;
            int[,] multiplications = new int[factor, multiple];
            static void MultiplicationsTable(int[,] arr)
            {
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        // serial[i, j] = i * 10 + (j+1) * 1;
                        arr[i, j] = (i + 1) * (j + 1);
                    }

                }
            }            
            Console.WriteLine();
            MultiplicationsTable(multiplications);
            Print2DArray(multiplications);

            //--------------------------- abandoned the missions from Part 2: Missions 4, 5; and Part 3 onwards

            //char[,] tttoe = new char[3, 3]; // Declare empty array
            //char[] marks = ['x', 'o', '-'];
            //for (int i = 0; i < 3; i++) // Loop to place char at all locations
            //{
            //    for (int j = 0; j < 3; j++)
            //    {
            //        tttoe[i, j] = marks[random.Next(3)];
            //        Console.Write(tttoe[i, j]);

            //        if (tttoe[i, j] || tttoe[i+1,j] == 'x')
            //        {

            //        }

            //    }
            //    Console.WriteLine();
            //}

            //int[,] chessboard = new int[8, 8];
            //for (int i = 0; i < 8; i++)
            //{
            //    for (int j = 0; j < 8; j++)
            //    {
            //        chessboard[i, j] = Int32.MaxValue;
            //    }
            //}

            //void knightMove(int sx, int sy, int move)
            //{
            //    if (sx < 0 || sx > 7 || sy < 0 || sy > 7) return;

            //    if (chessboard[sx, sy] < move) return;

            //    chessboard[sx, sy] = move;

            //    knightMove(sx + 1, sy + 2, move + 1);
            //    knightMove(sx + 2, sy + 1, move + 1);
            //    knightMove(sx - 1, sy + 2, move + 1);
            //    knightMove(sx - 2, sy + 1, move + 1);
            //    knightMove(sx + 1, sy - 2, move + 1);
            //    knightMove(sx + 2, sy - 1, move + 1);
            //    knightMove(sx + 1, sy + 2, move + 1);
            //    knightMove(sx - 1, sy - 2, move + 1);
            //    knightMove(sx - 2, sy - 1, move + 1);

            //}

            //knightMove(random.Next(8), random.Next(8), 0);

            //for (int i = 0; i < 8; i++)
            //{
            //    for (int j = 0; j < 8; j++)
            //    {
            //        Console.Write(chessboard[i,j]);
            //    }
            //    Console.WriteLine();
            //}
        }
    }
}