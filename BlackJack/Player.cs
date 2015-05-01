using System;
using System.Collections.Generic;
using System.Linq;
using BlackJack.contracts;
using BlackJack.domain;

namespace BlackJack
{
    public class Player : IPlayer
    {
        public Player()
        {
            Hand = new List<Card>();
            HandEvaluator = new BlackJackHandEvaluator();
            Play = new Play(HandPlaysEnum.NotPlayed,new Dollar{Value = 0});
        }

        private List<Card> Hand { get; set; }
        public IHandEvaluator HandEvaluator { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IPlay Play { get; private set; }

        public void ReceiveCard(Card card)
        {
            Console.WriteLine("{0}", FirstName + " " + LastName + " has received an " + card.Name);
            Hand.Add(card);
        }

        public void PlaceBet(ICurrency currency)
        {
            throw new NotImplementedException();
        }

        public short GetHandValue()
        {
            return (short)Hand.Sum(c => c.Value);
        }

        public Play MakePlay()
        {
            var playsAvailable = HandEvaluator.EvaluateHand(Hand);
            var playType = playsAvailable.OrderBy(x => Guid.NewGuid()).First(); //returns one choice randomly
            var bet = new Dollar {Value = 0};
            var play = new Play(playType,bet);
            Play = play; //assign last play to player for future evaluation
            Console.WriteLine("{0}", FirstName + " " + LastName + " plays a " + play.PlayType);
            Console.WriteLine("{0}", FirstName + " " + LastName + " hand value " + GetHandValue());
            return play; 
        }
    }
}