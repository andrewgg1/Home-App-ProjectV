using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeUIWithMAUI.Models
{
    public class Thermostat
    {
        private static Random random = new Random();

        private string id = GenerateRandomId();
        private string name = "Default Thermostat";
        private double currentTemperature = 20.0;
        private double desiredTemperature = 22.0;
        private string mode = "Off";
        private bool isOn = false;
        private DateTime lastUpdated = DateTime.Now;

        public string Id
        {
            get => id;
            set
            {
                id = value;
                UpdateLastUpdated();
            }
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                UpdateLastUpdated();
            }
        }

        public double CurrentTemperature
        {
            get => currentTemperature;
            set
            {
                currentTemperature = value;
                UpdateLastUpdated();
            }
        }

        public double DesiredTemperature
        {
            get => desiredTemperature;
            set
            {
                desiredTemperature = value;
                UpdateLastUpdated();
            }
        }

        public string Mode
        {
            get => mode;
            set
            {
                mode = value;
                UpdateLastUpdated();
            }
        }

        public bool IsOn
        {
            get => isOn;
            set
            {
                isOn = value;
                UpdateLastUpdated();
            }
        }

        public DateTime LastUpdated
        {
            get => lastUpdated;
            private set => lastUpdated = value;
        }

        private static string GenerateRandomId()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 16)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void UpdateLastUpdated()
        {
            LastUpdated = DateTime.Now;
        }
    }
}
