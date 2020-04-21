using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Menu.Servidor
{
    public class Servidor
    {
        public static List<Socket> ListaClientes = new List<Socket>();

        public static void Iniciar(bool visualizar)
        {
            var processo = new Process();
            processo.StartInfo.UseShellExecute = true;
            processo.StartInfo.FileName = ".\\Menu.exe";
            processo.StartInfo.CreateNoWindow = true;
            processo.StartInfo.Arguments = visualizar ? "/s" : "/n";
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
                // Define a quantidade de tentativas conexões ao servidor 
                listener.Listen(1000);
                while (true)
                {
                    try
                    {
                       // Console.WriteLine("Aguardando conexões dos clientes ... ");
                        //Aceita a conexão com o cliente 
                        Socket clientSocket = listener.Accept();

                        Console.WriteLine("clientes Conectado... ");

                        AddClienteLista(clientSocket);
                        var THAceitarConexao = new Thread(RecebeDados)
                        {
                            IsBackground = true,
                            Name = "ACEITA CONEXAO"
                        };
                        THAceitarConexao.Start(clientSocket);
                    }
                    catch { continue; }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        public static void EnviarMensagem(Socket clienteEnviado, String mensagem)
        {

            foreach (var cliente in ListaClientes)
            {
                var dataMensagem = mensagem.Split("#NOME#");

                byte[] message = Encoding.ASCII.GetBytes(dataMensagem[0] + ":" + dataMensagem[1].Substring(0, dataMensagem[1].Length - 1));
                if (cliente != clienteEnviado)
                {
                    //Envia resposta ao cliente
                    cliente.Send(message);
                }
            }
        }
        public static void AddClienteLista(Socket clientSocket)
        {
            ListaClientes.Add(clientSocket);
        }
        public static void RemoveClienteLista(Socket clientSocket)
        {
            ListaClientes.Remove(clientSocket);
            //Fecha a conexão com o cliente 
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
        }
        public static void RecebeDados(object obj)
        {
            Socket clientSocket = (Socket)obj;
            try
            {
                while (true)
                {
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
                    ///teste
                    ///
                    Console.WriteLine(data);

                    if (data.Contains("exit"))
                    {
                        EnviarMensagem(clientSocket, "SAIU");
                        RemoveClienteLista(clientSocket);
                        break;
                    }

                    EnviarMensagem(clientSocket, data);
                }
            }
            catch
            {
                EnviarMensagem(clientSocket, "SAIU");
            }
        }
    }
}
