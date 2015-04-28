namespace BlackJack.contracts
{
    public interface IPlayer
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        void ReceiveCard(Card card);
        void PlaceBet(ICurrency currency);
    }
}