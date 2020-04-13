using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ExerciciosSocketsCliente
{
    public class BaseCliente
    {
        public static void IniciarCliente()
        {
            var processo = new Process();
            processo.StartInfo.UseShellExecute = true;
            processo.StartInfo.FileName = ".\\ExerciciosThreads.exe";
            processo.StartInfo.CreateNoWindow = true;
            processo.StartInfo.Arguments = "/c";
            processo.Start();
        }

        public static async Task BaseClientAsync()
        {
            Console.OutputEncoding = Encoding.UTF8;
            byte[] data = new byte[1024];
            string input, stringData;
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                server.Connect(ipep);
            }
            catch (SocketException e)
            {
                Console.WriteLine("Desconectado do servidor!");
                Console.WriteLine(e.ToString());
                await Task.Delay(2400);
                Environment.Exit(0);
            }

            int recv = server.Receive(data);
            stringData = Encoding.UTF8.GetString(data, 0, recv);
            Console.WriteLine(stringData);
            Console.WriteLine("digite seu nome:");
            var nome = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Bem Vindo " + nome);

            while (true)
            {
                Console.Write("You : ");
                input =  Console.ReadLine();

                if (input == "exit")
                    break;

                input = nome + " #MENSAGEM# " + input;


                // Console.WriteLine(nome + ": " + input);
                server.Send(Encoding.UTF8.GetBytes(input));
                data = new byte[1024];
                recv = server.Receive(data);
                stringData = Encoding.UTF8.GetString(data, 0, recv);
                byte[] utf8string = System.Text.Encoding.UTF8.GetBytes(stringData);
                Console.WriteLine("Server: " + stringData);
            }
            Console.WriteLine("Desconectando do servidor...");
            server.Shutdown(SocketShutdown.Both);
            server.Close();
            Console.WriteLine("Disconnected!");
            Console.ReadLine();
        }
    }
}
