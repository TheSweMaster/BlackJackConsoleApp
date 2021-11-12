using System;
using System.Collections.Generic;

namespace BlackJackConsoleApp
{
    public class Deck
    {
        private static readonly Random Random = new();

        public List<Card> Cards { get; private set; }

        public Deck()
        {
            CreateCardDeck();
            ShuffleCardDeck();
        }

        private void ShuffleCardDeck()
        {
            // Don't ask how, it just works
            for (int cardIndex = Cards.Count - 1; cardIndex > 0; --cardIndex)
            {
                int randomCardIndex = Random.Next(cardIndex + 1);
                Card cardToShuffle = Cards[cardIndex];
                Cards[cardIndex] = Cards[randomCardIndex];
                Cards[randomCardIndex] = cardToShuffle;
            }
        }

        private void CreateCardDeck()
        {
            var cardValues = Enum.GetValues<CardValue>();
            var cardColors = Enum.GetValues<CardColor>();

            int cardId = 1;
            List<Card> deckList = new();
            foreach (CardColor cardColor in cardColors)
            {
                foreach (CardValue cardValue in cardValues)
                {
                    Card card = new(cardId, cardValue, cardColor);
                    deckList.Add(card);
                    cardId++;
                }
            }
            Cards = deckList;
        }
    }

    public class Card
    {
        public Card(int id, CardValue value, CardColor color)
        {
            Id = id;
            Value = value;
            Color = color;
        }

        public int Id { get; }
        public CardValue Value { get; }
        public CardColor Color { get; }
    }

    public enum CardValue
    {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Knight = 11,
        Queen = 12,
        King = 13,
    }

    public enum CardColor
    {
        Clubs,
        Diamonds,
        Spades,
        Hearts,
    }
}
