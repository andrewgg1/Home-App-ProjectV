using HomeUIWithMAUI.Models;

namespace HomeAppTests.Models
{
    public class ThermostatTests
    {
        [Fact]
        public void Thermostat_Initialization_SetsPropertiesCorrectly()
        {
            // Arrange
            var thermostat = new Thermostat(1, "Thermostat", "Living Room Thermostat", true, 22.0, 24.0, "Cooling");

            // Act & Assert
            Assert.Equal(1, thermostat.Id);
            Assert.Equal("Thermostat", thermostat.Type);
            Assert.Equal("Living Room Thermostat", thermostat.Name);
            Assert.Equal("Living Room", thermostat.Room);
            Assert.Equal(22.0, thermostat.CurrentTemperature);
            Assert.Equal(24.0, thermostat.DesiredTemperature);
            Assert.Equal("Cooling", thermostat.Mode);
            Assert.True(thermostat.IsOn);
        }

        [Fact]
        public void Thermostat_UpdateStatus_UpdatesIsOnAndLastUpdated()
        {
            // Arrange
            var thermostat = new Thermostat(1, "Thermostat", "Living Room Thermostat", false, 0.0, 0.0, "Off");

            // Act
            thermostat.UpdateStatus(true);

            // Assert
            Assert.True(thermostat.IsOn);
            Assert.True(thermostat.LastUpdated > DateTime.Now.AddMinutes(-1)); // Check if LastUpdated is recent
        }
    }
}
