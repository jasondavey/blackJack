using System;
using System.Linq;
using BlackJack.contracts.games;

namespace BlackJack.GameStates.BlackJack
{
    public class GameStartedState : BlackJackGameState
    {
        public GameStartedState(IBlackJackGame game) : base(game)
        {
            Console.WriteLine("Game started.");
        }

        public override void StartGame()
        {
            throw new Exception("Game has already started");
           
        }

        
        public override void Play()
        {
            Game.Dealer.DealCards(Game.Players, 2);
            Game.CurrentState = new GamePlayState(Game);
        }
    }
}