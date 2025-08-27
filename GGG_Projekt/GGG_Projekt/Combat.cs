using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GGG_Projekt
{
    public class Combat
    {
        public static double cDmg = default;      //Calculated Damage
        public static double dmg = default;       //Damage
        public static double exdmg = default;     //Extra Damage (Poison, Enviromental, etc.)

        public static bool eAction = false;       //"Extra Action" for using a spell even if enemy uses attacktype 0 (hit)

        public static bool sDmgCalc = false;      //Use standard damage formula even if bossM is true

        public static bool isG = default;         //Is guarding

        public static double pH = 100;            //Player Health  
        public static double pM = 50;             //Player Mana      
        public static double pmH = 100;           //Player Max Health
        public static double pmM = 50;            //Player Max Mana
        public static double pHR = 25;            //Player Health Regen after win (To be changed)
        public static double pMR = 2;             //Player Mana Regen per second

        public static bool cL = true;             //Combat Loop

        public static int turn = 0;
        public static int tc = 0;                 //Turn-Counter

        public static int aC = 0;                 //Ailment counter

        public static string enemy;               //<<<<<<<<<<<<<<<<<<< 
        public static string attack;              //string parameters;
        public static string attack2;
        public static string attack3;             //>>>>>>>>>>>>>>>>>>>

        public static bool spellHit = false;      //Does Spell hit
        public static bool attackHit = false;     //Does Attack hit

        public static int[] tV = new int[2];      //Temporary variables

        public static bool win = false;           //Win variable

        public static bool keepTurn = false;      //Keep Turn Variable

        public static void CombatLoop()
        {
            //To be continued

            while (cL)
            {
                if (turn == 0)
                {
                    turn = 1;
                    if (tc == 2)
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 12);
                        tc = 0;
                    }
                    tc = tc + 1;
                    return;
                }
                else if (turn == 1)
                {
                    turn = 0;
                    if (tc == 2)
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 12);
                        tc = 0;
                    }
                    tc = tc + 1;
                    return;
                }
            }
            Program.Main();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public static void PlayerAction()
        {
            int vR;      //Random int variable
            int i = 0;

            turn = 1;

            Status.PlayerStatusM();

            if (EnemyMoveset.eMFlag["icewind"] == true && MapTravel.input != "i" || EnemyMoveset.eMFlag["poison"] == true && MapTravel.input != "i") //Without timer
            {
                if (tV[0] == Status.sC[0])
                {
                    tV[0] = 0;
                    if (EnemyMoveset.eMFlag["icewind"] == true) EnemyMoveset.eMFlag["icewind"] = false;
                    else if (EnemyMoveset.eMFlag["poison"] == true) EnemyMoveset.eMFlag["poison"] = false;
                }
                tV[0]++;
            }

            if (EnemyMoveset.eMFlag["charm"] == true && MapTravel.input != "i" || EnemyMoveset.eMFlag["bind"] == true && MapTravel.input != "i") //With Timer
            {
                aC--;
                if (tV[1] == 0 || tV[1] < Status.sC[1])
                {
                    aC = Status.sC[1];
                }
                if (aC == -1) { aC = Status.sC[1]; }
                CombatText.PlayerActionText();
                tV[1]++;
                if (tV[1] > Status.sC[1])
                {
                    Status.isAilment = false;
                    tV[1] = 0;
                    if (EnemyMoveset.eMFlag["charm"] == true) EnemyMoveset.eMFlag["charm"] = false;
                    else if (EnemyMoveset.eMFlag["bind"] == true) EnemyMoveset.eMFlag["bind"] = false;
                }
            }

            if (Status.isAilment != true)
            {
                PlayerMoveset player = new PlayerMoveset();
                player.PlayerM("Hit", "Fire");
                attack = player.pmName;
                attack2 = player.pmName2;
            }
            else
            {
                PlayerMoveset player = new PlayerMoveset();
                player.PlayerM("Hit", "Fire");
                attack = player.pmName;
                attack2 = player.pmName2;
                if (MapTravel.input != "i") Console.SetCursorPosition(0, Console.CursorTop + 5);
                else if (MapTravel.input == "i") CombatText.PlayerActionText();
            }

            if (Status.isAilment != true) //Poison changes tV
            {
                switch (PlayerMoveset.pattackType)
                {
                    case "h":
                        if (dmg == 0)
                        {
                            vR = Program.rnd.Next(1);    //Miss Protection

                            switch (vR)
                            {
                                case 0:
                                    break;

                                case 1:
                                    dmg = dmg + 2;
                                    break;
                            }
                        }
                        switch (dmg)
                        {
                            case 1:
                                dmg = dmg + 2;
                                break;
                            case 2:
                                dmg = dmg + 1;
                                break;
                        }

                        if (dmg == 0)
                        {
                            Console.WriteLine("You missed moron.                                                ");
                            Console.WriteLine("                                                                 ");
                            Console.WriteLine("                                                                 ");
                            Console.WriteLine("                                                                 ");
                        }
                        else
                        {
                            #pragma warning disable CA1416  //Disables yellow warning line
                            Console.Beep(100, 100);

                            foreach (Weapons weapon in Items.WeaponList)
                            {
                                if (weapon.InPossession == true && weapon.WeaponType == "sword")
                                { 
                                    cDmg = dmg + Items.WeaponList[i].Adddmg;
                                    break;
                                }
                                else { cDmg = dmg; }
                                i++;
                            }
                            i = 0;

                            cDmg = Math.Round(cDmg);
                            Encounter.eH = Encounter.eH - cDmg;

                            CombatText.PlayerCombatText();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("P health: " + pH + "                                                             ");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("P Mana: " + pM + "                                                             ");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Enemy health: " + Encounter.eH + "                                                             ");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;

                    case "f":
                        if (pM <= 9)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("Not enough mana!                                                 ");
                            Console.WriteLine("                                                                 ");
                            Console.WriteLine("                                                                 ");
                            Console.WriteLine("                                                                 ");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            if (pM != 0) { pM = pM - 10; }

                            switch (dmg)
                            {
                                case 0:
                                    vR = Program.rnd.Next(1);
                                    if (vR == 1)
                                    {
                                        dmg = dmg + 5;
                                    }
                                    break;
                                case 1:
                                    dmg = dmg + 4;
                                    break;
                                case 2:
                                    dmg = dmg + 3;
                                    break;
                                case 3:
                                    dmg = dmg + 2;
                                    break;
                                case 4:
                                    dmg = dmg + 1;
                                    break;
                            }
                            if (dmg == 0)
                            {
                                Console.WriteLine("You missed moron.                                                ");
                                Console.WriteLine("                                                                 ");
                                Console.WriteLine("                                                                 ");
                                Console.WriteLine("                                                                 ");
                            }
                            else
                            {
                                Console.Beep(200, 50);
                                Console.Beep(100, 50);
                                Console.Beep(200, 50);

                                foreach (Weapons weapon in Items.WeaponList)
                                {
                                    if (weapon.InPossession == true && weapon.WeaponType == "staff")
                                    {
                                        cDmg = dmg + Items.WeaponList[i].Adddmg;
                                        break;
                                    }
                                    else { cDmg = dmg; }
                                    i++;
                                }
                                i = 0;

                                cDmg = Math.Round(cDmg);
                                Encounter.eH = Encounter.eH - cDmg;

                                CombatText.PlayerCombatText();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("P health: " + pH + "                                                             ");
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("P Mana: " + pM + "                                                             ");
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("Enemy health: " + Encounter.eH + "                                                             ");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            break;
                        }
                        break;

                    default:
                        CombatText.PlayerActionText();
                        break;
                }

                foreach (Weapons weapon in Items.WeaponList)
                {
                    if (weapon.InPossession == true)
                    {
                        pM = pM + Items.WeaponList[i].ManaRegen;
                        break;
                    }
                    i++;
                }
                i = 0;
                pM = pM + pMR;
                if (pM >= pmM) { pM = pmM; }

                Console.WriteLine("                                                 ");
                Thread.Sleep(1000);
                return;
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public static void EnemyAction()
        {
            if (MapTravel.map[MapTravel.r, MapTravel.c] == MapTravel.fEndDigit)
            {
                if (Encounter.e < 9) //Class Boss Goblin
                {
                    switch (Encounter.e)
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
                            var goblinking = EnemyFactory.CreateGoblinKing();
                            MethodClass.SetCombatInfo(goblinking); break;/*
                        case 3:
                        case 4:
                        case 5:
                            var goblin = EnemyFactory.CreateGoblin(); break;
                        case 6:
                        case 7:
                        case 8:
                            var goblin = EnemyFactory.CreateGoblin(); break;*/
                    }
                }
                else if (Encounter.e < 15) //Class Boss Merfolk
                {
                    switch (Encounter.e)
                    {
                        case 9:
                        case 10:
                        //>>>>>Temporary<<<<<
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                        //>>>>>>>>><<<<<<<<<<
                            var merfolkleviathan = EnemyFactory.CreateMerfolkLeviathan();
                            MethodClass.SetCombatInfo(merfolkleviathan); break;/*
                        case 11:
                        case 12:
                            var goblin = EnemyFactory.CreateGoblin(); break;
                        case 13:
                        case 14:
                            var goblin = EnemyFactory.CreateGoblin(); break;*/
                    }
                }
                else if (Encounter.e < 20)
                {
                    switch (Encounter.e)
                    {
                        case 15:
                        case 16:
                        //>>>>>Temporary<<<<<
                        case 17:
                        case 18:
                        case 19:
                        //>>>>>>>>><<<<<<<<<<
                            var plantkingoliath = EnemyFactory.CreatePlantkinGoliath();
                            MethodClass.SetCombatInfo(plantkingoliath); break;/*
                        case 17:
                        case 18:
                            var goblin = EnemyFactory.CreateGoblin(); break;
                        case 19:
                            var goblin = EnemyFactory.CreateGoblin(); break; */
                    }
                }
                else if (Encounter.e < 24)
                {
                    switch (Encounter.e)
                    {
                        case 20:
                        case 21:
                        //>>>>>Temporary<<<<<
                        case 22:
                        case 23:
                        //>>>>>>>>><<<<<<<<<<
                            var redwolfalpha = EnemyFactory.CreateRedWolfAlpha();
                            MethodClass.SetCombatInfo(redwolfalpha); break;/*
                        case 22:
                            var goblin = EnemyFactory.CreateGoblin(); break;
                        case 23:
                            var goblin = EnemyFactory.CreateGoblin(); break; */
                    }
                }
                else if (Encounter.e < 25)
                {
                    switch (Encounter.e)
                    {
                        case 24:
                            var ogreboss = EnemyFactory.CreateOgreBoss();
                            MethodClass.SetCombatInfo(ogreboss); break;
                    }
                }
                else
                {
                    var abyssboss = EnemyFactory.CreateAbyssBoss();
                    MethodClass.SetCombatInfo(abyssboss);
                }
            }
            else
            {
                if (Encounter.e < 9) //Class Goblin
                {
                    switch (Encounter.e)
                    {
                        case 0:
                        case 1:
                        case 2:
                            var goblin = EnemyFactory.CreateGoblin();
                            MethodClass.SetCombatInfo(goblin); break;
                        case 3:
                        case 4:
                        case 5:
                            var goblinassassin = EnemyFactory.CreateGoblinAssassin();
                            MethodClass.SetCombatInfo(goblinassassin); break;
                        case 6:
                        case 7:
                        case 8:
                            var goblinwarlock = EnemyFactory.CreateGoblinWarlock();
                            MethodClass.SetCombatInfo(goblinwarlock); break;
                    }
                }
                else if (Encounter.e < 15) //Class Merfolk
                {
                    switch (Encounter.e)
                    {
                        case 9:
                        case 10:
                            var merfolk = EnemyFactory.CreateMerfolk();
                            MethodClass.SetCombatInfo(merfolk); break;
                        case 11:
                        case 12:
                            var merfolkpriest = EnemyFactory.CreateMerfolkPriest();
                            MethodClass.SetCombatInfo(merfolkpriest); break;
                        case 13:
                        case 14:
                            var merfolksiren = EnemyFactory.CreateMerfolkSiren();
                            MethodClass.SetCombatInfo(merfolksiren); break;
                    }
                }
                else if (Encounter.e < 20) //Class Plantkin
                {
                    switch (Encounter.e)
                    {
                        case 15:
                        case 16:
                            var plantkin = EnemyFactory.CreatePlantkin();
                            MethodClass.SetCombatInfo(plantkin); break;
                        case 17:
                        case 18:
                            var plantkinsunflower = EnemyFactory.CreatePlantkinSunflower();
                            MethodClass.SetCombatInfo(plantkinsunflower); break;
                        case 19:
                            var plantkinwithered = EnemyFactory.CreatePlantkinWithered();
                            MethodClass.SetCombatInfo(plantkinwithered); break;
                    }
                }
                else if (Encounter.e < 24) //Class Red Wolf
                {
                    switch (Encounter.e)
                    {
                        case 20:
                        case 21:
                            var redwolf = EnemyFactory.CreateRedWolf();
                            MethodClass.SetCombatInfo(redwolf); break;
                        case 22:
                            var redwolfhunter = EnemyFactory.CreateRedWolfHunter();
                            MethodClass.SetCombatInfo(redwolfhunter); break;
                        case 23:
                            var redwolfstarving = EnemyFactory.CreateRedWolfStarving();
                            MethodClass.SetCombatInfo(redwolfstarving); break;
                    }
                }
                else if (Encounter.e < 25) //Class Ogre
                {
                    var ogre = EnemyFactory.CreateOgre();
                    MethodClass.SetCombatInfo(ogre);
                }
                else //Class Abyss
                {
                    var abyss = EnemyFactory.CreateAbyss();
                    MethodClass.SetCombatInfo(abyss);
                }
            }
            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            if (EnemyMoveset.attackType == 0) //First attack type (usually hit)
            {
                if (dmg == 0)
                {
                    Console.Write($"The {enemy} missed");
                }
                else
                {
                    attackHit = true;
                    spellHit = true;

                    if (EnemyMoveset.isAttack == true)
                    {
                        //Boss calc to be added
                        if (Encounter.bossM == true)
                        {
                            switch (Encounter.e)
                            {
                                case 0:
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                case 5:
                                case 6:
                                case 7:
                                case 8:
                                case 9:
                                case 10:
                                case 11:
                                case 12:
                                case 13:
                                case 14:
                                    break;

                                //Plantkin Goliath
                                case 15:
                                case 16:
                                //>>>>>Temporary<<<<<
                                case 17:
                                case 18:
                                case 19:
                                //>>>>>>>>><<<<<<<<<<
                                    if (isG == true && EnemyMoveset.eMFlag["poison"] == false) { dmg = dmg / 2; }
                                    pH = pH - exdmg;
                                    attackHit = true;
                                    break;

                                case 20:
                                case 21:
                                case 22:
                                case 23:
                                case 24:
                                    break;
                            }
                            sDmgCalc = true;
                        }
                        else if (Encounter.bossM != true)
                        {
                            if (isG == true)
                            {
                                exdmg = exdmg / 2;
                                exdmg = Math.Round(exdmg);
                            }

                            switch (Encounter.e)
                            {
                                case 0:
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                case 5:
                                case 6:
                                case 7:
                                case 8:
                                case 9:
                                case 10:
                                case 11:
                                case 12:
                                case 13:
                                case 14:
                                    break;

                                //Plantkin
                                case 15:
                                case 16:
                                    pH = pH - exdmg;
                                    attackHit = true;
                                    break;
                                case 17: //Plantkin Sunflower
                                case 18:
                                    if (isG == true) { dmg = dmg / 2; }
                                    break;
                                case 19: //Withered Plantkin
                                    break;

                                case 20:
                                case 21:
                                case 22:
                                case 23:
                                case 24:
                                    break;
                            }
                        }

                        if (sDmgCalc == true || Encounter.bossM == false)
                        {
                            //                     -Standard Damage Calculation-
                            //----------------------------------------------------------------------
                            if (isG == true)
                            {
                                cDmg = dmg / 2;
                                cDmg = Math.Round(cDmg);
                                pH = pH - cDmg;

                                if (EnemyMoveset.mHit == true)
                                {
                                    for (int hc = 0; hc < EnemyMoveset.mHitValue - 1; hc++)
                                    {
                                        pH = pH - cDmg;
                                    }
                                }
                            }
                            else
                            {
                                cDmg = dmg;
                                cDmg = Math.Round(cDmg);
                                pH = pH - cDmg;

                                if (EnemyMoveset.mHit == true)
                                {
                                    for (int hc = 0; hc < EnemyMoveset.mHitValue - 1; hc++)
                                    {
                                        pH = pH - cDmg;
                                    }
                                }
                            }
                            //----------------------------------------------------------------------
                            sDmgCalc = false;
                        }
                    }
                }
            }
            
            if (EnemyMoveset.attackType == 1 || eAction == true) //Second attack type--------------------------------------------------------------------
            {
                if (Encounter.eM <= 0 && eAction == false)
                {
                    Console.Write($"The {enemy} tried to cast but failed");
                }
                else if (Encounter.eM != 0)
                {
                    Encounter.eM = Encounter.eM - 10;

                    if (dmg == 0 && eAction == false)
                    {
                        Console.Write($"The {enemy} missed");
                    }
                    else
                    {
                        if (dmg != 0)
                        {
                            attackHit = true;
                            spellHit = true;
                        }

                        Status.EnemyStatusM();

                        if (EnemyMoveset.isAttack == true && spellHit == true)
                        {
                            if (Encounter.bossM == true)
                            {
                                switch (Encounter.e)
                                {
                                    case 0: //Goblin King (Regal Might)
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
                                        if (isG == true)
                                        {
                                            cDmg = pH / 4;
                                            cDmg = Math.Round(cDmg);
                                            pH = pH - cDmg;
                                        }
                                        else
                                        {
                                            cDmg = pH / 2;
                                            cDmg = Math.Round(cDmg);
                                            pH = pH - cDmg;
                                        }
                                        break;

                                    case 9: //Merfolk Leviathan (Icy Winds)
                                    case 10:

                                    //>>>>>Temporary<<<<<
                                    case 11:
                                    case 12:
                                    case 13:
                                    case 14:
                                    //>>>>>>>>><<<<<<<<<<
                                        if (isG == true)
                                        {
                                            exdmg = exdmg / 2;
                                            exdmg = Math.Round(exdmg);
                                            pH = pH - exdmg;
                                        }
                                        else
                                        {
                                            exdmg = Math.Round(exdmg);
                                            pH = pH - exdmg;
                                        }
                                        if (eAction == false) { sDmgCalc = true; }
                                        eAction = true;
                                        break;

                                    case 15: //Plantkin Goliath (Thorn Bind)
                                    case 16:
                                    case 17:
                                    case 18:
                                    case 19:

                                    //>>>>>Temporary<<<<<
                                    case 20:
                                    case 21:
                                    case 22:
                                    case 23:
                                    case 24:
                                        //>>>>>>>>><<<<<<<<<<
                                        sDmgCalc = true;
                                        break;
                                }
                            }
                            else
                            {
                                if (isG == true)
                                { 
                                    exdmg = exdmg / 2;
                                    exdmg = Math.Round(exdmg);
                                }

                                switch (Encounter.e)
                                {
                                    case 0:
                                    case 1:
                                    case 2:
                                    case 3:
                                    case 4:
                                    case 5:
                                    case 6:
                                    case 7:
                                    case 8:
                                    case 9:
                                    case 10:
                                    case 11:
                                    case 12:
                                    case 13:
                                    case 14:
                                        break;

                                    case 15:
                                    case 16:
                                        pH = pH - exdmg;
                                        break;
                                    case 17:
                                    case 18:
                                    case 19:
                                        break;

                                    case 20:
                                    case 21:
                                    case 22:
                                    case 23:
                                    case 24:
                                        break;
                                }
                            }

                            if (sDmgCalc == true || Encounter.bossM == false)
                            {
                                //                     -Standard Damage Calculation-
                                //----------------------------------------------------------------------
                                if (isG == true)
                                {
                                    cDmg = dmg / 2;
                                    cDmg = Math.Round(cDmg);
                                    pH = pH - cDmg;

                                    if (EnemyMoveset.mHit == true)
                                    {
                                        for (int hc = 0; hc < EnemyMoveset.mHitValue - 1; hc++)
                                        {
                                            pH = pH - cDmg;
                                        }
                                    }
                                }
                                else
                                {
                                    cDmg = dmg;
                                    cDmg = Math.Round(cDmg);
                                    pH = pH - cDmg;

                                    if (EnemyMoveset.mHit == true)
                                    {
                                        for (int hc = 0; hc < EnemyMoveset.mHitValue - 1; hc++)
                                        {
                                            pH = pH - cDmg;
                                        }
                                    }
                                }
                                //----------------------------------------------------------------------
                                sDmgCalc = false;
                            }
                        }
                    }
                }
            }
            isG = false;
            if (EnemyMoveset.isAttack == true)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                CombatText.EnemyCombatText();
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (EnemyMoveset.isAttack != true)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                CombatText.EnemyActionText();
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("P health: " + pH + "                                                             ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("P Mana: " + pM + "                                                               ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Enemy health: " + Encounter.eH + "                                               ");
            Console.ForegroundColor = ConsoleColor.White;

            attackHit = false;
        }


        public static void HealthCheck()
        {
            if (pH <= 0)
            {
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("YOU DIED.\n");
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("Try again? (y=yes): ");
                MapTravel.input = Console.ReadLine();
                Console.WriteLine();

                if (MapTravel.input == "y") //New Game Reset all Variables
                {
                    MethodClass.ResetLose();
                    return;
                }
                else
                {
                    cL = false;
                    Program.cL = false;
                    Program.gL = false;
                    return;
                }
            }
            if (Encounter.eH <= 0)
            {
                if (pH < pmH)
                {
                    pH = pH + pHR;
                    if (pH >= pmH) { pH = pmH; }
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("YOU WIN.                                                   ");
                Console.WriteLine("Drops:                                                     ");
                Console.ForegroundColor = ConsoleColor.White;

                Reward.BattleReward();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"you got {Reward.bronze} bronze and {Reward.silver} silver.");
                Console.WriteLine("Press any key.                                             ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                if (Encounter.bossM == true)
                {
                    MethodClass.ResetWinBoss();
                    return;
                }/*
                else if (Encounter.e == -1) //Defeat Minion
                {
                    switch () //Which Enemy summoned
                        case  : //Return to that enemy (maybe)
                        break;
                }*/
                else
                {
                    MethodClass.ResetWin();
                    return;
                }
            }
        }
    }
}
