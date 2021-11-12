using System;

namespace BlackJackConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var blackJack = new BlackJack();
            blackJack.Deal();

            while (blackJack.IsComplete == false)
            {
                PrintPlayerInfo(blackJack.Computer);
                PrintPlayerInfo(blackJack.Player);
                Console.WriteLine("c = continue");
                Console.WriteLine("s = stop");
                var option = Console.ReadKey();
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
            PrintPlayerInfo(blackJack.Player);
            if (blackJack.IsDraw)
            {
                Console.WriteLine($"Draw!");
                
            }
            else
            {
                Console.WriteLine($"Winner: {blackJack.Winner.Name}");
            }
        }

        private static void PrintPlayerInfo(Player player)
        {
            Console.WriteLine($"{player.Name}, Score: {player.BlackJackScore}");
            foreach (var card in player.Cards)
            {
                Console.WriteLine($"Color: {card.Color}, Value: {card.Value}");
            }
        }
    }
}
