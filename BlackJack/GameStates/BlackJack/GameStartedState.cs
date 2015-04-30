using System;
using System.Collections.Generic;
using System.Linq;
using BlackJack.contracts;
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
            throw new Exception("Game has already started");
           
        }

        
        public override void Play()
        {
            var cardRecipients = new List<IPlayer>();
            const short twoCards = 2;
            cardRecipients.AddRange(Game.Players);
            cardRecipients.Add(Game.Dealer); //dealer deals himself last.
            Console.WriteLine("Dealing cards for the first play...");
            Game.Dealer.DealCards(cardRecipients, twoCards);
            CurrentPlayer = Game.Players.First();
            Game.CurrentState = new GameInPlayState(Game, Game.Players.First());
            
            Game.CurrentState.Play();
           
        }
    }
}