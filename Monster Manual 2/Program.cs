using System.Text.RegularExpressions;
using System.Threading;
namespace Monster_Manual_2
{
    enum ArmorTypeId
    {
        Unspecified = 1,
        Natural,
        Leather,
        StuddedLeather,
        Hide,
        ChainShirt,
        ChainMail,
        ScaleMail,
        Plate,
        Other
    };

    enum ArmorCategory
    {
        Light,
        Medium,
        Heavy
    };

    class ArmorTypeClass
    {
        public string DisplayName;
        public ArmorCategory Category;
        public int Weight;
    }

    class MonsterType
    {
        public string Name;
        public string Description;
        public string Alignment;
        public string HitPointsRoll;
        public string ArmorClass;
        public ArmorTypeId ArmorType;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Create monster manual and add items variables
            var monstersList = new List<MonsterType>();
            var manual = File.ReadAllLines("MonsterManual.txt");
            int NameLine = 0;
            int monsterIndex = 0;
            var monster = new MonsterType();

            // Search function variables
            
            bool matchExit = true;
            MonsterType onlyMonster;

            string[] armorTypeNames = Enum.GetNames<ArmorTypeId>();
            ArmorTypeId[] armorTypeIds = Enum.GetValues<ArmorTypeId>();
            List<MonsterType> monstersByArmorType = new List<MonsterType>();

            Dictionary<ArmorTypeId, List<MonsterType>> monstersByArmorTypeDict = new Dictionary<ArmorTypeId, List<MonsterType>>();

            Dictionary<ArmorTypeId, ArmorTypeClass> armorTypes = GenerateArmorTypes();

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
                        string alignmentValue = alignment.Groups[1].Value + " " + alignment.Groups[3].Value;
                        monster.Alignment = alignmentValue;
                        break;
                    case 3:
                        Match hpRolls = Regex.Match(line, @"^Hit\sPoints:\s(\d+)\s\((.*)\)\s$");
                        monster.HitPointsRoll = hpRolls.Groups[2].Value;
                        break;
                    case 4:
                        Match armor = Regex.Match(line, @"Armor\sClass:\s(\d+)(\s\((.*)\)\s)?"); // matches regex into match groups
                        monster.ArmorClass = armor.Groups[1].Value;

                        if (armor.Groups[3].Value.ToLower().Contains("natural"))
                        {
                            monster.ArmorType = ArmorTypeId.Natural;
                        }

                        else if (armor.Groups[3].Value.ToLower().Contains("studded leather"))
                        {
                            monster.ArmorType = ArmorTypeId.StuddedLeather;
                        }

                        else if (armor.Groups[3].Value.ToLower().Contains("leather"))
                        {
                            monster.ArmorType = ArmorTypeId.Leather;
                        }

                        else if (armor.Groups[3].Value.ToLower().Contains("hide"))
                        {
                            monster.ArmorType = ArmorTypeId.Hide;
                        }

                        else if (armor.Groups[3].Value.ToLower().Contains("chain shirt"))
                        {
                            monster.ArmorType = ArmorTypeId.ChainShirt;
                        }

                        else if (armor.Groups[3].Value.ToLower().Contains("chain mail"))
                        {
                            monster.ArmorType = ArmorTypeId.ChainMail;
                        }

                        else if (armor.Groups[3].Value.ToLower().Contains("plate"))
                        {
                            monster.ArmorType = ArmorTypeId.Plate;
                        }

                        else if (armor.Groups[3].Value.ToLower().Contains("other"))
                        {
                            monster.ArmorType = ArmorTypeId.Other;
                        }

                        AddToDictionary(monstersByArmorTypeDict, monster);


                        break;
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
                Console.WriteLine("MONSTER MANUAL\nDo you want to search by (n)ame or (a)rmor type?\n");
                string searchQuery = Console.ReadLine();

                if (searchQuery == "a") DisplayByArmorType(armorTypeNames, monstersByArmorTypeDict, armorTypes);

