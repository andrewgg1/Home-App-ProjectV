using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace HomeUIWithMAUI.Models
{
    public class Thermostat
    {
        private static Random random = new Random();
        private System.Timers.Timer temperatureAdjustmentTimer;

        private struct ThermostatMode
        {
            public const string Heat = "Heat";
            public const string Cool = "Cool";
            public const string Off = "Off";
        }

        private string id = GenerateRandomId();
        private string name = "Ground Floor Thermostat";
        private int currentTemperature = 20;
        private int desiredTemperature = 20;
        private int roomTemperature = 20;
        private string mode = ThermostatMode.Off;
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

        public int CurrentTemperature
        {
            get => currentTemperature;
            set
            {
                currentTemperature = value;
                UpdateLastUpdated();
            }
        }

        public int DesiredTemperature
        {
            get => desiredTemperature;
            set
            {
                desiredTemperature = value;
                UpdateLastUpdated();
                if (IsOn)
                {
                    StartTemperatureAdjustment();
                }
            }
        }

        public string Mode
        {
            get => mode;
            set
            {
                mode = value;
                UpdateLastUpdated();
                if (mode == ThermostatMode.Off && !isOn)
                {
                    StartReturningToRoomTemperature();
                }
            }
        }

        public bool IsOn
        {
            get => isOn;
            set
            {
                isOn = value;
                UpdateLastUpdated();
                if (isOn)
                {
                    StartTemperatureAdjustment();
                }
                else
                {
                    Mode = ThermostatMode.Off;
                    StartReturningToRoomTemperature();
                }
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

        private void StartReturningToRoomTemperature()
        {
            if (temperatureAdjustmentTimer != null)
            {
                temperatureAdjustmentTimer.Stop();
                temperatureAdjustmentTimer.Dispose();
            }

            temperatureAdjustmentTimer = new System.Timers.Timer(3000); // 3 seconds per degree
            temperatureAdjustmentTimer.Elapsed += ReturnToRoomTemperature;
            temperatureAdjustmentTimer.Start();
        }

        private void ReturnToRoomTemperature(object sender, ElapsedEventArgs e)
        {
            if (Math.Abs(CurrentTemperature - roomTemperature) < 1)
            {
                CurrentTemperature = roomTemperature;
                temperatureAdjustmentTimer.Stop();
                temperatureAdjustmentTimer.Dispose();
                return;
            }

            if (CurrentTemperature < roomTemperature)
            {
                CurrentTemperature += 1;
            }
            else if (CurrentTemperature > roomTemperature)
            {
                CurrentTemperature -= 1;
            }

            UpdateLastUpdated();
        }

        private void StartTemperatureAdjustment()
        {
            if (temperatureAdjustmentTimer != null)
            {
                temperatureAdjustmentTimer.Stop();
                temperatureAdjustmentTimer.Dispose();
            }

            temperatureAdjustmentTimer = new System.Timers.Timer(3000); // 3 seconds per degree
            temperatureAdjustmentTimer.Elapsed += AdjustTemperature;
            temperatureAdjustmentTimer.Start();
        }

        private void AdjustTemperature(object sender, ElapsedEventArgs e)
        {
            if (Math.Abs(CurrentTemperature - DesiredTemperature) < 1)
            {
                CurrentTemperature = DesiredTemperature;
                temperatureAdjustmentTimer.Stop();
                temperatureAdjustmentTimer.Dispose();
                return;
            }

            if (CurrentTemperature < DesiredTemperature)
            {
                Mode = ThermostatMode.Heat;
                CurrentTemperature += 1;
            }
            else if (CurrentTemperature > DesiredTemperature)
            {
                Mode = ThermostatMode.Cool;
                CurrentTemperature -= 1;
            }

            UpdateLastUpdated();
        }
    }
}
