using HomeUIWithMAUI.Models;

namespace HomeAppTests.Models
{
    public class DehumidifierTests
    {
        // Test for initialization
        [Fact]
        public void Dehumidifier_Initialization_SetsPropertiesCorrectly()
        {
            var dehumidifier = new Dehumidifier(1, "Living Room Dehumidifier", "Living Room");

            Assert.Equal(1, dehumidifier.Id);
            Assert.Equal("Dehumidifier", dehumidifier.Type);
            Assert.Equal("Living Room Dehumidifier", dehumidifier.Name);
            Assert.Equal("Living Room", dehumidifier.Room);
            Assert.Equal(50, dehumidifier.DesiredHumidity);
            Assert.Equal("Auto", dehumidifier.Mode);
            Assert.Equal(1, dehumidifier.FanSpeed);
            Assert.False(dehumidifier.IsOn);
        }

        // Test for updating humidity level
        [Fact]
        public void Dehumidifier_UpdateHumidityLevel_SetsCurrentHumidity()
        {
            var dehumidifier = new Dehumidifier(1, "Living Room Dehumidifier", "Living Room");

            dehumidifier.UpdateHumidityLevel(60);

            Assert.Equal(60, dehumidifier.HumidityLevel);
            Assert.True(dehumidifier.LastUpdated < DateTime.Now); // Check if LastUpdated is set to now
        }

        // Test for setting desired humidity
        [Fact]
        public void Dehumidifier_SetDesiredHumidity_UpdatesDesiredHumidity()
        {
            var dehumidifier = new Dehumidifier(1, "Living Room Dehumidifier", "Living Room");

            dehumidifier.SetDesiredHumidity(40);

            Assert.Equal(40, dehumidifier.DesiredHumidity);
            Assert.True(dehumidifier.LastUpdated < DateTime.Now); // Check if LastUpdated is set to now
        }

        // Test for setting mode
        [Fact]
        public void Dehumidifier_SetMode_UpdatesMode()
        {
            var dehumidifier = new Dehumidifier(1, "Living Room Dehumidifier", "Living Room");

            dehumidifier.SetMode("Eco");

            Assert.Equal("Eco", dehumidifier.Mode);
            Assert.True(dehumidifier.LastUpdated < DateTime.Now); // Check if LastUpdated is set to now
        }

        // Test for adjusting fan speed
        [Fact]
        public void Dehumidifier_AdjustFanSpeed_UpdatesFanSpeed()
        {
            var dehumidifier = new Dehumidifier(1, "Living Room Dehumidifier", "Living Room");

            dehumidifier.AdjustFanSpeed(2); // Medium speed

            Assert.Equal(2, dehumidifier.FanSpeed);
            Assert.True(dehumidifier.LastUpdated < DateTime.Now); // Check if LastUpdated is set to now
        }

        // Test for starting the dehumidifier
        [Fact]
        public void Dehumidifier_StartDehumidifying_SetsIsOnToTrue()
        {
            var dehumidifier = new Dehumidifier(1, "Living Room Dehumidifier", "Living Room");

            dehumidifier.StartDehumidifying();

            Assert.True(dehumidifier.IsOn);
            Assert.True(dehumidifier.LastUpdated < DateTime.Now); // Check if LastUpdated is set to now
        }

        // Test for stopping the dehumidifier
        [Fact]
        public void Dehumidifier_StopDehumidifying_SetsIsOnToFalse()
        {
            var dehumidifier = new Dehumidifier(1, "Living Room Dehumidifier", "Living Room");
            dehumidifier.StartDehumidifying(); // Start it first

            dehumidifier.StopDehumidifying();

            Assert.False(dehumidifier.IsOn);
            Assert.True(dehumidifier.LastUpdated < DateTime.Now); // Check if LastUpdated is set to now
        }
    }

}
