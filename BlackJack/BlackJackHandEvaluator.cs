using System.Collections.Generic;
using System.Linq;
using BlackJack.contracts;

namespace BlackJack
{
    public class BlackJackHandEvaluator : IHandEvaluator
    {
        public List<HandPlaysEnum> EvaluateHand(List<Card> hand)
        {
            var listOfPlays = new List<HandPlaysEnum>();

            if (GoneBust(hand))
            {
                listOfPlays.Add(HandPlaysEnum.Bust);
                return listOfPlays;
            }

            if (CanSplit(hand))
            {
                listOfPlays.Add(HandPlaysEnum.Split);
            }

            if (CanStand(hand))
            {
                listOfPlays.Add(HandPlaysEnum.Stand);
            }

            if (CanHit(hand))
            {
                listOfPlays.Add(HandPlaysEnum.Hit);
            }


            return listOfPlays;
        }

        private static bool GoneBust(IReadOnlyCollection<Card> hand)
        {
            const int maxNonBustedValue = 21;
            return (HandValues(hand).All(c => c > maxNonBustedValue));
        }

        private static IEnumerable<int> HandValues(IReadOnlyCollection<Card> hand)
        {
            var handValues = new List<int>();
            short handValue = 0;
            foreach (var card in hand)
            {
                if (AreCardsSameValue(hand))
                {
                    if (IsAnAceCard(card))
                    {
                        handValues.Add(1*hand.Count);
                        handValues.Add(11*hand.Count);
                        break;
                    }

                    handValues.Add(card.Value*hand.Count);
                    break;
                }

                /* The Hand contains an Ace card, must provide two value options */
                if (HandContainsAnAceCard(hand))
                {
                    var otherCard = hand.Where(s => s.Name != card.Name).Select(s => s).ToList().First();
                    handValues.Add(1 + otherCard.Value);
                    handValues.Add(11 + otherCard.Value);
                    break;
                }

                /* Handle cards not with an ace and of different value */

                handValue += card.Value;
            }

            handValues.Add(handValue);
            return handValues;
        }

        private static bool HandContainsAnAceCard(IEnumerable<Card> hand)
        {
            return hand.Any(IsAnAceCard);
        }

        private static bool AreCardsSameValue(IReadOnlyCollection<Card> hand)
        {
            return !hand.Count.Equals(0) && (hand.All(c => c.Value.Equals(hand.First().Value)));
        }


        private static bool IsAnAceCard(Card card)
        {
            return card.Value.Equals(1) || card.Value.Equals(11);
        }

        private static bool CanSplit(IReadOnlyCollection<Card> hand)
        {
            return (hand.Count.Equals(2) && (hand.First().Value.Equals(hand.Last().Value)));
        }

        /* Don't stand if hand value is less than 11 */
        private static bool CanStand(IReadOnlyCollection<Card> hand)
        {
            return (!GoneBust(hand) && hand.Sum(c =>c.Value) > 10);
        }

        private static bool CanHit(IReadOnlyCollection<Card> hand)
        {
            return (!GoneBust(hand));
        }
    }
}