using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TVMaze;

namespace TVMaze
{
    internal class Program
    {
        static Tv maze = null;
        static async Task Main(string[] args)
        {
            await tv();
            Console.WriteLine();
            Console.ReadKey();
        }
        private static async Task tv()
        {
            string url = $"http://api.tvmaze.com/search/shows?q=postman";
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Hiba a lekérdezés során");
            }
            string jsonString = await response.Content.ReadAsStringAsync();
            maze = Tv.FromJson(jsonString);
        }
    }
}
