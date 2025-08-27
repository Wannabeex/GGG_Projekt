using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GGG_Projekt
{
    public static class EnemyFactory
    {
        public static EnemyMoveset CreateGoblin()
        { return new EnemyMoveset("Goblin", "Clubbed", "1"); }
        public static EnemyMoveset CreateGoblinAssassin()
        { return new EnemyMoveset("Goblin Assassin", "Slashed", "2"); }
        public static EnemyMoveset CreateGoblinWarlock()
        { return new EnemyMoveset("Goblin Warlock", "3", "Dark Bolted"); }

        public static EnemyMoveset CreateGoblinKing()
        { return new EnemyMoveset("Goblin King", "Smashed", "used Regal Might on"); }


        public static EnemyMoveset CreateMerfolk()
        { return new EnemyMoveset("Merfolk", "Stabbed", "Water Beamed"); }
        public static EnemyMoveset CreateMerfolkPriest()
        { return new EnemyMoveset("Merfolk Priest", "Punched", "Prayed"); }
        public static EnemyMoveset CreateMerfolkSiren()
        { return new EnemyMoveset("Merfolk Siren", "Clawed", "Charmed"); }

        public static EnemyMoveset CreateMerfolkLeviathan()
        { return new EnemyMoveset("Merfolk Leviathan", "Slammed", "used Icy Winds on"); }


        public static EnemyMoveset CreatePlantkin()
        { return new EnemyMoveset("Plantkin", "Lashes", ""); }
        public static EnemyMoveset CreatePlantkinSunflower()
        { return new EnemyMoveset("Plantkin Sunflower", "Sunburned", ""); }
        public static EnemyMoveset CreatePlantkinWithered()
        { return new EnemyMoveset("Withered Plantkin", "Lashes", "Thorn bound"); }

        public static EnemyMoveset CreatePlantkinGoliath()
        { return new EnemyMoveset("Plantkin Goliath", "Lashes", "Sunburned", "Thorn Bound"); }


        public static EnemyMoveset CreateRedWolf()
        { return new EnemyMoveset("Red Wolf", "Bit", "Fire Blasted"); }
        public static EnemyMoveset CreateRedWolfHunter()
        { return new EnemyMoveset("Red Wolf Hunter", "Bit", "Shredded"); }
        public static EnemyMoveset CreateRedWolfStarving()
        { return new EnemyMoveset("Starving Red Wolf", "Ripped and Tore", ""); }

        public static EnemyMoveset CreateRedWolfAlpha()
        { return new EnemyMoveset("Red Wolf Alpha", "Gnawed", "Called for its pack"); }


        public static EnemyMoveset CreateOgre()
        { return new EnemyMoveset("Ogre", "Slammed", ""); }

        public static EnemyMoveset CreateOgreBoss()
        { return new EnemyMoveset("Ogre Boss", "Slammed", ""); }


        public static EnemyMoveset CreateAbyss()
        { return new EnemyMoveset("Abyss", "Consumed", ""); }

        public static EnemyMoveset CreateAbyssBoss()
        { return new EnemyMoveset("Abyss Boss", "Consumed", ""); }
    }
}
