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
                        Console.WriteLine($"Received from client: {receivedMessage}");

                        // Validate message and create device object
                        var (isValid, device) = ValidateMessageFormat(receivedMessage);
                        string responseMessage = isValid ? "1" : "0";
                        if (isValid)
                        {
                            Utilities.DataPackage.PackData(receivedMessage);
                            // Add device to the device pool or handle it as needed
                            Pool.UpdateDevice(device);
                        }

                        // Send validation result back to the client
                        byte[] responseData = Encoding.UTF8.GetBytes(responseMessage);
                        await stream.WriteAsync(responseData, 0, responseData.Length);
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

        private (bool, Device) ValidateMessageFormat(string message)
        {
            try
            {
                // Split the message into parts and trim any whitespace
                var parts = message.Split(',').Select(p => p.Trim()).ToArray();

                // Ensure there are enough parts to proceed
                if (parts.Length < 4)
                    return (false, null);

                // Common fields
                int hubId = int.Parse(parts[0]);
                int deviceId = int.Parse(parts[1]);
                string deviceType = parts[2];
                bool isOn = parts[3] == "1";
                State currentState = isOn ? State.On : State.Off;

                // Device variable to hold the created device
                Device device = null;

                switch (deviceType)
                {
                    case "SmartFridge":
                        if (parts.Length != 6)
                            return (false, null);

                        int fridgeTemp = int.Parse(parts[4]);
                        int freezerTemp = int.Parse(parts[5]);

                        // Instantiate the Fridge device
                        device = new Models.Fridge(currentState)
                        {
                            HubId = hubId,
                            DeviceId = deviceId,
                            Name = deviceType,
                            FridgeTemperature = fridgeTemp,
                            FreezerTemperature = freezerTemp
                        };
                        break;

                    case "SmartDehumidifier":
                        if (parts.Length != 6)
                            return (false, null);

                        int waterLevel = int.Parse(parts[4]);
                        int humidityLevel = int.Parse(parts[5]);

                        device = new Models.Dehumidifier(currentState)
                        {
                            HubId = hubId,
                            DeviceId = deviceId,
                            Name = deviceType,
                            WaterLevel = waterLevel,
                            HumidityLevel = humidityLevel
                        };
                        break;

                    case "SmartThermostat":
                        if (parts.Length != 5)
                            return (false, null);

                        double currentTemp = double.Parse(parts[4]);

                        device = new Models.Thermostat(currentTemp, currentState)
                        {
                            HubId = hubId,
                            DeviceId = deviceId,
                            Name = deviceType
                        };
                        break;

                    case "SmartLock":
                        device = new Models.SmartLock(deviceId, currentState, DefaultLockState: parts.Length > 4 && parts[4] == "1")
                        {
                            HubId = hubId,
                            Name = deviceType
                        };
                        break;

                    case "SmartSensor":
                        device = new Models.Sensor(deviceId, currentState, DefaultTrigger: parts.Length > 4 && parts[4] == "1")
                        {
                            HubId = hubId,
                            Name = deviceType
                        };
                        break;

                    case "SmartCamera":
                        device = new Models.SecurityCamera(deviceId, currentState, MotionDetected: parts.Length > 4 && parts[4] == "1")
                        {
                            HubId = hubId,
                            Name = deviceType
                        };
                        break;

                    case "SmartAlarm":
                        device = new Models.SecurityAlarm(deviceId, currentState, DefaultAlarmState: parts.Length > 4 && parts[4] == "1")
                        {
                            HubId = hubId,
                            Name = deviceType
                        };
                        break;

                    case "SmartTracker":
                        if (parts.Length != 5)
                            return (false, null);

                        int location = int.Parse(parts[4]);

                        device = new Models.Tracker(deviceId, currentState, DefaultTrackerState: true, location)
                        {
                            HubId = hubId,
                            Name = deviceType
                        };
                        break;

                    default:
                        // Unknown device type
                        return (false, null);
                }

                return (true, device);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing message: {ex.Message}");
                return (false, null);
            }
        }
    }
}
