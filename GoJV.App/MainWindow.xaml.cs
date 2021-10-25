using GoJV.DAL;
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

namespace GoJV.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DatabaseContext dbContext = new DatabaseContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Score_Click(object sender, RoutedEventArgs e)
        {
            if (!dbContext.Teams.Any())
                MessageBox.Show("Aucune équipe n'a été créée", "Attention", MessageBoxButton.OK, MessageBoxImage.Stop);
            else
            {
                var scoreWindow = new WindowScore();
                scoreWindow.Show();
            }
        }

        private void Media_Click(object sender, RoutedEventArgs e)
        {
            var media = new WindowMedia();
            media.Show();
        }

        private void SplashScreen_Click(object sender, RoutedEventArgs e)
        {
            var splash = new WindowSplashScreen();
            splash.Show();
        }

        private void Teams_Click(object sender, RoutedEventArgs e)
        {
            var teams = new WindowTeams();
            teams.Show();
        }

        private void Players_Click(object sender, RoutedEventArgs e)
        {
            var player = new WindowPlayer();
            player.Show();
        }

        private void AdminScore_Click(object sender, RoutedEventArgs e)
        {
            var adminScore = new WindowScoreAdmin();
            adminScore.Show();
        }
    }
}
