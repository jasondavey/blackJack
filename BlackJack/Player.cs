using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackJack.contracts;

namespace BlackJack
{
    public class Player : IPlayer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Card> Cards { private get; set; }

        public void ReceiveCard(Card card)
        {
            Cards.Add(card);
        }
    }
}
