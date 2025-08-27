using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGG_Projekt
{
    class PlayerMoveset
    {
        public string pmName = default;  //String parameters
        public string pmName2 = default; //       "
        public static bool pmHit = false;

        public static string pattackType;   //Type of attack

        public void PlayerM(string pmove, string pmove2)
        {
            bool pAction = true;

            pmName = pmove;
            pmName2 = pmove2;

            while (pAction)
            {
                Console.Write("\nAction?: ");
                #pragma warning disable CS8600  //Disables yellow warning line
                MapTravel.input = Console.ReadLine();
                Console.WriteLine();

                switch (MapTravel.input)
                {
                    case "h":   //Hit
                        Combat.dmg = Program.rnd.Next(6);   //Damage randomizer
                        pattackType = "h";
                        pAction = false;
                        Combat.keepTurn = false;
                        break;
                    case "f":   //Fire
                        Combat.dmg = Program.rnd.Next(11);
                        pattackType = "f";
                        pAction = false;
                        Combat.keepTurn = false;
                        break;
                    case "g":   //Guard
                        if (Status.isAilment == false) Combat.isG = true;
                        pattackType = "";
                        pAction = false;
                        Combat.keepTurn = false;
                        break;
                    case "k":   //Kill
                        Encounter.eH = 0;
                        pattackType = "";
                        pAction = false;
                        Combat.keepTurn = false;
                        break;
                    case "s":   //Suicide
                        Combat.pH = 0;
                        pattackType = "";
                        pAction = false;
                        Combat.keepTurn = false;
                        break;
                    case "i":   //Inventory

                        //Total Money-------------------------------------------------------
                        Reward.bronze = Reward.currencyValue % 100;
                        Reward.silver = Reward.currencyValue % 1000 / 100;
                        Reward.gold = Reward.currencyValue / 1000;
                        //------------------------------------------------------------------
                        pattackType = "";
                        Combat.turn = 0;
                        Combat.tc = 0;
                        Combat.keepTurn = true;
                        return;

                    default:
                        pattackType = "";
                        pAction = false;
                        Combat.keepTurn = false;
                        break;
                }
            }
        }
    }
}
