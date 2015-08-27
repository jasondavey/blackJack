using BlackJack.contracts;

namespace BlackJack
{
    public class Play : IPlay
    {
        public Play(HandPlaysEnum playType, ICurrency bet)
        {
            PlayType = playType;
            Bet = bet;
        }

        public ICurrency Bet { get; set; }
        public HandPlaysEnum PlayType { get; private set; }
    }
}