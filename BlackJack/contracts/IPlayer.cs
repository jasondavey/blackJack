using BlackJack.domain;

namespace BlackJack.contracts
{
    public interface IPlayer
    {
        IHandEvaluator HandEvaluator { get; }
        string FirstName { get; set; }
        string LastName { get; set; }
        IPlay Play { get; }
        void ReceiveCard(Card card);
        void PlaceBet(ICurrency currency);
        short GetHandValue();
        Play MakePlay();
    }
}