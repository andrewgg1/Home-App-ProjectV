using HomeUIWithMAUI.Models;

namespace HomeAppTests.Models
{
    // A concrete class for testing purposes
    public class TestDeviceWithHub : DeviceWithHub
    {
        public TestDeviceWithHub(int id, string name, string room, bool isOn, string hubName, string hubId)
            : base(id, "TestDeviceWithHub", name, room, isOn, hubName, hubId)
        {
        }
    }

    public class DeviceWithHubTests
    {
        [Fact]
        public void DeviceWithHub_Initialization_SetsPropertiesCorrectly()
        {
            // Arrange
            var deviceWithHub = new TestDeviceWithHub(1, "Smart Light", "Living Room", true, "Main Hub", "Hub001");

            // Act & Assert
            Assert.Equal(1, deviceWithHub.Id);
            Assert.Equal("TestDeviceWithHub", deviceWithHub.Type);
            Assert.Equal("Smart Light", deviceWithHub.Name);
            Assert.Equal("Living Room", deviceWithHub.Room);
            Assert.True(deviceWithHub.IsOn);
            Assert.Equal("Main Hub", deviceWithHub.HubName);
            Assert.Equal("Hub001", deviceWithHub.HubId);
            Assert.NotEqual(default(DateTime), deviceWithHub.LastUpdated); // Ensure LastUpdated is set
        }

        [Fact]
        public void UpdateStatus_ChangesIsOnAndLastUpdated()
        {
            // Arrange
            var deviceWithHub = new TestDeviceWithHub(2, "Smart Light", "Bedroom", false, "Main Hub", "Hub002");

            // Act
            deviceWithHub.UpdateStatus(true);

            // Assert
            Assert.True(deviceWithHub.IsOn);
            Assert.NotEqual(default(DateTime), deviceWithHub.LastUpdated); // Ensure LastUpdated is updated
        }
    }
}
