using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace loops
{
    internal class Program
    {
        static void Main()
        {
            
            float[] notes = new float[4];
            float res = 0;
            int i;
            Console.WriteLine("=== Sistema de Notas ===");

            for (i = 0; i < notes.Length; i++)
            {
               Console.Write($"Insira a nota {i+1}: ");
               notes[i] = float.Parse(Console.ReadLine());
               res += notes[i];
            }

            Console.WriteLine("\nAs notas inseridas foram: ");

            foreach (float n in notes)
            {
                Console.WriteLine(n);
            }

            res = res / i;
            Console.WriteLine($"\nA média final foi: {res}");

            if (res < 6)
            {
                Console.WriteLine("Reprovado.");
            } 
            else
            {
                Console.WriteLine("Aprovado");
            }
            Console.ReadLine();
        }
    }
}
