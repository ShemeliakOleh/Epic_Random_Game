using System;
using System.Collections.Generic;

using System.Text;

namespace Epic_Random_Game
{
    public class User
    {
        public Card CurrentCard { get; set; }
        public DeckOfCards Deck { get; set; }
        public User(DeckOfCards deck)
        {
            Deck = new DeckOfCards(deck.Cards);
            CurrentCard = Deck.Cards[0];
        }


    }
}
