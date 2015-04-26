using System;
using BlackJack.contracts;
using BlackJack.GameStates.BlackJack;

namespace BlackJack.GameStates
{
    public class GameStartedState : BlackJackGameState
    {
        public GameStartedState(IGame game) : base(game)
        {
        }

        public override void StartGame()
        {
            throw new Exception("Game has already started!");
        }

        public override void DealCards()
        {
            Game.Dealer.DealCards(Game.CurrentState.CurrentPlayer());
            Game.CurrentState = new CardsDealtState(Game);
        }
    }
}