using System.Diagnostics.Metrics;

Console.WriteLine("DANGER! A tank is approaching our position. Your artillery unit is our only hope!");

Console.WriteLine("What is your name, commander?");
string player = Console.ReadLine(); // Get name input

Console.WriteLine("Here is the map of the battlefield");

var random = new Random();
int tankDist = random.Next(41, 71);
//Console.WriteLine($"tank dist: {tankDist}"); // for playtesting
int tankShots = 5;

Console.Write("_/"); // Draw artillery

for (int i = 0; i < tankDist; i++) // Space tank
{
    Console.Write("_");
}

Console.Write("T"); // Place tank

for (int i = 0; i< (79 - tankDist); i++) // Space after tank
{
    Console.Write("_");
}

Console.WriteLine(" "); // linebreak

while (tankShots > 0)
{
    Console.WriteLine($"You have {tankShots} shells left.");
    Console.WriteLine($"Aim your shot, {player}! Enter distance: "); // Get dist input
    int dist1 = (Convert.ToInt32(Console.ReadLine())); // type cast string input to store in int variable

    for (int i = 0; i < dist1; i++) // Space at dist value
    {
        Console.Write(" ");
    }

    Console.WriteLine("  *"); // Place shot
    tankShots--;

    if (dist1 == tankDist)
    {
        Console.WriteLine("Hit! Congrats, you have successfully defended your base!");
        tankShots = 0;
    }

    else if (dist1 < tankDist)
    {
        Console.WriteLine("Damn, the shell lands too short.");
    }

    else if (dist1 > tankDist)
    {
        Console.WriteLine("Alas, the shell flies past the tank.");
    }

}

if (tankShots == 0)
{ 
    Console.WriteLine("GAME OVER");
}



