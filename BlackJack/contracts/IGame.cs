using System.Collections.Generic;
using BlackJack.GameStates.BlackJack;

namespace BlackJack.contracts
{
    public interface IGame
    {
        BlackJackGameState CurrentState { get; set; }
        List<IGameOption> Options { get; set; }
        List<IPlayer> Players { get; set; }
        void AddPlayer(Player player);
        void RemovePlayer(Player player);
        void StartGame();
        void EndGame();
    }
}