using BlackJack.contracts;
using BlackJack.contracts.games;
using BlackJack.contracts.states;
using BlackJack.domain;

namespace BlackJack.GameStates.BlackJack
{
    public abstract class BlackJackGameState : IBlackJackGameState
    {
        protected BlackJackGameState(IBlackJackGame game)
        {
            BlackJackStandardEdition.DisplayConsoleBanner("Entering " + GetType().Name);
            Game = game;
        }

        protected IBlackJackGame Game { get; private set; }

        public IPlayer CurrentPlayer { get; set; }


        public abstract void StartGame();

        public abstract void Play();

        public void EndGame()
        {
            Game.CurrentState = new GameEndedState(Game);
        }
    }
}