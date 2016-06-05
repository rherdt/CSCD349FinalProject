using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
using System.IO;
using CSCD349FinalProject.Properties;

namespace CSCD349FinalProject.GamePlay.BattleView
{
    /// <summary>
    /// Interaction logic for BattleWindow.xaml
    /// </summary>
    public partial class BattleWindow : Window
    {
        SoundPlayer music;

        public BattleWindow(ImageBrush user, ImageBrush enemy)
        {
            InitializeComponent();
            PlayFile();
            UserImage.Source = user.ImageSource;
            EnemyImage.Source = enemy.ImageSource;
        }
        private void PlayFile()
        {
            music = new SoundPlayer();
            music.Stream = CSCD349FinalProject.Properties.Resources.battlemusic;
            music.Play();
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            music.Stop();
        }
    }
}
