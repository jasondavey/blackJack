using System;
using System.Collections.Generic;
using System.Linq;
using BlackJack.contracts;

namespace BlackJack
{
    /* Make cards private TODO: how to prevent any part of the system reading cards */

    public class Dealer : IDealer
    {
        public Dealer(IDeckOfCards deckOfCards)
        {
            DeckOfCards = deckOfCards;
        }

        private List<Card> Hand { get; set; }
        private IDeckOfCards DeckOfCards { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public void DealCards(IPlayer player, short numberOfCards)
        {
            var cardsGiven = 0;
            Console.WriteLine("Cards left in Deck {0}", DeckOfCards.Cards.Count);
            while (cardsGiven < numberOfCards)
            {
                var card = DeckOfCards.Cards.First();
                player.ReceiveCard(card);
                DeckOfCards.Cards.Remove(card);
                cardsGiven++;
                Console.WriteLine("Cards left in Deck {0}", DeckOfCards.Cards.Count);
            }
        }


        public void ReceiveCard(Card card)
        {
            Console.WriteLine("{0}", FirstName + " " + LastName + " has received card " + card.Name);
            Hand.Add(card);
        }

        public void PlaceBet(ICurrency currency)
        {
            throw new NotImplementedException();
        }

        public void Shuffle()
        {
            Console.WriteLine("Shuffling cards...");
            DeckOfCards.Shuffle();
        }
    }
}