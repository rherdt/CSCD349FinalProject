using CSCD349FinalProject.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

[assembly: InternalsVisibleTo("CSCD349FinalProjectTests")]

namespace CSCD349FinalProject.Spaces
{
    class StairSquare : ASpace
    {
        public StairSquare() : base()
        {
            this.Decorate();
        }

        public override void runAction(Party user, MainWindow gameboard)
        {       
            gameboard.NextFloor();
        }
        public override string ToString()
        {
            return "Stair Square";
        }

        private void Decorate()
        {
            ImageBrush texture = new ImageBrush();
            texture.ImageSource = new BitmapImage(new Uri(@"../../Images/stairs.png", UriKind.Relative));

            Rectangle rec = new Rectangle();
            rec.Height = 60;
            rec.Width = 60;
            rec.Fill = texture;
            this.getSpace().Child = rec;
        }
    }


}