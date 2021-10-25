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
using System.Windows.Shapes;
using System.Media;
using GoJV.App.UserControls;

namespace GoJV.App
{
    /// <summary>
    /// Logique d'interaction pour WindowMedia.xaml
    /// </summary>
    public partial class WindowMedia : Window
    {
        public WindowMedia()
        {
            InitializeComponent();
        }

        private void btnSongAll_Click(object sender, RoutedEventArgs e)
        {
            Media1.PlayerPause();
            Media2.PlayerPause();
            Media3.PlayerPause();
            Media4.PlayerPause();
            Media5.PlayerPause();
            Media6.PlayerPause();
        }
    }
}
