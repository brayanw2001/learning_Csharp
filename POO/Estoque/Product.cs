using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estoque
{
    public class Product
    {
        string nome;
        double preco;
        int quantidade;

        public Product(string nome, double preco, int quantidade)
        {
            this.nome = nome; this.preco = preco; this.quantidade = quantidade;
        }

        public static Product product;

        public static void AddItem ()
        {
            Console.Clear();
            System.Console.WriteLine("===== Adicionar Item =====");

            System.Console.Write("Nome: ");
            string nome = Console.ReadLine();

            System.Console.Write("Preço: ");
            double preco = double.Parse(Console.ReadLine());

            System.Console.Write("Quantidade: ");
            int quantidade = int.Parse(Console.ReadLine());

            product = new Product (nome, preco, quantidade);

            Thread.Sleep(500);
            Program.Menu();
        }    

        public static void ItemView () 
        {
            Console.Clear();
            System.Console.WriteLine("Nome: " +product.nome);        
            System.Console.WriteLine("Preço: " +product.nome);        
            System.Console.WriteLine("Quantidade: " +product.nome);

            Console.Write("\n\nPressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
            Program.Menu();        
        }
    }
}
