using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HomeUIWithMAUI.TCP
{
    internal class Client
    {
        async internal void StartClient()
        {
            IPHostEntry ipHostInfo = await Dns.GetHostEntryAsync("127.0.0.1");
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            string ip = ipAddress.ToString();

            var ipEndPoint = new IPEndPoint(ipAddress, 8200);

            while (true)
            {
                try
                {
                    using TcpClient client = new();
                    await client.ConnectAsync(ipEndPoint);
                    await using NetworkStream stream = client.GetStream();

                    var buffer = new byte[1_024];
                    int received = await stream.ReadAsync(buffer);

                    var message = Encoding.UTF8.GetString(buffer, 0, received);
                    Console.WriteLine($"Message received: \"{message}\"");
                    // Sample output:
                    //     Message received: "8/22/2022 9:07:17 AM"
                    await Task.Delay(500);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                finally
                {
                    await Task.Delay(500);
                }
            }
        }
    }
}
