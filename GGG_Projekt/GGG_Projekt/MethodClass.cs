using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace GGG_Projekt
{
    class MethodClass
    {
        public static void ResetWinBoss()
        {
            Program.gStartFlag = true; //Is game start
            Program.cL = false; //Combat Loop
            Program.tL = true;  //Travel Loop (Program)

            MapTravel.mapGenerated = false; //Is map generated
            MapTravel.chU = 0; MapTravel.chR = 0; MapTravel.chD = 0; MapTravel.chL = 0; //Check up, right, down, left
            MapTravel.r = 0; MapTravel.c = 0; MapTravel.sc = 0; MapTravel.ec = 0;   //Rows, Collums, Step-Counter, Error-Counter
            MapTravel.tL = true; //Travel Loop (MapTravel)
            MapTravel.isPositionFlag = false;   //Print X at start (when showing player movement)
            MapTravel.tV = 0;   //Temporary Variable
            MapTravel.tC = 0;   //Temporary Collums
            MapTravel.tR = 0;   //Temporary Rows
            MapTravel.fEndDigit = 30; //Reset Highest steps digit

            Encounter.bossM = false;    //Boss monster flag

            Combat.tc = 0; //Turn-Counter
            Combat.turn = 0; //Turn (Combat)
            Combat.eAction = false;       //"Extra Action" for using a spell even if enemy uses attacktype 0 (hit)
            Combat.sDmgCalc = false;    //Use Standard Damage Calculation if enemy is a Boss
            Combat.win = true;  //Win flag

            EnemyMoveset.mHit = false;
            foreach (var key in EnemyMoveset.eMFlag.Keys.ToList()) //Reset enemy move flag
            {
                EnemyMoveset.eMFlag[key] = false;
            }

            CombatText.uniqueCombatText = false;    //Disable unique combat text

            Console.Clear();    //Clears console
        }

        public static void ResetWin()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 17);
            for (int td = 0; td < 18; td++) Console.WriteLine("                                                    ");
            Console.SetCursorPosition(0, Console.CursorTop - 18);

            Program.gStartFlag = false; //Game start flag
            Program.cL = false; //Combat loop
            Program.tL = true;  //Travel loop (Program)

            MapTravel.tL = true;    //Travel loop (MapTravel)
            MapTravel.eChance = 1;  //Encounter variable !0=No Encounter

            Combat.win = true;  //Win flag
            Combat.turn = 0;    //Entities turn 0=Player, 1=Enemy
            Combat.tc = 0;  //Turn counter
            Combat.eAction = false; //"Extra Action" for using a spell even if enemy uses attacktype 0 (hit)
            Combat.sDmgCalc = false;    //Use Standard Damage Calculation if enemy is a Boss

            EnemyMoveset.mHit = false;  //Enemy multihit
            foreach (var key in EnemyMoveset.eMFlag.Keys.ToList()) //Reset enemy move flag
            {
                EnemyMoveset.eMFlag[key] = false;
            }

            CombatText.uniqueCombatText = false;    //Disable unique combat text
        }

        public static void ResetLose()
        {
            Program.gStartFlag = true; //Is game start
            Program.cL = false; //Combat Loop
            Program.tL = true;  //Travel Loop (Program)
            Program.listIniFlag = false; //Initialize Lists again

            MapTravel.mapGenerated = false; //Is map generated
            MapTravel.chU = 0; MapTravel.chR = 0; MapTravel.chD = 0; MapTravel.chL = 0; //Check up, right, down, left
            MapTravel.r = 0; MapTravel.c = 0; MapTravel.sc = 0; MapTravel.ec = 0;   //Rows, Collums, Step-Counter, Error-Counter
            MapTravel.tL = true; //Travel Loop (MapTravel)
            MapTravel.isPositionFlag = false;   //Print X at start (when showing player movement)
            MapTravel.tV = 0;   //Temporary Variable
            MapTravel.tC = 0;   //Temporary Collums
            MapTravel.tR = 0;   //Temporary Rows

            Combat.pH = 100;    //Player health
            Combat.pM = 50; //Player mana
            Combat.tc = 0; //Turn-Counter
            Combat.turn = 0; //Turn (Combat)
            Combat.eAction = false;       //"Extra Action" for using a spell even if enemy uses attacktype 0 (hit)
            Combat.sDmgCalc = false;    //Use Standard Damage Calculation if enemy is a Boss

            EnemyMoveset.mHit = false;  //Enemy multihit
            foreach (var key in EnemyMoveset.eMFlag.Keys.ToList()) //Reset enemy move flag
            {
                EnemyMoveset.eMFlag[key] = false;
            }

            CombatText.uniqueCombatText = false;    //Disable unique combat text

            Reward.weaponObt = 0;   //Weapons obtained counter
            Reward.gold = 0;            //Money
            Reward.silver = 0;          //  |
            Reward.bronze = 0;          //  |
            Reward.currencyValue = 0;   //  |

            //Missing weapon reset (still works somehow)
            Console.Clear();    //Clears console
        }

        public static void SetCombatInfo(EnemyMoveset enemy)
        {
            Combat.enemy = enemy.eName;
            Combat.attack = enemy.mName;
            Combat.attack2 = enemy.mName2;
            Combat.attack3 = enemy.mName3;
        }
    }
}
