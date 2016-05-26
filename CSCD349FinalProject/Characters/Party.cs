using CSCD349FinalProject.Weapons;
using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CSCD349FinalProject.Characters
{
    class Party : IParty
    {
        private IGoodGuy[] party = new IGoodGuy[3];
        private int partyAttack;
        private int partyDefense;
        private int level;
        private ImageBrush img;

        public Party(int p)
        {
            level = 1;
            ConvertNumToParty(p);
            partyAttack = level * (party[0].GetAttack() + party[1].GetAttack() + party[2].GetAttack());
            partyDefense = level * (party[0].GetDefense() + party[1].GetDefense() + party[2].GetDefense());
        }

        private void ConvertNumToParty(int p)
        {
            if (p == 1)
            {
                party[0] = new Sharpshooter();
                party[1] = new Sharpshooter();
                party[2] = new Sharpshooter();
                img = new ImageBrush();
                img.ImageSource = new BitmapImage(new Uri(@"../../Images/sharpshooter.png", UriKind.Relative));
            }

            else if (p == 2)
            {
                party[0] = new Medic();
                party[1] = new Medic();
                party[2] = new Medic();
                img = new ImageBrush();
                img.ImageSource = new BitmapImage(new Uri(@"../../Images/sharpshooter.png", UriKind.Relative));
            }

            else if (p == 3)
            {
                party[0] = new Tank();
                party[1] = new Tank();
                party[2] = new Tank();
                img = new ImageBrush();
                img.ImageSource = new BitmapImage(new Uri(@"../../Images/sharpshooter.png", UriKind.Relative));
            }

            else
            {
                party[0] = new Sharpshooter();
                party[1] = new Medic();
                party[2] = new Tank();
                img = new ImageBrush();
                img.ImageSource = new BitmapImage(new Uri(@"../../Images/sharpshooter.png", UriKind.Relative));
            }
        }

        private void RecalcStats()
        {
            partyAttack = level * (party[0].GetAttack() + party[1].GetAttack() + party[2].GetAttack());
            partyDefense = level * (party[0].GetDefense() + party[1].GetDefense() + party[2].GetDefense());
        }

        public int GetPartyAttack()
        {
            return partyAttack;
        }

        public int GetPartyDefense()
        {
            return partyDefense;
        }

        public int GetLevel()
        {
            return level;
        }

        public ImageBrush GetImg()
        {
            return img;
        }

        public void LevelUp()
        {
            level += 1;
        }

        public void PickupWeapon(int character, IWeapon weapon)
        {
            party[character].ChangeWeapon(weapon);
            RecalcStats();
        }
    }
}
