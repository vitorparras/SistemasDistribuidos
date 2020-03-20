using System;
using System.Threading;

namespace ExerciciosThreads
{
    public class Exercicio4
    {
        public static Thread th1 = new Thread(escreverA);
        public static Thread th2 = new Thread(escreverB);
        public static Thread th3 = new Thread(escreverC);
        public static int cont = 0;
        public static int num = 0;

        public static void Exercicio4cod()
        {
            Console.WriteLine("Exercicio: 4 \n\n");
            Console.Write("Digite a quantidade de vezes que deseja escrever ABC: ");
            num = Convert.ToInt32(Console.ReadLine());
            th1.Start();
        }

        private static void escreverA()
        {
            Console.Write("A");
            cont++;
            if (cont == num)
            {

            }

        }
        private static void escreverB()
        {
            Console.Write("B");
            cont++;
            if (cont == num)
            {

            }

        }
        private static void escreverC()
        {
            Console.Write("C\n");
            cont++;
            if (cont == num)
            {

            }
        }



    }
}
