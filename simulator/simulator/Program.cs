using System.Net.Sockets;
using System.Net;
using System.Text;
using simulator.TCP;

namespace simulator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string ipHost = "";
            while (true)
            {
                Console.WriteLine("Enter the IP of the Host:");
                ipHost = Console.ReadLine();

                // Validate the IP address
                if (IPAddress.TryParse(ipHost, out _))
                {
                    break;
                }
            }
            Client newClient = new Client();
            newClient.StartClient(ipHost);

            Console.WriteLine("Press space bar to exit");

            while (true)
            {
                // on space bar exit
                if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                {
                    break;
                }
            }
        }
    }
}