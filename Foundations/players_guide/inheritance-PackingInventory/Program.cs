using inheritance___Packing_Inventory.Itens;

namespace inheritance___Packing_Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Create a pack");

            Console.WriteLine("Max itens: ");
            int maxItens = int.Parse(Console.ReadLine());

            Console.WriteLine("Max volume: ");
            float maxVolume = float.Parse(Console.ReadLine());

            Console.WriteLine("Max weight: ");
            float maxWeight = float.Parse(Console.ReadLine());

            Pack pack = new (maxItens, maxVolume, maxWeight);

            while (true)
            {
                Console.WriteLine("======== Add to inventory ========");
                Console.WriteLine("[1] Arrow. | [2] Bow. | [3] Rope. | [4] Water. | [5] Food. | [6] Sword");

                switch (Console.ReadLine())
                {
                    case "1":
                        Arrow arrow = new Arrow();
                        pack.Add(arrow);
                        break;

                    case "2":
                        Bow bow = new Bow();
                        pack.Add(bow);
                        break;

                    case "3":
                        Rope rope = new Rope();
                        pack.Add(rope);
                        break;

                    case "4":
                        Water water = new Water();
                        pack.Add(water);
                        break;

                    case "5":
                        Food food = new Food();
                        pack.Add(food);
                        break;

                    case "6":
                        Sword sword = new Sword();
                        pack.Add(sword);
                        break;

                    default:
                        Console.WriteLine("Invalid. Try again.");
                        break;
                }
                Console.WriteLine(pack.ToString());
                Console.WriteLine($"itens: {pack.CurrentCount} | weight: {Math.Round(pack.CurrentWeight)} | volume: {Math.Round(pack.CurrentVolume)}");
            }
        }
    }
}
