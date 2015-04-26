﻿using System;
using BlackJack.contracts.games;

namespace BlackJack.GameStates.BlackJack
{
    public class GameNotStartedState : BlackJackGameState
    {
        public GameNotStartedState(IBlackJackGame game) : base(game)
        {
        }

        public override void StartGame()
        {
            CanGameStart();
            Console.WriteLine("Game Started...");
            Game.CurrentState.CurrentPlayer = Game.Dealer;
            Game.Dealer.Shuffle();
            Game.CurrentState = new GameStartedState(Game);
        }

        public override void DealCards()
        {
            throw new Exception("Cannot deal cards before game has started!");
        }

        private void CanGameStart()
        {
            if (Game.Dealer == null)
            {
                throw new Exception("No Dealer at the table!");
            }
            if (Game.Players.Count.Equals(0))
            {
                throw new Exception("No Players at the table!");
            }
        }
    }
}