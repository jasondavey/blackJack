using System;
using BlackJack.contracts.games;

namespace BlackJack.GameStates.BlackJack
{
    public class CardsDealtState : BlackJackGameState
    {
        public CardsDealtState(IBlackJackGame game)
            : base(game)
        {
        }

        public override void StartGame()
        {
            throw new Exception("Game has already started!");
        }

        public override void DealCards()
        {
            throw new Exception("Hand have been dealt!");
        }
    }
}