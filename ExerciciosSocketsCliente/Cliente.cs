using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ExerciciosSocketsCliente
{
    public class Cliente
    {
        public static void Iniciar()
        {
            var processo = new Process();
            processo.StartInfo.UseShellExecute = true;
            processo.StartInfo.FileName = ".\\ExerciciosThreads.exe";
            processo.StartInfo.CreateNoWindow = true;
            processo.StartInfo.Arguments = "/c";
            processo.Start();
        }



        public static void Client()
        {
            try
            {
                //Carregar dados para conectar ao servidor local: IP local e definição de porta a ser usada
                IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddr = ipHost.AddressList[0];
                IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 11111);

                //Configuração inicial do Socket
                Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                try
                {

                    //Inicia a conexão com o servidor  
                    sender.Connect(localEndPoint);

                    //Exibe a mensagem caso consiga realizar a conexão
                    Console.WriteLine("Conectado ao servidor!");

                    while (true)
                    {
                        var mensagem = Console.ReadLine();
                        if (mensagem == "Sair")
                        {
                            break;
                        }
                        // Definir mensagem para enviar ao servidor
                        byte[] messageSent = Encoding.ASCII.GetBytes(mensagem);
                        int byteSent = sender.Send(messageSent);

                        // Data 
                        byte[] messageReceived = new byte[1024];

                        // Método receive retorna os dados enviados pelo servidor
                        int byteRecv = sender.Receive(messageReceived);
                        Console.WriteLine("Mensagem enviada pelo servidor: {0}", Encoding.ASCII.GetString(messageReceived, 0, byteRecv));
                    }
                    // Fechar a conexão com o servidor
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erro: {0}", e.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: {0}", e.ToString());
            }

        }

    }
}
