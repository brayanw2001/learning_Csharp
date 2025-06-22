using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class RockPaperScissors
    {
        public Hands hand1 { get; }
        public Hands hand2 { get; }

        public RockPaperScissors(Hands hand1, Hands hand2)
        {
            this.hand1 = hand1;
            this.hand2 = hand2;
        }

        public WhoWon Winner ()
        {
            if ( hand1 == Hands.rock && hand2 == Hands.scissors ||
                 hand1 == Hands.paper && hand2 == Hands.rock ||
                 hand1 == Hands.scissors && hand2 == Hands.paper
                )
            {
                return WhoWon.player1;
            }
            else if (hand1 == hand2) return WhoWon.tie;
            else return WhoWon.player2;

        }
    }
}
