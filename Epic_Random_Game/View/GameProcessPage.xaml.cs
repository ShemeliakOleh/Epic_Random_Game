using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Epic_Random_Game
{
    /// <summary>
    /// Interaction logic for GameProcessPage.xaml
    /// </summary>
    public partial class GameProcessPage : Page
    {
        public Game CurrentGame { get; set; }
        public GameProcessPage(Game game)
        {
            CurrentGame = game;
            InitializeComponent();
            
        }

        private void bNext_Click(object sender, RoutedEventArgs e)
        {
            CurrentGame.NextMove(this);
        }

        private void bShow_Click(object sender, RoutedEventArgs e)
        {
            CurrentGame.ShowCard(this);
        }

        private void bUserIntelligence_Click(object sender, RoutedEventArgs e)
        {
            CurrentGame.ChooseAttribute(this, "Intelligence",true);
        }

        private void bUserPower_Click(object sender, RoutedEventArgs e)
        {
            CurrentGame.ChooseAttribute(this, "Power", true);
        }

        private void bUserCunning_Click(object sender, RoutedEventArgs e)
        {
            CurrentGame.ChooseAttribute(this, "Cunning", true);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CurrentGame.Start(this);
        }
    }
}
