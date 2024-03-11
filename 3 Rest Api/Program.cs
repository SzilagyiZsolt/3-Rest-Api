using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Car;

namespace Car
{
   
    internal class Program
    {
        static Auto auto = null;
        static async Task Main(string[] args)
        {
            await Autok();
            Console.WriteLine();
            Console.ReadKey();
        }
        private static async Task Autok()
        {

            string url = $"https://vpic.nhtsa.dot.gov/api/vehicles/getallmakes?format=json";
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Hiba a lekérdezés során");
            }
            string jsonString = await response.Content.ReadAsStringAsync();
            auto = Auto.FromJson(jsonString);
        }
    }
}
