namespace BlackJack.contracts.games
{
    public interface IBlackJackGame : IGame, ICardGame
    {
        IBlackJackGameState CurrentState { get; set; }
        IDealer Dealer { get; set; }
        void Play();
    }
}