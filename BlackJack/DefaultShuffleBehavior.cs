using System;
using System.Collections.Generic;
using System.Linq;
using BlackJack.contracts;

namespace BlackJack
{
    internal class DefaultShuffleBehavior : IShuffleBehavior
    {
        public void Shuffle(IDeckOfCards deckOfCards)
        {

            Console.WriteLine(deckOfCards.SpadesSuite.Cards[12].Index);
            var cards = Enumerable.Range(0, 51);
            
            var shuffledcards = cards.OrderBy(a => Guid.NewGuid());
            
            

            foreach (var sc in shuffledcards)
            {
                deckOfCards.Suites.Select(s => s.Cards.Select(c => c.Index = (short)sc));

                //Console.Write(deckOfCards.Suites.Select(s => s.Cards.Select(c=>c.Index)));
            }

            Console.WriteLine(deckOfCards.HeartsSuite.Cards[0].Index);
            Console.Write("done");

            //var shuffledCards = deckOfCards.GetAllCards().OrderBy(a => Guid.NewGuid());
        }
    }
}