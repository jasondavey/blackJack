using System;
using BlackJack.contracts;
using BlackJack.contracts.games;

namespace BlackJack.GameStates.BlackJack
{
    public class DealerPlayingState : BlackJackGameState
    {

        public DealerPlayingState(IBlackJackGame game, IPlayer currentPlayer)
            : base(game)
        {
            CurrentPlayer = currentPlayer;
           
        }

        public override void StartGame()
        {
            throw new Exception("Game has already started!");
        }

        public override void Play()
        {
            Console.WriteLine("Dealer {0} to play their hand",
               CurrentPlayer.FirstName + " " + CurrentPlayer.LastName);

            Game.HandleDealerPlay(CurrentPlayer.MakePlay());

        }
    }

    
}