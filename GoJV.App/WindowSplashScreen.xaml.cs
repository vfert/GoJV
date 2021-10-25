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

namespace GoJV.App
{
    /// <summary>
    /// Logique d'interaction pour WindowSplashScreen.xaml
    /// </summary>
    public partial class WindowSplashScreen : Window
    {
        public WindowSplashScreen()
        {
            InitializeComponent();
            mdElement.Source = new Uri(Environment.CurrentDirectory + @"\Media\street-fighter-4-vs-effect-chroma-key.mp4");
            mdElement.Play();
        }

        private void mdElement_Unloaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
