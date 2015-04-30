using System.Collections.Generic;

namespace BlackJack.contracts.games
{
    public interface IGame
    {
        //IGameState CurrentState { get; set; }
        List<IGameOption> Options { get; set; }
        List<IPlayer> Players { get; set; }
        void AddPlayer(IPlayer player);
        void RemovePlayer(IPlayer player);
        void StartGame();
        void EndGame();
    }
}