using System.Text.RegularExpressions;

namespace Regex_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var httpClient = new HttpClient();
            string htmlCode = httpClient.GetStringAsync(@"https://store.steampowered.com/app/653530/Return_of_the_Obra_Dinn/").Result;

            string[] gameURLs = [

                httpClient.GetStringAsync(@"https://store.steampowered.com/app/653530/Return_of_the_Obra_Dinn/").Result,
                httpClient.GetStringAsync(@"https://store.steampowered.com/app/753640/Outer_Wilds/").Result,
                httpClient.GetStringAsync(@"https://store.steampowered.com/app/2357570/Overwatch_2/").Result,
                httpClient.GetStringAsync(@"https://store.steampowered.com/app/2570390/Daves_Fun_Algebra_Class_Remastered/").Result,
                httpClient.GetStringAsync(@"https://store.steampowered.com/app/1849900/Among_Us_VR/").Result,

                ];

           foreach (string url in gameURLs)
            {
                Match name = Regex.Match(url, @"<meta\sproperty=\Wog:title\W\scontent=\W(.*)\son\sSteam\W>");
                Match rating = Regex.Match(url, @"<span class=\Wgame_review_summary (positive)?\W itemprop=\Wdescription\W>(.*)</span>");
                string gameName = name.Groups[1].Value;
                Console.WriteLine(gameName.ToUpper());
                Console.WriteLine($"All reviews: {rating.Groups[2].Value}\n");
            }
           
        }
    }
}
