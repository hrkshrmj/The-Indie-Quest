using System.ComponentModel;

namespace Data_Structures___Classes___Travel_World_Map
{
    internal class Program
    {
        class Location
        {
            public string Name;
            public string Description;
            public List<Location> Neighbors = new List<Location>();
        }
        static void Main(string[] args)
        {
            var locations = new List<Location>();

            var winterfell = new Location
            {
                Name = "Winterfell",
                Description = "the capital of the Kingdom of the North."
            };
            locations.Add(winterfell);

            var pyke = new Location
            {
                Name = "Pyke",
                Description = "the stronghold and seat of House Greyjoy."
            };
            locations.Add(pyke);

            var riverrun = new Location
            {
                Name = "Riverrun",
                Description = "a large castle located in the central-western part of the Riverlands."
            };
            locations.Add(riverrun);

            var trident = new Location
            {
                Name = "The Trident",
                Description = "one of the largest and most well-known rivers on the continent of Westeros."
            };
            locations.Add(trident);

            var kingslanding = new Location
            {
                Name = "King's Landing",
                Description = "the capital, and largest city, of the Seven Kingdoms."
            };
            locations.Add(kingslanding);

            var highgarden = new Location
            {
                Name = "Highgarden",
                Description = "the seat of House Tyrell and the regional capital of the Reach."
            };
            locations.Add(highgarden);

            static void ConnectLocation(Location a, Location b)
            {
                a.Neighbors.Add(b);
                b.Neighbors.Add(a);
            }

            ConnectLocation(winterfell, riverrun);
            ConnectLocation(winterfell, pyke);
            ConnectLocation(winterfell, trident);
            ConnectLocation(pyke, riverrun);
            ConnectLocation(pyke, kingslanding);
            ConnectLocation(pyke, highgarden);
            ConnectLocation(riverrun, trident);
            ConnectLocation(riverrun, kingslanding);
            ConnectLocation(riverrun, highgarden);
            ConnectLocation(trident, kingslanding);
            ConnectLocation(highgarden, kingslanding);
            
            var currentLocation = new Location();
            currentLocation = winterfell;

            do 
            {
                Console.WriteLine($"Welcome to {currentLocation.Name}, {currentLocation.Description} Possible destinations are:");
                for (int i = 0; i < currentLocation.Neighbors.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {currentLocation.Neighbors[i].Name}");
                }

                Console.WriteLine("Where do you want to travel?");
                int x = Convert.ToInt32(Console.ReadLine());
                currentLocation = currentLocation.Neighbors[x - 1];
            }

            while (true);
            

           




        }
    }
}
