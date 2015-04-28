using System;
using System.Collections.Generic;
using BlackJack.contracts;
using BlackJack.contracts.games;
using BlackJack.GameOptions;

namespace BlackJack
{
    internal class GameFactory : IGameFactory
    {
        public IGame BuildGame(Enum gameType)
        {
            throw new NotImplementedException();
        }

        public static IGame BuildGame(GameTypes gameType)
        {
            switch (gameType)
            {
                case GameTypes.BlackJackStandardEdition:
                {
                    var aceValueOption = new AceValueGameOption {AceValue = 11};
                    var gameOptions = new List<IGameOption> {aceValueOption};
                    var cardDeck = new DeckOfCards(aceValueOption);
                    var currency = new Dollar();


                    var dealer = new Dealer(cardDeck)
                    {
                        FirstName = "Dennis",
                        LastName = "Dealer"
                    };
                    return new BlackJackStandardEdition(gameOptions, dealer, currency);
                }
            }
            throw new Exception(String.Format("Game type {0} cannot is not recognized by this factory.", gameType));
        }
    }
}