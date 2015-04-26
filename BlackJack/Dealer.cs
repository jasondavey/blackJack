using System;
using System.Collections.Generic;
using BlackJack.contracts;

namespace BlackJack
{
    /* Make cards private TODO: how to prevent any part of the system reading cards */

    public class Dealer : IDealer
    {
        public Dealer(IDeckOfCards cardDeck, IDealBehavior dealBehavior, IShuffleBehavior shuffleBehavior)
        {
            CardDeck = cardDeck;
            DealBehavior = dealBehavior;
            ShuffleBehavior = shuffleBehavior;
        }

        private IDeckOfCards CardDeck { get; set; }
        private IDealBehavior DealBehavior { get; set; }
        private IShuffleBehavior ShuffleBehavior { get; set; }


        public void DealCards(IPlayer player)
        {
            var cards = new List<Card> {CardDeck.NextCard()};
            player.ReceiveCards(cards);
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Card> Cards { private get; set; }


        public IDeckOfCards Shuffle()
        {
            Console.WriteLine("Shuffling cards...");
            ShuffleBehavior.Shuffle(CardDeck);
            return CardDeck;
        }

        public void ReceiveCards(List<Card> cards)
        {
            Cards.AddRange(cards);
        }
    }
}