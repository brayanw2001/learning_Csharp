namespace VinFletchersArrows
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Arrow arrow = new(AsksForArrow(), AsksForFletching(), AsksForLength());

            Console.WriteLine($"\nIt'll cost you ${arrow.GetCost()}");
        }

        static Arrowhead AsksForArrow()
        {
            string answer;

            while (true)
            {
                Console.WriteLine("What arrowhead would you like?");
                Console.WriteLine("[1] Steel  |  [2] Wood  |  [3] Obsidian");
                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1": return Arrowhead.steel;

                    case "2": return Arrowhead.wood;

                    case "3": return Arrowhead.obsidian;

                    default:
                        Console.WriteLine("Invalid option, sir. Please, try again.");
                        break;
                }
            }
        }
        static Fletching AsksForFletching()
        {
            string answer;

            while (true)
            {
                Console.WriteLine("\nWhat fletching would you like?");
                Console.WriteLine("[1] Plastic  |  [2] Turkey Feathers  |  [3] Goose Feathers");
                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1": return Fletching.plastic;

                    case "2": return Fletching.turkey_feathers;

                    case "3": return Fletching.goose_feathers;

                    default:
                        Console.WriteLine("Invalid option, sir. Please, try again.");
                        break;
                }
            }
        }
        static float AsksForLength ()
        {
            float length;

            do
            {
                Console.WriteLine("\nWhats the length?");
                length = float.Parse(Console.ReadLine());

            } while (length < 60 || length > 100);

            return length;
        }
    }
}
