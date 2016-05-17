using CSCD349FinalProject.Spaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CSCD349FinalProject.GamePlay
{
    static class MapArray
    {
        private static Map mapArray;
        private static Point currentPosition; 

        public static Map GetMapArray()
        {
            return mapArray;
        }

        public static Point GetCurrentPosition()
        {
            return currentPosition;
        }

        public static void SetMapArray(Map newMap)
        {
            mapArray = newMap;
        }

        public static void SetCurrentPosition(int row, int column)
        {
            if(row <= mapArray.GetRows() && column < mapArray.GetColumns())
            {
                currentPosition.X = row;
                currentPosition.Y = column;
            }          
        }

        public static void DrawSprite(int row, int col)
        {
            Rectangle rec = new Rectangle();
            //will need to change dynamically based on rectangle size
            rec.Height = 60;
            rec.Width = 60;
            rec.Fill = new SolidColorBrush(Colors.AliceBlue);
            MapArray.GetMapArray().GetBoardSpace(row, col).getSpace().Child = rec;
        }
    }
}
