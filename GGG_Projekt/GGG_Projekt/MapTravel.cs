using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;

namespace GGG_Projekt
{
    public class MapTravel
    {
        public static int chU = 0, chR = 0, chD = 0, chL = 0; //Check Up, Right, Down, Left
        public static int r = 0, c = 0, sc = 0, ec = 0;       //Rows, Collums, Step Counter, Error Counter
        public static int occurrence;                         //Occurrence (Up, Right, Down, Left)
        public static int dL = 0;                             //Default log
        public static bool dLLoop = false;                    //Default log loop

        public static bool tL = true;                         //Travel loop

        public static int tV = default;                      //Temporary Variable
        public static int tR = 0;                             //Temporary Rows
        public static int tC = 0;                             //Temporary Collums

        public static int rV1 = 100;                          //Random Variable 1, 2, 3
        public static int rV2 = 100;
        public static int rV3 = 100;

        public static bool isPositionFlag = false;            //Is Position Flagged y/n?

        public static int eChance = default;                  //Encounter Chance

        public static int[,] map = new int[10, 10];
        public static bool mapGenerated = false;              //Check is map generated

        public static string input = default;                 //String Input

        public static int fEndDigit = 40;                     //max step variable
        public static int minEndDigit = 30;                   //minimum map size

        public static void MapGeneration()
        {
            tV = Program.rnd.Next(3);
            switch (tV)
            {
                case 0:
                    rV1 = Program.rnd.Next(1, 30);
                    break;
                case 1:
                    rV1 = Program.rnd.Next(1, 30);
                    rV2 = Program.rnd.Next(1, 30);
                    break;
                case 2:
                    rV1 = Program.rnd.Next(1, 30);
                    rV2 = Program.rnd.Next(1, 30);
                    rV3 = Program.rnd.Next(1, 30);
                    break;
            }

            while (true)
            {
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        map[i, j] = 0;  // Empty/0 space
                    }
                }

                for (int steps = 0; steps < fEndDigit; steps++)
                {
                    occurrence = Program.rnd.Next(0, 100);
                    if (occurrence <= 25)
                    {
                        if (r != 0 && chD == 0 && map[r - 1, c] == 0)
                        {
                            sc = sc + 1;
                            map[r, c] = sc;
                            r--;    //Up
                            chU = 1; chR = 0; chD = 0; chL = 0;
                            ec = 0;
                        }
                        else
                        {
                            steps--;
                            ec++;
                        }
                    }
                    else if (occurrence <= 50)
                    {
                        if (c < map.GetLength(1) - 1 && chL == 0 && map[r, c + 1] == 0)
                        {
                            sc = sc + 1;
                            map[r, c] = sc;
                            c++;    //Right
                            chU = 0; chR = 1; chD = 0; chL = 0;
                            ec = 0;
                        }
                        else
                        {
                            steps--;
                            ec++;
                        }
                    }
                    else if (occurrence <= 75)
                    {
                        if (r < map.GetLength(0) - 1 && chU == 0 && map[r + 1, c] == 0)
                        {
                            sc = sc + 1;
                            map[r, c] = sc;
                            r++;    //Down
                            chU = 0; chR = 0; chD = 1; chL = 0;
                            ec = 0;
                        }
                        else
                        {
                            steps--;
                            ec++;
                        }
                    }
                    else if (occurrence <= 100)
                    {
                        if (c != 0 && chR == 0 && map[r, c - 1] == 0)
                        {
                            sc = sc + 1;
                            map[r, c] = sc;
                            c--;    //Left
                            chU = 0; chR = 0; chD = 0; chL = 1;
                            ec = 0;
                        }
                        else
                        {
                            steps--;
                            ec++;
                        }
                    }
                    if (ec >= 50)
                    {
                        steps = 1000;
                        fEndDigit = map[r, c]; //Flag for floor end
                    }
                    else if ((r == 0 || map[r - 1, c] != 0) && (c == map.GetLength(1) - 1 || map[r, c + 1] != 0) && (r == map.GetLength(0) - 1 || map[r + 1, c] != 0) && (c == 0 || map[r, c - 1] != 0))
                    {
                        sc = sc + 1;
                        map[r, c] = sc;
                        ec = 50;
                        fEndDigit = map[r, c]; //Flag for floor end
                    }
                }
                if (sc < minEndDigit)
                {
                    occurrence = 0;
                    chU = 0;
                    chD = 0;
                    chL = 0;
                    chR = 0;
                    r = 0;
                    c = 0;
                    sc = 0;
                    ec = 0;
                    mapGenerated = false;
                    fEndDigit = 30;
                    int wipeR = 0;
                    int wipeL = 0;

                    for (wipeR = 0; wipeR < map.GetLength(0); wipeR++)
                    {
                        for (wipeL = 0; wipeL < map.GetLength(1); wipeL++)
                        {
                            map[wipeR, wipeL] = 0;
                        }
                    }
                }
                if (sc >= minEndDigit) break;
            }
            for (r = 0; r < map.GetLength(0); r++) //Rows
            {
                for (c = 0; c < map.GetLength(1); c++) //Collums
                {
                    if (map[r, c] == fEndDigit)
                    {
                        if (map[r, c] < 10)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write(map[r, c] + "  ");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write(map[r, c] + " ");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    else if (map[r, c] == rV1 || map[r, c] == rV2 || map[r, c] == rV3)
                    {
                        if (map[r, c] < 10)
                        {
                            Console.Write($"\u001b[38;2;218;165;32m{map[r, c]}  \u001b[0m");

                            /*Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write($"{map[r, c]}  ");
                            Console.ForegroundColor = ConsoleColor.White;*/
                        }
                        else
                        {
                            Console.Write($"\u001b[38;2;218;165;32m{map[r, c]} \u001b[0m");

                            /*Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write($"{map[r, c]} ");
                            Console.ForegroundColor = ConsoleColor.White;*/
                        }
                    }
                    else
                    {
                        if (map[r, c] == 0)
                        {
                            Console.Write($"\u001b[38;2;0;102;0m{map[r, c]}  \u001b[0m");

                            /*Console.ForegroundColor= ConsoleColor.DarkGreen;
                            Console.Write($"{map[r, c]}  ");
                            Console.ForegroundColor = ConsoleColor.White;*/
                        }
                        else
                        {
                            if (map[r, c] < 10)
                            {
                                Console.Write(map[r, c] + "  ");
                            }
                            else
                            {
                                Console.Write(map[r, c] + " ");
                            }
                        }
                    }
                }
                Console.WriteLine();
            }
            mapGenerated = true;

        }

