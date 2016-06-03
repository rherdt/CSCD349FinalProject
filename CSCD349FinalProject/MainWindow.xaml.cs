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
            gameBoardMap = new Map(10, 10, this.party);
            CreateGameBoard();
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


        }


        private void InitializePlayer()
        {
            gameBoardMap.DrawSprite(gameBoardMap.GetRows() - 1, 0);
            gameBoardMap.SetCurrentPosition(gameBoardMap.GetRows() - 1, 0);
        }

        public void NextFloor()
        {
            Reset();
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
                checkSpace();
            }
            else if (e.Key == Key.Down)
            {
                PlayerMovement.KeyDown(gameBoardMap);
                checkSpace();
            }
            else if(e.Key == Key.Right)
            {
                PlayerMovement.KeyRight(gameBoardMap);
                checkSpace();
            }
            else if (e.Key == Key.Left)
            {
                PlayerMovement.KeyLeft(gameBoardMap);
                checkSpace();
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
    }
}
