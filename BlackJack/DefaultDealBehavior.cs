using BlackJack.contracts;

namespace BlackJack
{
    public class DefaultDealBehavior : IDealBehavior
    {
        public DefaultDealBehavior()
        {
            NumberOfCardsToDeal = 2;
        }

        private short NumberOfCardsToDeal { get; set; }
    }
}