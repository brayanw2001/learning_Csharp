using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCard
{
    class Card
    {
        internal Colors cardColor { get; }
        internal Ranks cardRank { get; }

        public Card(Colors color, Ranks rank)
        {
            cardColor = color;
            cardRank = rank;
        }

        bool IsNumber(Card card)
        {
            if (card.cardRank == Ranks.DollarSign || card.cardRank == Ranks.Percent ||
                card.cardRank == Ranks.Caret || card.cardRank == Ranks.Ampersand)
            {
                return false;
            }

            return true;
        }
    }
}
