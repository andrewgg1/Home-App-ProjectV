using HomeUIWithMAUI.Utilities;
using System;
using System.Text.Json;
using Xunit;

namespace HomeUIWithMAUI.Tests
{
    public class DataUnpackageTests
    {
        public class TestDevice
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public int Value { get; set; }
        }

        [Test]
        public void UnpackData_DeserializesStringToObject()
        {
            // Arrange
            var device = new TestDevice
            {
                Id = "1",
                Name = "Test Device",
                Value = 100
            };
            var jsonData = JsonSerializer.Serialize(device);

            // Act
            var result = DataUnpackage.UnpackData<TestDevice>(jsonData);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(device.Id, result.Id);
            Assert.Equal(device.Name, result.Name);
            Assert.Equal(device.Value, result.Value);
        }

        [Test]
        public void UnpackData_HandlesDeserializationError()
        {
            // Arrange
            var invalidJsonData = "{ invalid json }";

            // Act
            var result = DataUnpackage.UnpackData<TestDevice>(invalidJsonData);

            // Assert
            Assert.Null(result);
        }
    }
}
