using System;
using BlackJack.contracts;
using BlackJack.contracts.games;

namespace BlackJack.GameStates.BlackJack
{
    public class GameInPlayState : BlackJackGameState
    {
        //IHandEvaluator HandEvaluator { get; set; }
        public GameInPlayState(IBlackJackGame game,IPlayer currentPlayer)
            : base(game)
        {
            CurrentPlayer = currentPlayer;
            //HandEvaluator = new BlackJackHandEvaluator(); //TODO dependency injection
        }

        public override void StartGame()
        {
            throw new Exception("Game has already started!");
        }

        public override void Play()
        {
            Console.WriteLine("Player {0} to play their hand",
               CurrentPlayer.FirstName + " " + CurrentPlayer.LastName);

            Game.HandlePlay(CurrentPlayer.MakePlay());

        }
    }

    
}