using System.Collections.Generic;

namespace BlackJack.contracts.games
{
    public interface IGame
    {
        //IGameState CurrentState { get; set; }
        List<IGameOption> Options { get; set; }
        List<IPlayer> Players { get; set; }
        void AddPlayer(Player player);
        void RemovePlayer(Player player);
        void StartGame();
        void EndGame();
    }
}