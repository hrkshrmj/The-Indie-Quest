using static System.Net.Mime.MediaTypeNames;
using System;

namespace Algorithm_Design_7___Insertion_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var data = new List<int>() { 1, 14, 7, 3, 12, 10, 15, 4, 2, 9, 11, 5, 8, 6, 13 };
            /* 1, 14, 7, 3, 12, 10, 15, 4, 2, 9, 11, 5, 8, 6, 13
             * 0, 4, 8, 9 first number sorted and zero
             * 1, 2, 6, 4, 8 first number sorted
             * 7, 7, 7 same number
             * -7, -2, -5, -3, -1 negative numbers with first number sorted
             * 4, 5, 2, 7       first number unsorted
             * 1, 4, 5, 1, 5, 4 duplicates with first number sorted
             */

            // Insertion sort

            // Split the list between sorted numbers on the left and unsorted on the right.
            // At the start, only the first number is sorted, the rest are unsorted.
            // Then take the first unsorted number and move it to the left until it is in the correct place in the sorted list.
            // Repeat this with all unsorted numbers until all the numbers are in the sorted list.

            int sortedCount = 1;

            do
            {
                // Find the first unsorted number.
                int indexOfFirstUnsortedNumber = sortedCount;
                int firstUnsortedNumber = data[indexOfFirstUnsortedNumber];

                // Test the sorted number to the left of it and see if it is bigger.
                int testIndex = indexOfFirstUnsortedNumber - 1;

                while (data[testIndex] > firstUnsortedNumber)
                {
                    // The sorted number is bigger!
                    // Move the sorted number to the right since it is bigger than the unsorted number.
                    // (Bigger numbers must be on the right of the smaller ones.)
                    data[testIndex + 1] = data[testIndex];

                    // Continue testing the next number on the left.
                    testIndex--;

                    // Display data for diagnostic purposes.
                    DisplayData(data);
                }

                // The unsorted number should now be placed into the spot where the last tested number was shifted away from.
                int insertionIndex = testIndex + 1;
                data[insertionIndex] = firstUnsortedNumber;

                // We've successfully sorted a new number.
                sortedCount++;

                // Display data for diagnostic purposes.
                DisplayData(data);

            } while (sortedCount < data.Count);
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
