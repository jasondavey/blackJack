using System;
using System.Collections.Generic;
using System.Linq;
using BlackJack.contracts;

namespace BlackJack
{
    public class Dealer : IDealer
    {
        public Dealer(IDeckOfCards deckOfCards)
        {
            Hand = new List<Card>();
            HandEvaluator = new BlackJackHandEvaluator();
            DeckOfCards = deckOfCards;
        }

        private List<Card> Hand { get; set; }
        private IDeckOfCards DeckOfCards { get; set; }
        public IHandEvaluator HandEvaluator { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IPlay Play { get; private set; }

        public void DealCards(List<IPlayer> players, short numberOfCards)
        {
            foreach (var player in players)
            {
                if (DeckOfCards.Cards.Count.Equals(0))
                {
                    throw new Exception("Yikes, we've run out of cards!");
                }
                var cardsGiven = 0;

                while (cardsGiven < numberOfCards)
                {
                    var card = DeckOfCards.Cards.First();
                    player.ReceiveCard(card);
                    DeckOfCards.Cards.Remove(card);
                    cardsGiven++;
                    Console.WriteLine("Cards left in Deck {0}", DeckOfCards.Cards.Count);
                }
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

        public short GetHandValue()
        {
            return (short) Hand.Sum(c => c.Value);
        }

        public Play MakePlay()
        {
            var playsAvailable = HandEvaluator.EvaluateHand(Hand);
            var playType = playsAvailable.OrderBy(x => Guid.NewGuid()).FirstOrDefault(); //returns one choice randomly
            var bet = new Dollar {Value = 0};
            var play = new Play(playType, bet);
            Play = play; //assign last play to player for future evaluation
            Console.WriteLine("{0}", FirstName + " " + LastName + " plays a " + play.PlayType);
            return play;
        }

        public void Shuffle()
        {
            Console.WriteLine("Shuffling cards...");
            DeckOfCards.Shuffle();
        }
    }
}