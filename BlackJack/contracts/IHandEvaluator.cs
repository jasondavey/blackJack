using System.Collections.Generic;

namespace BlackJack.contracts
{
    public interface IHandEvaluator
    {
        List<HandPlaysEnum> EvaluateHand(List<Card> hand);
    }
}