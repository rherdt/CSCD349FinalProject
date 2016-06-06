using CSCD349FinalProject.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CSCD349FinalProject.Spaces;
using System.Data.SqlClient;
using System.Data;

namespace CSCD349FinalProject
{
    /// <summary>
    /// Interaction logic for StartMenu.xaml
    /// </summary>
    public partial class StartMenu : Window
    {
        ToggleButton difficulty = null;
        ToggleButton party = null;

        public StartMenu()
        {
            InitializeComponent();
        }

        private void ButtonChecked(object sender, RoutedEventArgs e)
        {
            ToggleButton tb = (ToggleButton)sender;
            tb.Foreground = Brushes.Green;
            difficulty = tb;
        }

        private void ButtonUnchecked(object sender, RoutedEventArgs e)
        {
            ToggleButton tb = (ToggleButton)sender;
            tb.Foreground = Brushes.Lime;
        }

        private void PartyButtonChecked(object sender, RoutedEventArgs e)
        {
            ToggleButton tb = (ToggleButton)sender;
            party = tb;
        }

        private void PreviewReadyButtonClick(object sender, RoutedEventArgs e)
        {
            if (difficulty != null)
            {
                if (party != null)
                {
                    ReadyButtonClick(sender, e);
                }
            }

            e.Handled = true;
        }

        private void ReadyButtonClick(object sender, RoutedEventArgs e)
        {
            //Need to pass difficulty and party to next window.

            MainWindow mw = new MainWindow(ConvertDifficultyButtonToNumber(), ConvertPartyButtonToNumber());
            this.Close();
            mw.ShowDialog();
        }

        private int ConvertDifficultyButtonToNumber()
        {
            if (difficulty == easyButton)
                return 1;

            else if (difficulty == normalButton)
                return 2;

            else
                return 3;
        }

        private int ConvertPartyButtonToNumber()
        {
            if (party == sharpshooterPartyButton)
                return 1;

            else if (party == medicsPartyButton)
                return 2;

            else if (party == tanksPartyButton)
                return 3;

            else
                return 4;
        }

        private void MenuExitClick(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void AboutMenuClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Developer: Brogrammers\r\n\r\nVersion: 1.0\r\n\r\n.NET Framework Version: 4.5.2\r\n\r\nBit Version: 32-bit" +
                "\r\n\r\nBattle Music: Property of Nintendo,\r\n\t     Composed by Junichi Masuda");
        }

        private void HelpMenuClick(object sender, RoutedEventArgs e)
        {
            HelpWindow hw = new HelpWindow();
            hw.Show();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //pass in difficulty from sql and party info
            string name = "test";
            int level = 1;
            int partytype = 1;
            int health = 100;
            int floornumber = 1;
            string command = "Select * From SavedGameMain;";
            string connection = "SavedGames.sqlite3";
            DataSet ds = new DataSet("SavedGames");
            SqlDataAdapter sqd = new SqlDataAdapter(command, connection);
            sqd = new SqlDataAdapter();
            sqd.Fill(ds);
            LoadGame lgScreen = new LoadGame(ds);
            Party partyLoad = new Party(partytype);
            partyLoad.SetPartyLevel(level);
            partyLoad.Savedname = name;
            partyLoad.setHealth(health);
            Map loadedMap = new Map(10, 10, partyLoad);
            loadedMap.setLevel(floornumber);
            MainWindow mw = new MainWindow(1, ConvertPartyButtonToNumber());
            this.Close();
            mw.ShowDialog();
        }
    }
}
