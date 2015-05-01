namespace BlackJack.contracts.states
{
    public interface IGameState
    {
        IPlayer CurrentPlayer { get; set; }
        void StartGame();
    }
}