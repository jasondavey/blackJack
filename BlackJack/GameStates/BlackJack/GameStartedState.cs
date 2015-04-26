using System;
using BlackJack.contracts.games;

namespace BlackJack.GameStates.BlackJack
{
    public class GameStartedState : BlackJackGameState
    {
        public GameStartedState(IBlackJackGame game) : base(game)
        {
        }

        public override void StartGame()
        {
            throw new Exception("Game has already started!");
        }

        public override void DealCards()
        {
            Game.Dealer.DealCards(Game.Dealer);
            Game.CurrentState = new CardsDealtState(Game);
        }
    }
}