using System;
using BlackJack.contracts.games;
using BlackJack.domain;
using BlackJack.GameOptions;

namespace BlackJack
{
    public static class BlackJack
    {
        private static void Main(string[] args)
        {
            //CardShuffleDemo();
            
            var blackJackGame = (IBlackJackGame) GameFactory.BuildGame(GameTypes.BlackJackStandardEdition);


            var playerOne = new Player
            {
                FirstName = "Ben",
                LastName = "Archibald"
            };

            var playerTwo = new Player
            {
                FirstName = "Nitin",
                LastName = "Singhal"
            };

            var playerThree = new Player
            {
                FirstName = "Heidi",
                LastName = "Spillett"
            };

            try
            {
                blackJackGame.AddPlayer(playerOne);
                blackJackGame.AddPlayer(playerTwo);
                blackJackGame.AddPlayer(playerThree);
                blackJackGame.StartGame();
                blackJackGame.Play();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }

        private static void CardShuffleDemo()
        {
            var aceValueOption = new AceValueGameOption {AceValue = 11};
            var deckOfCards = new DeckOfCards(aceValueOption);

            BlackJackStandardEdition.DisplayConsoleBanner("Viewing the non shuffled Deck");

            foreach (var card in deckOfCards.Cards)
            {
                Console.WriteLine("Index: {0} {1} : {2}", card.Index, card.Name, card.Value);
            }

            deckOfCards.Shuffle();

            BlackJackStandardEdition.DisplayConsoleBanner("Viewing the shuffled Deck");

            foreach (var card in deckOfCards.Cards)
            {
                Console.WriteLine("Index: {0} {1} : {2}", card.Index, card.Name, card.Value);
            }

            Console.ReadKey();
        }
    }
}