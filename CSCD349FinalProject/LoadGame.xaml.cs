using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
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
using System.Windows.Shapes;

namespace CSCD349FinalProject
{
    /// <summary>
    /// Interaction logic for LoadGame.xaml
    /// </summary>
    public partial class LoadGame : Window
    {
        DataSet savedGames;
        public LoadGame()
        {
            InitializeComponent();
        }
        public LoadGame(DataSet reader)
        {
            InitializeComponent();
            savedGames = reader;
            PullSaved(reader);
        }
        public void PullSaved(DataSet reader)
        {
            dataGrid.ItemsSource = reader.Tables["SavedGameMain"].DefaultView;
        }

    }
}
