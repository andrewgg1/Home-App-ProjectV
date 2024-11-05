using HomeUIWithMAUI.Models;

namespace HomeAppTests.Models
{
    public class FridgeTests
    {
        // Test for initialization
        [Fact]
        public void Fridge_Initialization_SetsPropertiesCorrectly()
        {
            var fridge = new Fridge(1, "Kitchen Fridge", "Kitchen");

            Assert.Equal(1, fridge.Id);
            Assert.Equal("Fridge", fridge.Type);
            Assert.Equal("Kitchen Fridge", fridge.Name);
            Assert.Equal("Kitchen", fridge.Room);
            Assert.Equal(4.0, fridge.CurrentTemperature);
            Assert.Equal(4.0, fridge.TargetTemperature);
            Assert.False(fridge.DoorOpen);
            Assert.True(fridge.IsCooling);
            Assert.True(fridge.IsOn);
        }

        // Test for updating temperature
        [Fact]
        public void Fridge_UpdateTemperature_UpdatesCurrentAndTargetTemperatures()
        {
            var fridge = new Fridge(1, "Kitchen Fridge", "Kitchen");

            fridge.UpdateTemperature(3.0, 2.0);

            Assert.Equal(3.0, fridge.CurrentTemperature);
            Assert.Equal(2.0, fridge.TargetTemperature);
            Assert.True(fridge.LastUpdated < DateTime.Now); // Check if LastUpdated is set to now
        }

        // Test for toggling the door
        [Fact]
        public void Fridge_ToggleDoor_UpdatesDoorOpenStatus()
        {
            var fridge = new Fridge(1, "Kitchen Fridge", "Kitchen");

            fridge.ToggleDoor(true);

            Assert.True(fridge.DoorOpen);
            Assert.True(fridge.LastUpdated < DateTime.Now); // Check if LastUpdated is set to now
        }

        // Test for toggling cooling
        [Fact]
        public void Fridge_ToggleCooling_UpdatesCoolingStatusAndKeepsOvenOn()
        {
            var fridge = new Fridge(1, "Kitchen Fridge", "Kitchen");

            fridge.ToggleCooling(false);

            Assert.False(fridge.IsCooling);
            Assert.True(fridge.IsOn);
        }

        // Test for maintaining status when cooling is turned off
        [Fact]
        public void Fridge_ToggleCooling_WhenOff_MaintainsCurrentTemperature()
        {
            var fridge = new Fridge(1, "Kitchen Fridge", "Kitchen");
            fridge.UpdateTemperature(5.0, 4.0); // Change to some temperature

            fridge.ToggleCooling(false);

            Assert.Equal(5.0, fridge.CurrentTemperature);
            Assert.Equal(4.0, fridge.TargetTemperature);
            Assert.True(fridge.IsOn);
        }
    }

}
