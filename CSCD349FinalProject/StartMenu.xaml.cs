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
            mw.Show();
            this.Close();
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
    }


}
