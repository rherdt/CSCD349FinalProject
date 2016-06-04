using CSCD349FinalProject.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CSCD349FinalProject.Spaces
{
    class TreasureSquare: ASpace
    {
        public TreasureSquare() : base()
        {
            this.Decorate();
        }

        public override void runAction(Party user, MainWindow gameboard)
        {
            //could use this to deal with change state?
            //redirect back onto playing board
            //traversed = true;
            MessageBox.Show(this.ToString());
        }

        public override string ToString()
        {
            return "Treasure Square";
        }

        private void Decorate()
        {
            ImageBrush texture = new ImageBrush();
            texture.ImageSource = new BitmapImage(new Uri(@"../../Images/treasure_chest.png", UriKind.Relative));

            Rectangle rec = new Rectangle();
            rec.Height = 60;
            rec.Width = 60;
            rec.Fill = texture;
            this.getSpace().Child = rec;
        }
    }
}
