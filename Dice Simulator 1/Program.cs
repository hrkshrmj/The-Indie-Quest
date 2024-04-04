using System;
using System.Diagnostics.Metrics;
using System.Diagnostics.Tracing;
using System.Numerics;
using System.Reflection.Emit;
using System.IO;

namespace Dice_Simulator_1
{
    internal class Program
    {
        private static Random random;
        static void Main(string[] args)
        {
            /* var lunchMessage = new[]
             {
                 (char)87,
                  (char) 97,
                 (char)110,
                 (char)116,
                 (char)32,
                 (char)116,
                 (char)111,'\n',
                 (char)32,
                 (char)109,
                 (char)101,
                 (char)101,
                 (char)116,
                 (char)32,
                 (char)102,
                 (char)111,
                 (char)114,
                 (char)32,
                 (char)108,'\n',
                 (char)117,
                 (char)110,
                 (char)99,
                 (char)104,
                 (char)63,
                 (char)32,
                 (char)73,
                 (char)39,
                 (char)108,
                 (char)108,
                 (char)32,'\n',
                 (char)108,
                 (char)101,
                 (char)97,
                 (char)118,
                 (char)101,
                 (char)32,
                 (char)116,
                 (char)104,
                 (char)101,
                 (char)32,
                 (char)114,'\n',
                 (char)101,
                 (char)115,
                 (char)116,
                 (char)97,
                 (char)117,
                 (char)114,
                 (char)97,
                 (char)110,
                 (char)116,
                 (char)32,'\n',
  (char)97, (char)100, (char)100, (char)114, (char)101, (char)115, (char)115,  (char)32, (char)105, (char)110, '\n',
  (char)32, (char)116, (char)104, (char)101,  (char)32, (char)115, (char)111, (char)117, (char)116, (char)104, '\n',
  (char)32, (char)109,  (char)97, (char)105, (char)110, (char)116, (char)101, (char)110,  (char)97, (char)110, '\n',
  (char)99, (char)101,  (char)32,  (char)99, (char)108, (char)111, (char)115, (char)101, (char)116, (char)46,'\n',
  (char)32,  (char)66, (char)114, (char)105, (char)110, (char)103,  (char)32,  (char)97, (char)110, (char)32,'\n',
  (char)65,  (char)83,  (char)67,  (char)73,  (char)73,  (char)32,  (char)99, (char)104,  (char)97, (char)114,'\n',
 (char)116,  (char)44,  (char)32, (char)116, (char)104, (char)101,  (char)32, (char)109, (char)101, (char)115,'\n',
 (char)115, (char)97, (char)103, (char)101,  (char)32, (char)119, (char)105, (char)108, (char)108, (char)32,'\n',
  (char)98, (char)101,  (char)32,  (char)99, (char)111, (char)100, (char)101, (char)100,  (char)46, '\n'

         };
             Console.WriteLine(string.Join(" ", lunchMessage));*/

            /*Console.Write("ASCII Chart:");
            for (int i = 1; i < 129; i++)
            {
                Console.Write($"{i} = {(char)i} ");
                if (i % 8 == 0)
                {
                    Console.WriteLine('\n');
                }
            }*/

            /*string txt = "To use the magic potion of Dragon Breath, first roll d8. If you roll 2 or higher, you manage to open the potion. Now roll 6d12+5 to see how many seconds the spell will last. Finally, the damage of the flames will be 2d6 per second.";
string[] splitText = txt.Split(' ');

int notationMentions = 0;
int performRolls = 0;
foreach (var word in splitText)
{
   if (IsStandardDiceNotation(word))
    {
       notationMentions++;
       performRolls += RollsfromNotation(word);
    }
}

Console.WriteLine($"{notationMentions} standard dice notations present");
Console.WriteLine($"The player will have to perform {performRolls} rolls.");*/

            //PrintRolls("99+9");
            //PrintRolls("3d6*9");
            //PrintRolls("14d4+5");
            //PrintRolls("2d8");
            //PrintRolls("d6");
            //PrintRolls("2d4-1");
            //PrintRolls("d8+12");

            bool programRun = true;
            Console.WriteLine("DICE SIMULATOR");
            while (programRun)
            {
                Console.WriteLine("Enter dice roll in standard dice notation (AdX+B): ");
                string diceNotation = Console.ReadLine();
                {
                    DiceSimulator(diceNotation);
                    Console.WriteLine("Do you want to (r)epeat, enter a (n)ew roll, or (q)uit?");


                    var userInput = Console.ReadKey().Key;

                    switch (userInput)
                    {
                        case ConsoleKey.R:
                            Console.Clear();
                            DiceSimulator(diceNotation);
                            //Console.WriteLine("Do you want to (r)epeat, enter a (n)ew roll, or (q)uit?");
                            // programRun = false;
                            break;
                    }

                    switch (userInput)
                    {
                        case ConsoleKey.N:
                            Console.Clear();
                            programRun = true;
                            break;
                    }

                    switch (userInput)
                    {
                        case ConsoleKey.Q:
                            programRun = false;
                            break;
                    }

                }

            }
        }

