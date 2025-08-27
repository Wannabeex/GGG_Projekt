using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GGG_Projekt
{
    public class Reward
    {
        public static int currencyValue = 0;
        public static int gold = 0;
        public static int silver = 0;
        public static int bronze = 0;

        public static string weaponname;

        public static int rV = default;

        public static int weaponObt = 0;
        public static int trinketObt = 0;

        public static bool fTreasure = false;

        public static void BattleReward()
        {
            gold = 0;
            silver = 0;
            bronze = 0;

            //Battle Reward---------------------------------
            rV = Program.rnd.Next(1, 201);
            bronze = rV % 100;
            silver = rV % 1000 / 100;
            gold = rV / 1000;
            currencyValue = currencyValue + rV;
            //----------------------------------------------
        }

        public static void Treasure()
        {
            int i = 0;
            int j = 0;
            int pC = 0; //Possession Counter
            bool loop = true;

            Thread.Sleep(100);

            //Treasure
            if (fTreasure == true)
            {
                //rV = Program.rnd.Next(100);  //5% chance two items
                rV = Program.rnd.Next(2);

                if (rV == 0)
                {
                    rV = Program.rnd.Next(6);

                    if (Items.WeaponList[rV].InPossession == false) { weaponObt = weaponObt + 1; }
                    Items.WeaponList[rV].InPossession = true;
                    Console.SetCursorPosition(6, Console.CursorTop - 3);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($" {Items.WeaponList[rV].WeaponName} ");
                    Console.ForegroundColor = ConsoleColor.White;

                    if (weaponObt == 2)
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 7);
                        Console.WriteLine("Keep which Weapon?:                          ");
                        foreach (Weapons weapon in Items.WeaponList)
                        {
                            if (weapon.InPossession == true)
                            {
                                i++;
                                Console.WriteLine($"{i}): {weapon.WeaponName}");
                            }
                        }
                        Console.WriteLine("                                         ");
                        Console.SetCursorPosition(0, Console.CursorTop - 1);

                        i = 0;
                        j = 0;
                        while (loop)
                        {
                            MapTravel.input = Console.ReadLine();
                            switch (MapTravel.input)
                            {
                                case "1":
                                    foreach (Weapons weapon in Items.WeaponList)
                                    {
                                        if (weapon.InPossession == true)
                                        {
                                            Console.WriteLine($"You keep {Items.WeaponList[i].WeaponName}");
                                            break;
                                        }
                                        i++;    //Placement of Weapon in List
                                    }
                                    for (j = 0; j < Items.WeaponList.Count; j++) { Items.WeaponList[j].InPossession = false; }
                                    Items.WeaponList[i].InPossession = true;
                                    loop = false;
                                    break;

                                case "2":
                                    foreach (Weapons weapon in Items.WeaponList)
                                    {
                                        if (weapon.InPossession == true)
                                        {
                                            pC = pC + 1;
                                            if (pC == 2)
                                            {
                                                Console.WriteLine($"You keep {Items.WeaponList[i].WeaponName}");
                                                break;
                                            }
                                        }
                                        i++;    //Placement of Weapon in List
                                    }
                                    for (j = 0; j < Items.WeaponList.Count; j++) { Items.WeaponList[j].InPossession = false; }
                                    Items.WeaponList[i].InPossession = true;
                                    loop = false;
                                    break;

                                default:
                                    Console.WriteLine("Wrong Input try again.           ");
                                    Thread.Sleep(1000);
                                    Console.SetCursorPosition(0, Console.CursorTop - 2);
                                    break;
                            }
                        }
                        Console.SetCursorPosition(0, Console.CursorTop + 2);
                        weaponObt = 1;
                    }
                }
                else if (rV == 1)
                {
                    rV = Program.rnd.Next(4);

                    if (Items.TrinketList[rV].InPossession == false) { trinketObt = trinketObt + 1; }
                    Items.TrinketList[rV].InPossession = true;
                    Console.SetCursorPosition(6, Console.CursorTop - 3);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($" {Items.TrinketList[rV].TrinketName} ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                fTreasure = false;

                //

            }
            else
            {
                Console.SetCursorPosition(0, Console.CursorTop - 3);
                Console.WriteLine("                                                     ");
            }
            Combat.win = false;
        }
    }
}
