using System.Collections.Generic;

namespace BlackJack.contracts.states
{
    public interface IGameState
    {
        List<IPlayer> Players { get; set; }
        void StartGame();
        IPlayer CurrentPlayer { get; set; }



    }
}