        static int DiceRoll(int noOfRolls, int diceSides, int fixedBonus = 0)
        {
            var d4 = File.ReadAllText("d4 ASCII.txt");
            var d6 = File.ReadAllText("d6 ASCII.txt");
            var d8 = File.ReadAllText("d8 ASCII.txt");
            var d10 = File.ReadAllText("d10 ASCII.txt");
            var d12 = File.ReadAllText("d12 ASCII.txt");
            var d20 = File.ReadAllText("d20 ASCII.txt");


            var random = new Random();
            int[] dice = new int[noOfRolls];

            switch (diceSides)
            {
                case 4:
                    for (int i = 0; i < noOfRolls; i++)
                    {
                        dice[i] = random.Next(1, diceSides + 1);
                        d4 = d4.Replace("?", $"{dice[i]}");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(d4);
                        d4 = d4.Replace($"{dice[i]}", "?");
                        Thread.Sleep(300);
                    }
                    Console.WriteLine($"Fixed Bonus: {fixedBonus}");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                case 6:
                    for (int i = 0; i < noOfRolls; i++)
                    {
                        dice[i] = random.Next(1, diceSides + 1);
                        d6 = d6.Replace("?", $"{dice[i]}");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(d6);
                        d6 = d6.Replace($"{dice[i]}", "?");
                        Thread.Sleep(300);
                    }
                    Console.WriteLine($"Fixed Bonus: {fixedBonus}");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                case 8:
                    for (int i = 0; i < noOfRolls; i++)
                    {
                        dice[i] = random.Next(1, diceSides + 1);
                        d8 = d8.Replace("?", $"{dice[i]}");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(d8);
                        d8 = d8.Replace($"{dice[i]}", "?");
                        Thread.Sleep(300);
                    }
                    Console.WriteLine($"Fixed Bonus: {fixedBonus}");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                case 10:
                    for (int i = 0; i < noOfRolls; i++)
                    {
                        dice[i] = random.Next(1, diceSides + 1);
                        d10 = d10.Replace("?", $"{dice[i]}");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(d10);
                        d10 = d10.Replace($"{dice[i]}", "?");
                        Thread.Sleep(300);
                    }
                    Console.WriteLine($"Fixed Bonus: {fixedBonus}");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                case 12:
                    for (int i = 0; i < noOfRolls; i++)
                    {
                        dice[i] = random.Next(1, diceSides + 1);
                        d12 = d12.Replace("??", $"{dice[i]}");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(d12);
                        d12 = d12.Replace($"{dice[i]}", "??");
                        Thread.Sleep(300);
                    }
                    Console.WriteLine($"Fixed Bonus: {fixedBonus}");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                case 20:
                    for (int i = 0; i < noOfRolls; i++)
                    {
                        dice[i] = random.Next(1, diceSides + 1);
                        d20 = d20.Replace("??", $"{dice[i]}");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(d20);
                        d20 = d20.Replace($"{dice[i]}", "??");
                        Thread.Sleep(300);
                    }
                    Console.WriteLine($"Fixed Bonus: {fixedBonus}");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                default:
                    {
                        for (int i = 0; i < noOfRolls; i++)
                        {
                            dice[i] = random.Next(1, diceSides + 1);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine($"Roll {i + 1} is: {dice[i]}");
                            Thread.Sleep(300);
                        }
                        Console.WriteLine($"Fixed Bonus: {fixedBonus}");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }


            }

            int sum = dice.Sum();
            Thread.Sleep(300);
            Console.WriteLine($"You rolled {sum += fixedBonus}");

            return sum += fixedBonus;

        } // Dice 
        static int DiceRoll(string diceNotation)
        {
            string[] values = diceNotation.Split('d', '+', '-');

            if (values[0] == "") values[0] = "1"; // for Omitted no. of rolls i.e 1d


            int noOfRolls, diceSides, fixedBonus;

            if (values[0].Length >= 1) noOfRolls = Int32.Parse(values[0]);

            diceSides = Int32.Parse(values[1]);
            if (values[1].Length >= 1) diceSides = Int32.Parse(values[1]);

            if (values.Length == 2) fixedBonus = 0; // for Omitted bonus

            else if (values.Length > 2) fixedBonus = Int32.Parse(values[2]);

            if (values.Length <= 1) throw new ArgumentException($"Roll isn't given in standard dice notation");

            try
            {
                noOfRolls = values[0].Length > 0 ? Int32.Parse(values[0]) : 1;
            }

            catch
            {
                throw new ArgumentException($"Number of rolls {values[0]} is not an integer");
            }

            if (noOfRolls <= 0)
            {
                throw new ArgumentException($"Number of rolls {values[0]} has to be positive.");
            }

            //values = values[1].Split(new[] { '+', '-' });

            try
            {
                diceSides = Int32.Parse(values[1]);
            }

            catch
            {
                throw new ArgumentException($"Number of dice sides {values[1]} is not an integer.");
            }

            if (diceSides <= 0)
            {
                throw new ArgumentException($"Number of dice sides has to be positive.");
            }

            if (values.Length > 2)
            {
                try
                {
                    fixedBonus = Int32.Parse(values[2]);
                }
                catch
                {
                    throw new ArgumentException($"Fixed bonus {values[2]} is not an integer.");
                }

                if (diceNotation.IndexOf('-') > -1) fixedBonus = -fixedBonus; // for Negative bonus 

                return DiceRoll(noOfRolls, diceSides, fixedBonus);
            }

            else
            {
                return DiceRoll(noOfRolls, diceSides);
            }

        } // Reads dice notation into Dice, checks if dice is/isn't standard notation

