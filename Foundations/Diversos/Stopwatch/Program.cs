using System;
using System.Threading;

namespace Stopwatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu ()
        {
            Console.Clear();
            Console.WriteLine("S = Segundos => 10s = 10 segundos");
            Console.WriteLine("M = Minutos => 1m = 1 minuto");
            Console.WriteLine("0 = Sair");
            Console.Write("Qunato tempo deseja contar?: ");

            string data = Console.ReadLine().ToLower(); //ToLower converte os caracteres inseridos para minúsculo
            char type = char.Parse(data.Substring(data.Length - 1, 1)); //pega o ultimo caracter
            int time = int.Parse(data.Substring(0, data.Length - 1));

            int mul = 60;

            PreStart();

            if (type == 'm') 
                Start(time * mul); 
            else
                Start(time);
            
            if(time == 0)
                System.Environment.Exit(0);
        }

        static void PreStart()
        {
            Console.Clear();
            Console.WriteLine ("Preparar...");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine ("Apontar...");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Valendo!");
            Thread.Sleep(1000);
            Console.Clear();
        }
        static void Start (int time)
        {
            int currentTime = 0; 

            while (currentTime != time) 
            {
                Console.Clear();
                currentTime++;
                Console.WriteLine (currentTime);
                Thread.Sleep(1000);
            }

            Console.Clear();
            Console.WriteLine("Cronômetro finalizado. Voltando ao menu.");
            Thread.Sleep(1000);
            Menu();
        }
    }
}