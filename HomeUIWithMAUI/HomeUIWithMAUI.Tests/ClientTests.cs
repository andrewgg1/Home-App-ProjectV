using HomeUIWithMAUI.TCP;
using Moq;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HomeUIWithMAUI.Tests
{
    public class ClientTests
    {
        private readonly Mock<IPHostEntry> _mockIpHostEntry;
        private readonly Mock<IPAddress> _mockIpAddress;
        private readonly Mock<IPEndPoint> _mockIpEndPoint;
        private readonly Mock<TcpClient> _mockTcpClient;
        private readonly Mock<NetworkStream> _mockNetworkStream;
        private readonly Client _client;

        public ClientTests()
        {
            _mockIpHostEntry = new Mock<IPHostEntry>();
            _mockIpAddress = new Mock<IPAddress>();
            _mockIpEndPoint = new Mock<IPEndPoint>(_mockIpAddress.Object, 8200);
            _mockTcpClient = new Mock<TcpClient>();
            _mockNetworkStream = new Mock<NetworkStream>();
            _client = new Client();
        }

        [Test]
        public async Task StartClient_ConnectsToServerAndReceivesMessage()
        {
            // Arrange
            _mockIpHostEntry.Setup(h => h.AddressList).Returns(new[] { _mockIpAddress.Object });
            _mockIpAddress.Setup(a => a.ToString()).Returns("127.0.0.1");
            _mockTcpClient.Setup(c => c.ConnectAsync(_mockIpEndPoint.Object)).Returns(Task.CompletedTask);
            _mockTcpClient.Setup(c => c.GetStream()).Returns(_mockNetworkStream.Object);
            var message = "Test message";
            var buffer = Encoding.UTF8.GetBytes(message);
            _mockNetworkStream.Setup(s => s.ReadAsync(It.IsAny<byte[]>(), 0, It.IsAny<int>())).ReturnsAsync(buffer.Length);

            // Act
            var startClientMethod = _client.GetType().GetMethod("StartClient", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            await (Task)startClientMethod.Invoke(_client, null);

            // Assert
            _mockTcpClient.Verify(c => c.ConnectAsync(_mockIpEndPoint.Object), Times.Once);
            _mockNetworkStream.Verify(s => s.ReadAsync(It.IsAny<byte[]>(), 0, It.IsAny<int>()), Times.Once);
        }

        [Test]
        public async Task StartClient_HandlesException()
        {
            // Arrange
            _mockIpHostEntry.Setup(h => h.AddressList).Returns(new[] { _mockIpAddress.Object });
            _mockIpAddress.Setup(a => a.ToString()).Returns("127.0.0.1");
            _mockTcpClient.Setup(c => c.ConnectAsync(_mockIpEndPoint.Object)).ThrowsAsync(new Exception("Test exception"));

            // Act
            var startClientMethod = _client.GetType().GetMethod("StartClient", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            await (Task)startClientMethod.Invoke(_client, null);

            // Assert
            _mockTcpClient.Verify(c => c.ConnectAsync(_mockIpEndPoint.Object), Times.Once);
        }
    }
}
