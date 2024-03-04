using System;
var random = new Random();

List<int> abilities = [];

for (int i = 0; i < 6; i++)
{
    List<int> rolls = [];

    for (int j = 0; j < 4; j++)
    {
        rolls.Add(random.Next(1, 7));
    }
    Console.WriteLine($"You roll {rolls[0]}, {rolls[1]}, {rolls[2]}, {rolls[3]}");
    rolls.Sort();
    rolls.Remove(rolls[0]);

    int ability = rolls[0] + rolls[1] + rolls[2];
    Console.WriteLine($"The ability score is {ability}");
    abilities.Add(ability);
    Console.WriteLine(ability);
}

abilities.Sort();
Console.WriteLine($"Your available ability scores are {abilities[0]}, {abilities[1]}, {abilities[2]}, {abilities[3]}, {abilities[4]}, {abilities[5]}.");


// roll, add to list, sort, remove lowest

