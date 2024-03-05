using System.IO;
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static int DiceRoll(int noOfRolls, int diceSides, int fixedBonus = 0)
    {
        var random = new Random();
        int dice = 0;
        for (int i = 0; i < noOfRolls; i++)
        {
            dice += random.Next(1, diceSides + 1);
        }
        return dice += fixedBonus;
    }
    static void SimulateCombat(List<string> characterNames, string monsterName, int monsterHP, int savingThrowDC)
    {
        var random = new Random();

        Console.WriteLine($"Watch out! {monsterName} with {monsterHP} HP appears!");

        while (monsterHP > 0 && characterNames.Count > 0)
        {
            foreach (var character in characterNames)
            {
                int roll = DiceRoll(2, 6);
                //Console.WriteLine(" "); //linebreak
                Console.WriteLine($"{character} hits the {monsterName} for {roll} damage.");
                monsterHP -= roll;
                if (monsterHP > 0)
                {
                    Console.WriteLine($"{monsterName} has {monsterHP} HP left.");
                }
                else
                {
                    Console.WriteLine($"{monsterName} has 0 HP left.");
                    break;
                }
            }// Characters attack

            if (monsterHP > 0)
            {
                int hitChar = random.Next(characterNames.Count()); // Random choice of target
                Console.WriteLine($"The {monsterName} attacks {characterNames[hitChar]}!"); // Monster attacks target
                int savingThrow = DiceRoll(1, 20, 3); // DC12 Constitution saving roll
                if (savingThrow >= savingThrowDC)
                {
                    Console.WriteLine($"{characterNames[hitChar]} dodges the attack!");
                } // Character survives
                else
                {
                    Console.WriteLine($"{characterNames[hitChar]} has been knocked out from the battle!");
                    characterNames.Remove(characterNames[hitChar]);
                } // Character knocked out
            } // Monster attack


            if ((characterNames.Count == 0) && (monsterHP > 0))
            {
                Console.WriteLine($"The party has failed and the {monsterName} continues to waylay unsuspecting adventurers.");
                break;
            }

            else if ((characterNames.Count > 0) && (monsterHP <= 0))
            {
                Console.WriteLine($"The {monsterName} collapses and the heroes celebrate their victory!");
            }
        }
    }
        

    static void Main(string[] args)
    {
        List<string> realNames = [ "Jazlyn", "Theron", "Dayana", "Rolando" ];
        Console.WriteLine($"Jazlyn, Theron, Dayana, Rolando descend into the dungeon.");
        SimulateCombat(realNames, "Orc", DiceRoll(2, 8, 6), 10);
        Console.WriteLine(" "); //linebreak
        SimulateCombat(realNames, "Azer", DiceRoll(6, 8, 12), 18);
        Console.WriteLine(" "); //linebreak
        SimulateCombat(realNames, "Troll", DiceRoll(8, 10, 40), 16);
        if (realNames.Count > 0)
        {
            Console.WriteLine($"After three grueling battles, the surviving heroes {realNames} return from the dungeons to live another day.");
        }
    }
        
}

