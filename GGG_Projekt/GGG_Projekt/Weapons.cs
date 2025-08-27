using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGG_Projekt
{
    public class Weapons
    {
        public string WeaponName { get; set; }
        public int Adddmg { get; set; }
        public bool InPossession { get; set; }
        public int ManaRegen { get; set; }
        public string WeaponType { get; set; }
        public int I { get; set; }

        public Weapons(string weaponName, string weaponType, bool inPossession)
        {
            //Necessary Parameters
            WeaponType = weaponType;
            WeaponName = weaponName;
            InPossession = inPossession;
            //i = Variable to Differentiate
            //I = i;

            //Base Method
        }

        public Weapons(string weaponName, string weaponType, bool inPossession, int adddmg)
        {
            //Necessary Parameters
            WeaponType = weaponType;
            WeaponName = weaponName;
            InPossession = inPossession;

            //Swords
            Adddmg = adddmg;

            //Sub-Swords
            //...
        }

        public Weapons(string weaponName, string weaponType, bool inPossession, int adddmg, int manaRegen)
        {
            //Necessary Parameters
            WeaponType = weaponType;
            WeaponName = weaponName;
            InPossession = inPossession;

            //Staffs
            Adddmg = adddmg;
            ManaRegen = manaRegen;

            //Sub-Staffs
            //...
        }
    }
}
