using System;
using BlackJack.contracts;

namespace BlackJack.GameStates.BlackJack
{
    public class CardsDealtState : BlackJackGameState
    {
        public CardsDealtState(IGame game)
            : base(game)
        {
        }

        public override void StartGame()
        {
            throw new Exception("Game has already started!");
        }

        public override void DealCards()
        {
            throw new Exception("Cards have been dealt!");
        }

        
    }
}