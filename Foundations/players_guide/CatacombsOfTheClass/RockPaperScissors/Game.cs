using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Game
    {
        RockPaperScissors rps;
        static int countPlayer1 = 0;
        static int countPlayer2 = 0;
        static int ties = 0;

        public Game()
        {
            Hands player1;
            Hands player2;

            Console.WriteLine("Player1:");
            Console.WriteLine("[1] Rock | [2] Paper | [3] Scissors:");
            int handPlayer1 = int.Parse(Console.ReadLine());

            Console.WriteLine("\nPlayer2:");
            Console.WriteLine("[1] Rock | [2] Paper | [3] Scissors:");
            int handPlayer2 = int.Parse(Console.ReadLine());

            switch (handPlayer1)
            {
                case 1:
                    player1 = Hands.rock;
                    break;
                case 2:
                    player1 = Hands.paper;
                    break;
                case 3:
                    player1 = Hands.scissors;
                    break;
                default:
                    player1 = Hands.missed;
                    break;
            }

            switch (handPlayer2)
            {
                case 1:
                    player2 = Hands.rock;
                    break;
                case 2:
                    player2 = Hands.paper;
                    break;
                case 3:
                    player2 = Hands.scissors;
                    break;
                default:
                    player2 = Hands.missed;
                    break;
            }

            rps = new RockPaperScissors(player1, player2);
        }

        internal string ScoreBoard()
        {

            if (rps.Winner() == WhoWon.player1) countPlayer1++;
            else if (rps.Winner() == WhoWon.player2) countPlayer2++;
            else ties++;

            return $"\nWins: \nPlayer 1: {countPlayer1} \nPlayer 2: {countPlayer2} \nTies: {ties}";

        }
    }
}
