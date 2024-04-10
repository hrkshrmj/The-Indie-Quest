using System.Text.RegularExpressions;
namespace Monster_Manual_1
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
            // Display all monsters in manual
            //Print MonsterType class objects
             foreach (MonsterType item in monstersList)
             {
                 Console.WriteLine($"Name: {item.Name}\nDescription: {item.Description}\nAlignment: {item.Alignment}\nHit Points Roll: {item.HitPointsRoll}\nArmor Class: {item.ArmorClass}\nArmor Type: {item.ArmorType}\n");
             }
        }
    }
}
