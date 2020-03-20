using System;
using System.Threading;

namespace ExerciciosThreads
{
    public class Exercicio1
    {
        public static void Exercicio1Cod()
        {
            var th1 = new Thread(Crescente);
            var th2 = new Thread(Decrescente);
            Console.WriteLine("Hello World!");
            th1.Start();
            th2.Start();
        }

        private static void Crescente()
        {
            for (int i = 0; i < 500; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine("Ordem Crescente: " + i);
            }
        }
        private static void Decrescente()
        {
            for (int i = 500; i > 1 ; i--)
            {
                Thread.Sleep(100);
                Console.WriteLine("Ordem Decrescente: " + i);
            }
        }
    }
}
