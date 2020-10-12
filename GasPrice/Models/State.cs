using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GasPrice.Models
{
    public class State
    {
        public string Name { get; set; }
        public double AvgGasoline { get; set; }
        public double AvgMidGrade { get; set; }
        public double AvgDiesel { get; set; }
        public List<City> Cities { get; set; } = new List<City>();
    }
}
