using System.Collections.Generic;

namespace BlackJack.contracts
{
    public interface IBlackJackGameState
    {
        List<IPlayer> Players { get; set; }
        void StartGame();
        void DealCards();
      
        IPlayer CurrentPlayer();
    }
}