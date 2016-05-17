﻿using System;
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
using CSCD349FinalProject.States;
using CSCD349FinalProject.Spaces;
using CSCD349FinalProject.GamePlay;

namespace CSCD349FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeButton_Click(object sender, RoutedEventArgs e)
        {
            int maxHeight = 10, maxWidth = 10, maxFloors = 10;

            int x, y, z;
            if (!(int.TryParse(HeightEntryTextBox.Text, out x) && (x > 0 && x <= maxHeight)) || !(int.TryParse(WidthEntryTextBox.Text, out y) && (y > 0 && y <= maxWidth)) || !(int.TryParse(FloorEntryTextBox.Text, out z) && (z > 0 && z <= maxFloors)))
            {
                MessageBox.Show("One or more inputs is invalid.", "Invalid Input");
                return;
            }
            else
            {
                
                int columns = int.Parse(WidthEntryTextBox.Text);
                int rows = int.Parse(HeightEntryTextBox.Text);
                MapArray.SetMapArray(new Map(rows, columns));
                CreateGameBoard();
                

                

            }//end elserfd
        }

        private void CreateGameBoard()
        {
            ISpace currentSpace;
            int i = 0;
            ImageBrush texture = new ImageBrush();
            texture.ImageSource = new BitmapImage(new Uri(@"../../Images/metal_plates.png", UriKind.Relative));

            for (int a = 0; a < MapArray.GetMapArray().GetColumns(); a++)
            {
                GameBoard.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int b = 0; b < MapArray.GetMapArray().GetRows(); b++)
            {
                GameBoard.RowDefinitions.Add(new RowDefinition());
            }

            for (int row = 0; row < GameBoard.RowDefinitions.Count; row++)
            {
                for (int column = 0; column < GameBoard.ColumnDefinitions.Count; column++)
                {
                    i++;
                    currentSpace = MapArray.GetMapArray().GetBoardSpace(row, column);
                    currentSpace.getSpace().Width = GameBoard.Width / MapArray.GetMapArray().GetColumns();
                    currentSpace.getSpace().Height = GameBoard.Width / MapArray.GetMapArray().GetColumns();
                    currentSpace.getSpace().Background = texture;
                    currentSpace.getSpace().VerticalAlignment = VerticalAlignment.Center;
                    currentSpace.getSpace().SetValue(Grid.ColumnProperty, column);
                    currentSpace.getSpace().SetValue(Grid.RowProperty, row);

                    GameBoard.Children.Add(currentSpace.getSpace());
                }
            }

            InitializePlayer();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            GameBoard.RowDefinitions.Clear();
            GameBoard.ColumnDefinitions.Clear();
            GameBoard.Children.Clear();
        }


        private void InitializePlayer()
        {
            MapArray.DrawSprite(MapArray.GetMapArray().GetRows() - 1, 0);
            MapArray.SetCurrentPosition(MapArray.GetMapArray().GetRows() - 1, 0);
            CurrentPositionTextBox.Text = MapArray.GetCurrentPosition().ToString();
        }

        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            PlayerMovement.KeyUp();
            CurrentPositionTextBox.Text = MapArray.GetCurrentPosition().ToString();
        }

        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            PlayerMovement.KeyLeft();
            CurrentPositionTextBox.Text = MapArray.GetCurrentPosition().ToString();
        }

        private void RightButton_Click(object sender, RoutedEventArgs e)
        {
            PlayerMovement.KeyRight();
            CurrentPositionTextBox.Text = MapArray.GetCurrentPosition().ToString();
        }



        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            PlayerMovement.KeyDown();
            CurrentPositionTextBox.Text = MapArray.GetCurrentPosition().ToString();
        }
    }
}
