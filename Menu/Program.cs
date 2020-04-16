using System;
using System.Linq;
using System.Threading.Tasks;

namespace Menu
{

    class Program
    {
        static void Main(string[] args)
        {
            int quantServer = 0;

            if (args.Contains("/s"))
            {
                Servidor.Servidor.Iniciar(true);
            }
            else if (args.Contains("/c"))
            {
                Cliente.Cliente.Client();
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
                            ExerciciosThreads.Exercicios.E1();
                            Console.WriteLine("Aperte qualquer tecla para voltar ao menu principal");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "2":
                            Console.Clear();
                            ExerciciosThreads.Exercicios.E2();
                            Console.WriteLine("Aperte qualquer tecla para voltar ao menu principal");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "3":
                            Console.Clear();
                            ExerciciosThreads.Exercicios.E3();
                            Console.WriteLine("Aperte qualquer tecla para voltar ao menu principal");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "4":
                            Console.Clear();
                            ExerciciosThreads.Exercicios.E4();
                            Console.WriteLine("Aperte qualquer tecla para voltar ao menu principal");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "5":
                            Console.Clear();
                            Console.WriteLine("Iniciando Chat do cliente....");
                            Cliente.Cliente.Iniciar();
                            Task.Delay(6000);
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
                                Servidor.Servidor.Iniciar(true);
                                quantServer++;
                            }
                            Task.Delay(3000);
                            Console.Clear();
                            break;
                        case "7":
                            Console.Clear();
                            Console.Write("Saindo em");
                            Task.Delay(300);
                            Console.Write(" 3 ");
                            Task.Delay(300);
                            Console.Write(" 2 ");
                            Task.Delay(300);
                            Console.Write(" 1... ");
                            Task.Delay(2400);
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
