using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var httpclienthandler = new HttpClientHandler()
            {
                Credentials = new NetworkCredential("arka", "arka")
            };
            var client = new HttpClient(httpclienthandler)
            {
                BaseAddress=new Uri("http://localhost:50980/api/")
            };

            var response = client.GetAsync("Test").Result;
            response.EnsureSuccessStatusCode();

            var content = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
            Console.ReadLine();
        }
    }
}
