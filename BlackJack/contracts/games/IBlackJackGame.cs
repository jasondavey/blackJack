using System.Collections.Generic;
using BlackJack.contracts.states;

namespace BlackJack.contracts.games
{
    public interface IBlackJackGame : IGame, ICardGame
    {
        IBlackJackGameState CurrentState { get; set; }
        IDealer Dealer { get; set; }
        List<IPlayer> Winners { get; }
        void Play();
        void HandlePlay(IPlay play);
        void HandleDealerPlay(IPlay play);
    }
}