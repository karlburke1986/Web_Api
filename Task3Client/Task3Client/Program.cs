using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Task3.Models;

namespace Task3Client
{
    class Program
    {
        static async Task RunAll()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51490/");

                client.DefaultRequestHeaders.Accept.
                    Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/Text");

                if(res.IsSuccessStatusCode)
                {
                    var item = await res.Content.ReadAsAsync<IEnumerable<Text>>();

                    foreach(var i in item)
                    {
                        Console.WriteLine("Sender : " + i.NumberSender + Environment.NewLine
                            + "Receiver : " + i.NumberReceiver + Environment.NewLine
                            + "Message : " + i.Message);
                    }
                }

                else
                {
                    Console.WriteLine(res.StatusCode + " " + res.ReasonPhrase);
                    Console.ReadLine();

                }


                Text text = new Text() { Message = "Hello", NumberReceiver = 123456, NumberSender = 987654 };
                res = await client.PostAsJsonAsync("api/Text", text);
                if(res.IsSuccessStatusCode)
                {
                    var reply = res.Content.ReadAsAsync<Text>();
                    Console.WriteLine("Sender : " + reply.Result.NumberSender + Environment.NewLine
                            + "Receiver : " + reply.Result.NumberReceiver + Environment.NewLine
                            + "Message : " + reply.Result.Message);
                    Console.WriteLine("Create");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine(res.StatusCode + " " + res.ReasonPhrase);
                    Console.ReadLine();
                }

                res = await client.DeleteAsync("api/Text?number=123456");
                if (res.IsSuccessStatusCode)
                {
                    var reply = res.Content.ReadAsAsync<Text>();
                    Console.WriteLine("Sender : " + reply.Result.NumberSender + Environment.NewLine
                            + "Receiver : " + reply.Result.NumberReceiver + Environment.NewLine 
                            + "Message : " + reply.Result.Message);
                    Console.WriteLine("Delete");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine(res.StatusCode + " " + res.ReasonPhrase);
                    Console.ReadLine();
                }
            }
        }

        static void Main(string[] args)
        {
            RunAll().Wait();
        }
    }
}
