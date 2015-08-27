using System;
using BlackJack.contracts.games;

namespace BlackJack.GameStates.BlackJack
{
    public class GameEndedState : BlackJackGameState
    {
        public GameEndedState(IBlackJackGame game)
            : base(game)
        {
            Game.Winners.ForEach(winner => Console.WriteLine("Winner! {0}", winner.FirstName + " " + winner.LastName));
        }

        public override void StartGame()
        {
            throw new Exception("Game must be initialized before starting!");
        }

        public override void Play()
        {
            Console.WriteLine("Game Over!");
            Console.ReadKey();
        }
    }
}