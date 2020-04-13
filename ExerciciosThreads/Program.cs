using System;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ExerciciosThreads
{
    using ExerciciosSocketsCliente;
    using ExerciciosSocketsServidor;
    using System.Linq;

    class Program
    {
        public static int quantServer = 0;
        static async Task Main(string[] args)
        {
            if (args.Contains("/s"))
            {
                BaseServidor.BaseServer();
            }
            else if (args.Contains("/c"))
            {
                BaseCliente.BaseClientAsync();
            }
            else
            {
                var validacao = true;
                while (validacao)
                {
                    Menu();
                    var op = Console.ReadLine();
                    switch (op)
                    {
                        case "1":
                            Console.Clear();
                            Exercicio1.Exercicio1Cod();
                            Console.WriteLine("Aperte qualquer tecla para voltar ao menu principal");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "2":
                            Console.Clear();
                            Exercicio2.Exercicio2cod();
                            Console.WriteLine("Aperte qualquer tecla para voltar ao menu principal");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "3":
                            Console.Clear();
                            Exercicio3.Exercicio3cod();
                            Console.WriteLine("Aperte qualquer tecla para voltar ao menu principal");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "4":
                            Console.Clear();
                            Exercicio4.Exercicio4cod();
                            Console.WriteLine("Aperte qualquer tecla para voltar ao menu principal");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "5":
                            Console.Clear();
                            Console.WriteLine("Iniciando Chat do cliente....");
                            BaseCliente.IniciarCliente();
                            await Task.Delay(6000);
                            Console.Clear();
                            break;
                        case "6":
                            Console.Clear();
                            if (quantServer > 0)
                            {
                                Console.WriteLine("Servidor ja iniciado voltando ao menu inicial.... ");
                            }
                            else
                            {
                                Console.WriteLine("Estamos iniciando o servidor em segundo plano....");
                                BaseServidor.IniciarServer();
                                quantServer++;
                            }
                            await Task.Delay(3000);
                            Console.Clear();
                            break;
                        case "7":
                            Console.Clear();
                            Console.Write("Saindo em");
                            await Task.Delay(300);
                            Console.Write(" 3 ");
                            await Task.Delay(300);
                            Console.Write(" 2 ");
                            await Task.Delay(300);
                            Console.Write(" 1... ");
                            await Task.Delay(2400);
                            validacao = false;
                            break;

                        default:
                            Console.Clear();
                            continue;
                    }
                    Console.Clear();
                }
            }
            Environment.Exit(0);
        }


        private static void Menu()
        {
            Console.WriteLine("Digite o numero equivalente ao Exercicio que deseja executar");
            Console.WriteLine("1 - Exercicio Thread 1");
            Console.WriteLine("2 - Exercicio Thread 2");
            Console.WriteLine("3 - Exercicio Thread 3");
            Console.WriteLine("4 - Exercicio Thread 4");
            Console.WriteLine("5 - Exercicio CHAT - Iniciar Cliente");
            Console.WriteLine("6 - Exercicio CHAT - Iniciar Servidor");
            Console.WriteLine("7 - Sair");
        }
    }
}
