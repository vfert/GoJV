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
    /// Logique d'interaction pour WindowScoreAdmin.xaml
    /// </summary>
    public partial class WindowScoreAdmin : Window
    {
        private readonly DatabaseContext dbContext = new DatabaseContext();
        public WindowScoreAdmin()
        {
            var countTeam = dbContext.Teams.Count();

            InitializeComponent();
            var i = 0;
            dbContext.Teams.ToList().ForEach(f =>
            {
                gridScoreTeam.RowDefinitions.Add(new RowDefinition());
                var scoreControl = new UserControls.UserControlAdminScore(f.Score, f.Color, f.Name);
                Grid.SetRow(scoreControl, i++);
                gridScoreTeam.Children.Add(scoreControl);

            });
        }
    }
}
