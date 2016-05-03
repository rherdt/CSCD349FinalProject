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
using CSCD349FinalProject.States;
using CSCD349FinalProject.Spaces;

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
                
                GameBoard = RawGrid;
                GameBoard.Visibility = Visibility.Visible;
                GameBoard.IsEnabled = true;
                int columns = int.Parse(WidthEntryTextBox.Text);
                int rows = int.Parse(HeightEntryTextBox.Text);

                ISpace currentSpace;
                Button btn;
                int i = 0;

                for (int a = 0; a < columns; a++)
                {
                    GameBoard.ColumnDefinitions.Add(new ColumnDefinition());
                }

                for (int b = 0; b < rows; b++)
                {
                    GameBoard.RowDefinitions.Add(new RowDefinition());
                }

                for (int row = 0; row < GameBoard.RowDefinitions.Count; row++)
                {
                    for (int column = 0; column < GameBoard.ColumnDefinitions.Count; column++)
                    {
                        i++;
                        currentSpace = new TravelSpace();
                        currentSpace.getSpace().Width = GameBoard.Width / columns;
                        currentSpace.getSpace().Height = GameBoard.Width / columns;
                        currentSpace.getSpace().Fill = new SolidColorBrush(Colors.Aqua);
                        //Need to make border, or switch back to buttons 
                        currentSpace.getSpace().VerticalAlignment = VerticalAlignment.Center;
                        currentSpace.getSpace().SetValue(Grid.ColumnProperty, column);
                        currentSpace.getSpace().SetValue(Grid.RowProperty, row);
                        //Need to add text element to each rectangle
                        //btn = new Button();
                        // btn.Width = GameBoard.Width / columns;
                        //btn.Height = GameBoard.Width / columns;
                        //btn.Content = i.ToString();
                        
                        GameBoard.Children.Add(currentSpace.getSpace());
                    }
                }

            }//end elserfd
        }
    }
}
