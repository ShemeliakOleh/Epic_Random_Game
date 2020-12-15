using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace Epic_Random_Game
{
    public class Card
    {
        public int Power { get; set; }
        public int Cunning { get; set; }
        public int Intelligence { get; set; }
        public BitmapImage PathToImage { get; set; }
        public string Title { get; set; }

        public Card(int power,int cunning,int intelligence,string pathToImage,string title)
        {
            Power = power;
            Cunning = cunning;
            Intelligence = intelligence;
            PathToImage = new BitmapImage(new Uri(pathToImage, UriKind.Relative));
            Title = title;
        }
        public int GetAttributeRank(string attribute)
        {
            int rank = 0;
            if(attribute.ToLower() == "power")
            {
                if(Power < 6)
                {
                    rank = 1;
                }
                else
                {
                    if(Power > 10)
                    {
                        rank = 3;
                    }
                    else
                    {
                        rank = 2;
                    }
                }
            }
            if (attribute.ToLower() == "cunning")
            {
                if (Cunning < 6)
                {
                    rank = 1;
                }
                else
                {
                    if (Cunning > 10)
                    {
                        rank = 3;
                    }
                    else
                    {
                        rank = 2;
                    }
                }
            }
            if (attribute.ToLower() == "intelligence")
            {
                if (Intelligence < 6)
                {
                    rank = 1;
                }
                else
                {
                    if (Intelligence > 10)
                    {
                        rank = 3;
                    }
                    else
                    {
                        rank = 2;
                    }
                }
            }
            return rank;

        }





    }
}
