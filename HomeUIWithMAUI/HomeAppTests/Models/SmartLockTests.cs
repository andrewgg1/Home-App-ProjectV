using HomeUIWithMAUI.Models;

namespace HomeAppTests.Models
{
    public class SmartLockTests
    {
        [Fact]
        public void SmartLock_Initialization_SetsPropertiesCorrectly()
        {
            // Arrange
            var smartLock = new SmartLock(1, "Smart Lock", "Front Door Lock", true, "Main Hub", "Hub001", false)
            {
                Room = "Entrance"
            };

            // Act & Assert
            Assert.Equal(1, smartLock.Id);
            Assert.Equal("Smart Lock", smartLock.Type);
            Assert.Equal("Front Door Lock", smartLock.Name);
            Assert.Equal("Entrance", smartLock.Room);
            Assert.Equal("Main Hub", smartLock.HubName);
            Assert.Equal("Hub001", smartLock.HubId);
            Assert.True(smartLock.IsOn);
            Assert.False(smartLock.IsLocked);
        }

        [Fact]
        public void SmartLock_UpdateStatus_UpdatesIsOnAndLastUpdated()
        {
            // Arrange
            var smartLock = new SmartLock(1, "Smart Lock", "Front Door Lock", false, "Main Hub", "Hub001", false)
            {
                Room = "Entrance"
            };

            // Act
            smartLock.UpdateStatus(true);

            // Assert
            Assert.True(smartLock.IsOn);
            Assert.True(smartLock.LastUpdated > DateTime.Now.AddMinutes(-1)); // Check if LastUpdated is recent
        }

        // Lock and unlock functionality
        [Fact]
        public void SmartLock_LockAndUnlock_ChangesStateCorrectly()
        {
            var smartLock = new SmartLock(1, "Smart Lock", "Front Door Lock", true, "Main Hub", "Hub001", false)
            {
                Room = "Entrance"
            };

            smartLock.Lock(); // Implement a Lock() method in SmartLock
            Assert.True(smartLock.IsLocked);

            smartLock.Unlock(); // Implement an Unlock() method in SmartLock
            Assert.False(smartLock.IsLocked);
        }
    }
}
