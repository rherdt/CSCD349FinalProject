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
using System.Threading;

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

        internal Party User
        {
            get
            {
                return user;
            }

            set
            {
                user = value;
                UserHealth.Value = user.GetHP();
            }
        }

        internal Party Enemy
        {
            get
            {
                return enemy;
            }

            set
            {
                enemy = value;
                EnemyHealth.Value = enemy.GetHP();
            }
        }

        public BattleMainWindow()
        {
            InitializeComponent();
            PlayFile();
        }
        private void Attack_Click(object sender, RoutedEventArgs e)
        {
            WriteOutput("Attacking Enemy...");
            UserAttack();
            WriteOutput("The enemy is attacking you...");
            EnemyAttack();
        }
        private void WriteOutput(string text)
        {
            Output.AppendText(text + "\n");
            Output.ScrollToEnd();
        }
        private void Mute_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)Mute.IsChecked)
            {
                music.Stop();
            }
            else
            {
                music.Play();
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
            User = userParty;
            Enemy = enemyParty;
        }
        private void DestroyedEnemy()
        {
            WriteOutput("You have slain the enemy party");
            user.LevelUp();
            Close();
        }
        private void UserAttack()
        {
            int damage = Attacking(user);
            if (Defend(enemy))
            {
                enemy.TakeDamage(damage);
                EnemyHealth.Value = (EnemyHealth.Value - damage);
                WriteOutput("The enemy party took " + damage + " points of damage");
            }
            else
            {
                WriteOutput("Your attack missed...");
            }
        }
        private void EnemyAttack()
        {
            int damage = Attacking(enemy);
            if (!Defend(user))
            {
                UserHealth.Value = (UserHealth.Value - damage);
                WriteOutput("Your party took " + damage + " points of damage");
                user.TakeDamage(damage);
            }
            else
            {
                WriteOutput("The enemies attack missed...");
            }
        }
        private int Attacking(Party attacker)
        {
            Random rand = new Random();
            if ((attacker.GetPartyAttack() * rand.NextDouble()) > .3)
            {
                return Convert.ToInt32(Math.Floor(Convert.ToInt32(attacker.GetPartyAttack()) * rand.NextDouble()));
            }
            else
            {
                return 0;
            }
        }
        private bool Defend(Party defender)
        {
            Random rand = new Random();
            if((defender.GetPartyDefense()*rand.NextDouble()) > .4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
