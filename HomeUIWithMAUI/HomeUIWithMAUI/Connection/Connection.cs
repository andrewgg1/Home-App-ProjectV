using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HomeUIWithMAUI.Utilities;
using HomeUIWithMAUI.Models;
using Pool = HomeUIWithMAUI.DevicePool.DevicePool;
using Device = HomeUIWithMAUI.Models.Device;
using System.Collections.Concurrent;
using System.Diagnostics;


namespace HomeUIWithMAUI.Connection
{
    public class HighCapacityTcpServer
    {
        private const int Port = 5000;
        private TcpListener _listener;

        // Dictionary to track connected clients and their associated device IDs
        private ConcurrentDictionary<TcpClient, int> _connectedClients = new ConcurrentDictionary<TcpClient, int>();

        public async Task StartServerAsync()
        {
            _listener = new TcpListener(IPAddress.Any, Port);
            _listener.Start();
            Trace.WriteLine($"Server started on port {Port}, waiting for connections...");

            // Subscribe to the DeviceUpdated event
            Pool.DeviceUpdated += OnDeviceUpdated;

            while (true)
            {
                try
                {
                    var client = await _listener.AcceptTcpClientAsync();
                    Trace.WriteLine("Client connected.");

                    // Process each client connection in a separate task
                    _ = HandleClientAsync(client);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine($"Error accepting client: {ex.Message}");
                }
            }
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            using (client)
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
                        Trace.WriteLine($"Received from client: {receivedMessage}");

                        // Validate message and create device object
                        var (isValid, device) = DataUnpackageCSV.ValidateMessageAndCreateDevice(receivedMessage);
                        string responseMessage = isValid ? "1" : "0";

                        if (isValid && device != null)
                        {
                            // Update device in the device pool
                            Pool.UpdateDevice(device);

                            // Store the client's associated device ID
                            _connectedClients[client] = device.DeviceId;
                        }

                        // Send validation result back to the client
                        byte[] responseData = Encoding.UTF8.GetBytes(responseMessage);
                        await stream.WriteAsync(responseData, 0, responseData.Length);
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine($"Error handling client: {ex.Message}");
                }
                finally
                {
                    // Remove client from the connected clients list when disconnected
                    _connectedClients.TryRemove(client, out _);
                    Trace.WriteLine("Client disconnected.");
                }
            }
        }

        private void OnDeviceUpdated(Device updatedDevice)
        {
            // Prepare the CSV data
            string csvData = updatedDevice.csvData;
            byte[] dataToSend = Encoding.UTF8.GetBytes(csvData);

            // Send the update to clients associated with the updated device
            foreach (var kvp in _connectedClients)
            {
                TcpClient client = kvp.Key;
                int deviceId = kvp.Value;

                if (deviceId == updatedDevice.DeviceId)
                {
                    try
                    {
                        NetworkStream stream = client.GetStream();
                        stream.WriteAsync(dataToSend, 0, dataToSend.Length);
                        Trace.WriteLine($"Sent update to client: {csvData}");
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine($"Error sending update to client: {ex.Message}");
                    }
                }
            }
            SendToLocalhostPort3500(dataToSend);
        }

        private void SendToLocalhostPort3500(byte[] data)
        {
            try
            {
                using (TcpClient client = new TcpClient("localhost", 3500))
                {
                    NetworkStream stream = client.GetStream();
                    stream.Write(data, 0, data.Length);
                    Trace.WriteLine("Sent update to localhost port 3500");
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Error sending update to localhost port 3500: {ex.Message}");
            }
        }
    }
}
