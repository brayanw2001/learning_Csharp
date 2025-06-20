namespace TheCard;

internal class Card
{
    private CardColor[] color = new CardColor[] { CardColor.red, CardColor.green, CardColor.blue, CardColor.yellow };
	private CardRank[] rank = new CardRank[] { CardRank.One, CardRank.Two, CardRank.Three, CardRank.Four, CardRank.Five, CardRank.Six, CardRank.Seven, CardRank.Eight, CardRank.Nine, CardRank.Ten, CardRank.Dollar, CardRank.Percent, CardRank.Caret, CardRank.Ampersand };
    private List<string> cards = new List<string>();

    public Card ()
    {
        cards = createCard();
    }

        
    internal List<string> createCard ()
    {
        List<string> generatedCards = new List<string>();

        foreach (CardColor color_ in color)
        {
            foreach (CardRank rank_  in rank)
            {
                generatedCards.Add($"{color_} {rank_}");
            }
        }
        return generatedCards;
    }

    public void drawCard()
    {
        Shuffler shuffledCard = new Shuffler();
    }
}