using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Drawing;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CSCD349FinalProject.States;
using CSCD349FinalProject.Spaces;
using CSCD349FinalProject.GamePlay;
using CSCD349FinalProject.Characters;
using System.Windows.Controls.Primitives;
using CSCD349FinalProject.Inventory;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Data;

namespace CSCD349FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Map gameBoardMap;
        private static int floor = 1;
        private Party party;
        private int difficulty;
        private int LoadedHealth;

        public MainWindow()
        {
            InitializeComponent();
            gameBoardMap = new Map(10, 10, party);
            CreateGameBoard();
        }

        public MainWindow(int difficulty, int party)
        {
            InitializeComponent();
            this.difficulty = difficulty;
            this.party = new Party(party);
            PartyLevel.Text = this.party.GetLevel().ToString();
            gameBoardMap = new Map(10, 10, this.party);
            CreateGameBoard();
            InitializeInventory();
            RoutedCommand ToggleStatCheats = new RoutedCommand();
            ToggleStatCheats.InputGestures.Add(new KeyGesture(Key.P, ModifierKeys.Control));
            CommandBindings.Add(new CommandBinding(ToggleStatCheats, ToggleCheats));
        }
        public MainWindow(int difficulty, int party,int health)
        {
            InitializeComponent();
            this.difficulty = difficulty;
            this.party = new Party(party);
            PartyLevel.Text = this.party.GetLevel().ToString();
            gameBoardMap = new Map(10, 10, this.party);
            CreateGameBoard();
            InitializeInventory();
            RoutedCommand ToggleStatCheats = new RoutedCommand();
            ToggleStatCheats.InputGestures.Add(new KeyGesture(Key.P, ModifierKeys.Control));
            CommandBindings.Add(new CommandBinding(ToggleStatCheats, ToggleCheats));
            LoadedHealth = health;
            HealthBar.Value = LoadedHealth;
        }
        private void CreateGameBoard()
        {
            ISpace currentSpace;
            int i = 0;
            ImageBrush texture = new ImageBrush();
            texture.ImageSource = new BitmapImage(new Uri(@"../../Images/metal_plates.png", UriKind.Relative));

            for (int a = 0; a < gameBoardMap.GetColumns(); a++)
            {
                GameBoard.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int b = 0; b < gameBoardMap.GetRows(); b++)
            {
                GameBoard.RowDefinitions.Add(new RowDefinition());
            }

            for (int row = 0; row < GameBoard.RowDefinitions.Count; row++)
            {
                for (int column = 0; column < GameBoard.ColumnDefinitions.Count; column++)
                {
                    i++;
                    currentSpace = gameBoardMap.GetBoardSpace(row, column);
                    currentSpace.getSpace().Width = GameBoard.Width / gameBoardMap.GetColumns();
                    currentSpace.getSpace().Height = GameBoard.Width / gameBoardMap.GetColumns();
                    currentSpace.getSpace().Background = texture;
                    currentSpace.getSpace().VerticalAlignment = VerticalAlignment.Center;
                    currentSpace.getSpace().SetValue(Grid.ColumnProperty, column);
                    currentSpace.getSpace().SetValue(Grid.RowProperty, row);

                    GameBoard.Children.Add(currentSpace.getSpace());
                }
            }

            InitializePlayer();
            InitializeStairs();

        }

        private void Reset()
        {
            GameBoard.RowDefinitions.Clear();
            GameBoard.ColumnDefinitions.Clear();
            GameBoard.Children.Clear();           
        }

        private void InitializeInventory()
        {
            int slots = party.GetInventory().getNumSlots();
            Border[] borderArray = new Border[slots];

            for(int x = 0; x < slots; x++)
            {
                InventoryGrid.ColumnDefinitions.Add(new ColumnDefinition());
                borderArray[x] = new Border();
                borderArray[x].Height = InventoryGrid.Height;
                borderArray[x].Width = InventoryGrid.Width / slots;
                borderArray[x].Background = Brushes.Gray;
                borderArray[x].VerticalAlignment = VerticalAlignment.Center;
                borderArray[x].SetValue(Grid.ColumnProperty, x);

                InventoryGrid.Children.Add(borderArray[x]);

            }
        }

        public void RedrawInventory()
        {

            int numItems = party.GetInventory().GetItems().Count;

            for(int x = 0; x < numItems; x++)
            {
                Border b = (Border)InventoryGrid.Children[x];
                b.Background = party.GetInventory().GetItems().ElementAt(x).GetImg();
                b.Tag = party.GetInventory().GetItems().ElementAt(x);
                InventoryGrid.Children[x].MouseLeftButtonDown -= new MouseButtonEventHandler(InventoryItemClick);
                InventoryGrid.Children[x].MouseLeftButtonDown += new MouseButtonEventHandler(InventoryItemClick);
            }
        }


        private void InitializePlayer()
        {
            gameBoardMap.DrawSprite(gameBoardMap.GetRows() - 1, 0);
            gameBoardMap.SetCurrentPosition(gameBoardMap.GetRows() - 1, 0);
        }

        public int GetFloor()
        {
            return floor;
        }

        public void NextFloor()
        {
            CheckIfWin();
            Reset();
            gameBoardMap = new Map(10, 10, this.party);
            CreateGameBoard();
            floor++;
            FloorNumberLabel.Content = floor;
        }

        private void InitializeStairs()
        {
            ImageBrush texture = new ImageBrush();
            texture.ImageSource = new BitmapImage(new Uri(@"../../Images/stairs.png", UriKind.Relative));

            Rectangle rec = new Rectangle();
            rec.Height = 60;
            rec.Width = 60;
            rec.Fill = texture;
            gameBoardMap.GetBoardSpace(0, gameBoardMap.GetColumns() - 1).getSpace().Child = rec;
        }

        private void checkSpace()
        {
            gameBoardMap.GetBoardSpace((int)gameBoardMap.GetCurrentPosition().X, (int)gameBoardMap.GetCurrentPosition().Y).runAction(party,this);
            
        }

        private void MainWindow1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                PlayerMovement.KeyUp(gameBoardMap);
                //checkSpace();
            }
            else if (e.Key == Key.Down)
            {
                PlayerMovement.KeyDown(gameBoardMap);
                //checkSpace();
            }
            else if(e.Key == Key.Right)
            {
                PlayerMovement.KeyRight(gameBoardMap);
                //checkSpace();
            }
            else if (e.Key == Key.Left)
            {
                PlayerMovement.KeyLeft(gameBoardMap);
                //checkSpace();
            }
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

        private void MainWindow1_Activated(object sender, EventArgs e)
        {
            HealthBar.Value = LoadedHealth;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveGame();
        }
        private void SaveGame()
        {
            party.Savedname = textBox.Text;
            Random random = new Random();

            string connection = "Data Source = ../../GameSaves.db; Version = 3; Password = test;";
            string command = "INSERT INTO  [SavedGames] Values(" + Convert.ToInt32(Math.Floor(random.NextDouble() * 1000)) + ",'" + party.Savedname + "', " + gameBoardMap.getLevel() + ", " + party.GetLevel() + ", " + party.GetPartyType() + ", " + party.GetHP() + ");";
            SQLiteConnection connect = new SQLiteConnection(connection);
            connect.Open();
            SQLiteCommand run = new SQLiteCommand(command,connect);
            run.ExecuteNonQuery();
        }

        private SqlDataAdapter SqlDataAdapter(object selectCommand, object connectionString)
        {
            throw new NotImplementedException();
        }
        public void setLevel(int lv)
        {
            PartyLevel.Text = lv.ToString();
        }
        public void setPartyHP(int hp)
        {
            HealthBar.Value = hp;
        }
        private void ToggleCheats(object sender, ExecutedRoutedEventArgs e)
        {
            party.ToggleCheat();
            MessageBox.Show("Cheats Toggled");
        }

        private void CheckIfWin()
        {
            if (difficulty == 1)
            {
                if (floor == 5)
                {
                    Winner win = new Winner();
                    win.ShowDialog();
                }
            }

            if (difficulty == 2)
            {
                if (floor == 10)
                {
                    Winner win = new Winner();
                    win.ShowDialog();
                }
            }

            if (difficulty == 3)
            {
                if (floor == 15)
                {
                    Winner win = new Winner();
                    win.ShowDialog();
                }
            }
        }

        private void InventoryItemClick(object sender, RoutedEventArgs e)
        {
            Border b = (Border)sender;
            if(b.Tag != null)
            {
                party.GetInventory().UseItem((IInvItem)b.Tag);
                foreach(Border bor in InventoryGrid.Children)
                {
                    bor.Background = Brushes.Gray;
                }
                RedrawInventory();
            }
        }
    }
}
