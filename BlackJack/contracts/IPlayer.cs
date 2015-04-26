using System.Collections.Generic;

namespace BlackJack.contracts
{
    public interface IPlayer
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        List<Card> Cards { set; }
        void ReceiveCards(List<Card> cards);
    }
}