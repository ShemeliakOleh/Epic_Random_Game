using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Epic_Random_Game
{
     public class Game
        {
        public bool IsUserLastMove { get; set; }
        public List<Card> UserPlayedCards { get; set; }
        public Bot CurrentBot { get; set; }
        public User CurrentUser { get; set; }
        public Game(DeckOfCards deckOfCardsForUser, DeckOfCards deckOfCardsForBot)
        {
            UserPlayedCards = new List<Card>();
            CurrentBot = new Bot(deckOfCardsForBot);
            CurrentUser = new User(deckOfCardsForUser);
        }

        public string Start(GameProcessPage gameProcessPage)
        {
            Random rand = new Random();
            int whoFirst = rand.Next(0, 2);
            gameProcessPage.UserCardImage.Source = CurrentUser.Deck.Cards[0].PathToImage;
            gameProcessPage.tUserCunning.Text = CurrentUser.Deck.Cards[0].Cunning.ToString();
            gameProcessPage.tUserIntell.Text = CurrentUser.Deck.Cards[0].Intelligence.ToString();
            gameProcessPage.tUserPower.Text = CurrentUser.Deck.Cards[0].Power.ToString();
            gameProcessPage.tUserCardName.Text = CurrentUser.Deck.Cards[0].Title.ToString();
            gameProcessPage.BotCardImage.Source = new BitmapImage(new Uri("Resources/question-mark.png", UriKind.Relative));
            if (whoFirst > 0)
            {
                gameProcessPage.bUserCunning.IsEnabled = true;
                gameProcessPage.bUserIntelligence.IsEnabled = true;
                gameProcessPage.bUserPower.IsEnabled = true;
                
            }
            else
            {
                gameProcessPage.bShow.IsEnabled = true;

            }
            return "";
        }

        internal void ShowCard(GameProcessPage gameProcessPage)
        {
            HideCard(gameProcessPage);
            var BotsChoice = CurrentBot.BotsChoice(UserPlayedCards);
            ChooseAttribute(gameProcessPage, BotsChoice, false);
        }

        internal void NextMove(GameProcessPage gameProcessPage)
        {
            HideCard(gameProcessPage);
            if (IsUserLastMove)
            {
                gameProcessPage.bShow.IsEnabled = true;
                gameProcessPage.bNext.IsEnabled = false;
                gameProcessPage.UserCardImage.Source = CurrentUser.Deck.Cards[0].PathToImage;
                gameProcessPage.tUserCunning.Text = CurrentUser.Deck.Cards[0].Cunning.ToString();
                gameProcessPage.tUserIntell.Text = CurrentUser.Deck.Cards[0].Intelligence.ToString();
                gameProcessPage.tUserPower.Text = CurrentUser.Deck.Cards[0].Power.ToString();
                gameProcessPage.tUserCardName.Text = CurrentUser.Deck.Cards[0].Title.ToString();
                gameProcessPage.BotCardImage.Source = new BitmapImage(new Uri("Resources/question-mark.png", UriKind.Relative));


            }
            else
            {
                gameProcessPage.bNext.IsEnabled = false;
                gameProcessPage.UserCardImage.Source = CurrentUser.Deck.Cards[0].PathToImage;
                gameProcessPage.tUserCunning.Text = CurrentUser.Deck.Cards[0].Cunning.ToString();
                gameProcessPage.tUserIntell.Text = CurrentUser.Deck.Cards[0].Intelligence.ToString();
                gameProcessPage.tUserPower.Text = CurrentUser.Deck.Cards[0].Power.ToString();
                gameProcessPage.tUserCardName.Text = CurrentUser.Deck.Cards[0].Title.ToString();
                gameProcessPage.BotCardImage.Source = new BitmapImage(new Uri("Resources/question-mark.png", UriKind.Relative));
                gameProcessPage.bUserCunning.IsEnabled = true;
                gameProcessPage.bUserIntelligence.IsEnabled = true;
                gameProcessPage.bUserPower.IsEnabled = true;
            }
        }

        private void HideCard(GameProcessPage gameProcessPage)
        {
            gameProcessPage.tBotPower.Text = "?";
            gameProcessPage.tBotCunning.Text = "?";
            gameProcessPage.tBotIntell.Text = "?";
            gameProcessPage.tUserPower.Foreground = new SolidColorBrush(Colors.Black);
            gameProcessPage.tBotPower.Foreground = new SolidColorBrush(Colors.Black);
            gameProcessPage.tUserCunning.Foreground = new SolidColorBrush(Colors.Black);
            gameProcessPage.tBotCunning.Foreground = new SolidColorBrush(Colors.Black);
            gameProcessPage.tUserIntell.Foreground = new SolidColorBrush(Colors.Black);
            gameProcessPage.tBotIntell.Foreground = new SolidColorBrush(Colors.Black);
        }

        internal void ChooseAttribute(GameProcessPage gameProcessPage, string selectedAttribute, bool IsUserMove)
        {
            
            gameProcessPage.BotCardImage.Source = CurrentBot.Deck.Cards[0].PathToImage;
            gameProcessPage.tBotCunning.Text = CurrentBot.Deck.Cards[0].Cunning.ToString();
            gameProcessPage.tBotIntell.Text = CurrentBot.Deck.Cards[0].Intelligence.ToString();
            gameProcessPage.tBotPower.Text = CurrentBot.Deck.Cards[0].Power.ToString();
            gameProcessPage.tBotCardName.Text = CurrentBot.Deck.Cards[0].Title.ToString();
            Random rnd = new Random();
            bool UserWon = false;
            selectedAttribute = selectedAttribute.ToLower();
                if((CurrentUser.CurrentCard.GetAttributeRank(selectedAttribute) == 1) && (CurrentBot.CurrentCard.GetAttributeRank(selectedAttribute) == 3))
                {
                UserWon = true;
                }
                if ((CurrentUser.CurrentCard.GetAttributeRank(selectedAttribute) == 1) && (CurrentBot.CurrentCard.GetAttributeRank(selectedAttribute) == 2))
                {
                UserWon = false;
                }
                
                if ((CurrentUser.CurrentCard.GetAttributeRank(selectedAttribute) == 2) && (CurrentBot.CurrentCard.GetAttributeRank(selectedAttribute) == 3))
                {
                UserWon = false;
                }
                if ((CurrentUser.CurrentCard.GetAttributeRank(selectedAttribute) == 2) && (CurrentBot.CurrentCard.GetAttributeRank(selectedAttribute) == 1))
                {
                UserWon = true;
                }
                if ((CurrentUser.CurrentCard.GetAttributeRank(selectedAttribute) == 3) && (CurrentBot.CurrentCard.GetAttributeRank(selectedAttribute) == 2))
                {
                UserWon = true;
                }
                if ((CurrentUser.CurrentCard.GetAttributeRank(selectedAttribute) == 3) && (CurrentBot.CurrentCard.GetAttributeRank(selectedAttribute) == 1))
                {
                UserWon = false;
                }
                if((CurrentUser.CurrentCard.GetAttributeRank(selectedAttribute) == (CurrentBot.CurrentCard.GetAttributeRank(selectedAttribute))))
                {
                if (selectedAttribute.ToLower() == "intelligence")
                {
                    if (CurrentUser.CurrentCard.Intelligence > CurrentBot.CurrentCard.Intelligence)
                    {
                        UserWon = true;
                    }
                    else if (CurrentUser.CurrentCard.Intelligence < CurrentBot.CurrentCard.Intelligence)
                    {
                        UserWon = false;
                    }
                }
                else if (selectedAttribute.ToLower() == "power")
                {
                    if (CurrentUser.CurrentCard.Power > CurrentBot.CurrentCard.Power)
                    {
                        UserWon = true;
                    }
                    else if (CurrentUser.CurrentCard.Power < CurrentBot.CurrentCard.Power)
                    {
                        UserWon = false;
                    }
                }
                else if (selectedAttribute.ToLower() == "cunning")
                {
                    if (CurrentUser.CurrentCard.Cunning > CurrentBot.CurrentCard.Cunning)
                    {
                        UserWon = true;
                    }
                    else if (CurrentUser.CurrentCard.Cunning < CurrentBot.CurrentCard.Cunning)
                    {
                        UserWon = false;
                    }
                }
                else
                {
                    if (rnd.Next(0, 1) == 0)
                    {
                        UserWon = false;
                    }
                    else
                    {
                        UserWon = true;
                    }
                }

                }
            if (UserWon)
            {
                CurrentBot.Deck.Cards.RemoveAt(0);
                gameProcessPage.tBotNumberOfCards.Text ="Deck: " + (CurrentBot.Deck.Cards.Count - 1).ToString();
                //gameProcessPage.BotCardImage.Source = new BitmapImage(new Uri("Resources/Death.png", UriKind.Relative));
                if (selectedAttribute.ToLower() == "power") 
                {
                    gameProcessPage.tBotPower.Foreground = new SolidColorBrush(Colors.Red);
                    gameProcessPage.tUserPower.Foreground = new SolidColorBrush(Colors.Green);
                }
                else if(selectedAttribute.ToLower() == "cunning")
                {
                    gameProcessPage.tBotCunning.Foreground = new SolidColorBrush(Colors.Red);
                    gameProcessPage.tUserCunning.Foreground = new SolidColorBrush(Colors.Green);
                }
                else
                {
                    gameProcessPage.tBotIntell.Foreground = new SolidColorBrush(Colors.Red);
                    gameProcessPage.tUserIntell.Foreground = new SolidColorBrush(Colors.Green);
                }

                
                
            }
            else
            {
                UserPlayedCards.Add(CurrentUser.CurrentCard);
                CurrentUser.Deck.Cards.RemoveAt(0);
                gameProcessPage.tUserNumberOfCards.Text = "Deck: " + (CurrentUser.Deck.Cards.Count - 1).ToString();
                //gameProcessPage.UserCardImage.Source = new BitmapImage(new Uri("Resources/Death.png", UriKind.Relative));
                if (selectedAttribute.ToLower() == "power")
                {
                    gameProcessPage.tUserPower.Foreground = new SolidColorBrush(Colors.Red);
                    gameProcessPage.tBotPower.Foreground = new SolidColorBrush(Colors.Green);
                }
                else if (selectedAttribute.ToLower() == "cunning")
                {
                    gameProcessPage.tUserCunning.Foreground = new SolidColorBrush(Colors.Red);
                    gameProcessPage.tBotCunning.Foreground = new SolidColorBrush(Colors.Green);
                }
                else
                {
                    gameProcessPage.tUserIntell.Foreground = new SolidColorBrush(Colors.Red);
                    gameProcessPage.tBotIntell.Foreground = new SolidColorBrush(Colors.Green);
                }
            }
            if (CurrentBot.Deck.Cards.Count == 0)
            {
                Navigator.ShowResult(gameProcessPage, true);
            }else if (CurrentUser.Deck.Cards.Count == 0)
            {
                Navigator.ShowResult(gameProcessPage, false);
            }
            else
            {
                CurrentUser.Deck.Shuffle();
                CurrentBot.Deck.Shuffle();
                CurrentBot.CurrentCard = CurrentBot.Deck.Cards[0];
                CurrentUser.CurrentCard = CurrentUser.Deck.Cards[0];
                if(IsUserMove)
                {
                    IsUserLastMove = true;
                    gameProcessPage.bUserCunning.IsEnabled = false;
                    gameProcessPage.bUserIntelligence.IsEnabled = false;
                    gameProcessPage.bUserPower.IsEnabled = false;
                    gameProcessPage.bNext.IsEnabled = true;
                }
                else
                {
                    IsUserLastMove = false;
                    gameProcessPage.bNext.IsEnabled = true;
                    gameProcessPage.bShow.IsEnabled = false;
                }
               
            }
            









        }

       
    }
}
