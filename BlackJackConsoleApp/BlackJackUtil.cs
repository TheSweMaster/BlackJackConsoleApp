namespace BlackJackConsoleApp
{
    public static class BlackJackUtil
    {
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
    }
}
