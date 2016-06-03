using CSCD349FinalProject.Characters;
using CSCD349FinalProject.Inventory;
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
            Random rand = new Random();
            int temp = rand.Next(7);
            Console.WriteLine("Number of items: " + user.GetInventory().GetItems().Count);
            if(temp < 2)
            {
                //user.UpgradeWeapon();
            }
            else
            {
                user.GetInventory().AddItem(GenerateItem());
            }
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

        private IInvItem GenerateItem()
        {
            Random rand = new Random();
            int temp = rand.Next(100);
            //Could use a weighing algorithm here to be more elegant
            if(temp <= 30)
            {
                return new Bandage();
            }
            else if(temp > 30 && temp <= 60)
            {
                return new Grenade();
            }
            else if( temp > 60 && temp <= 90)
            {
                return new Molotov();
            }
            else
            {
                return new Medkit();
            }


        }
    }
}
