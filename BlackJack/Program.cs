using System;
using System.Collections.Generic;
using BlackJack.contracts;
using BlackJack.GameOptions;
using BlackJack.GameStates;
using BlackJack.GameStates.BlackJack;

namespace BlackJack
{
    public static class BlackJack
    {
        private static void Main(string[] args)
        {
            var gameFactory = new GameFactory();
            var blackJackGame = GameFactory.BuildGame(GameTypes.BlackJackStandardEdition);
            var blackJackGameState = new BlackJackGameState(blackJackGame);


            //var blackJackGame = new BlackJackGame(gameOptions, dealer, players);
                //new StandardGameOfBlackJack();

            var aceValueOption = new AceValueGameOption {AceValue = 11};
            var gameOptions = new List<IGameOption> {aceValueOption};
            var cardDeck = new DeckOfCards(aceValueOption);
            var dealBehavior = new DefaultDealBehavior();
            var shuffleBehavior = new DefaultShuffleBehavior();
            var dealer = new Dealer(cardDeck, dealBehavior,shuffleBehavior);
            
            var playerOne = new Player
            {
                FirstName = "Winston",
                LastName = "Parks"
            };

            var playerTwo = new Player
            {
                FirstName = "Candy",
                LastName = "Swavenski"
            };

            var players = new List<IPlayer> {playerOne, playerTwo};
            var blackJackGame = new BlackJackGame(gameOptions,dealer,players);

            blackJackGame.StartGame();
            blackJackGame.DealCards();
           
            Console.ReadKey();




        }
    }
}