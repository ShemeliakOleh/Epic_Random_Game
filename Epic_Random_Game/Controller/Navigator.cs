using Epic_Random_Game.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Epic_Random_Game
{
    public static class Navigator 
    {
        internal static void Login(StartPage startPage)
        {
            if (startPage.TName.Text != "")
            {
                var mainWindow = GetParentWindow(startPage);
                mainWindow.tUserName.Text = startPage.TName.Text;
                Play(startPage,mainWindow);

            }
        }
        internal static void Play(Page page,MainWindow mainWindow)
        {
           
            List<DeckOfCards> listOfDecks = new List<DeckOfCards>(CreateDecks());
            Game currentGame = new Game(listOfDecks[0].Shuffle(), listOfDecks[0].Shuffle());
            var newPage = new GameProcessPage(currentGame);
            mainWindow.mainPage.Navigate(newPage);
        }
        internal static void Play(Page page)
        {
            var mainWindow = GetParentWindow(page);
            List<DeckOfCards> listOfDecks = new List<DeckOfCards>(CreateDecks());
            Game currentGame = new Game(listOfDecks[0].Shuffle(), listOfDecks[0].Shuffle());
            var newPage = new GameProcessPage(currentGame);
            mainWindow.mainPage.Navigate(newPage);
        }

        internal static void ShowRating(MainWindow mainWindow)
        {
           
            var newPage = new RatingPage();
            mainWindow.mainPage.Navigate(newPage);
            using (ApplicationContext db = new ApplicationContext())
            {
                
                newPage.mainGridData.ItemsSource = db.Players.ToList();

            }
            
        }

        internal static void ShowHelp(MainWindow mainWindow)
        {
            var newPage = new HelpPage();
            mainWindow.mainPage.Navigate(newPage);
        }

        internal static void Play(MainWindow mainWindow)
        {
            if (mainWindow.tUserName.Text.Length > 0)
            {
                List<DeckOfCards> listOfDecks = new List<DeckOfCards>(CreateDecks());
                Game currentGame = new Game(listOfDecks[0].Shuffle(), listOfDecks[0].Shuffle());
                var newPage = new GameProcessPage(currentGame);
                mainWindow.mainPage.Navigate(newPage);
            }
            else
            {
                var newPage = new StartPage();
                mainWindow.mainPage.Navigate(newPage);
            }
        }

        internal static MainWindow GetParentWindow(Page page)
        {
            MainWindow parentWindowUser = (MainWindow)Window.GetWindow(page);
            return parentWindowUser;
        }

        private static IEnumerable<DeckOfCards> CreateDecks()
        {
            List<DeckOfCards> listOfDecks = new List<DeckOfCards>();
            
            Card card1 = new Card(3, 11, 6, "Resources/Abaddon_icon.png","Abaddon");
            Card card2 = new Card(13, 5, 9, "Resources/Anti-Mage_icon.png", "Anti-Mage");
            Card card3 = new Card(2, 14, 7, "Resources/Axe_icon.png", "Axe");
            Card card4 = new Card(15, 6, 4, "Resources/Batrider_icon.png", "Batrider");
            Card card5 = new Card(10, 1, 13, "Resources/Drow_Ranger_icon.png", "Drow_Ranger");
            Card card6 = new Card(3, 12, 8, "Resources/Ember_Spirit_icon.png", "Ember_Spirit");
            Card card7 = new Card(15, 6, 4, "Resources/Gyrocopter_icon.png", "Gyrocopter");
            Card card8 = new Card(12, 2, 7, "Resources/Juggernaut_icon.png", "Juggernaut");
            Card card9 = new Card(3, 9, 11, "Resources/Keeper_of_the_Light_icon.png", "Keeper_of_the_Light");
            Card card10 = new Card(7, 13, 5, "Resources/Lion_icon.png", "Lion");
            Card card11 = new Card(1, 10, 14, "Resources/Lycan_icon.png", "Lycan");
            Card card12 = new Card(15, 3, 9, "Resources/Morphling_icon.png", "Morphling");
            Card card13 = new Card(11, 8, 5, "Resources/Nature's_Prophet_icon.png", "Nature's_Prophet");
            Card card14 = new Card(6, 4, 13, "Resources/Night_Stalker_icon.png", "Night_Stalker");
            Card card15 = new Card(3, 9, 12, "Resources/Pudge_icon.png", "Pudge");
            Card card16 = new Card(14, 1, 10, "Resources/Riki_icon.png", "Riki");
            Card card17 = new Card(5, 11, 8, "Resources/Skywrath_Mage_icon.png", "Skywrath_Mage");
            Card card18 = new Card(14, 8, 5, "Resources/Techies_icon.png", "Techies");
            Card card19 = new Card(9, 4, 13, "Resources/Tiny_icon.png", "Tiny");
            Card card20 = new Card(2, 12, 8, "Resources/Tusk_icon.png", "Tusk");
            List<Card> cards = new List<Card>();
            cards.AddRange(new[] {card1,card2, card3, card4, card5, card6, card7, card8, card9, card10
            ,card11,card12,card13,card14,card15,card16,card17,card18,card19,card20});
            DeckOfCards Dota2Cards = new DeckOfCards(cards);
            listOfDecks.Add(Dota2Cards);
            //////
            ///
            return listOfDecks;
        }

        internal static void ShowResult(GameProcessPage gameProcessPage, bool IsUserWinner)
        {
            var mainWindow = GetParentWindow(gameProcessPage);
            var page = new ResultPage();
            page.tGameResult.Text = "You won!";
            page.tGameResult.Foreground = new SolidColorBrush(Colors.Green);
            mainWindow.mainPage.Navigate(page);
            if (IsUserWinner)
            {
                SetResult(mainWindow);
            }
            else
            {
                page.tGameResult.Text = "You lost!";
                page.tGameResult.Foreground = new SolidColorBrush(Colors.Red);
                mainWindow.mainPage.Navigate(page);
            }
        }

        private static async void SetResult(MainWindow mainWindow)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var players = await db.Players
                                .Where(p => p.Name == mainWindow.tUserName.Text)
                                .ToListAsync();
                if (players.Count > 0)
                {
                    players[0].Points++;
                }
                else
                {
                    Player player = new Player { Name = mainWindow.tUserName.Text, Points = 1 };
                    db.Players.Update(player);
                }

                db.SaveChanges();
            }
        }
    }
}
