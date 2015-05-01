using System;
using BlackJack.contracts.games;

namespace BlackJack.GameStates.BlackJack
{
    public class GameInitializingState : BlackJackGameState
    {
        public GameInitializingState(IBlackJackGame game) : base(game)
        {
            Console.WriteLine("Loading Game dependencies...");
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

            Console.WriteLine("Dependencies Loaded");
            Game.CurrentState.CurrentPlayer = Game.Dealer;
            Game.Dealer.Shuffle();
            Game.CurrentState = new GameStartedState(Game);
        }

        public override void Play()
        {
            throw new Exception("Cannot play before game has started!");
        }
    }
}