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
            Write.Line(95,0,Color.MITIGATION+"      `'::::.                ");
            Write.Line(95,1, "      " + Color.DEATH + "  _____A_              ");
            Write.Line(95,2, "      " + Color.DEATH + " /      /\\             ");
            Write.Line(95,3, "   " + Color.DEATH + " __/__/\\__/  " + Color.DEATH + "\\___         ");
            Write.Line(95,4, "---" + Color.DEATH + "/__|" + Color.DAMAGE + "' '' '| " + Color.DEATH + "/___/\\" + Color.RESET + "----    ");
            Write.Line(95,5, "   " + Color.DAMAGE + "|''|''||''| |' '||        ");
            Write.Line(95,6, "  " + Color.HEALTH + " `'''''))'''`''''''        ");
            Write.Line(0, 9, "  " + Color.HEALTH + " ^   /\\      ");
            Write.Line(0, 10, " " + Color.HEALTH + " /*\\ /**\\     ");
            Write.Line(0, 11, "" + Color.HEALTH + " /***\\****\\ /\\   ");
            Write.Line(0, 12, "" + Color.HEALTH + "/*****\\----/**\\   ");
            Write.Line(0, 13, "" + Color.HEALTH + "-------" + Color.DEATH + "| | " + Color.HEALTH + "----" + Color.RESET + "");
            Write.Line(0,14, "  " + Color.DEATH + "| |  | |  | |" + Color.RESET + " ");
            Write.Line(93,8,"            /\\");
            Write.Line(93,9,"           /**\\");
            Write.Line(93,10,"          /****\\    /\\");
            Write.Line(93,11, Color.MITIGATION + "   /\\    /      \\ " + Color.RESET + " /**\\");
            Write.Line(93,12, Color.MITIGATION + "  /  \\  /  " + Color.DEATH + "/^^^\\" + Color.MITIGATION + " \\/    \\");
            Write.Line(93,13, Color.MITIGATION + " /    \\/   " + Color.DEATH + "|   |" +  Color.MITIGATION + " /      \\");
            Write.Line(93,14, Color.MITIGATION + "/     /    "  +Color.DEATH + "|   |" +   Color.MITIGATION + "/        \\");
            string choice = Return.Option();
            if (choice == "n") Family.Name();
            //if (choice == "x") GameState.TestCombat();
            //if (choice == "c")
            //{
            //    Create.p = new Warrior();
            //    Create.p.Damage = 1000;
            //    Create.p.Health = 3000;
            //    Create.p.Name = "Travis Marcotte";
            //    Forest.OldManGuess();
            //}
            else if (choice == "q") Environment.Exit(0);
            else Menu();
        }
    }
}