using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Menu.Cliente
{
    public class Cliente
    {
        public static void Iniciar()
        {
            var processo = new Process();
            processo.StartInfo.UseShellExecute = true;
            processo.StartInfo.FileName = ".\\Menu.exe";
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
                    Console.WriteLine("");
                    Console.Write("Digite seu nome:");
                    var nome = Console.ReadLine();
                    Console.Clear();

                    var THRecebeMensagem = new Thread(RecebeMensagems)
                    {
                        IsBackground = true,
                        Name = "THRecebeMensagem"
                    };
                    THRecebeMensagem.Start(sender);


                    Console.WriteLine("##################CHAT###################");
                    while (true)
                    {
                        // Definir mensagem para enviar ao servidor
                        Console.Write("YOU: ");
                        var mensagem = Console.ReadLine();

                        byte[] messageSent = Encoding.ASCII.GetBytes(nome + " #NOME# " + mensagem + "*");
                        int byteSent = sender.Send(messageSent);

                        if (mensagem == "exit")
                        {
                            break;
                        }

                    }
                    // Fechar a conexão com o servidor
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();

                    Console.ReadKey();
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



        public static void RecebeMensagems(object obj)
        {
            Socket sender = (Socket)obj;
            while (true)
            {
                // Data 
                byte[] messageReceived = new byte[1024];
                // Método receive retorna os dados enviados pelo servidor
                int byteRecv = sender.Receive(messageReceived);
                Console.WriteLine(Encoding.ASCII.GetString(messageReceived, 0, byteRecv));
            }
        }


    }
}
