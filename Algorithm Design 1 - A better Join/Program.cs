namespace Algorithm_Design_1___A_better_Join
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> items = [" Jazlyn", " Theron", " Dayana", " Rolando"];

            while (items.Count > 0) // Loop to repeat statement 4 times, with first index item removed each iteration
            {
                Console.WriteLine($"The heroes in the party are: {JoinWithAnd(items, true)}");
                items.RemoveAt(0);
            } 

            static string JoinWithAnd(List<string> items, bool useSerialComma = true)
            {
                var count = items.Count;

                if (count == 0) return " ";
                if (count == 1) return items[0];
                if (count == 2) return string.Join(" and", items);
                else
                {
                    var itemsCopy = new List<string>(items);
                    if (useSerialComma)
                    {
                        itemsCopy[count - 1] = " and" + itemsCopy[count - 1];
                        return string.Join(",", itemsCopy);

                    }
                    else
                    {
                        itemsCopy[count - 2] = string.Join(" and", items[count - 2], items[count - 1]);
                        itemsCopy.RemoveAt(count - 1);
                        return string.Join(",", itemsCopy);

                    }

                }

            }

        }
    }
}
