using System.Collections.Generic;
using BlackJack.contracts;
using BlackJack.contracts.games;

namespace BlackJack.GameStates.BlackJack
{
    public abstract class BlackJackGameState : IBlackJackGameState
    {
        protected BlackJackGameState(IBlackJackGame game)
        {
            Game = game;
        }

        protected IBlackJackGame Game { get; private set; }
        public List<IPlayer> Players { get; set; }
        public IPlayer CurrentPlayer { get; set; }


        public abstract void StartGame();


        public abstract void DealCards();
    }
}