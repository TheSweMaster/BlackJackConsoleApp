using System.Collections.Generic;
using System.Linq;

namespace BlackJackConsoleApp
{
    public class Player
    {
        public Player(string name, bool isComputer)
        {
            Name = name;
            IsComputer = isComputer;
            Cards = new List<Card>();
        }

        public string Name { get; private set; }
        public List<Card> Cards { get; private set; }
        public bool IsComputer { get; private set; }

        public void TakeCardsFromDeck(Deck deck, int amount)
        {
            List<Card> currentCards = deck.Cards.Take(amount).ToList();
            Cards.AddRange(currentCards);
            deck.Cards.RemoveRange(0, amount);
        }

        // TODO: Fix ace high for the computer, try high and low for every combination and result highest result at 21 or lower
        public int BlackJackScore => Cards.Sum(c => BlackJackUtil.MapToBlackJackValue(c.Value, c.IsHigh));
    }
}
