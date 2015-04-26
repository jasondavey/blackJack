using System.Collections.Generic;

namespace BlackJack.contracts
{
    public interface IDeckOfCards
    {
        IDeckSuite HeartsSuite { get; set; }
        IDeckSuite SpadesSuite { get; set; }
        IDeckSuite DiamondsSuite { get; set; }
        IDeckSuite ClubsSuite { get; set; }
        List<DeckSuite> Suites { get; }

        Card NextCard();
    }
}
