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
            string choice = Return.Option();
            if (choice == "n") Family.Name();
            //if (choice == "x") GameState.TestCombat(new List<Monster> { Dungeon.necromancer2});
            //if (choice == "c") GameState.Test();
            else if (choice == "q") Environment.Exit(0);
            else Menu();
        }
    }
}