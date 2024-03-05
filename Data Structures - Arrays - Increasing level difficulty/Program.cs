using System.Linq;

class Program
{
    private static Random random;
    static void Main(string[] args)
    {
        int[] monsterNum = new int[100];
        for (int i = 0; i < monsterNum.Length; i++)
        {
            random = new Random();
            int rand = random.Next(1, 51);
            monsterNum[i] = rand;
        }
        Array.Sort(monsterNum);
        Console.WriteLine($"Number of monsters in levels: {string.Join(",", monsterNum)}" );

    }
}