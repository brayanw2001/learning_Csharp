using System;

namespace Estoque
{
    class Program
    {
        static void Main (string[] args)
        {
            Console.Clear();
            Menu ();
        }

        public static void Menu ()
        {
            Console.Clear();
            System.Console.WriteLine("====== Estoque ======");
            System.Console.WriteLine("1. Visualizar estoque \n2. Adicionar Item \n3. Remover item\n");
            Console.Write("Insira a opção: ");
            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Product.ItemView();
                    break;
                case 2: 
                    Product.AddItem();
                    break;
                //case 3:
                //    RemoveItem();
                //    break;
                //default:
                //    Menu();
            }
        }
        
    }
}