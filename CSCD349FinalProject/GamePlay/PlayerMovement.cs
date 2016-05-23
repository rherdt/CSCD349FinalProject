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
        public static void KeyUp(Map gameBoardMap)
        {
            Point currentPosition = gameBoardMap.GetCurrentPosition();
            Point newPosition = new Point(currentPosition.X - 1, currentPosition.Y);

            if (newPosition.X >= 0)
            {
                MovePlayer(newPosition, gameBoardMap);
            }
        }

        public static void KeyDown(Map gameBoardMap)
        {
            Point currentPosition = gameBoardMap.GetCurrentPosition();
            Point newPosition = new Point(currentPosition.X + 1, currentPosition.Y);

            if(newPosition.X < gameBoardMap.GetRows())
            {
                MovePlayer(newPosition, gameBoardMap);
            }
        }

        public static void KeyLeft(Map gameBoardMap)
        {
            Point currentPosition = gameBoardMap.GetCurrentPosition();

            Point newPosition = new Point(currentPosition.X, currentPosition.Y - 1);

            if (newPosition.Y >= 0)
            {
                MovePlayer(newPosition, gameBoardMap);
            }
        }

        public static void KeyRight(Map gameBoardMap)
        {
            Point currentPosition = gameBoardMap.GetCurrentPosition();

            Point newPosition = new Point(currentPosition.X, currentPosition.Y + 1);

            if (currentPosition.X < gameBoardMap.GetColumns())
            {
                MovePlayer(newPosition, gameBoardMap);
            }
        }

        private static void MovePlayer(Point newPosition, Map gameBoardMap)
        {
            if (newPosition.Y >= 0 && newPosition.Y <= gameBoardMap.GetRows() - 1 && newPosition.X >= 0 && newPosition.X <= gameBoardMap.GetColumns() - 1)
            {
                if(gameBoardMap.GetBoardSpace((int)gameBoardMap.GetCurrentPosition().X, (int)gameBoardMap.GetCurrentPosition().Y).getSpace().Child != null)
                {         
                    gameBoardMap.GetBoardSpace((int) gameBoardMap.GetCurrentPosition().X, (int)gameBoardMap.GetCurrentPosition().Y).getSpace().Child = null;
                    gameBoardMap.DrawSprite((int)newPosition.X, (int)newPosition.Y);

                    gameBoardMap.SetCurrentPosition((int)newPosition.X, (int)newPosition.Y);
                    
                }
            }
        }
    }
}
