using BlackJackConsoleApp;
using NUnit.Framework;
using System.Linq;

namespace BlackJackTests
{
    public class BlackJackTest
    {
        [Test]
        public void DeckShouldContain52Cards()
        {
            // Arrange
            var deck = new Deck();

            // Act
            var count = deck.Cards.Count;

            // Assert
            Assert.AreEqual(52, count);
        }

        [Test]
        public void TakeCardsFromDeckShouldAddToPlayerAndRemoveFromDeck()
        {
            // Arrange
            var player = new Player("Test", false);
            var deck = new Deck();

            // Act
            var firstCard = deck.Cards.First();
            player.TakeCardsFromDeck(deck, 1);

            // Assert
            var isFirstCardInDeck = deck.Cards.Contains(firstCard);
            Assert.False(isFirstCardInDeck);
            Assert.AreEqual(firstCard, player.Cards.First());
        }
    }
}