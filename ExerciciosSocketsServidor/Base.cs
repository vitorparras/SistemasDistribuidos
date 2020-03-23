using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ExerciciosSocketsServidor
{
    public class BaseServidor
    {
        public static void BaseServer()
        {

            var th1 = new Thread(ServerBack)
            {
                Name = "SERVIDOR CHAT",
                IsBackground = true
            };

            th1.Start();
        }


        private static void ServerBack()
        {
            Console.OutputEncoding = Encoding.UTF8;

            int recv;

            byte[] data = new byte[1024];

            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);

            Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            newsock.Bind(ipep);

            newsock.Listen(10);

            Console.WriteLine("Waiting for a client...");

            Socket client = newsock.Accept();

            IPEndPoint clientep = (IPEndPoint)client.RemoteEndPoint;

            Console.WriteLine("Connected with {0} at port {1}", clientep.Address, clientep.Port);

            string welcome = "Welcome to my test server";

            data = Encoding.UTF8.GetBytes(welcome);

            client.Send(data, data.Length, SocketFlags.None);



            while (true)
            {

                data = new byte[1024];
                recv = client.Receive(data);

                if (recv == 0)
                    break;



                var dadosRecebidos = Encoding.UTF8.GetString(data, 0, recv);

                var spritDados = dadosRecebidos.Split("#MENSAGEM#");

                Console.WriteLine(spritDados[0] + ": " + spritDados[1]);

                Console.Write("You: ");
                var input = Console.ReadLine();
                Console.SetCursorPosition(0, Console.CursorTop);

                client.Send(Encoding.UTF8.GetBytes(input));

            }

            Console.WriteLine("Disconnected from {0}", clientep.Address);

            client.Close();

            newsock.Close();

            Console.ReadLine();
        }




    }
}
