using System.Collections.Generic;
using BlackJack.domain;

namespace BlackJack.contracts
{
    public interface IHandEvaluator
    {
        List<HandPlaysEnum> EvaluateHand(List<Card> hand);
    }
}