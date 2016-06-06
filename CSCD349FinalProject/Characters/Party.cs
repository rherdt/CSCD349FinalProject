using CSCD349FinalProject.Weapons;
using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using CSCD349FinalProject.Inventory;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CSCD349FinalProjectTests")]

namespace CSCD349FinalProject.Characters
{
    class Party : IParty
    {
        private IGoodGuy[] party = new IGoodGuy[3];
        private int partyAttack;
        private int partyDefense;
        private int type;
        private int level;
        private Inventory.Inventory inventory;
        private int hp;
        private ImageBrush img;
        private bool cheatEnabled = false;
        private string savedname;

        public string Savedname
        {
            get
            {
                return savedname;
            }

            set
            {
                savedname = value;
            }
        }

        public Party(int p)
        {
            level = 1;
            hp = 100;
            ConvertNumToParty(p);
            partyAttack = level * (party[0].GetAttack() + party[1].GetAttack() + party[2].GetAttack());
            partyDefense = level * (party[0].GetDefense() + party[1].GetDefense() + party[2].GetDefense());
        }

        private void ConvertNumToParty(int p)
        {
            if (p == 1)
            {
                type = 1;
                party[0] = new Sharpshooter();
                party[1] = new Sharpshooter();
                party[2] = new Sharpshooter();
                img = new ImageBrush();
                inventory = new Inventory.Inventory(5);
                img.ImageSource = new BitmapImage(new Uri(@"../../Images/Sharpshooters.png", UriKind.Relative));
            }

            else if (p == 2)
            {
                type = 2;
                party[0] = new Medic();
                party[1] = new Medic();
                party[2] = new Medic();
                img = new ImageBrush();
                inventory = new Inventory.Inventory(10);
                img.ImageSource = new BitmapImage(new Uri(@"../../Images/Medics.png", UriKind.Relative));
            }

            else if (p == 3)
            {
                type = 3;
                party[0] = new Tank();
                party[1] = new Tank();
                party[2] = new Tank();
                img = new ImageBrush();
                inventory = new Inventory.Inventory(3);
                img.ImageSource = new BitmapImage(new Uri(@"../../Images/Tanks.png", UriKind.Relative));
            }

            else
            {
                type = 4;
                party[0] = new Sharpshooter();
                party[1] = new Medic();
                party[2] = new Tank();
                img = new ImageBrush();
                inventory = new Inventory.Inventory(7);
                img.ImageSource = new BitmapImage(new Uri(@"../../Images/Balanced.png", UriKind.Relative));
            }
        }

        private void RecalcStats()
        {
            double factor = Math.Pow(level, (1.0 / 3.0));

            partyAttack = (int)(factor * (party[0].GetAttack() + party[1].GetAttack() + party[2].GetAttack()));
            partyDefense = (int)(factor * (party[0].GetDefense() + party[1].GetDefense() + party[2].GetDefense()));

            if (!cheatEnabled)
            {
                double factor = Math.Pow(level, (1.0 / 3.0));

                partyAttack = (int)(factor * (party[0].GetAttack() + party[1].GetAttack() + party[2].GetAttack()));
                partyDefense = (int)(factor * (party[0].GetDefense() + party[1].GetDefense() + party[2].GetDefense()));
            }
        }

        public void Damage(int hp)
        {
            partyHealth -= hp;

            if (partyHealth < 0)
                partyHealth = 0;
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

        public Inventory.Inventory GetInventory()
        {
            return inventory;
        }

        public void LevelUp()
        {
            level += 1;
            RecalcStats();
        }
        public int GetHP()
        {
            return hp;
        }
        public void TakeDamage(int damage)
        {
            hp = hp - damage;
            if(hp < 1)
            {
                PartyDead();
            }
        }
        public bool UpgradeWeapon()
        {
            int character = 0;

            while (party[character].IsUpgraded())
            {
                if (character <= 1)
                    character++;

                else
                    return false;
        }

            party[character].UpgradeWeapon();
            RecalcStats();
            return true;
        }

        public void ToggleCheat()
        {
            if (cheatEnabled)
                TurnOffCheat();

            else
                TurnOnCheat();
        }

        private void TurnOnCheat()
        {
            cheatEnabled = true;
            partyAttack = 1000000;
            partyDefense = 1000000;
        }

        private void TurnOffCheat()
        {
            cheatEnabled = false;
            RecalcStats();
        }

        private void PartyDead()
        {
            GameOver go = new GameOver();
            go.ShowDialog();
        }
        public void SetPartyLevel(int Setlevel)
        {
            level = Setlevel;
        }
        public void setHealth(int health)
        {
            hp = health;
        }
        public int GetPartyType()
        {
            return type;
        }
    }
}
