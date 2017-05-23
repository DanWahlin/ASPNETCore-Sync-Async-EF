using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncAwaitTaskT
{
    class Program
    {
        static void Main(string[] args)
        {
            GetContent();
            Console.ReadLine();
        }

        static async void GetContent()
        {
            var http = new HttpWrapper();
            var content = await http.MakeRequest("http://microsoft.com");
            Console.WriteLine(content);
        }

    }

    class HttpWrapper
    {
        public async Task<string> MakeRequest(string url)
        {
            HttpClient http = new HttpClient();
            var response = await http.GetAsync("http://microsoft.com");
            return await response.Content.ReadAsStringAsync();
        }
    }
}