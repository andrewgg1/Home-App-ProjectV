using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HomeUIWithMAUI.Connection
{
    public class HighCapacityTcpServer
    {
        private const int Port = 5000;
        private TcpListener _listener;

        public async Task StartServerAsync()
        {
            _listener = new TcpListener(IPAddress.Any, Port);
            _listener.Start();
            Console.WriteLine($"Server started on port {Port}, waiting for connections...");

            while (true)
            {
                try
                {
                    var client = await _listener.AcceptTcpClientAsync();
                    Console.WriteLine("Client connected.");

                    // Process each client connection in a separate task
                    _ = HandleClientAsync(client);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error accepting client: {ex.Message}");
                }
            }
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            using (client) // Ensures resources are disposed when done
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];

                try
                {
                    while (client.Connected)
                    {
                        int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                        if (bytesRead == 0) break; // Client disconnected

                        string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        Console.WriteLine($"Received from client: {receivedMessage}");

                        // Check if the received message matches any known format
                        bool isValid = ValidateMessageFormat(receivedMessage);
                        string responseMessage = isValid ? "1" : "0";

                        // Send validation result back to the client
                        byte[] responseData = Encoding.UTF8.GetBytes(responseMessage);
                        await stream.WriteAsync(responseData, 0, responseData.Length);
                        Console.WriteLine($"Sent to client: {responseMessage}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error handling client: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine("Client disconnected.");
                }
            }
        }

        private bool ValidateMessageFormat(string message)
        {
            // Define regex patterns for each device type
            string fridgePattern = @"^0, [0-2], SmartFridge, [0-1], -?\d+, -?\d+$";
            string dehumidifierPattern = @"^0, [0-2], SmartDehumidifier, [0-1], \d+, \d+$";
            string thermostatPattern = @"^0, [0-2], SmartThermostat, [0-1], -?\d+$";

            // Check if message matches any of the patterns
            return Regex.IsMatch(message, fridgePattern) ||
                   Regex.IsMatch(message, dehumidifierPattern) ||
                   Regex.IsMatch(message, thermostatPattern);
        }
    }
}
