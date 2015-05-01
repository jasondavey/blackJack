using System;
using System.Collections.Generic;
using System.Linq;
using BlackJack.contracts;
using BlackJack.contracts.games;
using BlackJack.contracts.states;
using BlackJack.GameStates.BlackJack;

namespace BlackJack.domain
{
    public class BlackJackStandardEdition : IBlackJackGame
    {
        public BlackJackStandardEdition(List<IGameOption> options, IDealer dealer, ICurrency currency)
        {
            Dealer = dealer;
            Players = new List<IPlayer>();
            Options = options;
            Currency = currency;
            CurrentState = new GameInitializingState(this);
            Winners = new List<IPlayer>();

            Console.WriteLine("{0} {1} will be this game's dealer.", dealer.FirstName, dealer.LastName);
        }

        private ICurrency Currency { get; set; }
        public List<IPlayer> Winners { get; private set; }
        public IBlackJackGameState CurrentState { get; set; }
        public List<IGameOption> Options { get; set; }
        public IDealer Dealer { get; set; }
        public List<IPlayer> Players { get; set; }
        public IDeckOfCards DeckOfCards { get; set; }

        public void Play()
        {
            CurrentState.Play();
        }

        public void HandlePlay(IPlay play)
        {
            var nextPlayer = CurrentState.CurrentPlayer;
            switch (play.PlayType)
            {
                case HandPlaysEnum.Bust:
                {
                    if (Players.Count < 2)
                    {
                        EndGame();
                    }
                    nextPlayer = FetchNextPlayer();

                    RemovePlayer(CurrentState.CurrentPlayer); //remove current player

                    break;
                }
                case HandPlaysEnum.Hit:
                {
                    Dealer.DealCards(new List<IPlayer> {CurrentState.CurrentPlayer}, 1);
                    break;
                }

                case HandPlaysEnum.Stand:
                {
                    nextPlayer = FetchNextPlayer();
                    break;
                }

                case HandPlaysEnum.Split:
                {
                    Console.WriteLine("Player Split not implemented yet!");
                    break;
                }
            }


            if (AllPlayersStanding())
            {
                CurrentState = new DealerPlayingState(this, Dealer);
                CurrentState.Play();
            }

            /* When a player takes a stand, do not play them, 
             * they are waiting for dealer to make a move 
             */

            if (nextPlayer.Play.PlayType.Equals(HandPlaysEnum.Stand))
            {
                CurrentState.CurrentPlayer = nextPlayer;
                HandlePlay(play);
            }
            CurrentState = new GameInPlayState(this, nextPlayer);
            CurrentState.Play();
        }

        public void HandleDealerPlay(IPlay play)
        {
            switch (play.PlayType)
            {
                case HandPlaysEnum.Bust:
                {
                    DetermineWinnersOnDealerBust();
                    EndGame();

                    break;
                }
                case HandPlaysEnum.Hit:
                {
                    Dealer.DealCards(new List<IPlayer> {CurrentState.CurrentPlayer}, 1);
                    break;
                }

                case HandPlaysEnum.Stand:
                {
                    DetermineWinnerOnAllStand();
                    EndGame();
                    break;
                }

                case HandPlaysEnum.Split:
                {
                    throw new Exception("The Dealer cannot split!");
                }
            }
            CurrentState.Play();
        }


        public void AddPlayer(IPlayer player)
        {
            Players.Add(player);
            Console.WriteLine("Player {0} {1} has joined the game.", player.FirstName, player.LastName);
        }

        public void RemovePlayer(IPlayer player)
        {
            Players.Remove(player);
            Console.WriteLine("Player {0} {1} has left the game.", player.FirstName, player.LastName);
        }

        public void StartGame()
        {
            CurrentState.StartGame();

            //TODO:Notify subscribers that game is on!
            //EventCoordinator.NotifyEvent(new GameStartedEvent())
        }

        public void EndGame()
        {
            CurrentState.EndGame();
        }

        private void DetermineWinnersOnDealerBust()
        {
            Winners.AddRange(Players);
            Winners.ForEach(winner => Console.WriteLine("{0} has a hand value of {1}", winner.FirstName + " " + winner.LastName,winner.GetHandValue()));
        }

        private void DetermineWinnerOnAllStand()
        {
            Console.WriteLine("Dealer {0} has a hand value of {1}", Dealer.FirstName + " " + Dealer.LastName, Dealer.GetHandValue());
            Players.ForEach(player => Console.WriteLine("{0} has a hand value of {1}", player.FirstName + " " + player.LastName, player.GetHandValue()));
            var winnerList = Players.Where(player => player.GetHandValue() > Dealer.GetHandValue()).ToList();

            if (winnerList.Count.Equals(0))
            {
                winnerList.Add(Dealer);
            }

            Winners = winnerList;
        }

        private bool AllPlayersStanding()
        {
            return Players.All(p => p.Play.PlayType.Equals(HandPlaysEnum.Stand));
        }

        private IPlayer FetchNextPlayer()
        {
            IPlayer nextPlayer = null;

            if (Players.Count.Equals(1))
            {
                nextPlayer = CurrentState.CurrentPlayer;
            }

            //are multiple players still playing?
            if (Players.Count <= 1) return nextPlayer;
            // is this the last player?
            if (Players.IndexOf(CurrentState.CurrentPlayer).Equals(Players.IndexOf(Players.Last())))
            {
                nextPlayer = Players.First();
            }
            else
            {
                var nextPlayerIndex = Players.IndexOf(CurrentState.CurrentPlayer) + 1;
                nextPlayer = Players[nextPlayerIndex];
            }

            return nextPlayer;
        }

        public static void DisplayConsoleBanner(string message)
        {
            const string asterisk = "*";
            const string space = " ";
            var topLineCount = message.Length + 6;
            var bottomLineCount = topLineCount;
            const short sideLineCount = 2;
            var spacesCount = topLineCount - (2*sideLineCount);
            var emptyLine = String.Concat(Enumerable.Repeat(asterisk, sideLineCount)) +
                            String.Concat(Enumerable.Repeat(space, spacesCount)) +
                            String.Concat(Enumerable.Repeat(asterisk, sideLineCount));
            Console.WriteLine();
            Console.WriteLine("{0}", String.Concat(Enumerable.Repeat(asterisk, topLineCount)));
            Console.WriteLine("{0}", emptyLine);
            Console.WriteLine("{0}", emptyLine);
            Console.WriteLine("{0} {1} {0}", String.Concat(Enumerable.Repeat(asterisk, sideLineCount)), message);
            Console.WriteLine("{0}", emptyLine);
            Console.WriteLine("{0}", emptyLine);
            Console.WriteLine("{0}", String.Concat(Enumerable.Repeat(asterisk, bottomLineCount)));
            Console.WriteLine();
        }
    }
}