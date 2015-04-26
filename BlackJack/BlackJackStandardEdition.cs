using System;
using System.Collections.Generic;
using BlackJack.contracts;
using BlackJack.contracts.games;
using BlackJack.GameStates.BlackJack;

namespace BlackJack
{
    public class BlackJackStandardEdition : IBlackJackGame
    {
        public BlackJackStandardEdition(List<IGameOption> options, IDealer dealer)
        {
            Dealer = dealer;
            Players = new List<IPlayer>();
            Options = options;
            CurrentState = new GameNotStartedState(this);
        }

        public IBlackJackGameState GameStartedState { get; set; }
        public IBlackJackGameState CardsDealtState { get; set; }
        public IBlackJackGameState CurrentState { get; set; }
        public List<IGameOption> Options { get; set; }
        public IDealer Dealer { get; set; }
        public List<IPlayer> Players { get; set; }
        public IDeckOfCards DeckOfCards { get; set; }

        public void DealCards()
        {
            CurrentState.DealCards();
        }


        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            Players.Remove(player);
        }

        public void StartGame()
        {
            CurrentState.StartGame();
            //TODO:Notify subscribers that game is on!
            //EventCoordinator.NotifyEvent(new GameStartedEvent())
        }

        public void EndGame()
        {
            throw new NotImplementedException();
        }
    }
}