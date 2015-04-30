using System;
using BlackJack.contracts.games;

namespace BlackJack
{
    public static class BlackJack
    {
        private static void Main(string[] args)
        {
            var blackJackGame = (IBlackJackGame) GameFactory.BuildGame(GameTypes.BlackJackStandardEdition);

            
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

            var playerThree = new Player
            {
                FirstName = "Pete",
                LastName = "Pistol"
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
    }
}