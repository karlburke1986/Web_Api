using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebExerciseApi1.Models;

namespace WebExerciseApi1Client
{
    class Program
    {
        static async Task RunAll()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:2326/");

                client.DefaultRequestHeaders.Accept.
                    Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Weather");

                if(response.IsSuccessStatusCode)
                {
                    var list = await response.Content.ReadAsAsync<IEnumerable<weather>>();

                    foreach (var item in list)
                    {
                        Console.WriteLine("City : " + item.City + " Temp : " + item.Temperature +
                            " Wind Speed : " + item.WindSpeed + " Condition : " + item.Condition +
                            "Weather Warning : " + item.Warning);
                        Console.WriteLine(" ");
                    }
                }
                else
                {
                    Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    Console.ReadLine();
                }

                weather reply = new weather();

                response = await client.GetAsync("api/Weather/Dublin");

                if(response.IsSuccessStatusCode)
                {
                    Console.WriteLine(" ");

                    reply = await response.Content.ReadAsAsync<weather>();
                    Console.WriteLine("City : " + reply.City + " Temp : " + reply.Temperature +
                            " Wind Speed : " + reply.WindSpeed + " Condition : " +  reply.Condition +
                            "Weather Warning : " +  reply.Warning);
                }
                else
                {
                    Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    Console.ReadLine();
                }

                response = await client.GetAsync("api/weather?warning=true");

                if(response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsAsync<IEnumerable<string>>();

                    foreach(var item in res)
                    {
                        Console.WriteLine(item);
                    }
                }
                else
                {
                    Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    Console.ReadLine();
                }

                weather weat = new weather();
                weat.City = "Dublin";               
                weat.Condition = Conditions.Snow;
                weat.Temperature = -2;
                weat.Warning = true;
                weat.WindSpeed = 3;

                response = await client.PutAsJsonAsync("api/weather/Cork", weat);
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                }

                response = await client.GetAsync("api/Weather");

                if (response.IsSuccessStatusCode)
                {
                    var list = await response.Content.ReadAsAsync<IEnumerable<weather>>();

                    foreach (var item in list)
                    {
                        Console.WriteLine("City : " + item.City + " Temp : " + item.Temperature +
                            " Wind Speed : " + item.WindSpeed + " Condition : " + item.Condition +
                            "Weather Warning : " + item.Warning);
                        Console.WriteLine(" ");
                    }
                }
                else
                {
                    Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    Console.ReadLine();
                }


            }
        }

        static void Main(string[] args)
        {
            RunAll().Wait();
            Console.ReadLine();
        }
    }
}
