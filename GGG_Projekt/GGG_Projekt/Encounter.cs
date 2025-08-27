using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GGG_Projekt
{
    public class Encounter
    {
        public static int e = default;            //Encounter variable

        public static double eH = default;        //Enemy Health
        public static double eM = default;        //Enemy Mana

        public static bool bossM = false;

        public static void Enemies()
        {
            Thread.Sleep(100);
            if (Program.fullTest == false) { /*e = Program.rnd.Next(26);*/ /*e = -1;*/ e = Program.rnd.Next(0,25); } //25th enemy -> Abyss
            if (MapTravel.map[MapTravel.r, MapTravel.c] == MapTravel.fEndDigit)
            {
                /*eH = eH * 1.5;
                Console.Write(" This one seems stronger.");*/

                if (e < 9) //Class Boss-Goblin
                {
                    switch (e)
                    {
                        case 0:
                        case 1:
                        case 2:
                        //>>>>>Temporary<<<<<
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        //>>>>>>>>><<<<<<<<<<
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("\n");
                            Console.Write("A Goblin King appeared!");
                            eH = 80;
                            eM = 10;
                            break;
                        /*Sub-Class Boss Goblin
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:*/
                    }
                }
                
                else if (e < 15) //Class Boss Merfolk
                {
                    switch (e)
                    {
                        case 9:
                        case 10:
                        //>>>>>Temporary<<<<<
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                        //>>>>>>>>><<<<<<<<<<
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("\n");
                            Console.Write("A Merfolk Leviathan appeared!");
                            eH = 100;
                            eM = 70;
                            break;
                        /*Sub-Class Boss Merfolk
                        case 11:
                        case 12:
                        case 13:
                        case 14:*/
                    }
                }
                else if (e < 20) //Class Boss Plantkin
                {
                    switch (e)
                    {
                        case 15: //Combines all three Plantkin
                        case 16:
                        //>>>>>Temporary<<<<<
                        case 17:
                        case 18:
                        case 19:
                        //>>>>>>>>><<<<<<<<<<
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("\n");
                            Console.Write("A Plantkin Goliath appeared!");
                            eH = 125;
                            eM = 100;
                            break;
                        /*Sub-Class Boss Plantkin
                        case 17:
                        case 18:
                        case 19:*/
                    }
                }
                else if (e < 25) //Class Boss Red Wolf
                {
                    switch (e)
                    {
                        case 20:
                        case 21:
                        //>>>>>Temporary<<<<<
                        case 22:
                        case 23:
                        case 24:
                        //>>>>>>>>><<<<<<<<<<
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("\n");
                            Console.Write("A Red Wolf Alpha appeared!");
                            eH = 150;
                            eM = 50;
                            break;
                            /*Sub-Class Boss Red Wolf
                            case 17:
                            case 18:
                            case 19:*/
                    }
                }
                else if (e < 26) //Class Boss Ogre
                {
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.Write(" ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("\n");
                    Console.Write("An Ogre Archmage appeared!");
                    eH = 150;
                    eM = 0;
                }

                bossM = true;
            }
            else
            {
                if (e == -1) //DUMMY
                {
                    Console.WriteLine($"\u001b[48;5;136m \u001b[0m");
                    Console.Write("A DUMMY appeared!");
                    eH = 10000;
                    eM = 10000;
                }
                else if (e < 9 && e >= 0) //Class Goblin
                {
                    switch (e)
                    {
                        case 0:
                        case 1:
                        case 2:
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("\n");
                            Console.Write("A Goblin appeared!");
                            eH = 40;
                            eM = 0;
                            break;
                        //Sub-Class Goblin
                        case 3:
                        case 4:
                        case 5:
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("\n");
                            Console.Write("A Goblin Assassin appeared!");
                            eH = 30;
                            eM = 0;
                            break;
                        case 6:
                        case 7:
                        case 8:
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.DarkMagenta;
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("\n");
                            Console.Write("A Goblin Warlock appeared!");
                            eH = 20;
                            eM = 100;
                            break;
                    }
                }
                else if (e < 15) //Class Merfolk
                {
                    switch (e)
                    {
                        case 9:
                        case 10:
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("\n");
                            Console.Write("A Merfolk appeared!");
                            eH = 60;
                            eM = 30;
                            break;
                        //Sub-Class Merfolk
                        case 11:
                        case 12:
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("\n");
                            Console.Write("A Merfolk Priest appeared!");
                            eH = 40;
                            eM = 100;
                            break;
                        case 13:
                        case 14:
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Write(" ");
                            Console.Write("\u001b[48;5;171m \u001b[0m");
                            /*Console.BackgroundColor = ConsoleColor.DarkMagenta;
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.Black;*/
                            Console.Write("\n");
                            Console.Write("A Merfolk Siren appeared!");
                            eH = 30;
                            eM = 30;
                            break;
                    }
                }
                else if (e < 20) //Class Plantkin
                {
                    switch (e)
                    {
                        case 15: //Poison on hit
                        case 16:
                            Console.BackgroundColor = ConsoleColor.Green; 
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("\n");
                            Console.Write("A Plantkin appeared!");
                            eH = 80;
                            eM = 0;
                            break;
                        //Sub-Class Plantkin
                        case 17: //charge attack
                        case 18:
                            Console.BackgroundColor = ConsoleColor.Green; 
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("\n");
                            Console.Write("A Plantkin Sunflower appeared!");
                            eH = 100;
                            eM = 0;
                            break;
                        case 19: //1 turn stun spell with dmg
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.Green; 
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("\n");
                            Console.Write("A Withered Plantkin  appeared!");
                            eH = 50;
                            eM = 70;
                            break;
                    }
                }
                else if (e < 24)
                {
                    switch (e) //Class Red Wolf 
                    {
                        case 20:
                        case 21:
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("\n");
                            Console.Write("A Red Wolf appeared!");
                            eH = 125;
                            eM = 30;
                            break;
                        //Sub-Class Red Wolf
                        case 22:
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("\n");
                            Console.Write("A Red Wolf Hunter appeared!");
                            eH = 100;
                            eM = 30;
                            break;
                        case 23:
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("\n");
                            Console.Write("A Starving Red Wolf appeared!");
                            eH = 15;
                            eM = 0;
                            break;
                    }
                }
                else if (e < 25) //Class Ogre
                {
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.Write(" ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("\n");
                    Console.Write("An Ogre appeared!");
                    eH = 150;
                    eM = 0;
                }
                else
                {
                    Console.Write(" ");
                    Console.Write("\n");
                    Console.Write("The Abyss appeared!");
                    eH = 1000;
                    eM = 0;
                }
            }
        }
    }
}
