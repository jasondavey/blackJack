using System;
using BlackJack.contracts;

namespace BlackJack.GameStates.BlackJack
{
    public class GameNotStartedState : BlackJackGameState
    {
        public GameNotStartedState(IBlackJackGame game) : base(game)
        {
        }

        public override void StartGame()
        {
            if (Game.Dealer == null)
            {
                throw new Exception("No Dealer at the table!");
            }
            if (Game.Players.Count.Equals(0))
            {
                throw new Exception("No Players at the table!");
            }
            Console.WriteLine("Game Started...");
            Game.Dealer.Shuffle();
            Game.CurrentState = new GameStartedState(Game);
            
        }

        public override void DealCards()
        {
            throw new Exception("Cannot deal cards before game has started!");
        }

        
    }
}