using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebExerciseApi1.Models
{
    public enum Conditions
    {
        Cloudy,
        Sunny,
        Rain,
        Fog,
        Snow
    }

    public class weather
    {
        public string City { get; set; }
        [Range(-50, 50, ErrorMessage ="Entered values must be between -50 and 50")]
        [Display(Name = "Temperature in Degrees Celsius")]
        public int Temperature { get; set; }
        [Range(0, 200, ErrorMessage = "Entered values must be between 0 and 200" )]
        [Display(Name = "Wind Speed in Km/h")]
        public int WindSpeed { get; set; }
        public Conditions Condition  { get; set; }
        public bool Warning { get; set; }
    }
}