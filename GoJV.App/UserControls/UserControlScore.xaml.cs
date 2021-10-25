using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GoJV.App.UserControls
{
    /// <summary>
    /// Logique d'interaction pour UserControlScore.xaml
    /// </summary>
    public partial class UserControlScore : UserControl
    {
        public double Score { get; set; }
        public string Color { get; set; }
        public string Team { get; set; }
        public int Rank { get; set; }

        public UserControlScore( int score, string color, string team, int rank)
        {
            Score = score;
            Rank = rank;
            InitializeComponent();
            tbScore.Text = Score.ToString();
            teamName.Text = team;
            doubleAnimationRectDrawing.From = 0;
            doubleAnimationRectDrawing.To = score;
            doubleAnimationRectDrawing.Duration = new Duration(TimeSpan.FromSeconds(Rank + 1));

            doubleAnimationScoreOpacity.BeginTime = TimeSpan.FromSeconds(Rank + 1);
            mediaTimeLineSound.BeginTime = TimeSpan.FromSeconds(Rank + 1.1);
            var colorToBrush = (Color)ColorConverter.ConvertFromString(color);
            var myBrush = new LinearGradientBrush(colorToBrush, colorToBrush + colorToBrush, 4);
            rectScore.Fill = myBrush;
            mediaTimeLineSound.Source = new Uri($"{AppContext.BaseDirectory}Media/mixkit-arcade-score-interface-217.wav");
        }

    }
}
