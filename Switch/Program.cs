namespace Switch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Set desired price: ");
            var price = Console.ReadLine(); // stored as string
            string[] subs = price.Split(' ', ' ');
            switch (subs[1])
            {
                case "+":
                    {
                        double x = Convert.ToDouble(subs[0]);
                        double y = Convert.ToDouble(subs[2]);
                        double setPrice = x + y;
                        price = Convert.ToString(setPrice);
                    }
                    break;

                case "plus":
                    {
                        double x = Convert.ToDouble(subs[0]);
                        double y = Convert.ToDouble(subs[2]);
                        double setPrice = x + y;
                        price = Convert.ToString(setPrice);
                    }
                    break;

                case "-":
                    {
                        double x = Convert.ToDouble(subs[0]);
                        double y = Convert.ToDouble(subs[2]);
                        double setPrice = x - y;
                        price = Convert.ToString(setPrice);
                    }
                    break;

                case "minus":
                    {
                        double x = Convert.ToDouble(subs[0]);
                        double y = Convert.ToDouble(subs[2]);
                        double setPrice = x - y;
                        price = Convert.ToString(setPrice);
                    }
                    break;

                case "*":
                    {
                        double x = Convert.ToDouble(subs[0]);
                        double y = Convert.ToDouble(subs[2]);
                        double setPrice = x * y;
                        price = Convert.ToString(setPrice);
                    }
                    break;

                case "times":
                    {
                        double x = Convert.ToDouble(subs[0]);
                        double y = Convert.ToDouble(subs[2]);
                        double setPrice = x * y;
                        price = Convert.ToString(setPrice);
                    }
                    break;

                case "/":
                    {
                        double x = Convert.ToDouble(subs[0]);
                        double y = Convert.ToDouble(subs[2]);
                        double setPrice = x / y;
                        price = Convert.ToString(setPrice);
                      
                    }
                    break;

                case "divided":
                    {
                        double x = Convert.ToDouble(subs[0]);
                        double y = Convert.ToDouble(subs[3]);
                        double setPrice = x / y;
                        price = Convert.ToString(setPrice);

                    }
                    break;


            }
            Console.WriteLine($"The price was set to {price}");
        }
    }
}
