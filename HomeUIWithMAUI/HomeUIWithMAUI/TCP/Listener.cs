﻿using System.Diagnostics;
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
                    TcpClient handler = await listener.AcceptTcpClientAsync();
                    _ = HandleClientAsync(handler); // Start a new task to handle the client
                }
                catch (Exception ex)
                {
                    Trace.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private async Task HandleClientAsync(TcpClient handler)
        {
            try
            {
                var clientEndPoint = handler.Client.RemoteEndPoint as IPEndPoint;
                if (clientEndPoint != null)
                {
                    Trace.WriteLine($"Client connected: {clientEndPoint.Address}:{clientEndPoint.Port}");
                }

                await using NetworkStream stream = handler.GetStream();

                var buffer = new byte[1_024];
                int received = await stream.ReadAsync(buffer);
                var receivedMessage = Encoding.UTF8.GetString(buffer, 0, received);
                Trace.WriteLine($"Message received: \"{receivedMessage}\"");

                while (true)
                {
                    var message = $"{DateTime.Now}";
                    var dateTimeBytes = Encoding.UTF8.GetBytes(message);
                    await stream.WriteAsync(dateTimeBytes);

                    Trace.WriteLine($"Sent message: \"{message}\"");
                    await Task.Delay(1000);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                Trace.WriteLine($"Client disconnected");
                handler.Close();
            }
        }
    }
}