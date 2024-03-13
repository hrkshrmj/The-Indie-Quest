namespace Enums
{
    internal class Program
    {
        enum Suit
        {
            Heart,
            Spade,
            Diamond,
            Club
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

           static void DrawCard(Suit suit, int rank)
            {
                char[] symbols = ['♥', '♠', '♦', '♣'];
                string[] ranks = [ "A" ,"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"];

                if (ranks[rank-1] == "A")
                {
                    Console.WriteLine("╭─────--──╮");
                    Console.WriteLine($"│{ranks[rank-1]}        │");
                    Console.WriteLine($"│{symbols[(int)suit]}        │");
                    Console.WriteLine($"│         │");
                    Console.WriteLine($"│    {symbols[(int)suit]}    │");
                    Console.WriteLine($"│         │");
                    Console.WriteLine($"│        {symbols[(int)suit]}│");
                    Console.WriteLine($"│        {ranks[rank-1]}│");
                    Console.WriteLine("╰────--───╯");
                }
                

                if (ranks[rank-1] == "2")
                {
                    Console.WriteLine("╭──--─────╮");
                    Console.WriteLine($"│{ranks[rank - 1]}   {symbols[(int)suit]}    │");
                    Console.WriteLine($"│{symbols[(int)suit]}        │");
                    Console.WriteLine($"│         │");
                    Console.WriteLine($"│         │");
                    Console.WriteLine($"│         │");
                    Console.WriteLine($"│        {symbols[(int)suit]}│");
                    Console.WriteLine($"│    {symbols[(int)suit]}   {ranks[rank - 1]}│");
                    Console.WriteLine("╰──────--─╯");
                }

                if (ranks[rank-1] == "3")
                {
                    Console.WriteLine("╭─────--──╮");
                    Console.WriteLine($"│{ranks[rank - 1]}   {symbols[(int)suit]}    │");
                    Console.WriteLine($"│{symbols[(int)suit]}        │");
                    Console.WriteLine($"│         │");
                    Console.WriteLine($"│    {symbols[(int)suit]}    │");
                    Console.WriteLine($"│         |");
                    Console.WriteLine($"│        {symbols[(int)suit]}│");
                    Console.WriteLine($"│    {symbols[(int)suit]}   {ranks[rank - 1]}│");
                    Console.WriteLine("╰─────--──╯");
                }

                if (ranks[rank-1] == "4")
                {
                    Console.WriteLine("╭────--───╮");
                    Console.WriteLine($"│{ranks[rank - 1]} {symbols[(int)suit]}   {symbols[(int)suit]}  │");
                    Console.WriteLine($"│{symbols[(int)suit]}        │");
                    Console.WriteLine($"│         │");
                    Console.WriteLine($"│         │");
                    Console.WriteLine($"│         │");
                    Console.WriteLine($"│        {symbols[(int)suit]}│");
                    Console.WriteLine($"│  {symbols[(int)suit]}   {symbols[(int)suit]} {ranks[rank - 1]}│");
                    Console.WriteLine("╰────--───╯");
                }

                if (ranks[rank-1] == "5")
                {
                    Console.WriteLine("╭────--───╮");
                    Console.WriteLine($"│{ranks[rank - 1]} {symbols[(int)suit]}   {symbols[(int)suit]}  │");
                    Console.WriteLine($"│{symbols[(int)suit]}        │");
                    Console.WriteLine($"│         │");
                    Console.WriteLine($"│    {symbols[(int)suit]}    │"); Console.WriteLine($"│         │");
                    Console.WriteLine($"│        {symbols[(int)suit]}│");
                    Console.WriteLine($"│  {symbols[(int)suit]}   {symbols[(int)suit]} {ranks[rank - 1]}│");
                    Console.WriteLine("╰────--───╯");
                }

                if (ranks[rank-1] == "6")
                {
                    Console.WriteLine("╭────--───╮");
                    Console.WriteLine($"│{ranks[rank - 1]} {symbols[(int)suit]}   {symbols[(int)suit]}  │");
                    Console.WriteLine($"│{symbols[(int)suit]}        │");
                    Console.WriteLine($"│         │");
                    Console.WriteLine($"│  {symbols[(int)suit]}   {symbols[(int)suit]}  │");
                    Console.WriteLine($"│         │");
                    Console.WriteLine($"│        {symbols[(int)suit]}│");
                    Console.WriteLine($"│  {symbols[(int)suit]}   {symbols[(int)suit]} {ranks[rank - 1]}│");
                    Console.WriteLine("╰────--───╯");
                }

                if (ranks[rank-1] == "7")
                {
                    Console.WriteLine("╭────--───╮");
                    Console.WriteLine($"│{ranks[rank - 1]} {symbols[(int)suit]}   {symbols[(int)suit]}  │");
                    Console.WriteLine($"│{symbols[(int)suit]}        │");
                    Console.WriteLine($"│    {symbols[(int)suit]}    │"); Console.WriteLine($"│         │");
                    Console.WriteLine($"│  {symbols[(int)suit]}   {symbols[(int)suit]}  │");
                    Console.WriteLine($"│         │");
                    Console.WriteLine($"│        {symbols[(int)suit]}│");
                    Console.WriteLine($"│  {symbols[(int)suit]}   {symbols[(int)suit]} {ranks[rank - 1]}│");
                    Console.WriteLine("╰────--───╯");
                }

                if (ranks[rank-1] == "8")
                {
                    Console.WriteLine("╭────--───╮");
                    Console.WriteLine($"│{ranks[rank - 1]} {symbols[(int)suit]}   {symbols[(int)suit]}  │");
                    Console.WriteLine($"│{symbols[(int)suit]}        │");
                    Console.WriteLine($"│    {symbols[(int)suit]}    │"); Console.WriteLine($"│         │");
                    Console.WriteLine($"│  {symbols[(int)suit]}   {symbols[(int)suit]}  │");
                    Console.WriteLine($"│    {symbols[(int)suit]}    │"); Console.WriteLine($"│         │");
                    Console.WriteLine($"│        {symbols[(int)suit]}│");
                    Console.WriteLine($"│  {symbols[(int)suit]}   {symbols[(int)suit]} {ranks[rank - 1]}│");
                    Console.WriteLine("╰────--───╯");
                }

                if (ranks[rank-1] == "9")
                {
                    Console.WriteLine("╭────--───╮");
                    Console.WriteLine($"│{ranks[rank - 1]} {symbols[(int)suit]}   {symbols[(int)suit]}  │");
                    Console.WriteLine($"│{symbols[(int)suit]}        │");
                    Console.WriteLine($"│  {symbols[(int)suit]}   {symbols[(int)suit]}  │");
                    Console.WriteLine($"│    {symbols[(int)suit]}    │"); Console.WriteLine($"│         │");
                    Console.WriteLine($"│  {symbols[(int)suit]}   {symbols[(int)suit]}  │");
                    Console.WriteLine($"│        {symbols[(int)suit]}│");
                    Console.WriteLine($"│  {symbols[(int)suit]}   {symbols[(int)suit]} {ranks[rank - 1]}│");
                    Console.WriteLine("╰────--───╯");
                }

                if (ranks[rank-1] == "10")
                {
                    Console.WriteLine("╭────--───╮");
                    Console.WriteLine($"│{ranks[rank - 1]}{symbols[(int)suit]}   {symbols[(int)suit]}  │");
                    Console.WriteLine($"│{symbols[(int)suit]}   {symbols[(int)suit]}    │");
                    Console.WriteLine($"│  {symbols[(int)suit]}   {symbols[(int)suit]}  │");
                    Console.WriteLine($"│         │");
                    Console.WriteLine($"│  {symbols[(int)suit]}   {symbols[(int)suit]}  │");
                    Console.WriteLine($"│    {symbols[(int)suit]}   {symbols[(int)suit]}│");
                    Console.WriteLine($"│  {symbols[(int)suit]}   {symbols[(int)suit]}{ranks[rank - 1]}│");
                    Console.WriteLine("╰────--───╯");
                }

                if (ranks[rank-1] == "J")
                {
                    Console.WriteLine("╭────--───╮");
                    Console.WriteLine($"│{ranks[rank - 1]}┌─────┐ │");
                    Console.WriteLine($"│{symbols[(int)suit]}│{symbols[(int)suit]}\\__/│ │");
                    Console.WriteLine($"│ │|(_/|│ │");
                    Console.WriteLine($"│ │}} / {{│ │");
                    Console.WriteLine($"│ │|/_)|│ │");
                    Console.WriteLine($"│ |/  \\{symbols[(int)suit]}│{symbols[(int)suit]}|");
                    Console.WriteLine($"│ └─────┘{ranks[rank - 1]}│");
                    Console.WriteLine("╰────--───╯");
                }

                if (ranks[rank-1] == "Q")
                {
                    Console.WriteLine("╭────--───╮");
                    Console.WriteLine($"│{ranks[rank - 1]}┌─────┐ │");
                    Console.WriteLine($"│{symbols[(int)suit]}│{symbols[(int)suit]}(_(/│ │");
                    Console.WriteLine($"│ │  )/❀│ │");
                    Console.WriteLine($"│ │{{ / }}│ │");
                    Console.WriteLine($"│ │❀/(  │ │");
                    Console.WriteLine($"│ |/) ){symbols[(int)suit]}│{symbols[(int)suit]}|");
                    Console.WriteLine($"│ └─────┘{ranks[rank - 1]}│");
                    Console.WriteLine("╰────--───╯");
                }
                if (ranks[rank - 1] == "K")
                {
                    Console.WriteLine("╭────--───╮");
                    Console.WriteLine($"│{ranks[rank - 1]}┌─────┐ │");
                    Console.WriteLine($"│{symbols[(int)suit]}│{symbols[(int)suit]}\\__/│ │");
                    Console.WriteLine($"│ │ (_/|│ │");
                    Console.WriteLine($"│ │+ / +│ │");
                    Console.WriteLine($"│ │|/_) │ │");
                    Console.WriteLine($"│ |/  \\{symbols[(int)suit]}│{symbols[(int)suit]}|");
                    Console.WriteLine($"│ └─────┘{ranks[rank - 1]}│");
                    Console.WriteLine("╰────--───╯");
                }

            }

            for (int i = 0; i < 13; i++)
            {
                DrawCard(Suit.Heart, i + 1);
                DrawCard(Suit.Spade, i + 1);
                DrawCard(Suit.Diamond, i + 1);
                DrawCard(Suit.Club, i + 1);
            }
           
        }
    }
}
