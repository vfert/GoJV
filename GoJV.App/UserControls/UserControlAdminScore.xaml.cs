using GoJV.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Logique d'interaction pour UserControlAdminScore.xaml
    /// </summary>
    public partial class UserControlAdminScore : UserControl
    {
        private readonly DatabaseContext dbContext = new DatabaseContext();
        private Team _team;
        public UserControlAdminScore(int score, string color, string team)
        {
            InitializeComponent();
            _team = dbContext.Teams.Single(t => t.Name == team);
            tbName.Text = _team.Name;
            tbCurrentScore.Text = _team.Score.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(tbScore.Text, out var scoreToAdd);
            _team.Score += scoreToAdd;
            dbContext.SaveChanges();
            tbCurrentScore.Text = _team.Score.ToString();
        }
    }
}
