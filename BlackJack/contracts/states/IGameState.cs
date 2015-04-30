using System.Collections.Generic;

namespace BlackJack.contracts.states
{
    public interface IGameState
    {
        
        void StartGame();
        IPlayer CurrentPlayer { get; set; }



    }
}