using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Pokemon;

namespace Pokemon
{
    internal class Program
    {
        static Poke poke = null;
        static async Task Main(string[] args)
        {
            await pokemon();
            Console.WriteLine(poke.Name);
            Console.ReadKey();
        }
        private static async Task pokemon()
        {
            string url = $"https://pokeapi.co/api/v2/pokemon/ditto/";
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Hiba a lekérdezés során");
            }
            string jsonString = await response.Content.ReadAsStringAsync();
            poke = Poke.FromJson(jsonString);
        }
    }
}
