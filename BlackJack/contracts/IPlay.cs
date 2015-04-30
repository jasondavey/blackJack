namespace BlackJack.contracts
{
    public interface IPlay
    {
        ICurrency Bet { get; set; }
        HandPlaysEnum PlayType { get; }
    }
}