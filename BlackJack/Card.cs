using BlackJack.contracts;

namespace BlackJack
{
    public class Card : ICard
    {
        public string SuiteName { get; set; }
        public string Name { get; set; }
        public short Value { get; set; }
        public short Index { get; set; }
    }
}
