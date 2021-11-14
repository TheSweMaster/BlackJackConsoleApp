using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJackConsoleApp
{
    public class BlackJack
    {
        private const int BlackJackWinScore = 21;
        public Deck Deck { get; private set; }

        public Player Computer { get; private set; }
        public Player Player { get; private set; }
        public bool IsComplete { get; private set; }
        public bool IsDraw { get; private set; }
        public Player Winner { get; private set; }

        public BlackJack()
        {
            Deck = new Deck();
            Player = new Player("Player 1", false);
            Computer = new Player("Computer", true);
        }

        public static int MapToBlackJackValue(CardValue cardValue, bool isHigh)
        {
            return cardValue switch
            {
                CardValue.Ace => isHigh ? 11 : 1,
                CardValue.Two => 2,
                CardValue.Three => 3,
                CardValue.Four => 4,
                CardValue.Five => 5,
                CardValue.Six => 6,
                CardValue.Seven => 7,
                CardValue.Eight => 8,
                CardValue.Nine => 9,
                CardValue.Ten or CardValue.Knight or CardValue.Queen or CardValue.King => 10,
                _ => 0,
            };
        }

        public void Deal()
        {
            Player.TakeCardsFromDeck(Deck, 2);
            Computer.TakeCardsFromDeck(Deck, 2);
        }

        public void Continue()
        {
            Player.TakeCardsFromDeck(Deck, 1);

            if (Player.BlackJackScore <= BlackJackWinScore)
            {
                PlayComputer();
                if (Computer.BlackJackScore > BlackJackWinScore)
                {
                    Winner = Player;
                    IsComplete = true;
                }
            }
            else
            {
                Winner = Computer;
                IsComplete = true;
            }
        }

        public void ChooseAce(List<Card> currentCards)
        {
            foreach (Card card in currentCards)
            {
                if (card.Value == CardValue.Ace)
                {
                    Console.WriteLine("Oh you got an Ace!");
                    Console.WriteLine("Ace high? y = yes");
                    var option = Console.ReadKey();
                    Console.WriteLine();
                    card.IsHigh = option.KeyChar switch
                    {
                        'y' => true,
                        _ => false,
                    };
                }
            }
        }

        public void Stop()
        {
            PlayComputer();
            if (Computer.BlackJackScore > BlackJackWinScore)
            {
                Winner = Player;
                IsComplete = true;
            }
            else if (Player.BlackJackScore == Computer.BlackJackScore)
            {
                IsDraw = true;
                IsComplete = true;
            }
            else
            {
                Winner = Computer;
                IsComplete = true;
            }
        }

        private void PlayComputer()
        {
            while (Player.BlackJackScore > Computer.BlackJackScore)
            {
                Computer.TakeCardsFromDeck(Deck, 1);
                if (Computer.BlackJackScore > BlackJackWinScore)
                {
                    return;
                }
            }
        }
    }

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
        public int BlackJackScore => Cards.Sum(c => BlackJack.MapToBlackJackValue(c.Value, c.IsHigh));
    }
}
