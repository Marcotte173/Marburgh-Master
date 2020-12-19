using System;
using System.Collections.Generic;

namespace MedievalRPG
{
    internal class GameStart
    {
        internal static void Menu()
        {
            //Sound.Loop("town");
            Console.CursorVisible = false;
            Console.Clear();
            UI.GameMenu(new List<int> { 1, 1, 1, 1, 1, 1, 1 }, new List<string>
            {
                Color.TIME,  "",  "/'\\_/`\\             ( )                       ( )    ","",
                Color.XP,    "",  "|     |   _ _  _ __ | |_    _   _  _ __   __  | |__  ","",
                Color.BOSS,  "",  "| (_) | /'_` )( '__)| '_`\\ ( ) ( )( '__)/'_ `\\|  _ `\\","",
                Color.DROP,  "",  "| | | |( (_| || |   | |_) )| (_) || |  ( (_) || | | |,","",
                Color.RAREDROP,"","(_) (_)`\\__,_)(_)   (_,__/'`\\___/'(_)  `\\__  |(_) (_)","",
                Color.NAME,  "",  "                                       ( )_) |       ","",
                Color.GOLD,  "", "                                        \\___/'       ",""
            },
            new List<string> { "ew Game" }, new List<string> { Color.HEALTH + "N" + Color.RESET });
            Write.Line(95,0,Color.DEATH+"      `'::::.                ");
            Write.Line(95,1,"        _____A_              ");
            Write.Line(95,2,"       /      /\\             ");
            Write.Line(95,3,"    __/__/\\__/  \\___         ");
            Write.Line(95,4,"---/__|' '' '| /___/\\----    ");
            Write.Line(95,5,"   |''|''||''| |' '||        ");
            Write.Line(95,6,"   `'''''))'''`''''''        ");
            string choice = Return.Option();
            if (choice == "n") Family.Name();
            //if (choice == "x") GameState.TestCombat();
            //if (choice == "c") GameState.Test();
            else if (choice == "q") Environment.Exit(0);
            else Menu();
        }
    }
}