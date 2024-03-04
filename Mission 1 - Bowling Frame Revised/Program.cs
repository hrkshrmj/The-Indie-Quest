using System.Runtime.InteropServices;

var random = new Random(); // initializing new Random method

int pins1 = 10; 
int roll1 = random.Next(0, 11);
pins1 = pins1 - roll1;

int roll2;
int pins2;

if (pins1 == 0)
{
    Console.WriteLine("First Roll: X");
    Console.WriteLine($"Knocked Pins: 10");
}

else
{
    if ((pins1 == 10) || (pins1 > 0))
    {
        Console.WriteLine($"First Roll: {roll1}");
        roll2 = random.Next(0, pins1+1);
        pins2 = pins1 - roll2;
     
        if (pins2 == 0)
        {
            Console.WriteLine("Second Roll: /");
        }

        else if ((pins2 > 0) || (pins2 == pins1))
        {
            Console.WriteLine($"Second Roll: {roll2}");
        }
        Console.WriteLine($"Knocked Pins: {roll1 + roll2}");

    }
}

