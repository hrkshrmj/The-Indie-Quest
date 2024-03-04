var random = new Random();

int gelCubeMon; // declaring here
int gelCubeHorde = 0;

int oneD6 = random.Next(6) + 1;
int twoD6 = random.Next(1, 7);
int threeD6 = random.Next(1, 7);
int charStrength = oneD6 + twoD6 + threeD6;
Console.WriteLine($"A character with strength {charStrength} was created.");

gelCubeMon = 0; // initializing here, where needed
for (int i = 0; i < 8; i++)
{
    gelCubeMon += random.Next(1, 11);
}
gelCubeMon += 40;


Console.WriteLine($"A gelatinous cube with {gelCubeMon} HP appears!");

for (int i = 0; i < 100; i++)
{
    gelCubeMon = 0;
    for (int j = 0; j < 8; j++)
    {
        gelCubeMon += random.Next(1, 11);
    }
    gelCubeMon += 40;
    gelCubeHorde += gelCubeMon;
}

Console.WriteLine($"Dear gods, an army of 100 cubes descends upon us with a total of {gelCubeHorde} HP. We are doomed!");

