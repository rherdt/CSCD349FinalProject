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

        public Party(IGoodGuy p1, IGoodGuy p2, IGoodGuy p3, string imgPath)
        {
            party[0] = p1;
            party[1] = p2;
            party[2] = p3;

            level = 1;

            partyAttack = level * (party[0].GetAttack() + party[1].GetAttack() + party[2].GetAttack());
            partyDefense = level * (party[0].GetDefense() + party[1].GetDefense() + party[2].GetDefense());

            img = new ImageBrush();
            img.ImageSource = new BitmapImage(new Uri(imgPath, UriKind.Relative));
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
        public ImageBrush getImg()
        {
            return img;
        }
    }
}
