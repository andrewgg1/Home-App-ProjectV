using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Connetion
{
    internal class Connection
    {
    }

    public class HighCapacityTcpServer
    {
        private const int Port = 5000;

        public async Task StartServerAsync()
        {
            TcpListener listener = new TcpListener(IPAddress.Any, Port);
            listener.Start();
            Console.WriteLine("Server started, waiting for connections...");

            while (true)
            {
                // Accept new client connections
                TcpClient client = await listener.AcceptTcpClientAsync();
                Console.WriteLine("Client connected.");

                // Handle each client in a separate task for scalability
                _ = Task.Run(() => HandleClientAsync(client));
            }
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];

            try
            {
                while (true)
                {
                    // Asynchronously read data from the client
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break; // Client disconnected

                    string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine("Received from client: " + receivedMessage);

                    // Respond back to the client
                    string responseMessage = "Server response: " + receivedMessage.ToUpper();
                    byte[] responseData = Encoding.UTF8.GetBytes(responseMessage);
                    await stream.WriteAsync(responseData, 0, responseData.Length);
                    Console.WriteLine("Sent to client: " + responseMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Client error: " + ex.Message);
            }
            finally
            {
                client.Close();
                Console.WriteLine("Client disconnected.");
            }
        }
    }
}


