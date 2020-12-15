using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.mainPage.Navigate(new StartPage());
        }

        private void bExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void mItemPlay_Click(object sender, RoutedEventArgs e)
        {
            Navigator.Play(this);
        }

        private void mItemRating_Click(object sender, RoutedEventArgs e)
        {
            Navigator.ShowRating(this);
        }

        private void mItemHelp_Click(object sender, RoutedEventArgs e)
        {
            Navigator.ShowHelp(this);
        }

        private void mItemExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
