using System;
using System.Threading;

namespace Menu.ExerciciosThreads
{
    public class Exercicios
    {
        public static int cont = 0;
        public static int num4 = 0;
        public static int num;
        public static string resultado;
        public static string[] vetor = null;

        public static void E1()
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
            for (int i = 500; i > 1; i--)
            {
                Thread.Sleep(100);
                Console.WriteLine("Ordem Decrescente: " + i);
            }
        }
    


        public static void E2()
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
   
  
        public static void E3()
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
                if (string.IsNullOrEmpty(item)) { continue; }
                Console.WriteLine($"O numero {item} é primo");
            }

        }



        public static void E4()
        {
            Console.WriteLine("Exercicio: 4 \n\n");
            Console.Write("Digite a quantidade de vezes que deseja escrever ABC: ");
            num4 = Convert.ToInt32(Console.ReadLine());

            Thread[] th = new Thread[num4];

            while (cont < num4)
            {
                th[cont] = new Thread(EscreverA);
                th[cont].Start();
                Thread.Sleep(100);

                th[cont] = new Thread(EscreverB);
                th[cont].Start();
                Thread.Sleep(150);

                th[cont] = new Thread(EscreverC);
                th[cont].Start();
                Thread.Sleep(190);

                cont++;
            }
        }
        private static void EscreverA()
        {

            Console.Write("A");
        }
        private static void EscreverB()
        {
            Console.Write("B");
        }
        private static void EscreverC()
        {
            Console.Write("C\n");
        }

    }
}
