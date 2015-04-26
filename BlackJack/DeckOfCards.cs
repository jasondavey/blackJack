using System.Collections.Generic;
using BlackJack.contracts;

namespace BlackJack
{
    public class DeckOfCards : IDeckOfCards
    {
        public DeckOfCards(IAceValueGameOption aceValueOption)
        {
            AceValue = aceValueOption;
            ClubsSuite = new DeckSuite("Clubs", 0, aceValueOption);
            DiamondsSuite = new DeckSuite("Diamonds", 1, aceValueOption);
            HeartsSuite = new DeckSuite("Hearts", 2, aceValueOption);
            SpadesSuite = new DeckSuite("Spades", 3, aceValueOption);
        }

        private IAceValueGameOption AceValue { get; set; }

        public List<DeckSuite> Suites
        {
            get
            {
                return new List<DeckSuite>
                {
                    (DeckSuite) HeartsSuite,
                    (DeckSuite) SpadesSuite,
                    (DeckSuite) DiamondsSuite,
                    (DeckSuite) ClubsSuite
                };
            }
        }

        public Card NextCard()
        {
            throw new System.NotImplementedException();
        }

        public IDeckSuite SpadesSuite { get; set; }
        public IDeckSuite DiamondsSuite { get; set; }
        public IDeckSuite ClubsSuite { get; set; }
        public IDeckSuite HeartsSuite { get; set; }
    }
}