using System;
using System.Threading;

namespace ExerciciosThreads
{
    public class Exercicio3
    {
        public static int num, resultado, i = 0;
        public static void Exercicio3cod()
        {
            Console.WriteLine("Exercicio: 3 \n\n");
            Console.Write("digite o numero final do intervalo: ");
            num = Convert.ToInt32(Console.ReadLine());

            var th2 = new Thread(valida1);
            th2.Start();
            Thread.Sleep(300);
        }

        private static void valida1()
        {
            for (i = 2; i <= num / 2; i++)
            {
                var th1 = new Thread(valida2);
                th1.Start();
            }
        }
        private static void valida2()
        {
            if (num % i == 0)
            {
                resultado++;
            }
            else
            {
                Console.WriteLine("o numero "+ num + "é primo");
            }
        }
    }
}
