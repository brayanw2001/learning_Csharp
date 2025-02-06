using System;

namespace Program
{
    class Program
    {
        static void Main ()
        {
            Product mouse = new Product(1, "Logitech", 120, EProductType.Product);

            Product manutencaoEletrica = new Product (2, "Manutenção Elétrica Residencial", 500, EProductType.Service);

            //Product teste;
            //teste.Id = 2;

            Console.WriteLine(mouse.Id);
            Console.WriteLine(mouse.Name);
            Console.WriteLine(mouse.Price);
            Console.WriteLine(mouse.Type);
            
            //Console.WriteLine(teste.Id);
        }
    }
    
    struct Product  
    {
        public Product(int id, string name, float price, EProductType type)
        {
            Id = id;
            Name = name;
            Price = price;
            Type = type;
        }
        public int Id;
        public string Name;
        public float Price;
        public EProductType Type;
        public float PriceInDolar (float dolar)
        {
            return Price * dolar;
        }
    }
}
    enum EProductType 
{
    Product = 1,
    Service = 2,
}