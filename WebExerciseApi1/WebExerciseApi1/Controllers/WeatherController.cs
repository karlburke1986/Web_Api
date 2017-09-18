using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebExerciseApi1.Models;


namespace WebExerciseApi1.Controllers
{
    public class WeatherController : ApiController
    {
        public static List<weather> Weather = new List<weather>()
        {
            new weather { City = "Dublin", Condition = Conditions.Rain, Temperature = 8, Warning = false, WindSpeed = 10 },
            new weather { City = "New York", Condition = Conditions.Snow, Temperature = -3, Warning = true, WindSpeed = 50 },
            new weather { City = "Abu Dabbi", Condition = Conditions.Sunny, Temperature = 35, Warning = false, WindSpeed = 10 },
            new weather { City = "Amsterdam", Condition = Conditions.Fog, Temperature = 2, Warning = false, WindSpeed = 12 }
        };

        public IEnumerable<weather>GetAllData()
        {
            return Weather;
        }

        public weather GetCityData(string city)
        {
            weather City = Weather.FirstOrDefault(c => c.City == city);

            if(City == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                return City;
            }
        }

        public IEnumerable<string>GetWarningCitys(bool warning)
        {
            var citys = Weather.Where(w => w.Warning == warning).Select(w => w.City);

            return citys;
        }

        public void PutCityUpdate(string city, weather data)
        {
            if (ModelState.IsValid)
            {
                if (city == data.City)
                {
                    int index = Weather.FindIndex(c => c.City.ToUpper() == data.City.ToUpper());

                    if (index == -1)
                    {
                         throw new HttpResponseException(HttpStatusCode.NotFound);
                    }
                    else
                    {
                        Weather.RemoveAt(index);
                        Weather.Add(data);
                    }
                }
                else
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }
    }
}
