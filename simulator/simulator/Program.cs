using System.Net.Sockets;
using System.Net;
using System.Text;

namespace simulator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Client newClient = new Client();
            newClient.StartClient();

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