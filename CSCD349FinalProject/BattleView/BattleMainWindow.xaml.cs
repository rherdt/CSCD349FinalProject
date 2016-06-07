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
using System.Windows.Controls.Primitives;

namespace BattleView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    partial class BattleMainWindow : Window
    {
        SoundPlayer music;
        private Party user;
        private IEnemyParty enemy;
        private int floor;

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
                UserParty.Fill = user.GetImg();
            }
        }

        internal IEnemyParty Enemy
        {
            get
            {
                return enemy;
            }

            set
            {
                enemy = value;
                EnemyHealth.Value = enemy.getHP();
                EnemyParty.Fill = enemy.GetImg();
                WriteOutput("You are being attacked by " + enemy.GetName());
            }
        }

        internal int Floor
        {
            get
            {
                return floor;
            }

            set
            {
                floor = value;
            }
        }

        public BattleMainWindow()
        {
            InitializeComponent();
            InitializeEnemy();
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
        private void DestroyedEnemy()
        {
            WriteOutput("You have slain the enemy party");
            user.LevelUp();
            Close();
        }
        private void UserAttack()
        {
            int damage = UserAttacking();
            if (EnemyDefend())
            {
                if (enemy.TakeDamage(damage))
                {
                    EnemyHealth.Value = (EnemyHealth.Value - damage);
                    WriteOutput("The enemy party took " + damage + " points of damage");
                    BattleVictory();
                }
                else
                {
                    EnemyHealth.Value = (EnemyHealth.Value - damage);
                    WriteOutput("The enemy party took " + damage + " points of damage");
                }
            }
            else
            {
                WriteOutput("Your attack missed...");
            }
        }
        private string UseItem()
        {

            return "";
        }
        private void EnemyAttack()
        {
            int damage = EnemyAttacking();
            if (!UserDefend())
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
        private int UserAttacking()
        {
            Random rand = new Random();
            if ((user.GetPartyAttack() * rand.NextDouble()) > .3)
            {
                return Convert.ToInt32(Math.Floor(Convert.ToInt32(user.GetPartyAttack()) * rand.NextDouble()));
            }
            else
            {
                return 0;
            }
        }
        private int EnemyAttacking()
        {
            Random rand = new Random();
            if ((enemy.GetAttack() * rand.NextDouble()) > .3)
            {
                return Convert.ToInt32(Math.Floor(Convert.ToInt32(enemy.GetAttack()) * rand.NextDouble()));
            }
            else
            {
                return 0;
            }
        }
        private bool UserDefend()
        {
            Random rand = new Random();
            if((user.GetPartyDefense()*rand.NextDouble()) > 2*user.GetLevel())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool EnemyDefend()
        {
            Random rand = new Random();
            if (((enemy.GetDefense() + floor) * rand.NextDouble()) < rand.NextDouble()*user.GetLevel()+2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void BattleVictory()
        {
            MessageBox.Show(this, "You have vanquished the " + enemy.GetName() + "\n The party has leveled up");
            user.LevelUp();
            this.Close();
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            music.Stop();
            
        }

        private void InitializeEnemy()
        {
            Random rand = new Random();
            int val = rand.Next(3);

            if (val == 0)
                enemy = new Mutants();

            else if (val == 1)
                enemy = new Zombies();

            else
                enemy = new Raiders();

            EnemyHealth.Value = enemy.getHP();
            EnemyParty.Fill = enemy.GetImg();
            WriteOutput("You are being attacked by " + enemy.GetName());
        }
    }
}
