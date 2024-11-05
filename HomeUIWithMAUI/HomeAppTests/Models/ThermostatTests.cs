using HomeUIWithMAUI.Models;

namespace HomeAppTests.Models
{
    public class ThermostatTests
    {
        // Test for initialization
        [Fact]
        public void Thermostat_Initialization_SetsPropertiesCorrectly()
        {
            var thermostat = new Thermostat(1, "Living Room Thermostat", "Living Room", true, 22.0, 24.0, "Heating")
            {
                LastUpdated = DateTime.Now
            };

            Assert.Equal(1, thermostat.Id);
            Assert.Equal("Thermostat", thermostat.Type);
            Assert.Equal("Living Room Thermostat", thermostat.Name);
            Assert.Equal("Living Room", thermostat.Room);
            Assert.Equal(22.0, thermostat.CurrentTemperature);
            Assert.Equal(24.0, thermostat.DesiredTemperature);
            Assert.Equal("Heating", thermostat.Mode);
            Assert.True(thermostat.IsOn);
        }

        // Test for setting desired temperature
        [Fact]
        public void Thermostat_SetTemperature_UpdatesDesiredTemperatureAndLastUpdated()
        {
            var thermostat = new Thermostat(1, "Living Room Thermostat", "Living Room", true, 22.0, 24.0, "Heating");

            thermostat.SetTemperature(20.0);

            Assert.Equal(20.0, thermostat.DesiredTemperature);
            Assert.True(thermostat.LastUpdated > DateTime.Now.AddMinutes(-1)); // Check if LastUpdated is recent
        }

        // Test for setting mode
        [Fact]
        public void Thermostat_SetMode_UpdatesModeAndLastUpdated()
        {
            var thermostat = new Thermostat(1, "Living Room Thermostat", "Living Room", true, 22.0, 24.0, "Heating");

            thermostat.SetMode("Cooling");

            Assert.Equal("Cooling", thermostat.Mode);
            Assert.True(thermostat.LastUpdated > DateTime.Now.AddMinutes(-1)); // Check if LastUpdated is recent
        }

        // Test for updating current temperature
        [Fact]
        public void Thermostat_UpdateCurrentTemperature_UpdatesCurrentTemperature()
        {
            var thermostat = new Thermostat(1, "Living Room Thermostat", "Living Room", true, 22.0, 24.0, "Heating");

            thermostat.CurrentTemperature = 23.5;

            Assert.Equal(23.5, thermostat.CurrentTemperature);
        }
    }

}
