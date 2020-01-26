using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Tavern:Location
{    
    Player p = Create.p;
    public static int wager;
    public Tavern()
    : base() { }
    public static List<string> tavernOptionButton = new List<string>
    {
        Colour.XP + "L" + Colour.RESET,
        Colour.XP + "T" + Colour.RESET,
        Colour.GOLD + "G" + Colour.RESET,
        ""
    };
    public static List<string> tavernOptionList = new List<string>
    {
        "ocal gossip",
        "alk to the bartender",
        "amble",
        ""
    };
    
    public override void Menu()
    {
        Console.Clear();
        UI.Choice(new List<int> { 1 }, new List<string>
            {
                Colour.SPEAK, "", "You enter a bustling tavern. More flavor will be added soon describing the place and what you can do.",""
            },
           tavernOptionList, tavernOptionButton);
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (choice == "g")
            Gamble(p);
        else if (choice == "l")
            Gossip();
        else if (choice == "t")
            Bartender();
        else if (choice == "r")
            Utilities.ToTown();
        //else if (choice == "s" && tavernOptionList[3] == "peak to townsfolk" && Marburgh.Program.tutorial == false)
        //{
        //    Console.Clear();
        //    if (Dungeon.DungeonInfo[0].boss.IsAlive)
        //    {
        //        if (p.family.FirstName == RandomEvent.RescueName)
        //            UI.Keypress(new List<int> { 0, 0, 3, 1, 1 }, new List<string>
        //            {
        //                "One of the townsfolk approaches, while the others regard you, gratitude in their eyes.",
        //                "",
        //                Colour.SPEAK, Colour.NAME, Colour.SPEAK, "", "'Thank you so much ","", $"{p.family.FirstName} ","","for rescuing us!","",
        //                Colour.SPEAK, "",$"We were sure we were going to die in there","",
        //                Colour.SPEAK, "","If only that horrible Orc was dead we would be able to start rebuilding our village'","",
        //            });
        //        else
        //            UI.Keypress(new List<int> { 0, 0, 3, 3, 1 }, new List<string>
        //            {
        //                "One of the townsfolk approaches, while the others regard you, gratitude in their eyes.",
        //                "",
        //                Colour.SPEAK, Colour.NAME, Colour.SPEAK, "", "'We are so sorry for your loss, ","", $"{p.family.FirstName} ","",".","",
        //                Colour.SPEAK, Colour.NAME, Colour.SPEAK,"", "We know ","", $"{RandomEvent.RescueName} ","","was family, and saving us from that Orc is a debt we'll never be able to repay.","",
        //                Colour.SPEAK, "","We'll certainly try tho, once that Orc and his army are gone and we can rebuild'",""
        //            });
        //    }
        //    else
        //    {
        //        Console.WriteLine("The townspeople thank you, one by one, relief on all of their faces.\nThe last person to thank you, the mayor of the town pulls you aside a moment");
        //        if (p.family.FirstName == RandomEvent.RescueName) Utilities.ColourText(Colour.SPEAK, $"\n'Thank the gods you were able to save us all.\nWe will start rebuilding immediately.\nIn time, our town will be as strong and prosperous as it ever was.\nI am worried tho. I believe that this was only the beginning\nThere are monsters and terrors out there eager to stake a claim on our land'");
        //        else Utilities.ColourText(Colour.SPEAK, $"\n'Thank you so much for saving us all. We owe everything to you and your family, especially {RandomEvent.RescueName}\nWe will start rebuilding immediately.\nIn time, our town will be as strong and prosperous as it ever was.\nI am worried tho. I believe that this was only the beginning\nThere are monsters and terrors out there eager to stake a claim on our land'");
        //        Utilities.Keypress();
        //        Console.Clear();                
        //    }
        //}
        Menu();
    }

    private static void Bartender()
    {
        Console.Clear();
        UI.Keypress(new List<int> { 1 }, new List<string>
        {
            Colour.SPEAK, "","The Bartender will have more to say once dungeoning has been implemented",""
        });
    }

    private static void Gossip()
    {
        Console.Clear();
        UI.Keypress(new List<int> { 1 }, new List<string>
                {
                    Colour.SPEAK, "","Word is this game's gonna be pretty cool when it gets finished",""
                });
    }

    private static void Gamble(Creature p)
    {
        if (p.Gold > 0)
        {
            Console.Clear();
            UI.Choice(new List<int> { 0, 0, 0, 0 }, new List<string>
            {
                "You head towards the back of the tavern",
                "Having grown up in Marburgh, you know where all the games are, legal and otherwise",
                "",
                "What do you feel like playing?"
            },
            new List<string> { "lack Jack", "hree Card Monty", "ice", "" }, new List<string> { Colour.GOLD + "B" + Colour.RESET, Colour.GOLD + "T" + Colour.RESET, Colour.GOLD + "D" + Colour.RESET, "" });
            string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
            if (choice == "r") Location.list[5].Menu();
            else if (choice != "b" && choice != "t" && choice != "d") Gamble(p);
            Wager(p);
            if (choice == "b") BlackJackGame.StartBlackJack(p, wager);
            if (choice == "d") DiceGame.Dice(p, wager);
            if (choice == "t") ThreeCardMonteGame.ThreeCardMonte(p, wager);
        }
        else UI.Keypress(new List<int> { 0 }, new List<string>
                {
                    "You don't have enough money!"
                });
    }

    private static void Wager(Creature p)
    {
        Console.Clear();
        wager = UI.HowMuch(new List<int> { 1, 0, 0, 0, 0 }, new List<string>
                {
                    Colour.GOLD, "You have ", $"{p.Gold}", " gold",
                    "",
                    "How much would you like to wager?",
                    "",
                    "[0] Return"
                });
        if (wager == 0) Location.list[5].Menu();
        else if (wager > 150 * p.Level)
        {
            UI.Keypress(new List<int> { 0 }, new List<string>
                {
                    "You can't gamble that much"
                });
            Wager(p);
        }
        else if (p.Gold >= wager)
        {
            if (UI.Confirm(new List<int> { 1 }, new List<string>
            {
                Colour.GOLD, "You want to wager ", $"{wager}", " gold?"
            }) == false) Wager(p);
            else p.Gold -= wager;
        }
    }
}