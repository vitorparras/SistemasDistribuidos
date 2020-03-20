using System;
using System.Threading;

namespace ExerciciosThreads
{
    public class Exercicio4
    {
        public static int cont = 0;
        public static int num = 0;

        public static void Exercicio4cod()
        {
            Console.WriteLine("Exercicio: 4 \n\n");
            Console.Write("Digite a quantidade de vezes que deseja escrever ABC: ");
            num = Convert.ToInt32(Console.ReadLine());

            Thread[] th = new Thread[num];

            while (cont < num)
            {
                th[cont] = new Thread(escreverA);
                th[cont].Start();
                Thread.Sleep(100);

                th[cont] = new Thread(escreverB);
                th[cont].Start();
                Thread.Sleep(150);

                th[cont] = new Thread(escreverC);
                th[cont].Start();
                Thread.Sleep(190);

                cont++;
            }
        }

        private static void escreverA()
        {

            Console.Write("A");
        }
        private static void escreverB()
        {
            Console.Write("B");
        }
        private static void escreverC()
        {
            Console.Write("C\n");
        }



    }
}
