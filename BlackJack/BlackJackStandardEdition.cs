using System;
using System.Collections.Generic;
using BlackJack.contracts;
using BlackJack.GameStates.BlackJack;

namespace BlackJack
{
    public class BlackJackStandardEdition : IBlackJackGame
    {
        public BlackJackStandardEdition(List<IGameOption> options, IDealer dealer, List<IPlayer> players)
        {
            Dealer = dealer;
            Players = players;
            Options = options;
            CurrentState = new GameNotStartedState(this);
            
        }

        public BlackJackGameState CurrentState { get; set; }
        public List<IGameOption> Options { get; set; }
        public IDealer Dealer { get; set; }

        public void DealCards()
        {
            CurrentState.DealCards();
        }

        public List<IPlayer> Players { get; set; }


        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            throw new NotImplementedException();
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