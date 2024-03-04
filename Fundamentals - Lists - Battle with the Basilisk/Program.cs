List<string> party = ["Aragorn", "Legolas", "Gimli", "Gandalf"];
Console.WriteLine($"The Fellowship of {party[0]}, {party[1]}, {party[2]} and {party[3]} descend into the dungeon.");

var random = new Random();

// Basilisk with 8d8+16 HP
int d8 = 0;
for (int j = 0; j < 8; j++)
{
    d8 += random.Next(1, 9);
}
int basilisk = d8 + 16;
Console.WriteLine($"A basilisk with {basilisk} HP appears!");

// Greatswords do 2d6 damage
// Daggers do 1d4 damage


while (basilisk > 0)
{
    foreach (var character in party)
    {
        int d4 = 0;
        d4 += random.Next(1, 5);
        Console.WriteLine(" ");
        Console.WriteLine($"{character} hits the basilisk for {d4} damage.");
        basilisk = basilisk - d4;
        if (basilisk > 0)
        {
            Console.Write($"Basilisk has {basilisk} HP left.");
        }
        else
        {
            Console.WriteLine("Basilisk has 0 HP left.");
            goto VictoryMessage;
        }
    }// Character attacks

    int hitChar = random.Next(party.Count()); // Random choice of target
    Console.WriteLine($"The basilisk uses petrifying gaze on {party[hitChar]}"); // Basilisk attacks target
    int d20 = (random.Next(1, 21)) + 3; // DC12 Constitution saving roll
    if (d20 >= 12)
    {
        Console.WriteLine($"{party[hitChar]} dodges the attack!");
    } // Character survives
    else
    {
        Console.WriteLine($"{party[hitChar]} has been turned to stone! They are knocked out from the battle!");
        party.Remove(party[hitChar]);
    } // Character knocked out

    if ((party.Count == 0) && (basilisk > 0))
    {
        Console.WriteLine("The party has failed and the basilisk continues to turn unsuspecting adventurers to stone.");
        basilisk = 0;
    }
}

VictoryMessage:
    Console.WriteLine("The basilisk collapses and the heroes celebrate their victory!");
