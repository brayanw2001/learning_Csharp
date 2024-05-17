using System;
using System.Globalization;
using System.Threading;

namespace NotasEMoedas
{
    class Program
    {
        static void Main (string[] args)
        {
            Console.Clear();
            InsereValor();
        }
    
        static void InsereValor()
        {

            Console.Write("Insira um valor com duas casas decimais (use vírgula): ");
            float valor = float.Parse(Console.ReadLine());
        
            if (VerificaValor(valor))
            {
                MenorTroco(valor);
            }
            else 
            {
                Console.WriteLine("Valor inválido.");
                Thread.Sleep(1000);
                Console.Clear();
                InsereValor();
            }
        }

        static bool VerificaValor(float valor)
        {
            valor *= 100;

            if (valor % 1 == 0) return true;
        
            else return false;             
        }

        static void MenorTroco(float valor)
        {
            float [] notas = {100f, 50f, 20f, 10f, 5f, 2f, 1f, 0.5f, 0.25f, 0.10f, 0.05f, 0.01f};
            int troco = 0;

            for (int i = 0; i < notas.Length; i++)
            {
                //troco = (int)(valor/notas[i]);

                if (valor/notas[i] >= 1)
                {
                   // Console.WriteLine($"=== {valor} ===");
            
                    int div = (int)(valor/notas[i]);

                    //Console.WriteLine($"{div} nota(s) de {notas[i]}");
                    Console.WriteLine($"{div} nota(s) de " + notas[i].ToString("C", CultureInfo.CreateSpecificCulture("pt-BR")));
                    
                    valor = valor - (div*notas[i]);
                }
            }
        }
    }
}