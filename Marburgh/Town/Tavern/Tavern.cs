using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Tavern
{    
    public static int wager;    

    public static void Menu()
    {
        GameState.location = Location.Tavern;
        Console.Clear();
        Utilities.Buttons(Button.listOfTavernOptions);
        if (GameState.phase3)
        {

        }
        else if (GameState.phase2b)
        {
            UI.Choice(new List<int> { 1, 0, 1, 0, 1 }, new List<string>
            {
                Color.XP, "You enter a surprisingly lively ", "tavern","",
                "",
                Color.NAME,"Groups of ","townspeople"," are drinking lively, as if in open defiance of their circumstances",
                "",
                Color.NAME,"",$"{GameState.currentBartender.name}"," is serving several customers at the same time"
            }, Button.list1, Button.button1);
        }
        else if (GameState.phase2a)
        {
            UI.Choice(new List<int> { 1, 0, 1, 0, 1 }, new List<string>
            {
                Color.XP, "You enter a surprisingly lively ", "tavern","",
                "",
                Color.NAME,"Groups of ","townspeople"," are drinking lively, as if in open defiance of their circumstances",
                "",
                Color.NAME,"",GameState.currentBartender.name," the bartender motions you over to talk"
            }, Button.list1, Button.button1);
        }
        else if (GameState.phase1b)
        {
            UI.Choice(new List<int> { 1, 0, 1, 0, 1 }, new List<string>
            {
                Color.XP, "You enter a the ", "tavern","",
                "",
                Color.NAME,"There are a few ","townspeople"," drinking together. Possibly having reunions",
                "",
                Color.NAME,"",$"{GameState.currentBartender.name}"," the bartender is cleaning a glass"
            }, Button.list1, Button.button1);
        }
        else
        {
            UI.Choice(new List<int> {1,0,1,0,1 }, new List<string>
            {
                Color.XP, "You enter the ", "tavern","",
                "",
                Color.NAME,"There are a couple of older ","townspeople"," in the corner, drinking quietly",
                "",
                Color.NAME,"",$"{GameState.currentBartender.name}"," the bartender is polishing a glass quietly"
            }, Button.list1, Button.button1);
        }
        Write.Line(104, 27, "[" + Color.BLOOD + "?" + Color.RESET + "] " + Color.BLOOD + "MORE INFO" + Color.RESET);
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (choice == "g" && Button.gambleButton.active) Gamble(Create.p);
        else if (choice == "l" && Button.gossipButton.active) LocalGossip.Menu();
        else if (choice == "t")
        {
            if (GameState.phase2a)
            {
                UI.Keypress(new List<int> { 1,0,1,0,3,0,3 }, new List<string>
                {
                    Color.SPEAK,"","'Hail the conquering hero!","",
                    "",
                    Color.SPEAK,"","Seriously tho, we're in deep shit","",
                    "",
                    Color.SPEAK,Color.BOSS,Color.SPEAK,"","Turns out the ","","Savage Orc",""," was just a lackey","",
                    "",
                    Color.SPEAK,Color.DEATH,Color.SPEAK,"","While you were sleeping, his master, the ","","Necromancer","",", came to town","",
                 });
                UI.Keypress(new List<int> {3,0,2,0,3 }, new List<string>
                {
                    Color.SPEAK,Color.BOSS,Color.SPEAK,"","'We should have seen this coming, ","","weird stuff",""," has been hapening in town for a while ","",
                    "",
                    Color.NAME,Color.SPEAK,"","Daniel","",", the town's Grave keeper swears that many old graves have been opened","",
                    "",
                    Color.SPEAK,Color.DEATH,Color.SPEAK,"","It's clear the ","","Necromancer",""," has been here, behind the scenes, for some time","",
                 });
                UI.Keypress(new List<int> {1,0,3,0,1,0,3,0,3 }, new List<string>
                {
                    Color.SPEAK,"","We hate to ask you to help again, but we can't live like this","",
                    "",
                    Color.SPEAK,Color.DEATH,Color.SPEAK,"","I do warn you, however, This ","","foe",""," is far more powerful than anything you've ever faced","",
                    "",
                    Color.SPEAK,"","You may want to find a way to get stronger before you take him on","",
                    "",
                    Color.SPEAK,Color.HEALTH,Color.SPEAK,"","Here is a map to the ","","forest","",". There, you can hone your skills","",
                    "",
                    Color.SPEAK,Color.DEATH,Color.SPEAK,"","Either way, he lives in his ","","mansion",""," at the top of the hill",""
                 });
                UI.Keypress(new List<int> {3,0,2,0,1,0,2,0,3 }, new List<string>
                {
                    Color.SPEAK,Color.HEALTH,Color.SPEAK,"","Everyone is ","","pitching",""," in","",
                    "",
                    Color.SPEAK,Color.XP,"","Everyone is opening their ","","businesses","",
                    "",
                    Color.SPEAK,"","It's dangerous but it's our only hope","",
                    "",
                    Color.SPEAK,Color.GOLD,"","Hell, if anything, this danger is ","","good for business","",
                    "",
                    Color.SPEAK,Color.POTION,Color.SPEAK,"","If it's the end times, what are people going to do but ","","drink","","?",""
                 });
                UI.Keypress(new List<int> {1,0,1,0,2,0,2,0,3 }, new List<string>
                {
                    Color.SPEAK,"","One last thing","",
                    "",
                    Color.SPEAK,"","My family had a necklace. It is an heirloom passed down through the years ","",
                    "",
                    Color.SPEAK,Color.DEATH,"","It has mystical powers and is said to be able to absorb ","","death","",
                    "",
                    Color.SPEAK,Color.DEATH,"","It may come in handy working through his ","","mansion","",
                    "",
                    Color.SPEAK,Color.DEATH,Color.SPEAK,"","If you could return it to me when you have defeated the ","","Necromancer",""," I would be eternally grateful'","",
                 });
                GameState.Phase2B();
            }            
            else GameState.currentBartender.Menu();
        }
        else if (choice == "?") Info();
        else if (choice == "0")
            Utilities.ToTown();
        else if (choice == "9")
            CharacterSheet.Display();
        else if (choice == "s" && Button.townspeopleButton.active)
        {
            Console.Clear();
            if (GameState.firstBossDead)
            {
                UI.Keypress(new List<int> { 0, 0, 0 }, new List<string>
                {
                    "The townspeople thank you, one by one, relief on all of their faces",
                    "",
                    "The last person to thank you, the mayor of the town pulls you aside a moment",
                });
                if (Create.p.Name == GameState.villagersSaved)
                {
                    UI.Keypress(new List<int> { 1, 0, 1 }, new List<string>
                    {
                         Color.SPEAK,"","'Thank the gods you were able to save us all'","",
                        "",
                        Color.SPEAK, "", "'We will start rebuilding immediately'","",

                    });
                }
                else
                {
                    UI.Keypress(new List<int> { 1, 0, 1 }, new List<string>
                    {
                         Color.SPEAK,"",$"'Thank you so much for saving us all. We owe everything to you and your family, especially {GameState.villagersSaved}","",
                        "",
                        Color.SPEAK, "", "'We will start rebuilding immediately'","",

                    });
                }
                UI.Keypress(new List<int> { 1, 0, 1, 0, 1 }, new List<string>
                {
                    Color.SPEAK, "",$"'I am worried, however'","",
                    "",
                        Color.SPEAK,"","'The Savage Orc is still out there, raising an army'","",
                    "",
                    Color.SPEAK, "", "'Take this map, we found it when we were prisoner. It may lead you to his real location''","",
                });
                GameState.Phase1B();
            }
            else
            {
                if (Create.p.Name == GameState.villagersSaved)
                    UI.Keypress(new List<int> { 0, 0, 3, 1, 1 }, new List<string>
                    {
                        "One of the townsfolk approaches, while the others regard you, gratitude in their eyes.",
                        "",
                        Color.SPEAK, Color.NAME, Color.SPEAK, "", "'Thank you so much ","", $"{Create.p.Name} ","","for rescuing us!","",
                        Color.SPEAK, "",$"We were sure we were going to die in there","",
                        Color.SPEAK, "","If only that horrible Orc was dead we would be able to start rebuilding our village'","",
                    });
                else
                    UI.Keypress(new List<int> { 0, 0, 3, 3, 1 }, new List<string>
                    {
                        "One of the townsfolk approaches, while the others regard you, gratitude in their eyes.",
                        "",
                        Color.SPEAK, Color.NAME, Color.SPEAK, "", "'We are so sorry for your loss, ","", $"{Create.p.Name} ","",".","",
                        Color.SPEAK, Color.NAME, Color.SPEAK,"", "We know ","", $"{GameState.villagersSaved} ","","was family, and saving us from that Orc is a debt we'll never be able to repay.","",
                        Color.SPEAK, "","We'll certainly try tho, once that Orc and his army are gone and we can rebuild'",""
                    });
            }
        }
        Menu();
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
            new List<string> { "lack Jack", "hree Card Monty", "ice" }, new List<string> { Color.GOLD + "B" + Color.RESET, Color.GOLD + "T" + Color.RESET, Color.GOLD + "D" + Color.RESET });
            string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
            if (choice == "0") Menu();
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
                    Color.GOLD, "You have ", $"{p.Gold}", " gold",
                    "",
                    "How much would you like to wager?",
                    "",
                    "[0] Return"
                });
        if (wager == 0) Menu();
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
                Color.GOLD, "You want to wager ", $"{wager}", " gold?"
            }) == false) Wager(p);
            else p.Gold -= wager;
        }
    }
    static void Info()
    {
        Console.Clear();
        Write.Line(Color.BLOOD, "", "MORE INFO", "\n\n");
        Console.WriteLine("\nThe" + Color.TIME + " Tavern" + Color.RESET + " is a place to relax, socialize, gamble and meet the locals ");
        Console.WriteLine("\n\n" + Color.CLASS + "GOSSIP" + Color.RESET + "\n\nThe locals are a veritable font of information. \nWhere to find a job, who's in love with whom, where to find a secret dungeon.....");
        Console.WriteLine("\n\n" + Color.XP + "TALK TO THE BARTENDER" + Color.RESET + "\n\nThe bartender has his finger on the pulse of this town.\nGranted, that's not saying much\nBut for the right price anything can be yours");
        Console.WriteLine("\n\n" + Color.GOLD + "GAMBLE" + Color.RESET + "\n\nWho needs adventure? You have all the excitement you need at the table surrounded by stuffy old men.\nI mean, the orcs are still coming, but maybe uf you don't lose it all, you can get a new weapon.\n\n\n\n");
        Utilities.Keypress();
    }
}