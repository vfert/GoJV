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
using System.Windows.Shapes;

namespace GoJV.App
{
    /// <summary>
    /// Logique d'interaction pour WindowTeams.xaml
    /// </summary>
    public partial class WindowTeams : Window
    {
        private readonly DatabaseContext dbContext = new DatabaseContext();
        public WindowTeams()
        {
            InitializeComponent();
            LoadTeams();
        }

        private void LoadTeams()
        {
            lstTeams.Items.Clear();
            dbContext.Teams.ToList().ForEach(s =>
            {
                lstTeams.Items.Add(s);
            });
        }

        private void btSubmit_Click(object sender, RoutedEventArgs e)
        {
            var newTeam = new Team
            {
                Color = ((ComboBoxItem)cbColor.SelectedItem).Background.ToString(),
                Name = tbName.Text
            };
            dbContext.Teams.Add(newTeam);
            dbContext.SaveChanges();
            LoadTeams();
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            var team = (Team)lstTeams.SelectedItem;
            if (team != null)
            {
                var teamToDelete = dbContext.Teams.Single(s => s.Id == team.Id);
                dbContext.Remove(teamToDelete);
                dbContext.SaveChanges();
                LoadTeams();
            }
        }
    }
}
