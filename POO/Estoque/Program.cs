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
            System.Console.WriteLine("1. Visualizar estoque \n2. Adicionar um produto \n3. Adicionar quantidade de um produto \n4. Remover quantidade de um produto");
            Console.Write("Insira a opção: ");
            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Product.ItemView();
                    break;
                case 2: 
                    Product.CreateItem();
                    break;
                case 3:
                    Product.addQuantity();
                    break;
                case 4:
                    Product.RemoveQuantity();
                    break;
                default:
                    Menu();
                    break;
            }
        }
        
    }
}