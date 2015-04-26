using System.Collections.Generic;
using BlackJack.contracts;

namespace BlackJack
{
    public class Player : IPlayer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Card> Cards { private get; set; }

        public void ReceiveCards(List<Card> cards)
        {
            Cards.AddRange(cards);
        }
    }
}