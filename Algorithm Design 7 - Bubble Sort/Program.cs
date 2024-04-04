namespace Algorithm_Design_7___Bubble_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var data = new List<int>() { 1, 14, 7, 3, 12, 10, 15, 4, 2, 9, 11, 5, 8, 6, 13 };
            var random = new Random();

            

            // Bubble sort

            // Go through the list number by number and compare it to its next neighbor.
            // If the next neighbor is smaller than the previous one, swap them!
            // Continue until we reach the end.
            // Each time we go through the list, the highest neighbor will 'bubble' to the end.
            // This means we have to sort a smaller and smaller part of the list as we go on.
            // We'll decrease our sorting range one by one until the whole list is sorted.

            int i = 0;
            bool swapped = true;
            int swaps = 0;
            int length = data.Count;

            while (swapped)
            {
                while(i < length - 1)
                {
                    if (data[i] > data[i + 1])
                    {
                        int temp = data[i];
                        data[i] = data[i + 1];
                        data[i + 1] = temp;
                        swaps++;
                    }
                    i++;
                    length--;
                }

                if (swaps == 0)
                {
                    swapped = !true;
                }
                else
                {
                    swaps = 0;
                    i = 0;
                }
                DisplayData(data);
            }

        }

        static void DisplayData(List<int> data)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);

            for (int y = 20; y >= 0; y--)
            {
                if (y % 5 == 0)
                {
                    Console.Write($"{y,3} |");
                }
                else
                {
                    Console.Write("    |");
                }

                for (int x = 0; x < data.Count; x++)
                {
                    if (y == 0)
                    {
                        Console.Write("-");
                        continue;
                    }

                    Console.Write(y <= data[x] ? "\u2592" : " ");
                }

                Console.WriteLine();
            }

            Thread.Sleep(10);


            Console.WriteLine($"The sorted numbers are: {string.Join(", ", data)}");
        }
    }
}
