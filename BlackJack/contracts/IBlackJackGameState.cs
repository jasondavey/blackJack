using BlackJack.contracts.states;

namespace BlackJack.contracts
{
    public interface IBlackJackGameState : IGameState
    {
       void Play();

       void EndGame();
    }
}