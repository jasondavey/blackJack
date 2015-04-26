using System;
using System.Collections.Generic;
using BlackJack.contracts;

namespace BlackJack
{
    public class DeckSuite : IDeckSuite
    {
        public DeckSuite(string name, short index, IAceValueGameOption aceValueOption)
        {
            const short cardsPerSuite = 13;
            Name = name;
            AceValue = aceValueOption.AceValue;
            SuiteIndex = index;
            Cards = GenerateSuiteOfCards(cardsPerSuite);
//          
        }

        private short SuiteIndex { get; set; }
        private short AceValue { get; set; }
        public List<Card> Cards { get; set; }
        public string Name { get; set; }


        private List<Card> GenerateSuiteOfCards(short cardsPerSuite)
        {
            var cards = new List<Card>();
            short cardIndex = 1;
            while (cardIndex <= cardsPerSuite)
            {
                var card = new Card();
                if (cardIndex == 1) //handle the Ace
                {
                    card.Value = AceValue;
                    card.Index = calculateCardIndex(cardIndex, SuiteIndex, cardsPerSuite);
                    card.Name = String.Format("Ace of {0}", Name).ToUpper();
                }


                if (cardIndex > 1 & cardIndex < 11) // handle 2 - 10
                {
                    card.Value = cardIndex;
                    card.Index = calculateCardIndex(cardIndex, SuiteIndex, cardsPerSuite);
                    card.Name = String.Format("{0} of {1}", card.Value, Name).ToUpper();
                }

                string cardName = "";
                if (cardIndex > 10 & cardIndex < 14) // handle Jack, Queen, King
                {
                    card.Value = 10;
                    card.Index = calculateCardIndex(cardIndex, SuiteIndex, cardsPerSuite);

                    switch (cardIndex)
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
                            ;
                    }


                    card.Name = String.Format("{0} of {1}", cardName, Name).ToUpper();
                }


                cards.Add(card);
                cardIndex++;
            }

            return cards;
        }

        private short calculateCardIndex(short cardIndex, short suiteIndex, short cardsPerSuite)
        {
            return (short) ((suiteIndex*cardsPerSuite) + cardIndex);
        }
    }
}