using System.Collections.Generic;

namespace BlackJack.contracts
{
    public interface IDealer : IPlayer
    {
        void DealCards(List<IPlayer> player,short numberOfCards);
        void Shuffle();
        
    }
}