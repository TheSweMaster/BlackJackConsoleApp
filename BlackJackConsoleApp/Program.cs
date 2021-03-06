using System;
using System.Linq;

namespace BlackJackConsoleApp
{
    public class Program
    {
        public static void Main()
        {
            var blackJack = new BlackJack();
            blackJack.Deal();

            while (blackJack.IsComplete == false)
            {
                PrintPlayerInfo(blackJack.Computer);
                PrintPlayerScore(blackJack.Computer);
                PrintPlayerInfo(blackJack.Player);
                blackJack.ChooseAce(GetAceHighInput);
                PrintPlayerScore(blackJack.Player);

                Console.WriteLine("c = continue");
                Console.WriteLine("s = stop");
                var option = Console.ReadKey();
                Console.WriteLine();
                switch (option.KeyChar)
                {
                    case 'c':
                        blackJack.Continue();
                        break;
                    case 's':
                        blackJack.Stop();
                        break;
                    default:
                        return;
                }
            }

            Console.WriteLine("-------------------------");
            PrintPlayerInfo(blackJack.Computer);
            PrintPlayerScore(blackJack.Computer);
            PrintPlayerInfo(blackJack.Player);
            PrintPlayerScore(blackJack.Player);
            if (blackJack.IsDraw)
            {
                Console.WriteLine($"Draw!");
            }
            else
            {
                Console.WriteLine($"Winner: {blackJack.Winner.Name}");
            }
        }

        private static bool GetAceHighInput()
        {
            Console.WriteLine("Oh you got an Ace!");
            Console.WriteLine("Ace high? y = yes");
            var input = Console.ReadKey();
            Console.WriteLine();
            return input.KeyChar switch
            {
                'y' => true,
                _ => false,
            };
        }

        private static void PrintPlayerInfo(Player player)
        {
            Console.WriteLine($"{player.Name}");
            foreach (var card in player.Cards)
            {
                Console.WriteLine($"Color: {card.Color}, Value: {card.Value}");
            }
        }

        private static void PrintPlayerScore(Player player)
        {
            Console.WriteLine($"Score: {player.BlackJackScore}");
        }
    }
}
