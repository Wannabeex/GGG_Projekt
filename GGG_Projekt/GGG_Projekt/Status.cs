using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGG_Projekt
{
    public class Status
    {
        public static int[] sC = new int[3];     //Status Counter (Array depicts: 0=hard ailment, 1=soft further changes may be needed)
        public static bool isAilment = default;     //Is affected by Ailment

        public static void PlayerStatusM()
        {
            int i = 0;

            if (Combat.keepTurn == false)
            {
                foreach (Trinkets trinket in Items.TrinketList)
                {
                    if (trinket.InPossession == true)
                    {
                        Combat.pH = Combat.pH + Items.TrinketList[i].HealthRegen;
                        if (Combat.pH >= Combat.pmH) { Combat.pH = Combat.pmH; }
                    }
                    i++;
                }
            }

            if (EnemyMoveset.eMFlag["charm"] == true)
            {
                if (Combat.spellHit == true)
                {
                    isAilment = true;
                    sC[1] = 3;
                    Combat.spellHit = false;
                }
            }
            if (EnemyMoveset.eMFlag["bind"] == true)
            {
                if (Combat.spellHit == true)
                {
                    isAilment = true;
                    sC[1] = 1;
                    Combat.spellHit = false;
                }
            }
            if (EnemyMoveset.eMFlag["icewind"] == true)
            {
                if (Combat.spellHit == true)
                {
                    sC[0] = 6;
                    Combat.spellHit = false;
                }
            }
            if (EnemyMoveset.eMFlag["poison"] == true)
            {
                if (Combat.spellHit == true)
                {
                    sC[0] = 1;
                    Combat.spellHit = false;
                }
            }


        }

        public static void EnemyStatusM()
        {
            if (EnemyMoveset.eMFlag["pray"] == true)
            {
                if (Combat.spellHit == true)
                {
                    isAilment = true;
                    sC[2] = 3;
                    Combat.spellHit = false;
                }
            }
        }
    }
}
