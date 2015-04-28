using System.Collections.Generic;

namespace BlackJack.contracts
{
    public interface IDeckOfCards
    {
        List<Card> Cards { get; }
        void Shuffle();
    }
}