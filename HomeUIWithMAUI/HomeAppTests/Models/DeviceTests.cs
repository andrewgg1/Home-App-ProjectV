using Device = HomeUIWithMAUI.Models.Device;

namespace HomeAppTests.Models
{
    public class TestDevice : Device
    {
        public TestDevice(int id, string name, string room, bool isOn)
            : base(id, "TestDevice", name, room, isOn)
        {
        }
    }

    public class DeviceTests
    {
        [Fact]
        public void Device_Initialization_SetsPropertiesCorrectly()
        {
            // Arrange
            var device = new TestDevice(1, "Test Device", "Living Room", true);

            // Act & Assert
            Assert.Equal(1, device.Id);
            Assert.Equal("TestDevice", device.Type);
            Assert.Equal("Test Device", device.Name);
            Assert.Equal("Living Room", device.Room);
            Assert.True(device.IsOn);
            Assert.NotEqual(default, device.LastUpdated); // Ensure LastUpdated is set
        }

        [Fact]
        public void UpdateStatus_ChangesIsOnAndLastUpdated()
        {
            // Arrange
            var device = new TestDevice(2, "Test Device", "Kitchen", false);

            // Act
            device.UpdateStatus(true);

            // Assert
            Assert.True(device.IsOn);
            Assert.NotEqual(default, device.LastUpdated); // Ensure LastUpdated is updated
        }
    }
}
