namespace BlackJack.contracts.games
{
    public interface ICardGame
    {
        IDeckOfCards DeckOfCards { get; set; }
        void DealCards();
    }
}
