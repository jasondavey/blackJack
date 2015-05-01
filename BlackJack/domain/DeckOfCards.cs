using System;
using System.Collections.Generic;
using System.Linq;
using BlackJack.contracts;

namespace BlackJack.domain
{
    public class DeckOfCards : IDeckOfCards
    {
        public DeckOfCards(IAceValueGameOption aceValueOption)
        {
            AceValueOption = aceValueOption;
            Cards = GenerateCards();
        }

        private IAceValueGameOption AceValueOption { get; set; }
        public List<Card> Cards { get; private set; }


        public void Shuffle()
        {
            Cards = Cards.OrderBy(a => Guid.NewGuid()).ToList();
        }

        private List<Card> GenerateCards()
        {
            const short cardsPerSuite = 13;
            var cards = new List<Card>();
            var suites = new List<string> {"Hearts", "Spades", "Diamonds", "Clubs"};
            short cardDeckIndex = 1;

            foreach (var suiteName in suites)
            {
                short cardSuiteIndex = 1;

                while (cardSuiteIndex <= cardsPerSuite)
                {
                    var card = new Card();
                    if (cardSuiteIndex == 1) //handle the Ace
                    {
                        card.Value = AceValueOption.AceValue;
                        card.Name = String.Format("Ace of {0}", suiteName).ToUpper();
                    }


                    if (cardSuiteIndex > 1 & cardSuiteIndex < 11) // handle 2 - 10
                    {
                        card.Value = cardSuiteIndex;
                        card.Name = String.Format("{0} of {1}", card.Value, suiteName).ToUpper();
                    }

                    var cardName = "";
                    if (cardSuiteIndex > 10 & cardSuiteIndex < 14) // handle Jack, Queen, King
                    {
                        card.Value = 10;
                        //card.Index = cardSuiteIndex;

                        switch (cardSuiteIndex)
                        {
                            case 11:
                            {
                                cardName = "Jack";
                                break;
                            }

                            case 12:
                            {
                                cardName = "Queen";
                                break;
                            }


                            case 13:
                            {
                                cardName = "King";
                                break;
                            }
                                
                        }

                        card.Value = 10;
                        card.Name = String.Format("{0} of {1}", cardName, suiteName).ToUpper();
                    }

                    card.SuiteName = suiteName;
                    card.Index = cardDeckIndex;
                    cards.Add(card);
                    cardDeckIndex++;
                    cardSuiteIndex++;
                }
               
            }


            return cards;
        }
    }
}