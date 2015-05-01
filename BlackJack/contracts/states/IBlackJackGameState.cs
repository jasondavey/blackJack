namespace BlackJack.contracts.states
{
    public interface IBlackJackGameState : IGameState
    {
       void Play();

       void EndGame();
    }
}