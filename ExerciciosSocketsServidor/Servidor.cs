using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ExerciciosSocketsServidor
{
    public class Servidor
    {

        public static void IniciarServer()
        {
            var processo = new Process();
            processo.StartInfo.UseShellExecute = false;
            processo.StartInfo.FileName = ".\\ExerciciosThreads.exe";
            processo.StartInfo.CreateNoWindow = true;
            processo.Start();
        }


        public static void Server()
        {
            //Carregar dados para liberar acesso a clientes: IP local e definição de porta a ser usada
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 11111);

            //Configuração inicial do Socket
            Socket listener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                //Libera acesso aos clientes
                listener.Bind(localEndPoint);

                // Define a quantidade de conexões ao servidor 
                listener.Listen(1000);

                while (true)
                {

                    Console.WriteLine("Aguardando conexões dos clientes ... ");

                    //Aceita a conexão com o cliente 
                    Socket clientSocket = listener.Accept();

                    //Serializar os dados recebidos do servidor
                    byte[] bytes = new Byte[1024];
                    string data = null;

                    while (true)
                    {
                        //quantidade de bytes recebidos
                        int numByte = clientSocket.Receive(bytes);
                        //Transformar os bytes em string
                        data += Encoding.ASCII.GetString(bytes, 0, numByte);
                        //Para de receber os dados do cliente assim que ler o caracter *
                        if (data.IndexOf("*") > -1)
                            break;
                    }

                    Console.WriteLine("Texto recebido: {0} ", data);
                    byte[] message = Encoding.ASCII.GetBytes("Mensagem recebida com sucesso pelo servidor!");
                    //Envia resposta ao cliente
                    clientSocket.Send(message);

                    // Fecha a conexão com o cliente 
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

    }
}
