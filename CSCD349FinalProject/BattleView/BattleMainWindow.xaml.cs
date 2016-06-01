using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Media;
using System.IO;
using CSCD349FinalProject.Properties;
using System.ComponentModel;
using CSCD349FinalProject.Characters;

namespace BattleView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    partial class BattleMainWindow : Window
    {
        SoundPlayer music;
        private Party user;
        private Party enemy;

        public BattleMainWindow()
        {
            InitializeComponent();
            PlayFile();
        }

        private void Attack_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void Mute_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)Mute.IsChecked)
            {
               // player.settings.mute = true;
               
            }
            else
            {
             //   player.settings.mute = false;
            }
        }
        private void PlayFile()
        {
            music = new SoundPlayer();
            music.Stream = CSCD349FinalProject.Properties.Resources.battlemusic;
            music.Play();
        }
        private void BattleMainWindow_Closing(object sender, CancelEventArgs e)
        {
            music.Stop();
        }
        private void setPartys(Party userParty,Party enemyParty)
        {
            user = userParty;
            enemy = enemyParty;
        }
        public void Battle()
        {
            //battle logic 
        }
    }
}
