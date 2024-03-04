using System.Numerics;

var random = new Random();
int checkSix = 0;

int roll1;
int roll2;
int roll3;

roll1 = random.Next(0, 7);
Console.WriteLine($"The player rolls: {roll1}");
if (roll1 == 6)
{
    checkSix++;
    roll2 = 0;
    roll3 = 0;
    Console.WriteLine($"Total score is: {roll1 + roll2 + roll3}");
}

if (checkSix < 1)
{
    roll2 = random.Next(0, 7);
    Console.WriteLine($"The player rolls: {roll2}");
    if (roll2 == 6)
    {
        roll3 = 0;
        Console.WriteLine($"Total score is: {roll1 + roll2 + roll3}");
    }
    else
    {
        roll3 = random.Next(0, 7);
        Console.WriteLine($"The player rolls: {roll3}");
        Console.WriteLine($"Total score is: {roll1 + roll2 + roll3}");
    }
}