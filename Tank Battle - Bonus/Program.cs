using System.Diagnostics.Metrics;

Console.WriteLine("DANGER! A tank is approaching our position. Your artillery unit is our only hope!");

Console.WriteLine("What is your name, commander?");
string player = Console.ReadLine(); // Get name input

int tankMax = 80;
var random = new Random();
int tankDist = random.Next(41, tankMax+1);

while (tankDist > 0)
{
    Console.WriteLine("Here is the map of the battlefield:");
    //Console.WriteLine($"tank dist: {tankDist}"); // for playtesting

    Console.Write("_/"); // Draw artillery

    for (int i = 0; i < tankDist; i++) // Space tank
    {
        Console.Write("_");
    }

    Console.Write("T"); // Place tank

    for (int i = 0; i < ((tankMax-1) - tankDist); i++) // Space after tank
    {
        Console.Write("_");
    }

    Console.WriteLine(" "); // linebreak
    Console.WriteLine($"Aim your shot, {player}! Enter distance: "); // Get dist input
    int dist1 = (Convert.ToInt32(Console.ReadLine())); // type cast string input to store in int variable
    int tankMove = 5;

    for (int i = 0; i < dist1; i++) // Space shot at dist value
    {
        Console.Write(" ");
    }

    Console.WriteLine("  *"); // Place shot

    if (dist1 == tankDist)
    {
        Console.WriteLine("Hit! Target Eliminated!");
        tankDist = 0;
    }

    else if (dist1 < tankDist)
    {
        Console.WriteLine("Damn, the shell lands too short.");
        tankDist = tankDist - tankMove;
        Console.WriteLine("Press ENTER to see updated battlefield: ");
        Console.ReadLine();
        Console.Clear();
    }

    else if (dist1 > tankDist)
    {
        Console.WriteLine("Alas, the shell flies past the tank.");
        tankDist = tankDist - tankMove;
        Console.WriteLine("Press ENTER to see updated battlefield: ");
        Console.ReadLine();
        Console.Clear();
    }
}

if (tankDist == 0)
{
    Console.WriteLine("BOOM! Your aim is legendary and the tank is destroyed!");
}




