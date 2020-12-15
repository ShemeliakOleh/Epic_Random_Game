using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epic_Random_Game
{
    public class Bot
    {
        public Card CurrentCard { get; set; }
        public DeckOfCards Deck { get; set; }
        public Bot(DeckOfCards deck)
        {
            Deck = new DeckOfCards(deck.Cards);
            CurrentCard = Deck.Cards[0];
        }
        public string BotsChoice(List<Card> UserPlayedCards)
        {

            int strongCard = 0;
            int mediumCard = 0;
            int weakCard = 0;
            for (int i =0; i< UserPlayedCards.Count; i++)
            {
                if(UserPlayedCards[i].GetAttributeRank("Power") == 1)
                {
                    weakCard++;
                }
                if (UserPlayedCards[i].GetAttributeRank("Power") == 2)
                {
                    mediumCard++;
                }
                if (UserPlayedCards[i].GetAttributeRank("Power") == 3)
                {
                    strongCard++;
                }
                if (UserPlayedCards[i].GetAttributeRank("Cunning") == 1)
                {
                    weakCard++;
                }
                if (UserPlayedCards[i].GetAttributeRank("Cunning") == 2)
                {
                    mediumCard++;
                }
                if (UserPlayedCards[i].GetAttributeRank("Cunning") == 3)
                {
                    strongCard++;
                }
                if (UserPlayedCards[i].GetAttributeRank("Intelligence") == 1)
                {
                    weakCard++;
                }
                if (UserPlayedCards[i].GetAttributeRank("Intelligence") == 2)
                {
                    mediumCard++;
                }
                if (UserPlayedCards[i].GetAttributeRank("Intelligence") == 3)
                {
                    strongCard++;
                }
            }
            int CardRank = 0;
            if((strongCard == mediumCard) && (strongCard == weakCard))
            {
                CardRank = 0;
            }
            else
            {
                if (strongCard < mediumCard)
                {
                    if (strongCard < weakCard)
                    {
                        CardRank = 3;
                    }
                    else
                    {
                        CardRank = 1;
                    }
                }
                else
                {
                    if(mediumCard < weakCard)
                    {
                        CardRank = 2;
                    }
                    else
                    {
                        CardRank = 1;
                    }
                }

            }
            string selectedAttribute = "Power";
            if (CardRank == 0)
            {
                int Power = CurrentCard.Power -((CurrentCard.GetAttributeRank("Power")-1)*5);
                int Cunning = CurrentCard.Cunning - ((CurrentCard.GetAttributeRank("Cunning") - 1) * 5);
                int Intelligence = CurrentCard.Intelligence - ((CurrentCard.GetAttributeRank("Intelligence") - 1) * 5);
                if(Power > Cunning)
                {
                    if(Power > Intelligence)
                    {
                        selectedAttribute = "Power";
                    }
                    else
                    {
                        selectedAttribute = "Intelligence";
                    }
                }
                else
                {
                    if (Cunning > Intelligence)
                    {
                        selectedAttribute = "Cunning";
                    }
                    else
                    {
                        selectedAttribute = "Intelligence";
                    }

                }
            }
            else
            {
                if(CardRank == 1)
                {
                    if(CurrentCard.GetAttributeRank("Power") == 2)
                    {
                        selectedAttribute = "Power";
                    }
                    else if (CurrentCard.GetAttributeRank("Cunning") == 2)
                    {
                        selectedAttribute = "Cunning";
                    }
                    else //////////////можна ускладнити
                    {
                        selectedAttribute = "Intelligence";
                    }
                   
                }
                if (CardRank == 2)
                {
                    if (CurrentCard.GetAttributeRank("Power") == 3)
                    {
                        selectedAttribute = "Power";
                    }
                    else if (CurrentCard.GetAttributeRank("Cunning") == 3)
                    {
                        selectedAttribute = "Cunning";
                    }
                    else //////////////можна ускладнити
                    {
                        selectedAttribute = "Intelligence";
                    }

                }
                if (CardRank == 3)
                {
                    if (CurrentCard.GetAttributeRank("Power") == 1)
                    {
                        selectedAttribute = "Power";
                    }
                    else if (CurrentCard.GetAttributeRank("Cunning") == 1)
                    {
                        selectedAttribute = "Cunning";
                    }
                    else //////////////можна ускладнити
                    {
                        selectedAttribute = "Intelligence";
                    }

                }

            }
            return selectedAttribute;
            
            

        }

    }
}
