using System.Collections.Generic;

namespace BlackJack.contracts
{
    public interface IHandEvaluator
    {
        List<HandChoicesEnum> EvaluateHand(List<Card> hand);
    }
}