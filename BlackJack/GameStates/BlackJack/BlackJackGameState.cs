using System;
using System.Collections.Generic;
using System.Linq;
using BlackJack.contracts;

namespace BlackJack.GameStates.BlackJack
{
    public abstract class BlackJackGameState : IBlackJackGameState
    {
        protected BlackJackGameState(IGame game)
        {
            Game = (IBlackJackGame) game;
        }

        protected IBlackJackGame Game { get; private set; }

        public List<IPlayer> Players { get; set; }
        public abstract void StartGame();
        public abstract void DealCards();
      

        public IPlayer CurrentPlayer()
        {
            Console.WriteLine("Current Player: {0} {1}", Game.Players.First().FirstName, Game.Players.First().LastName);
            return Game.CurrentState.CurrentPlayer();
        }
    }
}