        public static void Travel()
        {
            char cinput = ' ';    //Char Input

            void DefaultLogger()
            {
                Console.WriteLine("\n");
                dL = 1;
            }

            if (Program.gStartFlag == true)
            {
                r = 0;
                c = 0;
            }

            while (tL)
            {
                do
                {
                    tV = map[r, c];

                    if (isPositionFlag == false)
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 10);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("P");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(0, Console.CursorTop + 10);

                        isPositionFlag = true;
                    }

                    var directions = new Dictionary<char, (int dr, int dc)>
                    {
                        { 'w', (-1, 0) },
                        { 'd', (0, 1) },
                        { 's', (1, 0) },
                        { 'a', (0, -1) }
                    };

                    List<char> availableMoves = new List<char>();

                    foreach (var dir in directions)
                    {
                        int newR = r + dir.Value.dr;
                        int newC = c + dir.Value.dc;

                        if (newR >= 0 && newR < map.GetLength(0) &&
                            newC >= 0 && newC < map.GetLength(1) &&
                            map[newR, newC] != 0)
                        {
                            availableMoves.Add(dir.Key);
                        }
                    }

                    if (availableMoves.Count > 0)
                    {
                        Console.WriteLine("Go " + string.Join(", ", availableMoves).ToUpper() + ":              ");
                        var key = Console.ReadKey(intercept: false).KeyChar;
                        cinput = char.ToLower(key);

                        if (availableMoves.Contains(cinput))
                        {
                            var move = directions[cinput];
                            r += move.dr;
                            c += move.dc;
                            Console.WriteLine($"\nYou go {cinput}");
                        }
                        else
                        {
                            DefaultLogger();
                        }
                    }

                    if (dL == 1) { dLLoop = true; dL = 0; }
                    else { dLLoop = false; }

                    Console.WriteLine(map[r, c] + "             ");
                    Console.SetCursorPosition(0, Console.CursorTop - 4);

                } while (dLLoop);