        //static void PrintRolls(string diceNotation) 
        //{

        //    /*{
        //        int[] dicerolls = new int[10];
        //        for (int i = 0; i < 10; i++) // adds 10 rolls to an array of size 10
        //        {
        //            dicerolls[i] = DiceRoll(diceNotation);
        //        }
        //        Console.WriteLine($"Throwing {diceNotation}...{string.Join(" ", dicerolls)}");
        //    }*/

        //    var notationSplit = diceNotation.Split('d');
        //    int noOfRolls;
        //    if (notationSplit[0] == "")
        //        noOfRolls = 1;
        //    else noOfRolls = Int32.Parse(notationSplit[0]);

        //    int[] RollsForPrint = new int[noOfRolls];

        //    for (int i = 0; i < RollsForPrint.Length; i++)
        //    {
        //        RollsForPrint[i] = DiceRoll(diceNotation);
        //        Console.WriteLine($"Roll {i+1} is: {RollsForPrint[i]}." );
        //    }
        //    Console.WriteLine($"You rolled {RollsForPrint.Sum()}.");


        //} // Prints read dice notation
        static bool IsStandardDiceNotation(string diceNotation)
        {
            if (diceNotation.IndexOf('*') > -1) return false;
            if (diceNotation.IndexOf('/') > -1) return false;
            if (diceNotation.Contains("d1") || diceNotation.Contains("d2") || diceNotation.Contains("d3") || diceNotation.Contains("d4") || diceNotation.Contains("d5") || diceNotation.Contains("d6") || diceNotation.Contains("d7") || diceNotation.Contains("d8") || diceNotation.Contains("d9"))
            {
                return true;
            }
            else return false;
        }  // only Checks if dice notation is/isn't standard notation

        //static int RollsfromNotation(string word)
        //{
        //    int def = 1;
        //    if (word[0].ToString() == "d") return def;
        //    else return Int32.Parse(word[0].ToString());
        //}
        static void DiceSimulator(string diceNotation)
        {

            IsStandardDiceNotation(diceNotation);

            while (IsStandardDiceNotation(diceNotation) == false)
            {
                Console.WriteLine("You didn't use standard dice notation. Try again:");
                diceNotation = Console.ReadLine();
            }

            if (IsStandardDiceNotation(diceNotation))
            {
                Console.WriteLine("Simulating...");
                Thread.Sleep(250);
                DiceRoll(diceNotation);
            }

        }
    }
}
