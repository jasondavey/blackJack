using System;
using BlackJack.contracts.games;
using BlackJack.GameOptions;

namespace BlackJack
{
    public static class BlackJack
    {
        private static void Main(string[] args)
        {
            var gameFactory = new GameFactory();
            var blackJackGame = (IBlackJackGame) GameFactory.BuildGame(GameTypes.BlackJackStandardEdition);

            var aceValueOption = new AceValueGameOption { AceValue = 11 };
            var cardDeck = new DeckOfCards(aceValueOption);


            //var blackJackGame = new BlackJackGame(gameOptions, dealer, players);
            //new StandardGameOfBlackJack();

//            var aceValueOption = new AceValueGameOption {AceValue = 11};
//            var gameOptions = new List<IGameOption> {aceValueOption};
//            var cardDeck = new DeckOfCards(aceValueOption);
//            var dealBehavior = new DefaultDealBehavior();
//            var shuffleBehavior = new DefaultShuffleBehavior();
//            var dealer = new Dealer(cardDeck, dealBehavior,shuffleBehavior);

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


            blackJackGame.AddPlayer(playerOne);
            blackJackGame.AddPlayer(playerTwo);
            blackJackGame.StartGame();
            
            Console.ReadKey();
        }
    }
}