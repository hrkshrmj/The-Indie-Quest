using System.Text.RegularExpressions;
namespace Monster_Manual_2
{
    internal class Program
    {
        class MonsterType
        {
            public string Name;
            public string Description;
            public string Alignment;
            public string HitPointsRoll;
            public string ArmorClass;
            public string ArmorType;
        }
        static void Main(string[] args)
        {
            // Create monster manual and add items variables
            var monstersList = new List<MonsterType>();
            var manual = File.ReadAllLines("MonsterManual.txt");
            int NameLine = 0;
            int monsterIndex = 0;
            var monster = new MonsterType();

            // Search function variables
            int listIndex = 0;
            int matchCounter = 0;
            bool matchExit = true;
            var searchMatches = new List<MonsterType>();
            MonsterType onlyMonster;

            // Parses and adds MonsterType objects to monstersList
            for (int i = 0; i < manual.Length; i++)
            {
                string line = manual[i];
                if (line.Length == 0 || (i + 1) >= manual.Length) NameLine = 0;
                else NameLine++;
                switch (NameLine)
                {
                    case 1:
                        monster.Name = line;
                        break;
                    case 2:
                        Match description = Regex.Match(line, @"(.*),\s(unaligned|lawful|chaotic|neutral)(\s(\w+))?$");
                        monster.Description = description.Groups[1].Value;
                        Match alignment = Regex.Match(line, @"(unaligned|lawful|chaotic|neutral)(\s(\w+))?$");
                        string alignmentValue = alignment.Groups[1].Value + " " + alignment.Groups[4].Value;
                        monster.Alignment = alignmentValue;
                        break;
                    case 3:
                        Match hpRolls = Regex.Match(line, @"^Hit\sPoints:\s(\d+)\s\((.*)\)\s$");
                        monster.HitPointsRoll = hpRolls.Groups[2].Value;
                        break;
                    case 4:
                        Match armor = Regex.Match(line, @"Armor\sClass:\s(\d+)(\s\((.*)\)\s)?");
                        monster.ArmorClass = armor.Groups[1].Value;
                        monster.ArmorType = armor.Groups[3].Value;
                        if (monster.ArmorType == "") monster.ArmorType = "n/a";
                        break;
                    case 5:
                        continue;
                    case 6:
                        continue;
                    case 0:
                        monstersList.Add(monster);
                        monsterIndex++;
                        monster = new MonsterType();
                        break;
                }
            }

            // Search function
            while (matchExit)
            {
                Console.WriteLine("MONSTER MANUAL\nEnter a query to search monsters by name: ");
                string searchQuery = Console.ReadLine();
                // Checks if matches exist and if so, increments match counter
                foreach (MonsterType item in monstersList)
                {
                    if (Regex.IsMatch(item.Name, searchQuery, RegexOptions.IgnoreCase))
                    {
                        matchExit = false;
                        matchCounter++;
                    }

                }

                // Returns to start of search if search query returns no matches
                if (matchExit)
                {
                    Console.WriteLine("No monsters found. Try again: ");
                }

                // 
                if (matchExit == false)
                {
                    // Prints matched entries in ordered list and adds them to a list for response matching
                    foreach (MonsterType item in monstersList)
                    {
                        if (Regex.IsMatch(item.Name, searchQuery, RegexOptions.IgnoreCase)) // matches each item Name with entered name
                        {
                            listIndex++;
                            searchMatches.Add(item);

                            if (matchCounter > 1) Console.WriteLine($"{listIndex}. {item.Name}"); // Prints list only if matches are greater than one

                        }
                    }

                    // Automatically displays monster information if only one match exists in the database
                    if (matchCounter == 1)
                    {
                        onlyMonster = monstersList[monstersList.IndexOf(searchMatches[0])];

                        Console.WriteLine($"\nDisplaying information for {onlyMonster.Name}");

                        Thread.Sleep(400);

                        Console.WriteLine($"Name: {onlyMonster.Name}\nDescription: {onlyMonster.Description}\nAlignment: {onlyMonster.Alignment}\nHit Points Roll: {onlyMonster.HitPointsRoll}");

                    }

                    // Prompts user to choose which monster they want to look up from displayed list of options
                    else if (matchCounter > 1)
                    {
                        Console.WriteLine("Which monster do you want to look up?\nEnter number: ");
                        string lookUpAnswer = Console.ReadLine();
                        int lookUpAnswerIndex = Convert.ToInt32(lookUpAnswer);
                        MonsterType lookedUpMonster = searchMatches[lookUpAnswerIndex - 1];
                        Console.WriteLine($"\nDisplaying information for {lookedUpMonster.Name}");
                        Thread.Sleep(400);
                        Console.WriteLine($"Name: {lookedUpMonster.Name}\nDescription: {lookedUpMonster.Description}\nAlignment: {lookedUpMonster.Alignment}\nHit Points Roll: {lookedUpMonster.HitPointsRoll}");
                    }

                    Console.WriteLine("\nLook up another monster? Press any key to confirm: ");
                    string restart = Console.ReadLine();
                    if (restart.Length > 0)
                    {
                        Console.Clear();
                        matchExit = true;
                    }
                }
            }

        }
    }
}
