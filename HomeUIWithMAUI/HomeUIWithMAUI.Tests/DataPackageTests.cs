using HomeUIWithMAUI.Utilities;
using System;
using System.Text.Json;
using Xunit;

namespace HomeUIWithMAUI.Tests
{
    public class DataPackageTests
    {
        public class TestDevice
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public int Value { get; set; }
        }

        [Test]
        public void PackData_SerializesObjectToString()
        {
            // Arrange
            var device = new TestDevice
            {
                Id = "1",
                Name = "Test Device",
                Value = 100
            };

            // Act
            var result = DataPackage.PackData(device);

            // Assert
            var expected = JsonSerializer.Serialize(device);
            Assert.Equal(expected, result);
        }

        [Test]
        public void PackData_HandlesSerializationError()
        {
            // Arrange
            var device = new TestDevice
            {
                Id = "1",
                Name = "Test Device",
                Value = 100
            };

            // Act
            var result = DataPackage.PackData((TestDevice)null);

            // Assert
            Assert.Null(result);
        }
    }
}
