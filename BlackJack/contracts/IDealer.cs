namespace BlackJack.contracts
{
    public interface IDealer : IPlayer
    {
        void DealCards(IPlayer player,short numberOfCards);
        void Shuffle();
        
    }
}