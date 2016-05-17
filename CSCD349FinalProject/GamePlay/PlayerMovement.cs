using CSCD349FinalProject.Spaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace CSCD349FinalProject.GamePlay
{
    class PlayerMovement
    {
        public static void KeyUp()
        {
            Point currentPosition = MapArray.GetCurrentPosition();

            Console.WriteLine("Number of Rows: " + MapArray.GetMapArray().GetRows());

            Point newPosition = new Point(currentPosition.X - 1, currentPosition.Y);
            Console.WriteLine("New Position: " + newPosition.ToString());

            if (newPosition.X >= 0)
            {
                MovePlayer(newPosition);
            }
        }

        public static void KeyDown()
        {
            Point currentPosition = MapArray.GetCurrentPosition();
            Console.WriteLine("Number of Rows: " + MapArray.GetMapArray().GetRows());

            Point newPosition = new Point(currentPosition.X + 1, currentPosition.Y);
            Console.WriteLine("New Position: " + newPosition.ToString());

            if (newPosition.Y < MapArray.GetMapArray().GetRows())
            {
                MovePlayer(newPosition);
            }
        }

        public static void KeyLeft()
        {
            Point currentPosition = MapArray.GetCurrentPosition();

            Console.WriteLine("Number of Rows: " + MapArray.GetMapArray().GetRows());

            Point newPosition = new Point(currentPosition.X, currentPosition.Y - 1);
            Console.WriteLine("New Position: " + newPosition.ToString());

            if (newPosition.Y >= 0)
            {
                MovePlayer(newPosition);
            }
        }

        public static void KeyRight()
        {
            Point currentPosition = MapArray.GetCurrentPosition();
            
            Console.WriteLine("Number of Rows: " + MapArray.GetMapArray().GetRows());

            Point newPosition = new Point(currentPosition.X, currentPosition.Y + 1);
            Console.WriteLine("New Position: " + newPosition.ToString());

            if (currentPosition.X < MapArray.GetMapArray().GetColumns())
            {
                MovePlayer(newPosition);
            }
        }

        private static void MovePlayer(Point newPosition)
        {
            Map map = MapArray.GetMapArray();

            if (newPosition.Y >= 0 && newPosition.Y <= map.GetRows() - 1 && newPosition.X >= 0 && newPosition.X <= map.GetColumns() - 1)
            {
                if (map.GetBoardSpace((int)MapArray.GetCurrentPosition().X, (int)MapArray.GetCurrentPosition().Y).getSpace().Child != null)
                {         
                    map.GetBoardSpace((int) MapArray.GetCurrentPosition().X, (int) MapArray.GetCurrentPosition().Y).getSpace().Child = null;
                    MapArray.DrawSprite((int)newPosition.X, (int)newPosition.Y);

                    MapArray.SetCurrentPosition((int)newPosition.X, (int)newPosition.Y);
                    
                }
            }
        }
    }
}
