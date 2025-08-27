using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;

namespace GGG_Projekt
{
    class Program
    {
        const int STD_OUTPUT_HANDLE = -11;                                          //--------------------------------------------
        const uint ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004;

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetStdHandle(int nStdHandle);
                                                                                    //Enables ANSI excape code for VS 2022 (colors)
        [DllImport("kernel32.dll")]
        static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

        [DllImport("kernel32.dll")]
        static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);      //--------------------------------------------

        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public static bool fullTest = false;      //True = Test / False = Regular
        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        public static Random rnd = new Random();  //Random Class

        public static bool gL = true;             //Game Loop
        public static bool cL = true;
        public static bool tL = true;             //Travel Loop

        public static bool gStartFlag = true;     //Flag to decide if set r, c = 0
        public static bool listIniFlag = false;   //Flag to Initialize Lists at start of Program
  
        public static void Main()
        {
            var handle = GetStdHandle(STD_OUTPUT_HANDLE);                       //
            GetConsoleMode(handle, out uint mode);                              //Enables ANSI excape code for VS 2022 (colors)
            SetConsoleMode(handle, mode | ENABLE_VIRTUAL_TERMINAL_PROCESSING);  //

            while (gL == true)
            {
                Start();
            }
            Environment.Exit(0);
        }

        public static void Start()
        {
            if (listIniFlag == false)
            {
                Items weaponsList = new Items();
                listIniFlag = true;
            }

            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //                  Test
            if (fullTest == true)
            {
                MapTravel.eChance = 0; //When Encounter (0 = after every step)
                Encounter.e = 0; //Which Enemy          (0 = Goblin)
            }
            //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            
            while (tL == true)
            {
                if (MapTravel.mapGenerated == false)
                {
                    MapTravel.MapGeneration();
                    MapTravel.Travel();
                }
                else if (MapTravel.mapGenerated == true)
                {
                    MapTravel.Travel();
                }
                if (MapTravel.eChance == 0 || MapTravel.map[MapTravel.r, MapTravel.c] == MapTravel.fEndDigit)
                {
                    tL = false;
                    cL = true;
                    Encounter.Enemies();
                }
            }
            while (cL)
            {
                Combat.CombatLoop();
                if (Combat.turn == 1)
                {
                    Combat.PlayerAction();
                    Combat.HealthCheck();
                }
                else
                {
                    Combat.EnemyAction();
                    Combat.HealthCheck();
                }
            }
        }
    }
}
