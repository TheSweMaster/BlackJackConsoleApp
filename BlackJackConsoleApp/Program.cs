using System;

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
                Console.WriteLine($"Score: {blackJack.Computer.BlackJackScore}");
                PrintPlayerInfo(blackJack.Player);
                blackJack.ChooseAce(blackJack.Player.Cards);
                Console.WriteLine($"Score: {blackJack.Player.BlackJackScore}");
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

            Console.WriteLine("\n-------------------------");
            PrintPlayerInfo(blackJack.Computer);
            Console.WriteLine($"Score: {blackJack.Computer.BlackJackScore}");
            PrintPlayerInfo(blackJack.Player);
            Console.WriteLine($"Score: {blackJack.Player.BlackJackScore}");
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
            Console.WriteLine($"{player.Name}");
            foreach (var card in player.Cards)
            {
                Console.WriteLine($"Color: {card.Color}, Value: {card.Value}");
            }
        }
    }
}
