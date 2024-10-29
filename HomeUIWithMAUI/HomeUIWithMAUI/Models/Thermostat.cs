using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeUIWithMAUI.Models
{
    public class Thermostat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double CurrentTemperature { get; set; }
        public double DesiredTemperature { get; set; }
        public string Mode { get; set; }
        public bool IsOn { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