                switch (cinput)
                {
                    case 'w':   //Reset earlier Position
                        Console.SetCursorPosition(Console.CursorLeft + tC, Console.CursorTop + (tR - 10));
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        if (map[r, c] > 9) { Console.Write(tV + " "); }
                        else { Console.Write(tV); }
                        Console.SetCursorPosition(0, Console.CursorTop - (tR - 10));
                        tR--;
                        //Set new Position
                        Console.SetCursorPosition(Console.CursorLeft + tC, Console.CursorTop + (tR - 10));
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        if (map[r, c] > 9) { Console.Write("Pl"); }
                        else { Console.Write("P"); }
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(0, Console.CursorTop + (10 - tR));
                        break;
                    case 'd':   //Reset earlier Position
                        Console.SetCursorPosition(Console.CursorLeft + tC, Console.CursorTop + (tR - 10));
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        if (map[r, c] > 9) { Console.Write(tV + " "); }
                        else { Console.Write(tV); }
                        Console.SetCursorPosition(0, Console.CursorTop - (tR - 10));
                        tC = tC + 3;
                        //Set new Position
                        Console.SetCursorPosition(Console.CursorLeft + tC, Console.CursorTop + (tR - 10));
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        if (map[r, c] > 9) { Console.Write("Pl"); }
                        else { Console.Write("P"); }
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(0, Console.CursorTop + (10 - tR));
                        break;
                    case 's':   //Reset earlier Position
                        Console.SetCursorPosition(Console.CursorLeft + tC, Console.CursorTop + (tR - 10));
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        if (map[r, c] > 9) { Console.Write(tV + " "); }
                        else { Console.Write(tV); }
                        Console.SetCursorPosition(0, Console.CursorTop - (tR - 10));
                        tR++;
                        //Set new Position
                        Console.SetCursorPosition(Console.CursorLeft + tC, Console.CursorTop + (tR - 10));
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        if (map[r, c] > 9) { Console.Write("Pl"); }
                        else { Console.Write("P"); }
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(0, Console.CursorTop + (10 - tR));
                        break;
                    case 'a':   //Reset earlier Position
                        Console.SetCursorPosition(Console.CursorLeft + tC, Console.CursorTop + (tR - 10));
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        if (map[r, c] > 9) { Console.Write(tV + " "); }
                        else { Console.Write(tV); }
                        Console.SetCursorPosition(0, Console.CursorTop - (tR - 10));
                        tC = tC - 3;
                        //Set new Position
                        Console.SetCursorPosition(Console.CursorLeft + tC, Console.CursorTop + (tR - 10));
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        if (map[r, c] > 9) { Console.Write("Pl"); }
                        else { Console.Write("P"); }
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(0, Console.CursorTop + (10 - tR));
                        break;
                }

                if (map[r, c] == rV1 || map[r, c] == rV2 || map[r, c] == rV3)
                {
                    Console.WriteLine("\n\n\n");
                    for (int td = 0; td < 9; td++) Console.WriteLine("                                                    ");

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("YOU FOUND TREASURE.                                        ");
                    Console.WriteLine("Found:                                                     ");
                    Console.WriteLine("                                                           ");
                    Console.WriteLine("Press any Key:                                             ");
                    Console.ForegroundColor = ConsoleColor.White;

                    Reward.fTreasure = true;
                    Reward.Treasure();

                    Console.ReadKey();

                    Console.SetCursorPosition(0, Console.CursorTop - 15);
                    for (int td = 0; td < 18; td++) Console.WriteLine("                                                    ");
                    Console.SetCursorPosition(0, Console.CursorTop - 18);
                    if (map[r, c] == rV1) { rV1 = 100; }
                    else if (map[r, c] == rV2) { rV2 = 100; }
                    else if (map[r, c] == rV3) { rV3 = 100; }
                }

                if (Program.fullTest == false) { eChance = Program.rnd.Next(10); }
                if (eChance == 0 || map[r, c] == fEndDigit)
                {
                    tL = false;
                    dL = 0;
                    dLLoop = false;
                    Console.WriteLine("\n\n\n");
                }
                if (map[r, c] == fEndDigit)
                {
                    for (int test = 0; test < 13; test++) Console.WriteLine(" ");
                    MethodClass.ResetWinBoss();
                    return;
                }
            }
        }
    }
}