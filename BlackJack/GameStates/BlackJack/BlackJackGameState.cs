using BlackJack.contracts;
using BlackJack.contracts.games;

namespace BlackJack.GameStates.BlackJack
{
    public abstract class BlackJackGameState : IBlackJackGameState
    {
        protected BlackJackGameState(IBlackJackGame game)
        {
            BlackJackStandardEdition.DisplayStateTransition("Entering " + GetType().Name);
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