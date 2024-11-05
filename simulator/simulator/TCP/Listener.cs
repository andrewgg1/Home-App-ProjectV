using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace simulator.TCP
{
    // Listener class
    // This class is responsible for listening for incoming connections and sending messages
    internal class Listener
    {
        async internal void StartListening()
        {
            Trace.WriteLine("Starting...");
            var ipEndPoint = new IPEndPoint(IPAddress.Any, 8200);
            TcpListener listener = new(ipEndPoint);

            try
            {
                Trace.WriteLine("Starting Listener ...");
                listener.Start();
                while (true)
                {
                    using TcpClient handler = await listener.AcceptTcpClientAsync();
                    await using NetworkStream stream = handler.GetStream();

                    var message = $"{DateTime.Now}";
                    var dateTimeBytes = Encoding.UTF8.GetBytes(message);
                    await stream.WriteAsync(dateTimeBytes);

                    Trace.WriteLine($"Sent message: \"{message}\"");
                    // Sample output:
                    //     Sent message: "📅 8/22/2022 9:07:17 AM 🕛"
                }
            }
            finally
            {
                listener.Stop();
            }
        }
    }
}
