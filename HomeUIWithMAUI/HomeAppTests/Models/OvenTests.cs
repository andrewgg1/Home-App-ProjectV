using HomeUIWithMAUI.Models;

namespace HomeAppTests.Models
{
    public class OvenTests
    {
        // Test for initialization
        [Fact]
        public void Oven_Initialization_SetsPropertiesCorrectly()
        {
            var oven = new Oven(1, "Kitchen Oven", "Kitchen");

            Assert.Equal(1, oven.Id);
            Assert.Equal("Oven", oven.Type);
            Assert.Equal("Kitchen Oven", oven.Name);
            Assert.Equal("Kitchen", oven.Room);
            Assert.Equal(0, oven.Temperature);
            Assert.Equal("Off", oven.Mode);
            Assert.Equal(0, oven.Timer);
            Assert.False(oven.IsOn);
        }

        // Test for starting preheat
        [Fact]
        public void Oven_StartPreheat_UpdatesTemperatureAndModeAndTurnsOn()
        {
            var oven = new Oven(1, "Kitchen Oven", "Kitchen");

            oven.StartPreheat(200);

            Assert.Equal(200, oven.Temperature);
            Assert.Equal("Preheat", oven.Mode);
            Assert.True(oven.IsOn);
        }

        // Test for setting mode
        [Fact]
        public void Oven_SetMode_UpdatesModeAndKeepsOvenOn()
        {
            var oven = new Oven(1, "Kitchen Oven", "Kitchen");

            oven.StartPreheat(200);
            oven.SetMode("Bake");

            Assert.Equal("Bake", oven.Mode);
            Assert.True(oven.IsOn);
        }

        // Test for setting timer
        [Fact]
        public void Oven_SetTimer_UpdatesTimerAndKeepsOvenOn()
        {
            var oven = new Oven(1, "Kitchen Oven", "Kitchen");

            oven.StartPreheat(200);
            oven.SetTimer(30);

            Assert.Equal(30, oven.Timer);
            Assert.True(oven.IsOn);
        }

        // Test for stopping the oven
        [Fact]
        public void Oven_Stop_ResetsPropertiesAndTurnsOff()
        {
            var oven = new Oven(1, "Kitchen Oven", "Kitchen");

            oven.StartPreheat(200);
            oven.Stop();

            Assert.Equal(0, oven.Temperature);
            Assert.Equal("Off", oven.Mode);
            Assert.Equal(0, oven.Timer);
            Assert.False(oven.IsOn);
        }
    }

}
