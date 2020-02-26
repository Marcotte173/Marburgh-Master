using System;
using System.Collections.Generic;

namespace MedievalRPG
{
    internal class GameStart
    {
        internal static void Menu()
        {
            Console.CursorVisible = false;
            Console.Clear();
            UI.GameMenu(new List<int> { 1, 1, 1, 1, 1, 1, 1 }, new List<string>
            {
                Colour.TIME,  "",  "/'\\_/`\\             ( )                       ( )    ","",
                Colour.XP,    "",  "|     |   _ _  _ __ | |_    _   _  _ __   __  | |__  ","",
                Colour.BOSS,  "",  "| (_) | /'_` )( '__)| '_`\\ ( ) ( )( '__)/'_ `\\|  _ `\\","",
                Colour.DROP,  "",  "| | | |( (_| || |   | |_) )| (_) || |  ( (_) || | | |,","",
                Colour.RAREDROP,"","(_) (_)`\\__,_)(_)   (_,__/'`\\___/'(_)  `\\__  |(_) (_)","",
                Colour.NAME,  "",  "                                       ( )_) |       ","",
                Colour.GOLD,  "", "                                        \\___/'       ",""
            },
            new List<string> { "ew Game" }, new List<string> { Colour.HEALTH + "N" + Colour.RESET });
            string choice = Return.Option();
            if (choice == "n") Family.Create();
            else if (choice == "q") Environment.Exit(0);
            else Menu();
        }
    }
}