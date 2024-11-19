using HomeUIWithMAUI.Models;
using HomeUIWithMAUI.TCP;
using Moq;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HomeUIWithMAUI.Tests
{
    public class ListenerTests
    {
        private readonly Mock<MainPage> _mockMainPage;
        private readonly Listener _listener;

        public ListenerTests()
        {
            _mockMainPage = new Mock<MainPage>();
            _listener = new Listener(_mockMainPage.Object);
        }

        [Test]
        public void InitializeLogFile_CreatesLogDirectoryAndFile()
        {
            // Arrange
            var logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");

            // Act
            _listener.GetType().GetMethod("InitializeLogFile", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).Invoke(_listener, null);

            // Assert
            Assert.True(Directory.Exists(logDirectory));
            Assert.True(File.Exists(Directory.GetFiles(logDirectory)[0]));
        }

        [Test]
        public void ConvertThermostatToCsv_ReturnsCorrectCsvString()
        {
            // Arrange
            var thermostat = new Thermostat
            {
                Id = "1",
                Name = "Test Thermostat",
                CurrentTemperature = 22,
                DesiredTemperature = 24,
                Mode = "Heat",
                IsOn = true,
                LastUpdated = DateTime.Now
            };

            // Act
            var result = _listener.GetType().GetMethod("ConvertThermostatToCsv", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).Invoke(_listener, new object[] { thermostat });

            // Assert
            var expected = $"{thermostat.Id},{thermostat.Name},{thermostat.CurrentTemperature},{thermostat.DesiredTemperature},{thermostat.Mode},{thermostat.IsOn},{thermostat.LastUpdated:O}";
            Assert.Equal(expected, result);
        }

        [Test]
        public async Task HandleClientAsync_LogsClientConnectionAndDisconnection()
        {
            // Arrange
            var mockTcpClient = new Mock<TcpClient>();
            var mockNetworkStream = new Mock<NetworkStream>();
            mockTcpClient.Setup(c => c.GetStream()).Returns(mockNetworkStream.Object);
            mockTcpClient.Setup(c => c.Client.RemoteEndPoint).Returns(new IPEndPoint(IPAddress.Loopback, 12345));

            // Act
            var handleClientAsyncMethod = _listener.GetType().GetMethod("HandleClientAsync", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            await (Task)handleClientAsyncMethod.Invoke(_listener, new object[] { mockTcpClient.Object });

            // Assert
            // Check the log file for connection and disconnection messages
            var logFilePath = _listener.GetType().GetField("_logFilePath", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(_listener).ToString();
            var logContent = File.ReadAllText(logFilePath);
            Assert.Contains("Client connected", logContent);
            Assert.Contains("Client disconnected", logContent);
        }
    }
}
