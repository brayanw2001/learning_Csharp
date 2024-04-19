using System;

namespace Calculadora
{
    class Program
    {
        static void Main ()
        {
            int opc = 90;
            float res = 0.0f;

            do 
            {
                Console.WriteLine("=== Menu ===");
                Console.Write("1. Soma \n2. Subtração \n3. Multiplicação \n4. Divisão \n0. Sair \n\nInsira a opção: ");
                opc = int.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        Console.WriteLine("\n=== Soma ===");
                        res = Soma (res);
                        Console.WriteLine("\nres: {0}", res);
                        break;

                    case 2:
                        Console.WriteLine("\n=== Subtração ===");
                        res = Sub (res);
                        Console.WriteLine("\nres: {0}", res);                    
                        break;

                    case 3:
                        Console.WriteLine("\n=== Multiplicação ===");
                        res = Mul (res);
                        Console.WriteLine("\nres: {0}", res);   
                        break;

                    case 4:
                        Console.WriteLine("\n=== Divisão ===");
                        res = Div (res);
                        Console.WriteLine("\nres: {0}", res);   
                        break;
                }      
            }
            while (opc != 0);
        }

        static float Soma (float res)
        {
            float num;

            Console.Write("Insira o número: ");
            num = int.Parse(Console.ReadLine());

            return res += num;
        }
        static float Sub (float res)
        {
            float num;

            Console.Write("Insira o número: ");
            num = int.Parse(Console.ReadLine());

            return res -= num;
        }

        static float Mul (float res)
        {
            float num;

            Console.Write("Insira o número: ");
            num = int.Parse(Console.ReadLine());

            return res *= num;
        }

        static float Div (float res)
        {
            float num;

            Console.Write("Insira o número: ");
            num = int.Parse(Console.ReadLine());

            return res /= num;
        }
    }
}