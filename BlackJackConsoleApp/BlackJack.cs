using System;
using System.Collections.Generic;

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

        public void ChooseAce()
        {
            foreach (Card card in Player.Cards)
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
}
