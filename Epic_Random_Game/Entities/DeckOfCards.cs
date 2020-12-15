using System;
using System.Collections.Generic;
using System.Text;

namespace Epic_Random_Game
{
    public class DeckOfCards
    {
        public List<Card> Cards { get; set; }
        public DeckOfCards(List<Card> cards)
        {

            Cards = new List<Card>(cards);
            Shuffle();
        }

        public DeckOfCards Shuffle()
        {
            Random rnd = new Random();
            var card = Cards[0];
            for (int i =0; i< (Cards.Count)*rnd.Next(3,15); i++)
            {
               var index1 = rnd.Next(0, Cards.Count - 1);
               var index2 = rnd.Next(0, Cards.Count - 1);
                card = Cards[index1];
                Cards[index1] = Cards[index2];
                Cards[index2] = card;
            }
            return this;
        }
    }
}
