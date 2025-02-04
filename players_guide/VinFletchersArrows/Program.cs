using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinFletchersArrows
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("[1]- Steel \n[2] - Wood \n[3] - Obsidian");
            System.Console.WriteLine("Choose a arrow head: ");
            int choosedArrow =  int.Parse(Console.ReadLine());

            Console.Clear();

            Console.WriteLine($"[1]- Plastic \n[2] - Turkey Feathers \n[3] - Goose Feathers");
            System.Console.WriteLine("Choose the fletching head: ");    
            int choosedFLetching = int.Parse(Console.ReadLine());

            Console.Clear();

            Console.WriteLine("Whats the lenght of the shaft? (between 60cm and 100cm long): ");
            int choosedLenght = int.Parse(Console.ReadLine());

            Arrow newArrow = new Arrow(choosedArrow, choosedFLetching, choosedLenght);
            Console.Clear();

           // System.Console.WriteLine(newArrow.arrowHead);
           // System.Console.WriteLine(newArrow.fletching);
           // System.Console.WriteLine(newArrow.lenght);

           newArrow.GetCost();
        }

    }
}