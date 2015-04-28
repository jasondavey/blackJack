using System;
using System.Collections.Generic;
using BlackJack.contracts;

namespace BlackJack
{
    public class Player : IPlayer
    {
        public Player()
        {
            Hand = new List<Card>();
        }

        private List<Card> Hand { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void ReceiveCard(Card card)
        {
            Console.WriteLine("{0}", FirstName + " " + LastName + " has received card " + card.Name);
            Hand.Add(card);
        }
    }
}