                if (searchQuery == "n") DisplayByName(matchExit, monstersList, armorTypes);

            }

        }

        static void PrintMonsterInfo(MonsterType monsterToPrint, Dictionary<ArmorTypeId, ArmorTypeClass> armorTypes)
        {
            Console.WriteLine($"\nDisplaying information for {monsterToPrint.Name}");

            Thread.Sleep(400);
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"Name: {monsterToPrint.Name}\nDescription: {monsterToPrint.Description}\nAlignment: {monsterToPrint.Alignment}\nHit Points Roll: {monsterToPrint.HitPointsRoll}\nArmor Class: {monsterToPrint.ArmorClass}\n");
            if (armorTypes.ContainsKey(monsterToPrint.ArmorType))
            {
                Console.WriteLine($"Armor Type: {armorTypes[monsterToPrint.ArmorType].DisplayName}");
                Console.WriteLine($"Armor Category: {armorTypes[monsterToPrint.ArmorType].Category}");
                Console.WriteLine($"Armor Weight: {armorTypes[monsterToPrint.ArmorType].Weight}");
            }
            Console.ResetColor();
        }

        static Dictionary<ArmorTypeId, ArmorTypeClass> GenerateArmorTypes()
        {
            ArmorTypeClass Leather = new ArmorTypeClass();
            Leather.DisplayName = "Leather";
            Leather.Category = (ArmorCategory)0;
            Leather.Weight = 10;

            ArmorTypeClass StuddedLeather = new ArmorTypeClass();
            StuddedLeather.DisplayName = "Studded Leather";
            StuddedLeather.Category = (ArmorCategory)0;
            StuddedLeather.Weight = 13;

            ArmorTypeClass Hide = new ArmorTypeClass();
            Hide.DisplayName = "Hide";
            Hide.Category = (ArmorCategory)1;
            Hide.Weight = 13;

            ArmorTypeClass ChainShirt = new ArmorTypeClass();
            ChainShirt.DisplayName = "Chain Shirt";
            ChainShirt.Category = (ArmorCategory)1;
            ChainShirt.Weight = 20;

            ArmorTypeClass ScaleMail = new ArmorTypeClass();
            ScaleMail.DisplayName = "Scale Mail";
            ScaleMail.Category = (ArmorCategory)1;
            ScaleMail.Weight = 45;

            ArmorTypeClass ChainMail = new ArmorTypeClass();
            ChainMail.DisplayName = "Chain Mail";
            ChainMail.Category = (ArmorCategory)2;
            ChainMail.Weight = 55;

            ArmorTypeClass Plate = new ArmorTypeClass();
            Plate.DisplayName = "Plate";
            Plate.Category = (ArmorCategory)2;
            Plate.Weight = 65;

            var armorTypes = new Dictionary<ArmorTypeId, ArmorTypeClass>();
            armorTypes.Add(ArmorTypeId.Leather, Leather);
            armorTypes.Add(ArmorTypeId.StuddedLeather, StuddedLeather);
            armorTypes.Add(ArmorTypeId.ChainMail, ChainMail);
            armorTypes.Add(ArmorTypeId.ChainShirt, ChainShirt);
            armorTypes.Add(ArmorTypeId.ScaleMail, ScaleMail);
            armorTypes.Add(ArmorTypeId.Plate, Plate);

            return armorTypes;

        }

        static void AddToDictionary(Dictionary<ArmorTypeId, List<MonsterType>> armorToMonsterList, MonsterType monster)
        {
            if (!armorToMonsterList.ContainsKey(monster.ArmorType))
            {
                armorToMonsterList.Add(monster.ArmorType, new List<MonsterType>());
            }

            var oldList = armorToMonsterList[monster.ArmorType];
            oldList.Add(monster);
        }

        static void DisplayByArmorType(string[] armorTypeNames, Dictionary<ArmorTypeId, List<MonsterType>> monstersByArmorTypeDict, Dictionary<ArmorTypeId, ArmorTypeClass> armorTypes)
        {

            Console.WriteLine("Which armor type do you want to display?\n");
            for (int i = 0; i < armorTypeNames.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {armorTypeNames[i]}");
            }
            Console.WriteLine("Enter number: \n");
            int armorTypeResponse = Convert.ToInt32(Console.ReadLine());
            var ChosenArmoredList = new List<MonsterType>();
            ArmorTypeId responseArmorTypeId = ArmorTypeId.Unspecified;
            switch (armorTypeResponse)
            {
                case 1:
                    responseArmorTypeId = ArmorTypeId.Unspecified;
                    break;
                case 2:
                    responseArmorTypeId = ArmorTypeId.Natural;
                    break;
                case 3:
                    responseArmorTypeId = ArmorTypeId.Leather;
                    break;
                case 4:
                    responseArmorTypeId = ArmorTypeId.StuddedLeather;
                    break;
                case 5:
                    responseArmorTypeId = ArmorTypeId.Hide;
                    break;
                case 6:
                    responseArmorTypeId = ArmorTypeId.ChainShirt;
                    break;
                case 7:
                    responseArmorTypeId = ArmorTypeId.ChainMail;
                    break;
                case 8:
                    responseArmorTypeId = ArmorTypeId.ScaleMail;
                    break;
                case 9:
                    responseArmorTypeId = ArmorTypeId.Plate;
                    break;
                case 10:
                    responseArmorTypeId = ArmorTypeId.Other;
                    break;
            }

            Console.WriteLine($"Displaying monsters with armor type {responseArmorTypeId}");
            ListMonsters(monstersByArmorTypeDict[responseArmorTypeId], armorTypes);
        }

        static void DisplayByName(bool matchExit, List<MonsterType> monstersList, Dictionary<ArmorTypeId, ArmorTypeClass> armorTypes)
        {
            int listIndex = 0;
            int matchCounter = 0;
            var searchMatches = new List<MonsterType>();

            Console.WriteLine("Which monster do you want to look up?");
            string desiredName = Console.ReadLine();



            // Checks if matches exist and if so, increments match counter
            foreach (MonsterType item in monstersList)
            {
                if (Regex.IsMatch(item.Name, desiredName, RegexOptions.IgnoreCase))
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

            // Prints matched entries in ordered list and adds them to a list for response matching
            if (matchExit == false)
            {
                listIndex = 0;
                // Prints matched entries in ordered list and adds them to a list for response matching
                foreach (MonsterType item in monstersList)
                {
                    if (Regex.IsMatch(item.Name, desiredName, RegexOptions.IgnoreCase)) // matches each item Name with entered name
                    {
                        listIndex++;
                        searchMatches.Add(item);

                        if (matchCounter > 1) Console.WriteLine($"{listIndex}. {item.Name}"); // Prints list only if matches are greater than one

                    }
                }

                // Automatically displays monster information if only one match exists in the database
                if (matchCounter < 2)
                {
                    MonsterType onlyMonster = new MonsterType();
                    onlyMonster = monstersList[monstersList.IndexOf(searchMatches[0])];
                    PrintMonsterInfo(onlyMonster, armorTypes);
                }

                // Prompts user to choose which monster they want to look up from displayed list of options
                else if (matchCounter > 1)
                {
                    Console.WriteLine("Which monster do you want to look up?\nEnter number: ");
                    string lookUpAnswer = Console.ReadLine();
                    int lookUpAnswerIndex = Convert.ToInt32(lookUpAnswer);
                    MonsterType lookedUpMonster = searchMatches[lookUpAnswerIndex - 1];
                    PrintMonsterInfo(lookedUpMonster, armorTypes);
                }

                Console.WriteLine("\nLook up another monster? Press any key to confirm: ");
                string restart = Console.ReadLine();
                if (restart.Length > 0)
                {
                    Console.Clear();
                    matchCounter = 0;
                    searchMatches = new List<MonsterType>();
                    matchExit = true;
                }

            }

        }

        static void ListMonsters(List<MonsterType> ChosenList, Dictionary<ArmorTypeId, ArmorTypeClass> armorTypes)
        {

            if (ChosenList.Count <= 0)
            {
                Console.WriteLine("No monsters found.");
                return;
            }

            if (ChosenList.Count == 1)
            {
                PrintMonsterInfo(ChosenList.First(), armorTypes);
                return;
            }

            for (int i = 0; i < ChosenList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ChosenList[i].Name}");
            }

            Console.WriteLine("Which monster do you want to look up? \n");
            int lookUpAnswerIndex = Convert.ToInt32(Console.ReadLine());

            MonsterType lookedUpMonster = ChosenList[lookUpAnswerIndex - 1];

            PrintMonsterInfo(lookedUpMonster, armorTypes);
        }

    }
}
