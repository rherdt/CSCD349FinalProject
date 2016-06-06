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
        SQLiteDataReader savedGames;
        StartMenu loadscreen;
        public LoadGame()
        {
            InitializeComponent();
        }
        public LoadGame(SQLiteDataReader reader,string name)
        {
            InitializeComponent();
            savedGames = reader;
            PullSaved(reader);
        }
        public void PullSaved(SQLiteDataReader reader)
        {
            int x, y;
            while (reader.Read())
            {
                listBox.Items.Add(reader.GetString(1));
            }
            
        }
        public void SetSetSave(Window parent)
        {
            loadscreen = (StartMenu)parent;
        }
        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            loadscreen.SetSelected(e.AddedItems[0].ToString());
            this.Close();
        }
    }
}
