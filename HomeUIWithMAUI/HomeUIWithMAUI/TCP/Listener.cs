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
        async internal void StartListening()
        {
            Trace.WriteLine("Starting...");
            var ipEndPoint = new IPEndPoint(IPAddress.Any, 8100);
            TcpListener listener = new(ipEndPoint);

            Trace.WriteLine("Starting Listener ...");
            listener.Start();
            while (true)
            {
                try
                {
                    Trace.WriteLine("Accepting Clients...");
                    using TcpClient handler = await listener.AcceptTcpClientAsync();
                    await using NetworkStream stream = handler.GetStream();
                    while (true)
                    {
                        var message = $"{DateTime.Now}";
                        var dateTimeBytes = Encoding.UTF8.GetBytes(message);
                        await stream.WriteAsync(dateTimeBytes);

                        Trace.WriteLine($"Sent message: \"{message}\"");
                        // Sample output:
                        //     Sent message: "📅 8/22/2022 9:07:17 AM 🕛"
                        await Task.Delay(1000);
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine($"Error: {ex.Message}");
                }
                finally
                {
                    //listener.Stop();
                }
            }
        }
    }
}
