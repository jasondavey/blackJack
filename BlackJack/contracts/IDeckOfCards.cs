using System.Collections.Generic;
using BlackJack.domain;

namespace BlackJack.contracts
{
    public interface IDeckOfCards
    {
        List<Card> Cards { get; }
        void Shuffle();
    }
}