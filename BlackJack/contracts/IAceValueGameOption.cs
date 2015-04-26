namespace BlackJack.contracts
{
    public interface IAceValueGameOption : IGameOption
    {
        short AceValue { get; set; }
    }
}