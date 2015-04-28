using System;
using System.Collections.Generic;
using BlackJack.contracts;
using BlackJack.contracts.games;
using BlackJack.GameStates.BlackJack;

namespace BlackJack
{
    public class BlackJackStandardEdition : IBlackJackGame
    {
        public BlackJackStandardEdition(List<IGameOption> options, IDealer dealer,ICurrency currency)
        {
            Dealer = dealer;
            Players = new List<IPlayer>();
            Options = options;
            Currency = currency;
            CurrentState = new GameNotStartedState(this);
        }

        public IBlackJackGameState GameStartedState { get; set; }
        public IBlackJackGameState CardsDealtState { get; set; }
        public IBlackJackGameState CurrentState { get; set; }
        public List<IGameOption> Options { get; set; }
        public IDealer Dealer { get; set; }
        public List<IPlayer> Players { get; set; }
        public IDeckOfCards DeckOfCards { get; set; }
        public ICurrency Currency { get; set; }

        public void DealCards()
        {
            CurrentState.DealCards();
        }


        public void AddPlayer(Player player)
        {
            Players.Add(player);
            Console.WriteLine("Player {0} {1} has joined the game.", player.FirstName, player.LastName);
        }

        public void RemovePlayer(Player player)
        {
            Players.Remove(player);
            Console.WriteLine("Player {0} {1} has left the game.", player.FirstName, player.LastName);
        }

        public void StartGame()
        {
            CurrentState.StartGame();
            Console.WriteLine("Game has started.");
            //TODO:Notify subscribers that game is on!
            //EventCoordinator.NotifyEvent(new GameStartedEvent())
        }

        public void EndGame()
        {
            Console.WriteLine("Game has ended.");
        }
    }
}