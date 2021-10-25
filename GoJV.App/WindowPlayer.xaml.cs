using GoJV.DAL;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace GoJV.App
{
    /// <summary>
    /// Logique d'interaction pour WindowPlayer.xaml
    /// </summary>
    public partial class WindowPlayer : Window
    {
        private readonly DatabaseContext dbContext = new DatabaseContext();
        public WindowPlayer()
        {
            InitializeComponent();
            LoadPlayers();
            LoadTeams();
        }

        private void LoadPlayers()
        {
            lstPlayers.Items.Clear();
            var players = dbContext.Players.ToList();
            tbCounter.Text = players.Count().ToString();
            players.ForEach(s =>
            {
                lstPlayers.Items.Add(s);
            });
        }

        private void LoadTeams()
        {
            cbTeam.ItemsSource = dbContext.Teams.ToList();
            cbTeam.ItemsSource.Cast<Team>().ToList().Add(new Team
            {
                Id = 0,
                Name = "Nouvelle équipe",
                Color = "blanc"
            });
        }

        private void btSubmit_Click(object sender, RoutedEventArgs e)
        {
            if(!validPlayer()) return;
            var newPlayer = new Player
            {
                Name = tbName.Text,
                Image = imgPlayer.Source.ToString(),
                Team = (Team)cbTeam.SelectedItem
            };
            dbContext.Players.Add(newPlayer);
            dbContext.SaveChanges();
            LoadPlayers();
            tbName.Text = string.Empty;
            imgPlayer.Source = null;
            tbCounter.Text = dbContext.Players.Count().ToString();
        }

        private bool validPlayer()
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Aucun nom de joueur saisie", "Attention", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            if(dbContext.Players.Any(a => a.Name.ToLower() == tbName.Text.ToLower()))
            {
                MessageBox.Show("Ce jouer existe déjà", "Attention", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
        
            if (string.IsNullOrEmpty(imgPlayer.Source?.ToString().TrimEnd()))
            {
                MessageBox.Show("Aucune image sélectionnée", "Attention", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }

            if ((Team)cbTeam.SelectedItem == null)
            {
                MessageBox.Show("Aucune équipe sélectionnée", "Attention", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            return true;
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            var player = (Player)lstPlayers.SelectedItem;
            if (player != null)
            {
                var playerToDelete = dbContext.Players.Single(s => s.Id == player.Id);
                dbContext.Remove(playerToDelete);
                dbContext.SaveChanges();
                LoadPlayers();
            }
        }

        private void btImg_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                imgPlayer.Source = new BitmapImage(fileUri);
            }
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            if (Tag.ToString() == "NewTeam")
            {
                new WindowTeams().Show();
            }
        }

        private void lstPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var player = (Player)lstPlayers.SelectedItem;
            if (player != null)
            {
                imgPlayer.Source = new BitmapImage(new Uri(player.Image));
                tbName.Text = player.Name;
                cbTeam.SelectedItem = player.Team;
            }
        }
    }
}
