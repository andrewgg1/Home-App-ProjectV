using System.Net.Sockets;
using System.Net;
using System.Text;
using simulator.Models;
using simulator.Utilities;

namespace simulator.TCP
{
    // Client class
    // This class is responsible for connecting to the server and receiving messages
    internal class Client
    {
        async internal void StartClient(string ipHost)
        {
            try
            {
                //IPHostEntry ipHostInfo = await Dns.GetHostEntryAsync("127.0.0.1");
                IPHostEntry ipHostInfo = await Dns.GetHostEntryAsync(ipHost);
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                var ipEndPoint = new IPEndPoint(ipAddress, 8100);

                while (true)
                {
                    using TcpClient client = new();
                    try
                    {
                        Console.WriteLine("Attempting to connect to listener...");
                        await client.ConnectAsync(ipEndPoint);
                        Console.WriteLine($"Connected from local port: {((IPEndPoint)client.Client.LocalEndPoint).Port}");
                        await using NetworkStream stream = client.GetStream();

                        // Send a message upon connection
                        string initialMessage = "Hello, server!";
                        byte[] messageBytes = Encoding.UTF8.GetBytes(initialMessage);
                        await stream.WriteAsync(messageBytes);
                        Console.WriteLine($"Sent message: \"{initialMessage}\"");

                        while (true)
                        {
                            var buffer = new byte[1_024];
                            int received = await stream.ReadAsync(buffer);

                            if (received == 0)
                            {
                                Console.WriteLine("Connection lost...");
                                break;
                            }

                            var rawMessage = Encoding.UTF8.GetString(buffer, 0, received);
                            Thermostat thermostat = DataUnpackage.UnpackData<Thermostat>(rawMessage);
                            thermostat.PrintDetails();
                        }
                    }
                    //catch (SocketException ex)
                    //{
                    //    Console.WriteLine($"Error: {ex.GetType().Name} - {ex.Message}");
                    //    Console.WriteLine("Tap space bar to exit...");
                    //    break;
                    //}
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.GetType().Name} - {ex.Message}");
                        await Task.Delay(1000);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.GetType().Name} - {ex.Message}");
                Console.WriteLine("Tap space bar to exit...");
            }
        }
    }
}
