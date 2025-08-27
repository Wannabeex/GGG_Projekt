using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGG_Projekt
{
    public class EnemyMoveset
    {
        public static int eA;   //Enemy action

        public static int attackType;   //Type of attack
        public static bool isAttack;    //Is an attack?

        public static int cCounter = 0; //Charge Counter

        public static bool mHit = false;        //Multihit bool
        public static int mHitValue = default;    //Multihit Value

        public string eName = default;  //<<<<<<<<<<<<<<<<<<<
        public string mName = default;  //string parameters
        public string mName2 = default;
        public string mName3 = default; //>>>>>>>>>>>>>>>>>>>

        //public static string[] mFlag = new string[4];
        public static Dictionary<string, bool> eMFlag = new Dictionary<string, bool>() //Move type flag
        {
            { "icewind", false } ,
            { "poison", false } ,
            { "charm", false } ,
            { "bind", false } ,
            { "charge", false } ,
            { "pray", false }
        };

        public EnemyMoveset(string name, string move, string move2)
        {
            switch (name)
            {
                case "Goblin":
                    GoblinM(name, move, move2);
                    break;
                case "Goblin Assassin":
                    GoblinAssassinM(name, move, move2);
                    break;
                case "Goblin Warlock":
                    GoblinWarlockM(name, move, move2);
                    break;
                case "Goblin King":
                    GoblinKingM(name, move, move2);
                    break;
                case "Merfolk":
                    MerfolkM(name, move, move2);
                    break;
                case "Merfolk Priest":
                    MerfolkPriestM(name, move, move2);
                    break;
                case "Merfolk Siren":
                    MerfolkSirenM(name, move, move2);
                    break;
                case "Merfolk Leviathan":
                    MerfolkLeviathanM(name, move, move2);
                    break;
                case "Plantkin":
                    PlantkinM(name, move, move2);
                    break;
                case "Plantkin Sunflower":
                    PlantkinSunflowerM(name, move, move2);
                    break;
                case "Withered Plantkin":
                    PlantkinWitheredM(name, move, move2);
                    break;
                    //Plantkin Goliath in other Method
                case "Red Wolf":
                    RedWolfM(name, move, move2);
                    break;
                case "Red Wolf Hunter":
                    RedWolfHunterM(name, move, move2);
                    break;
                case "Starving Red Wolf":
                    RedWolfStarvingM(name, move, move2);
                    break;
                case "Red Wolf Alpha":
                    RedWolfAlphaM(name, move, move2);
                    break;
                case "Ogre":
                    OgreM(name, move, move2);
                    break;
                case "Ogre Boss":
                    OgreBossM(name, move, move2);
                    break;
                case "Abyss":
                    AbyssM(name, move, move2);
                    break;
                case "Abyss Boss":
                    AbyssBossM(name, move, move2);
                    break;
            }
        }
        public EnemyMoveset(string name, string move, string move2, string move3)
        {
            switch (name)
            {
                case "Plantkin Goliath":
                    PlantkinGoliathM(name, move, move2, move3);
                    break;
            }
        }

        //DUMMY Method
        public void DUMMYM(string name, string move, string move2)
        {
            eName = name;
            mName = move;
            mName2 = move2;

            eA = Program.rnd.Next(10);
            if (eA != 9)        //Hit
            {
                attackType = 0;
                isAttack = true;
                Combat.dmg = Program.rnd.Next(1);
            }
            else                //Spell 1
            {
                /*no Mana*/
                attackType = 0;
                isAttack = true;
                Combat.dmg = Program.rnd.Next(1);
            }

            Combat.enemy = eName;
            Combat.attack = mName;
            
        }

        //Boss Goblin Method
        public void GoblinKingM(string name, string move, string move2)
        {
            eName = name;
            mName = move;
            mName2 = move2;

            eA = Program.rnd.Next(9,10);
            if (eA != 9)        //Hit
            {
                attackType = 0;
                isAttack = true;
                Combat.dmg = Program.rnd.Next(8);
            }
            else                //Spell 1
            {
                if (Encounter.eM > 0) //Regal Might
                {
                    attackType = 1;
                    isAttack = true;
                    Combat.dmg = Program.rnd.Next(1, 2);
                }
                else
                {
                    attackType = 0;
                    isAttack = true;
                    Combat.dmg = Program.rnd.Next(8);
                }
            }

            Combat.enemy = eName;
            Combat.attack = mName;
            
        }

        //Boss Merfolk Method
        public void MerfolkLeviathanM(string name, string move, string move2)
        {
            eName = name;
            mName = move;
            mName2 = move2;

            eA = Program.rnd.Next(10);
            if (eA != 9)        //Hit
            {
                attackType = 0;
                isAttack = true;
                Combat.dmg = Program.rnd.Next(9);
            }
            else                //Spell 1
            {
                if (eMFlag["icewind"] != false && Encounter.eM > 0) //Icy Winds
                {
                    attackType = 1;
                    isAttack = true;
                    Combat.dmg = Program.rnd.Next(1, 6);
                    eMFlag["icewind"] = true;
                    Combat.exdmg = 5;
                }
                else
                {
                    attackType = 0;
                    isAttack = true;
                    Combat.dmg = Program.rnd.Next(9);
                }
            }

            Combat.enemy = eName;
            Combat.attack = mName;
            
        }

        //Boss Plantkin Method
        public void PlantkinGoliathM(string name, string move, string move2, string move3)
        {
            eName = name;
            mName = move;
            mName2 = move2;
            mName3 = move3;
            CombatText.uniqueCombatText = true;

            if (cCounter == 0) { eA = Program.rnd.Next(10); }
            if (eA < 4)        //Hit 1 (Poison)
            {
                    attackType = 0;
                    isAttack = true;
                    Combat.dmg = Program.rnd.Next(10);
                    if (Combat.dmg != 0) { eMFlag["poison"] = true; }
                    eMFlag["charge"] = false;
                    Combat.exdmg = Program.rnd.Next(1, 6);
                    CombatText.uniqueCombatText = false;
            }
            else if (eA < 7)   //Hit 2 (Charge)
            {
                if (cCounter == 0)
                {
                    attackType = 2;
                    isAttack = false;
                    eMFlag["charge"] = true;
                    cCounter++;
                    Combat.attackHit = true;
                }
                else if (cCounter == 1)
                {
                    Combat.dmg = Program.rnd.Next(10,21);
                    attackType = 0;
                    isAttack = true;
                    cCounter = 0;
                }
            }
            else              //Spell 1 (Bind)
            {
                if (Encounter.eM > 0)
                {
                    attackType = 1;
                    isAttack = true;
                    Combat.dmg = Program.rnd.Next(8);
                    if (Combat.dmg != 0) { eMFlag["bind"] = true; }
                    eMFlag["charge"] = false;
                    Status.isAilment = false;
                    Combat.tV[1] = 0;
                }
                else
                {
                    attackType = 0; //Hit 1 (Poison)
                    isAttack = true;
                    Combat.dmg = Program.rnd.Next(10);
                    if (Combat.dmg != 0) { eMFlag["poison"] = true; }
                    eMFlag["charge"] = false;
                    Combat.exdmg = Program.rnd.Next(1, 10);
                    CombatText.uniqueCombatText = false;
                }
            }

            Combat.enemy = eName;
            Combat.attack = mName;
            
        }

        //Boss Red Wolf Method
        public void RedWolfAlphaM(string name, string move, string move2)
        {
            eName = name;
            mName = move;
            mName2 = move2;

            eA = Program.rnd.Next(10);
            if (eA != 9)        //Hit
            {
                attackType = 0;
                isAttack = true;
                Combat.dmg = Program.rnd.Next(11);
            }
            else                //Spell 1
            {
                if (Encounter.eM > 0) //Pack Call
                {
                    attackType = 1;
                    isAttack = true;
                    Combat.dmg = Program.rnd.Next(1, 2);
                }
                else
                {
                    attackType = 0;
                    isAttack = true;
                    Combat.dmg = Program.rnd.Next(11);
                }
            }

            Combat.enemy = eName;
            Combat.attack = mName;
            
        }

        //Boss Ogre Method
        public void OgreBossM(string name, string move, string move2)
        {
            eName = name;
            mName = move;
            mName2 = move2;

            eA = Program.rnd.Next(9, 10);
            if (eA != 9)        //Hit
            {
                attackType = 0;
                isAttack = true;
                Combat.dmg = Program.rnd.Next(8);
            }
            else                //Spell 1
            {
                if (Encounter.eM > 0) //Regal Might
                {
                    attackType = 1;
                    isAttack = true;
                    Combat.dmg = Program.rnd.Next(1, 2);
                }
                else
                {
                    attackType = 0;
                    isAttack = true;
                    Combat.dmg = Program.rnd.Next(8);
                }
            }

            Combat.enemy = eName;
            Combat.attack = mName;
            
        }

        //Boss Abyss Method
        public void AbyssBossM(string name, string move, string move2)
        {
            eName = name;
            mName = move;
            mName2 = move2;

            eA = Program.rnd.Next(9, 10);
            if (eA != 9)        //Hit
            {
                attackType = 0;
                isAttack = true;
                Combat.dmg = Program.rnd.Next(8);
            }
            else                //Spell 1
            {
                if (Encounter.eM > 0) //Regal Might
                {
                    attackType = 1;
                    isAttack = true;
                    Combat.dmg = Program.rnd.Next(1, 2);
                }
                else
                {
                    attackType = 0;
                    isAttack = true;
                    Combat.dmg = Program.rnd.Next(8);
                }
            }

            Combat.enemy = eName;
            Combat.attack = mName;
            
        }
        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        //Goblin Method
        public void GoblinM(string name, string move, string move2)
        {
            eName = name;
            mName = move;
            mName2 = move2;

            eA = Program.rnd.Next(10);
            if (eA != 9)        //Hit
            {
                attackType = 0;
                isAttack = true;
                Combat.dmg = Program.rnd.Next(4);
            }
            else                //Spell 1
            {
                /*no Mana*/
                attackType = 0;
                isAttack = true;
                Combat.dmg = Program.rnd.Next(4);
            }

            Combat.enemy = eName;
            Combat.attack = mName;
            
        }
        public void GoblinAssassinM(string name, string move, string move2)
        {
            eName = name;
            mName = move;
            mName2 = move2;

            eA = Program.rnd.Next(10);
            if (eA != 9)        //Hit
            {
                attackType = 0;
                isAttack = true;
                Combat.dmg = Program.rnd.Next(3);

                mHit = true;
                mHitValue = 2;
            }
            else                //Spell 1
            {
                /*no Mana*/
                attackType = 0;
                isAttack = true;
                Combat.dmg = Program.rnd.Next(3);

                mHit = true;
                mHitValue = 2;
            }

            Combat.enemy = eName;
            Combat.attack = mName;
            
        }
        public void GoblinWarlockM(string name, string move, string move2)
        {
            eName = name;
            mName = move;
            mName2 = move2;

            eA = Program.rnd.Next(10);
            if (eA != 9)        //Hit
            {
                /*spellcaster*/ 
                attackType = 1;
                isAttack = true;
                Combat.dmg = Program.rnd.Next(10);
            }
            else                //Spell 1
            {
                attackType = 1;
                isAttack = true;
                Combat.dmg = Program.rnd.Next(10);
                //Dark Bolt
            }

            Combat.enemy = eName;
            Combat.attack = mName;
            
        }

        //Merfolk Method
        public void MerfolkM(string name, string move, string move2)
        {
            eName = name;
            mName = move;
            mName2 = move2;

            eA = Program.rnd.Next(10);
            if (eA != 9)        //Hit
            {
                attackType = 0;
                isAttack = true;
                Combat.dmg = Program.rnd.Next(5);
            }
            else                //Spell 1
            {
                attackType = 1;
                isAttack = true;
                Combat.dmg = Program.rnd.Next(7);
                //Water Blast
            }

            Combat.enemy = eName;
            Combat.attack = mName;
            
        }
        public void MerfolkPriestM(string name, string move, string move2)
        {
            eName = name;
            mName = move;
            mName2 = move2;

            eA = Program.rnd.Next(10);
            if (eA < 8)        //Hit
            {
                attackType = 0;
                isAttack = true;
                Combat.dmg = Program.rnd.Next(4);
                eMFlag["pray"] = false;
            }
            else                //Spell 1
            {
                attackType = 1;
                Combat.dmg = Program.rnd.Next(1, 4);
                if (Combat.dmg != 0) { eMFlag["pray"] = true; }
                isAttack = false;
                //Pray
            }

            Combat.enemy = eName;
            Combat.attack = mName;
            
        }
        public void MerfolkSirenM(string name, string move, string move2)
        {
            eName = name;
            mName = move;
            mName2 = move2;

            eA = Program.rnd.Next(10);
            if (eA != 9)        //Hit
            {
                attackType = 0;
                isAttack = true;
                Combat.dmg = Program.rnd.Next(6);
            }
            else                //Spell 1
            {
                attackType = 1;
                isAttack = false;
                Combat.dmg = Program.rnd.Next(3);
                if (Combat.dmg != 0) { eMFlag["charm"] = true; }

                //Enchant/Charm
            }

            Combat.enemy = eName;
            Combat.attack = mName;
            
        }

        //Plantkin Method //TO BE ADDED
        public void PlantkinM(string name, string move, string move2)
        {
            eName = name;
            mName = move;
            mName2 = move2;

            eA = Program.rnd.Next(10);
            if (eA != 9)        //Hit
            {
                attackType = 0;
                isAttack = true;
                Combat.dmg = Program.rnd.Next(6);
                if (Combat.dmg != 0) { eMFlag["poison"] = true; }
                Combat.exdmg = Program.rnd.Next(1,6);
            }
            else                
            {
                /*no Mana*/
                attackType = 0;
                isAttack = true;
                Combat.dmg = Program.rnd.Next(6);
                if (Combat.dmg != 0) { eMFlag["poison"] = true; }
                Combat.exdmg = Program.rnd.Next(1,6);
            }

            Combat.enemy = eName;
            Combat.attack = mName;
            
        }
        public void PlantkinSunflowerM(string name, string move, string move2)
        {
            eName = name;
            mName = move;
            mName2 = move2;

            eA = Program.rnd.Next(10);
            if (eA != 9)        //Hit
            {
                Combat.dmg = Program.rnd.Next(10,21);
                if (cCounter == 0)
                {
                    attackType = 2;
                    isAttack = false;
                    eMFlag["charge"] = true;
                    cCounter++;
                    Combat.attackHit = true;
                }
                else if (cCounter == 1)
                {
                    attackType = 0;
                    isAttack = true;
                    cCounter = 0;
                }
            }
            else                //Spell 1
            {
                /*no Mana*/
                Combat.dmg = Program.rnd.Next(10,21);
                if (cCounter == 0)
                {
                    attackType = 2;
                    isAttack = false;
                    eMFlag["charge"] = true;
                    cCounter++;
                    Combat.attackHit = true;
                }
                else if (cCounter == 1)
                {
                    attackType = 0;
                    isAttack = true;
                    eMFlag["charge"] = false;
                    cCounter = 0;
                }
            }

            Combat.enemy = eName;
            Combat.attack = mName;
            
        }
        public void PlantkinWitheredM(string name, string move, string move2)
        {
            eName = name;
            mName = move;
            mName2 = move2;

            eA = Program.rnd.Next(2);
            if (eA != 1)        //Hit
            {
                attackType = 0;
                isAttack = true;
                Combat.dmg = Program.rnd.Next(6);
            }
            else                //Spell 1
            {
                attackType = 1;
                isAttack = true;
                Combat.dmg = Program.rnd.Next(6);
                if (Combat.dmg != 0) { eMFlag["bind"] = true; }
            }

            Combat.enemy = eName;
            Combat.attack = mName;
            
        }

        //Red Wolf Method
        public void RedWolfM(string name, string move, string move2)
        {
            eName = name;
            mName = move;
            mName2 = move2;

            eA = Program.rnd.Next(10);
            if (eA != 9)   //Hit 
            {
                attackType = 0;
                isAttack = true;
                Combat.dmg = Program.rnd.Next(6);
            }
            else           //Spell 1
            {
                attackType = 1;
                isAttack = true;
                Combat.dmg = Program.rnd.Next(8);
            }

            Combat.enemy = eName;
            Combat.attack = mName;
            
        }
        public void RedWolfHunterM(string name, string move, string move2)
        {
            eName = name;
            mName = move;
            mName2 = move2;

            eA = Program.rnd.Next(10);
            if (eA != 9)   //Hit 
            {
                attackType = 0;
                isAttack = true;
                Combat.dmg = Program.rnd.Next(7);
            }
            else           //Spell 1
            {
                attackType = 1;
                isAttack = true;
                Combat.dmg = Program.rnd.Next(8);

                //Shred (Bleed)
            }

            Combat.enemy = eName;
            Combat.attack = mName;
            
        }
        public void RedWolfStarvingM(string name, string move, string move2)
        {
            eName = name;
            mName = move;
            mName2 = move2;

            eA = Program.rnd.Next(10);
            if (eA != 9)   //Hit 
            {
                attackType = 0;
                isAttack = true;
                Combat.dmg = Program.rnd.Next(11);

                mHit = true;
                mHitValue = 2;
            }
            else           //Spell 1
            {
                /*no Mana*/
                attackType = 0;
                isAttack = true;
                Combat.dmg = Program.rnd.Next(11);

                mHit = true;
                mHitValue = 2;
            }

            Combat.enemy = eName;
            Combat.attack = mName;
            
        }

        //Ogre Method
        public void OgreM(string name, string move, string move2)
        {
            eName = name;
            mName = move;
            mName2 = move2;

            eA = Program.rnd.Next(10);
            if (eA != 9)        //Hit
            {
                attackType = 0;
                isAttack = true;
                Combat.dmg = Program.rnd.Next(7);
            }
            else                //Spell 1
            {
                /*no mana*/ 
                attackType = 1;
                isAttack = true;
            }

            Combat.enemy = eName;
            Combat.attack = mName;
            
        }

        //Abyss Method
        public void AbyssM(string name, string move, string move2)
        {
            eName = name;
            mName = move;
            mName2 = move2;

            eA = Program.rnd.Next(10);
            if (eA != 9)        //Hit
            {
                attackType = 0;
                isAttack = true;
                Combat.dmg = Program.rnd.Next(100);
            }
            else                //Spell 1
            {
                /*no mana*/
                attackType = 0;
                isAttack = true;
                Combat.dmg = Program.rnd.Next(100);
            }
            
            Combat.enemy = eName;
            Combat.attack = mName;
            
        }
        //What kind of attack
        //How much dmg SHOULD it do
    }
}
