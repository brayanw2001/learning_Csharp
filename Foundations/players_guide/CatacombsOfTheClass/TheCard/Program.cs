namespace TheCard
{
    internal class Program
    {
        static void Main(string[] args)
        {

            foreach (Colors Color in Enum.GetValues(typeof(Colors)))
            {
                foreach (Ranks Rank in Enum.GetValues(typeof(Ranks)))
                {
                    Card cards = new Card(Color, Rank);
                    Console.WriteLine($"The {cards.cardColor} {cards.cardRank}");
                }
            }

        }
    }
}
