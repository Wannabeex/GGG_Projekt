using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGG_Projekt
{
    public class Items
    {
        public static List<Weapons> WeaponList { get; set; }
        public static List<Trinkets> TrinketList { get; set; }
        public static List<Artifacts> ArtifactList { get; set; }

        public Items()
        {
            WeaponList = new List<Weapons>
            {
                //Swords
                new Weapons("Weathered-Sword", "sword", false, 1),    //[0]
                new Weapons("Mercenary-Sword", "sword", false, 2),    //[1]
                new Weapons("Knight-Sword", "sword", false, 3),       //[2]

                //Staffs
                new Weapons("Magewood-Branch", "staff", false, 1, 1), //[3]
                new Weapons("Apprentice-Staff", "staff", false, 2, 2),//[4]
                new Weapons("Courtmage-Staff", "staff", false, 3, 3), //[5]
            };

            TrinketList = new List<Trinkets>
            {
                new Trinkets("Peculiar-Doll", "", false, 2),                       //[0] //Jimmy

                new Trinkets("Red-Gem-Necklace-(small)", "HPRegen", false, 1, 0),  //[1]
                new Trinkets("Red-Gem-Necklace-(medium)", "HPRegen", false, 2, 0), //[2]
                new Trinkets("Red-Gem-Necklace-(large)", "HPRegen", false, 3, 0),  //[3]
            };

            ArtifactList = new List<Artifacts>
            {

            };
        }

        public static void Weapons()
        {
            //Weapons
            //To be continued
        }
        public static void Trinkets()
        {
            //Buff and effects
            //To be continued
        }
        public static void Artifacts()
        {
            //Bigger Buff and effects with downsides
            //To be continued
        }
    }
}
