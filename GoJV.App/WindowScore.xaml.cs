using GoJV.DAL;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GoJV.App
{
    /// <summary>
    /// Logique d'interaction pour WindowScore.xaml
    /// </summary>
    public partial class WindowScore : Window
    {
        private readonly DatabaseContext dbContext = new DatabaseContext();
        public WindowScore()
        {
            var countTeam = dbContext.Teams.Count();

            InitializeComponent();
            var i = 0;
            var teams = dbContext.Teams.ToList();
            var teamsRanked = teams.OrderBy(s => s.Score).Select((n, index) => new { n, index });
            teams.ToList().ForEach(f =>
            {
                gridScore.ColumnDefinitions.Add(new ColumnDefinition());
                var scoreControl = new UserControls.UserControlScore(f.Score, f.Color, f.Name, teamsRanked.Single(s => s.n.Id == f.Id).index);
                Grid.SetColumn(scoreControl, i++);
                gridScore.Children.Add(scoreControl);

            });

            mediaElementBackground.Source = new Uri($"{AppContext.BaseDirectory}Media/FallingStars.mp4");
            mediaElementBackground.LoadedBehavior = MediaState.Play;
            mediaElementSoundBack.Source = new Uri($"{AppContext.BaseDirectory}Media/mixkit-arcade-rising-231.wav");
            mediaElementBackground.LoadedBehavior = MediaState.Play;

        }

        private void MediaTimeline_CurrentTimeInvalidated(object sender, EventArgs e)
        {

        }

        private void MediaTimeChanged(object sender, EventArgs e)
        {

        }

        private void Element_MediaOpened(object sender, RoutedEventArgs e)
        {
        }
    }
}
