using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGG_Projekt
{
    public class CombatText
    {
        public static bool uniqueCombatText = false;

        public static void EnemyCombatText()
        {
            if (Combat.attackHit == true)
            {
                if (uniqueCombatText != true)  //Maybe Temporary
                {
                    switch (EnemyMoveset.attackType)
                    {
                        //Hit
                        case 0:
                            if (EnemyMoveset.mHit == true) { Console.Write($"The {Combat.enemy} {Combat.attack} you {EnemyMoveset.mHitValue}x for " + Combat.cDmg); }
                            else { Console.Write($"The {Combat.enemy} {Combat.attack} you for " + Combat.cDmg); }
                            break;

                        //Spell
                        case 1:
                            if (EnemyMoveset.mHit == true) { Console.Write($"The {Combat.enemy} {Combat.attack2} you {EnemyMoveset.mHitValue}x for " + Combat.cDmg); }
                            else if (EnemyMoveset.mHit == false) { Console.Write($"The {Combat.enemy} {Combat.attack2} you for " + Combat.cDmg); }
                            break;
                    }
                }
                else
                {
                    if (EnemyMoveset.attackType == 0 && EnemyMoveset.eMFlag["charge"] == true)
                    {
                        if (EnemyMoveset.mHit == true) { Console.Write($"The {Combat.enemy} {Combat.attack2} you {EnemyMoveset.mHitValue}x for " + Combat.cDmg); }
                        else { Console.Write($"The {Combat.enemy} {Combat.attack2} you for " + Combat.cDmg); }
                    }
                    else
                    {
                        if (EnemyMoveset.mHit == true) { Console.Write($"The {Combat.enemy} {Combat.attack3} you {EnemyMoveset.mHitValue}x for " + Combat.cDmg); }
                        else { Console.Write($"The {Combat.enemy} {Combat.attack3} you for " + Combat.cDmg); }
                    }
                }
                if (Combat.dmg == 0 && EnemyMoveset.eMFlag["icewind"] == true) { Console.Write($" but its icy wind pelted you for {Combat.exdmg}"); }
                else if (EnemyMoveset.eMFlag["icewind"] == true) { Console.Write($" and the icy wind pelted you for {Combat.exdmg}"); }

                else if (Combat.dmg == 0 && EnemyMoveset.eMFlag["poison"] == true) { Console.Write($" but its poison hurt you for {Combat.exdmg}"); }
                else if (EnemyMoveset.eMFlag["poison"] == true) { Console.Write($" and its poison hurt you for {Combat.exdmg}"); }
            }
            if (Combat.dmg == 0 || Encounter.eM <= 0 && Combat.attackHit != true) { Console.Write(".                                                       \n"); }
            else { Console.Write(" damage.                            \n"); }
        }
        public static void EnemyActionText()
        {
            if (Combat.attackHit == true)
            {
                if (EnemyMoveset.eMFlag["pray"] == true)
                {
                    Console.WriteLine($"The {Combat.enemy} {Combat.attack2}.                                          ");
                }
                if (EnemyMoveset.eMFlag["charm"] == true)
                {
                    Console.WriteLine($"The {Combat.enemy} {Combat.attack2} you.                                      ");
                }
                if (EnemyMoveset.eMFlag["charge"] == true)
                {
                    Console.WriteLine($"The {Combat.enemy} is charging an attack.                                     ");
                }
            }
            else if (Combat.dmg == 0 || Encounter.eM <= 0 && Combat.attackHit != true) { Console.Write(".                                                     \n"); }
        }

        public static void PlayerCombatText()
        {
            switch (MapTravel.input)
            {
                case "h":
                    Console.WriteLine("You Hit for " + Combat.cDmg + " damage.                                        ");
                    break;

                case "f":
                    Console.WriteLine("Your Fire hit for " + Combat.cDmg + " damage.                                        ");
                    break;
            }
        }

        public static void PlayerActionText()
        {
            int formatc = 0;   //Format Counter

            if (Status.isAilment == false || MapTravel.input == "i")
            {
                switch (MapTravel.input)
                {
                    case "g":   //Guard
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("You brace for impact.                                        ");
                        Console.WriteLine("                                                             ");
                        Console.WriteLine("                                                             ");
                        Console.WriteLine("                                                             ");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "k":   //Kill
                        Console.WriteLine("You Kill.                                                    ");
                        Console.WriteLine("                                                             ");
                        Console.WriteLine("                                                             ");
                        Console.WriteLine("                                                             ");
                        break;
                    case "s":   //Suicide
                        Console.WriteLine("You Kill...yourself?.                                        ");
                        Console.WriteLine("                                                             ");
                        Console.WriteLine("                                                             ");
                        Console.WriteLine("                                                             ");
                        break;
                    case "i":   //Inventory
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write($"gold: {Reward.gold} ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write($"silver: {Reward.silver} ");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"bronze: {Reward.bronze}                                                     ");
                        Console.ForegroundColor = ConsoleColor.White;

                        for (int i = 0; i < Items.WeaponList.Count; i++)
                        {
                            if (Items.WeaponList[i].InPossession == true)
                            {
                                if (Items.WeaponList[i].WeaponType == "sword") 
                                {
                                    Console.WriteLine($"Weapon:{Items.WeaponList[i].WeaponName} " +
                                                      $"Hdmg:{Items.WeaponList[i].Adddmg}");
                                    formatc = formatc + 1;
                                }
                                else if (Items.WeaponList[i].WeaponType == "staff")
                                {
                                    Console.WriteLine($"Weapon:{Items.WeaponList[i].WeaponName} " +
                                                      $"Sdmg:{Items.WeaponList[i].Adddmg} " +
                                                      $"MRegen:{Items.WeaponList[i].ManaRegen}             ");
                                    formatc = formatc + 1;
                                }
                            }
                        }
                        if (formatc == 0)
                        {
                            Console.WriteLine("                                                             ");
                        }

                        formatc = 0;
                        for (int i = 0; i < Items.TrinketList.Count; i++)
                        {
                            if (Items.TrinketList[i].InPossession == true)
                            {
                                if (Items.TrinketList[i].TrinketType == "HPRegen")
                                {
                                    Console.WriteLine($"{Items.TrinketList[i].TrinketName} " +
                                                      $"Health-Regen:{Items.TrinketList[i].HealthRegen}             ");
                                }
                                else
                                {
                                    Console.WriteLine($"{Items.TrinketList[i].TrinketName}             ");
                                }
                                formatc = formatc + 1;
                            }
                        }
                        if (formatc == 0)
                        {
                            Console.WriteLine("                                                             ");
                        }


                        Console.WriteLine("                                                             ");
                        Console.WriteLine("                                                             ");
                        Console.ReadKey();
                        if (Status.isAilment == false) Console.SetCursorPosition(9, 14);
                        else Console.SetCursorPosition(9, 15);
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("You are confused and freeze up!!!                            ");
                        Console.WriteLine("                                                             ");
                        Console.WriteLine("                                                             ");
                        Console.WriteLine("                                                             ");
                        Console.Beep(37, 200);
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }
            else if (Status.isAilment == true)
            {
                if (EnemyMoveset.eMFlag["charm"] == true)
                {
                    Console.WriteLine("\n\n");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"You are charmed and can't move.                             ");
                    Console.WriteLine($"{Combat.aC} turns remaining                                 ");
                    Console.WriteLine("                                                             ");
                    Console.WriteLine("                                                             ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(Console.CursorLeft + 9, Console.CursorTop - 7);
                    //Console.ReadLine();
                    //Console.SetCursorPosition(0, Console.CursorTop + 6);
                }

                if (EnemyMoveset.eMFlag["bind"] == true)
                {
                    Console.WriteLine("\n\n");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"You are bound by thorns and can't move.                     ");
                    Console.WriteLine($"{Combat.aC} turns remaining                                 ");
                    Console.WriteLine("                                                             ");
                    Console.WriteLine("                                                             ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(Console.CursorLeft + 9, Console.CursorTop - 7);
                    //Console.ReadLine();
                    //Console.SetCursorPosition(0, Console.CursorTop + 6);
                }
            }
        }
    }
}
