using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace GoJV.App.UserControls
{
    /// <summary>
    /// Logique d'interaction pour UserControlMediaPlay.xaml
    /// </summary>
    public partial class UserControlMediaPlay : UserControl
    {
        private bool isPaused=false;
        public string MediaPath { get; set; }
        public UserControlMediaPlay()
        {
            InitializeComponent();

        }

        private void btnSong_Click(object sender, RoutedEventArgs e)
        {
            PlayerPause();
        }

        public void PlayerPause()
        {
            if (!isPaused)
            {
                mdSong.Play();
                btnSong.Content = "Play";
                isPaused = true;
            }
            else
            {
                mdSong.Pause();
                btnSong.Content = "Pause";
                isPaused = false;
            }
        }

        private void btnMedia_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media files (*.mp3)|*.mp3|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                MediaPath = openFileDialog.FileName;
                mdSong.Volume = 1;
                mdSong.Source = new Uri(MediaPath);
                mdSong.Position = new TimeSpan(60000);
                tbName.Text = MediaPath.Remove(0, MediaPath.LastIndexOf('\\') + 1);
            }
        }


        private void MediaFailedHandler(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBox.Show("Une erreur est survenue durant le chargement du média.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void mdSong_MediaOpened(object sender, RoutedEventArgs e)
        {
            sldPosition.Maximum = mdSong.NaturalDuration.TimeSpan.TotalSeconds;
            sldPosition.Value = mdSong.Position.TotalSeconds;
        }
    }
}
