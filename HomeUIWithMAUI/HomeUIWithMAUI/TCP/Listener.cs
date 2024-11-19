using HomeUIWithMAUI.Models;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace HomeUIWithMAUI.TCP
{
    // Listener class
    // This class is responsible for listening for incoming connections and sending messages
    internal class Listener
    {
        private MainPage _mainPage;
        private string _logFilePath;

        public Listener(MainPage mainPage)
        {
            _mainPage = mainPage;
            InitializeLogFile();
        }

        private void InitializeLogFile()
        {
            var logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }
            _logFilePath = Path.Combine(logDirectory, $"log-{DateTime.Now:yyyy-MM-dd-HHmmss}.txt");
        }

        private void Log(string message)
        {
            File.AppendAllText(_logFilePath, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}{Environment.NewLine}");
        }

        private string ConvertThermostatToCsv(Thermostat thermostat)
        {
            return $"{thermostat.Id},{thermostat.Name},{thermostat.CurrentTemperature},{thermostat.DesiredTemperature},{thermostat.Mode},{thermostat.IsOn},{thermostat.LastUpdated:O}";
        }

        async internal void StartListening()
        {
            Log("Starting...");
            var ipEndPoint = new IPEndPoint(IPAddress.Any, 8100);
            TcpListener listener = new(ipEndPoint);

            Log("Starting Listener ...");
            listener.Start();
            while (true)
            {
                try
                {
                    Log("Accepting Clients...");
                    TcpClient handler = await listener.AcceptTcpClientAsync();
                    _ = HandleClientAsync(handler); // Start a new task to handle the client
                }
                catch (Exception ex)
                {
                    Log($"Error: {ex.Message}");
                }
            }
        }

        private async Task HandleClientAsync(TcpClient handler)
        {
            IPEndPoint clientEndPoint = null;
            try
            {
                clientEndPoint = handler.Client.RemoteEndPoint as IPEndPoint;
                if (clientEndPoint != null)
                {
                    Log($"Client connected: {clientEndPoint.Address}:{clientEndPoint.Port}");
                }

                await using NetworkStream stream = handler.GetStream();

                var buffer = new byte[1_024];
                int received = await stream.ReadAsync(buffer);
                var receivedMessage = Encoding.UTF8.GetString(buffer, 0, received);
                Log($"Message received: \"{receivedMessage}\"");

                while (true)
                {
                    string stringMessage = Utilities.DataPackage.PackData(_mainPage.testThermostat);
                    var byteMessage = Encoding.UTF8.GetBytes(stringMessage);
                    await stream.WriteAsync(byteMessage);

                    string csvMessage = ConvertThermostatToCsv(_mainPage.testThermostat);
                    Log($"Sent message: \"{csvMessage}\"");
                    //Log($"Sent message: \"{stringMessage}\"");
                    await Task.Delay(1000);
                }
            }
            catch (Exception ex)
            {
                Log($"Error: {ex.Message}");
            }
            finally
            {
                if (clientEndPoint != null)
                    Log($"Client disconnected: {clientEndPoint.Address}:{clientEndPoint.Port}");
                else
                    Log("Client disconnected");
                handler.Close();
            }
        }
    }
}
