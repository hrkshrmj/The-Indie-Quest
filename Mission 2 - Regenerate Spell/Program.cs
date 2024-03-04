var random = new Random();
int warriorHP = random.Next(1, 101);

if (warriorHP < 50)
    {
    Console.WriteLine("The Regenerate spell is cast!");
    }

else
{
    Console.WriteLine($"The warrior need not be healed, Warrior HP: {warriorHP}");
}
while (warriorHP < 50)
    {
        warriorHP = warriorHP + 10;
        Console.WriteLine($"Warrior HP: {warriorHP}");
    }
