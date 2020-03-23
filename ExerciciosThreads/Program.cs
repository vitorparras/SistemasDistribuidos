using ExerciciosSocketsCliente;
using ExerciciosSocketsServidor;
using System;
using System.Threading.Tasks;

namespace ExerciciosThreads
{
    class Program
    {
        static async Task Main(string[] args)
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
                        BaseCliente.BaseClient();
                        Console.WriteLine("Aperte qualquer tecla para voltar ao menu principal");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "6":
                        Console.Clear();
                        Console.WriteLine("Estamos iniciando o servidor em segundo plano....");
                        BaseServidor.BaseServer();
                        Console.WriteLine("");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "7":
                        Console.Clear();
                        Console.WriteLine("Voce escolheu sair Obrigado Por Usar o Programa");
                        await Task.Delay(1000);
                        validacao = false;
                        break;

                    default:
                        Console.Clear();
                        continue;
                }
                Console.Clear();
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
            Console.WriteLine("5 - Exercicio Servidor - Iniciar cliente");
            Console.WriteLine("6 - Exercicio Servidor - Iniciar Servidor");
            Console.WriteLine("7 - Sair");
        }
    }
}
