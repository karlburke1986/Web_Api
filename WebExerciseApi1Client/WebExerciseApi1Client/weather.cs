using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int Temperature { get; set; }        
        public int WindSpeed { get; set; }
        public Conditions Condition { get; set; }
        public bool Warning { get; set; }
    }
}
