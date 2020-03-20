using System;
using System.Threading;

namespace ExerciciosThreads
{
    public class Exercicio2
    {
        public static string[] vetor = null;

        public static void Exercicio2cod()
        {
            Console.WriteLine("Digite os valores separados por virgula: ");
            var text = Console.ReadLine();
            vetor = text.Split(",");

            var th1 = new Thread(Soma);
            var th2 = new Thread(Mult);
            th1.Start();
            th2.Start();
        }
        private static void Mult()
        {
            var mult = 1;
            foreach (var item in vetor)
            {
                if (string.IsNullOrEmpty(item)) { continue; }
                bool converteu = int.TryParse(item, out var convertido);
                if (!converteu) { continue; }
                mult *= convertido;
                Thread.Sleep(100);
                Console.WriteLine("executando multiplicação......");
            }
            Console.WriteLine("Resultado da multiplicação......: " + mult);

        }
        private static void Soma()
        {
            var soma = 0;
            foreach (var item in vetor)
            {
                if (string.IsNullOrEmpty(item)) { continue; }
                bool converteu = int.TryParse(item, out var convertido);
                if (!converteu) { continue; }
                soma += convertido;
                Thread.Sleep(100);
                Console.WriteLine("executando Soma......");
            }
            Console.WriteLine("Resultado da Soma......: " + soma);
        }
    }
}
