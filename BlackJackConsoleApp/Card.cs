namespace BlackJackConsoleApp
{
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
        public bool IsHigh { get; set; }
        public CardColor Color { get; }
    }
}
