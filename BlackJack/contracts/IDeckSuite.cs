using System.Collections.Generic;

namespace BlackJack.contracts
{
    public interface IDeckSuite
    {
        string Name { get; set; }
        List<Card> Cards { get; set; }
    }
}
