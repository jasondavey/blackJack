using System;
using BlackJack.contracts.games;

namespace BlackJack.GameStates.BlackJack
{
    public class GamePlayState : BlackJackGameState
    {
        public GamePlayState(IBlackJackGame game)
            : base(game)
        {
        }

        public override void StartGame()
        {
            throw new Exception("Game has already started!");
        }

        public override void Play()
        {
            throw new Exception("Game is playing!");
        }

       
    }
}