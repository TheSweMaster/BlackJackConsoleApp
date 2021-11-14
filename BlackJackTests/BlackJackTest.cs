using BlackJackConsoleApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
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

        [Test]
        public void ShouldCalculateBlackJackScoreWithAces()
        {
            // Arrange
            var player = new Player("test", false);
            var playerCards = new List<Card>()
            {
                new Card(0, CardValue.Ace, CardColor.Clubs) { IsHigh = true, IsPicked = true }, // 11
                new Card(0, CardValue.Ace, CardColor.Diamonds) { IsHigh = false, IsPicked = false }, // 1
                new Card(0, CardValue.Seven, CardColor.Diamonds), // 7
            };

            player.Cards.AddRange(playerCards);

            // Act
            var blackJackScore = player.BlackJackScore;

            // Assert
            Assert.AreEqual(19, blackJackScore);
        }

        [Test]
        public void ShouldChooseAceHighAndCalculateScoreCorrect()
        {
            // Arrange
            var player = new Player("test", false);
            var playerCards = new List<Card>()
            {
                new Card(0, CardValue.Ace, CardColor.Hearts) { IsPicked = true, IsHigh = false, }, // 1
                new Card(0, CardValue.Ace, CardColor.Clubs) { IsPicked = false }, // 1
                new Card(0, CardValue.Ace, CardColor.Diamonds) { IsPicked = false }, // 11
                new Card(0, CardValue.Seven, CardColor.Diamonds), // 7
            };
            player.Cards.AddRange(playerCards);

            var blackJack = new BlackJack(null, player, null);

            // Act
            var calls = 1;
            bool isHighFunc()
            {
                if (calls == 1)
                {
                    calls++;
                    return false;
                }
                return true;
            }

            blackJack.ChooseAce(isHighFunc);
            var blackJackScore = player.BlackJackScore;

            // Assert
            Assert.AreEqual(20, blackJackScore);
        }
    }
}