using HomeUIWithMAUI.Models;

namespace HomeAppTests.Models
{
    public class VacuumTests
    {
        // Test for initialization
        [Fact]
        public void Vacuum_Initialization_SetsPropertiesCorrectly()
        {
            var vacuum = new Vacuum(1, "Living Room Vacuum", "Living Room");

            Assert.Equal(1, vacuum.Id);
            Assert.Equal("Vacuum", vacuum.Type);
            Assert.Equal("Living Room Vacuum", vacuum.Name);
            Assert.Equal("Living Room", vacuum.Room);
            Assert.Equal("Standard", vacuum.Mode);
            Assert.Equal(100, vacuum.BatteryLevel);
            Assert.True(vacuum.IsDocked);
            Assert.False(vacuum.IsOn);
        }

        // Test for updating battery level
        [Fact]
        public void Vacuum_UpdateBatteryLevel_SetsBatteryLevel()
        {
            var vacuum = new Vacuum(1, "Living Room Vacuum", "Living Room");

            vacuum.UpdateBatteryLevel(80);

            Assert.Equal(80, vacuum.BatteryLevel);
            Assert.True(vacuum.LastUpdated < DateTime.Now); // Check if LastUpdated is set to now
        }

        // Test for setting mode
        [Fact]
        public void Vacuum_SetMode_UpdatesMode()
        {
            var vacuum = new Vacuum(1, "Living Room Vacuum", "Living Room");

            vacuum.SetMode("Eco");

            Assert.Equal("Eco", vacuum.Mode);
            Assert.True(vacuum.LastUpdated < DateTime.Now); // Check if LastUpdated is set to now
        }

        // Test for docking the vacuum
        [Fact]
        public void Vacuum_Dock_SetsIsDockedToTrueAndIsOnToFalse()
        {
            var vacuum = new Vacuum(1, "Living Room Vacuum", "Living Room");

            vacuum.Dock(true); // Docking the vacuum

            Assert.True(vacuum.IsDocked);
            Assert.False(vacuum.IsOn);
            Assert.True(vacuum.LastUpdated < DateTime.Now); // Check if LastUpdated is set to now
        }

        // Test for undocking the vacuum
        [Fact]
        public void Vacuum_Dock_SetsIsDockedToFalseAndIsOnToTrue()
        {
            var vacuum = new Vacuum(1, "Living Room Vacuum", "Living Room");

            vacuum.Dock(false); // Undocking the vacuum

            Assert.False(vacuum.IsDocked);
            Assert.True(vacuum.IsOn); // Should turn on when undocked
            Assert.True(vacuum.LastUpdated < DateTime.Now); // Check if LastUpdated is set to now
        }

        // Test for starting cleaning
        [Fact]
        public void Vacuum_StartCleaning_SetsIsOnToTrue_WhenNotDockedAndHasBattery()
        {
            var vacuum = new Vacuum(1, "Living Room Vacuum", "Living Room");
            vacuum.Dock(false); // Ensure it's undocked

            vacuum.StartCleaning();

            Assert.True(vacuum.IsOn);
            Assert.True(vacuum.LastUpdated < DateTime.Now); // Check if LastUpdated is set to now
        }

        // Test for starting cleaning when battery is 0
        [Fact]
        public void Vacuum_StartCleaning_DoesNotSetIsOn_WhenBatteryIsZero()
        {
            var vacuum = new Vacuum(1, "Living Room Vacuum", "Living Room");
            vacuum.Dock(false); // Ensure it's undocked
            vacuum.UpdateBatteryLevel(0); // Set battery to 0

            vacuum.StartCleaning();

            Assert.False(vacuum.IsOn); // Should not turn on
        }

        // Test for stopping cleaning
        [Fact]
        public void Vacuum_StopCleaning_SetsIsOnToFalse()
        {
            var vacuum = new Vacuum(1, "Living Room Vacuum", "Living Room");
            vacuum.Dock(false); // Ensure it's undocked
            vacuum.StartCleaning(); // Start cleaning first

            vacuum.StopCleaning();

            Assert.False(vacuum.IsOn);
            Assert.True(vacuum.LastUpdated < DateTime.Now); // Check if LastUpdated is set to now
        }
    }

}
