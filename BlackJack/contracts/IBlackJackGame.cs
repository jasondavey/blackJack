using System.Collections.Generic;

namespace BlackJack.contracts
{
    public interface IBlackJackGame : IGame
    {
        List<IGameOption> Options { get; set; }
        IDealer Dealer { get; set; }
        void DealCards();
    }
}