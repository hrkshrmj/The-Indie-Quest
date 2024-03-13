using System.Collections.Concurrent;
using System.IO;
namespace Files

{
    internal class Program
    {
        static void Main(string[] args)
        {
        var playerNamePath = File.Create("playername.txt");

        if (File.Exists("playername.txt"))
            {
                var nameRead = File.ReadAllText("playername.txt");
                Console.WriteLine($"Welcome Back, {nameRead}");
            }
        else
            Console.WriteLine("Welcome to your biggest adventure yet!");
            Console.WriteLine("What is your name, traveler?");
            File.WriteAllText("playername.txt", Console.ReadLine());

        }
    }
}
