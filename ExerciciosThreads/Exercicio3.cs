using System;
using System.Threading;

namespace ExerciciosThreads
{
    public class Exercicio3
    {
        public static int num;
        public static string resultado;
        public static void Exercicio3cod()
        {
            Console.WriteLine("Exercicio: 3 \n\n");
            Console.Write("digite o numero final do intervalo: ");
            num = Convert.ToInt32(Console.ReadLine());
            do
            {
                var th1 = new Thread(ValidaNumeroPrimo);
                th1.Start();
                Thread.Sleep(100);
                num--;
            } while (num >= 2);
            var th2 = new Thread(ApresentaResultado);
            th2.Start();
        }

        private static void ValidaNumeroPrimo()
        {
            var numAtual = num;
            bool primo = true;
            for (int i = 2; i <= (int)Math.Sqrt(numAtual); i++)
            {
                if (numAtual % i == 0)
                {
                    primo = false;
                    break;
                }
            }
            if (primo)
            {
                resultado += "," + numAtual;
            }
        }
        private static void ApresentaResultado()
        {
            var numeros = resultado.Split(",");

            foreach (var item in numeros)
            {
                if (string.IsNullOrEmpty(item)){ continue; }
                Console.WriteLine($"O numero {item} é primo");
            }

        }
    }
}
