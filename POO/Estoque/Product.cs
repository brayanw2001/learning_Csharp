using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estoque
{
    public class Product
    {
        string name;
        double price;
        int quantity;

        public Product(string name, double price, int quantity)
        {
            this.name = name; this.price = price; this.quantity = quantity;
        }

        public static Product product;
        //private static List<Product> product = new List<Product>();

        public static void CreateItem ()
        {
            Console.Clear();
            System.Console.WriteLine("===== Adicionar Item =====");

            System.Console.Write("Nome: ");
            string name = Console.ReadLine();

            System.Console.Write("Preço: ");
            double price = double.Parse(Console.ReadLine());

            System.Console.Write("Quantidade: ");
            int quantity = int.Parse(Console.ReadLine());

            product = new Product (name, price, quantity);

            System.Console.WriteLine("\nProduto criado com sucesso!");

            Thread.Sleep(800);
            Program.Menu();
        }    

        public static void ItemView () 
        {
            if (product == null || product.quantity == 0) 
            {
                Console.Clear();
                System.Console.WriteLine("Estoque vazio.");
                Thread.Sleep(1000);
                Program.Menu();
            }
            else
            {
                Console.Clear();
                System.Console.WriteLine("Nome: " +product.name);        
                System.Console.WriteLine("Preço: " +product.price);        
                System.Console.WriteLine("Quantidade: " +product.quantity);

                Console.Write("\nPressione qualquer tecla para voltar ao menu.");
                Console.ReadKey();
                Program.Menu();     
            }   
        }

        public static void addQuantity()
        {
            Console.Clear();            

            System.Console.WriteLine("Quantos itens deseja adicionar?");
            int addQuantity = int.Parse(Console.ReadLine());

            if (addQuantity < 0 ) 
            {
                Console.Clear();
                System.Console.WriteLine("Valor inválido. Tente novamente. \n\nAperta qualquer tecla para continuar.");
                Console.ReadKey();
                Product.addQuantity();
            }

            int oldQuantity = product.quantity;
            
            product.quantity += addQuantity;

            if (product.quantity > oldQuantity)
            {
                System.Console.WriteLine("\nAdicionado com sucesso!");
                Thread.Sleep(1000);
            }

            Program.Menu();
        }

        public static void RemoveQuantity()
        {
            Console.Clear();            

            System.Console.WriteLine("Quantos itens deseja remover?");
            int removeQuantity = int.Parse(Console.ReadLine());

            if (removeQuantity < 0 ) 
            {
                Console.Clear();
                System.Console.WriteLine("Valor inválido. Tente novamente. \n\nAperta qualquer tecla para continuar.");
                Console.ReadKey();
                Product.RemoveQuantity();
            }            

            int oldQuantity = product.quantity;

            product.quantity -= removeQuantity;
            
            if (product.quantity < oldQuantity)
            {
                System.Console.WriteLine("Removido com sucesso!");
                Thread.Sleep(1000);
            }

            Program.Menu();
        }
    }
}
