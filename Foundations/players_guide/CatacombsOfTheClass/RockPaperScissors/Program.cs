namespace RockPaperScissors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Game game = new Game();
                Console.WriteLine(game.ScoreBoard());
                Console.WriteLine("-----------------------------\n");
            }
            
        }
    }
}
