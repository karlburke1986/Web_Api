using System;
using System.Net.Http;
using System.Threading.Tasks;
using Task2.Models;

namespace Task2Client
{
    class Program
    {
        static async Task PostMessage()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:4752/");

                    client.DefaultRequestHeaders.
                        Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    Text mes = new Text() { NumberSender = 123456, NumberReceiver = 987654, Message = "Hello World"};
                    HttpResponseMessage res = await client.PostAsJsonAsync("api/text", mes);

                    if(res.IsSuccessStatusCode)
                    {
                        var items = await res.Content.ReadAsAsync<Text>();

                        Console.WriteLine(items.Message);

                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine(res.StatusCode + " " + res.ReasonPhrase);
                    }
                }
            }

            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        static void Main(string[] args)
        {
            PostMessage().Wait();
        }
    }
}
