using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Tavern
{    
    public static int wager;

    public static List<string> tavernOptionButton = new List<string>
    {
        Color.XP + "L" + Color.RESET,
        Color.XP + "T" + Color.RESET,
        Color.GOLD + "G" + Color.RESET,
        ""
    };
    public static List<string> tavernOptionList = new List<string>
    {
        "ocal gossip",
        "alk to the bartender",
        "amble",
        ""
    };
    
    public static void Menu()
    {
        GameState.location = Location.Tavern;
        Console.Clear();
        UI.Choice(new List<int> { 1 }, new List<string>
            {
                Color.SPEAK, "", "You enter a bustling tavern. More flavor will be added soon describing the place and what you can do.",""
            },
           tavernOptionList, tavernOptionButton);
        Console.SetCursorPosition(53, 25);
        Console.Write("[?] " + Color.BLOOD + "MORE INFO" + Color.RESET);
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (choice == "g")
            Gamble(Create.p);
        else if (choice == "l")
            Gossip();
        else if (choice == "t")
            Bartender();
        else if (choice == "?") Info();
        else if (choice == "0")
            Utilities.ToTown();
        else if (choice == "9")
            CharacterSheet.Display();
        else if (choice == "s" && tavernOptionList[3] == "peak to townsfolk" && GameState.villagersSaved != "")
        {
            Console.Clear();
            if (GameState.canCraft)
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
                        Color.SPEAK,"","'The Savage Orc is still out there, raising and army'","",
                    "",
                    Color.SPEAK, "", "'Take this, we found it when we were prisoner. It may lead you to his real location''","",
                });
                Buttons.adventureButton.Add(Color.MONSTER + "2" + Color.RESET);
                Buttons.adventureList.Add("Savage Orc's Lair");
                GameState.tutorialDungeon_B_available = true;
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

    private static void Bartender()
    {
        Console.Clear();
        UI.Keypress(new List<int> { 1 }, new List<string>
        {
            Color.SPEAK, "","The Bartender will have more to say once dungeoning has been implemented",""
        });
    }

    private static void Gossip()
    {
        Console.Clear();
        UI.Keypress(new List<int> { 1 }, new List<string>
                {
                    Color.SPEAK, "","Word is this game's gonna be pretty cool when it gets finished",""
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
            new List<string> { "lack Jack", "hree Card Monty", "ice", "" }, new List<string> { Color.GOLD + "B" + Color.RESET, Color.GOLD + "T" + Color.RESET, Color.GOLD + "D" + Color.RESET, "" });
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
        Console.WriteLine("\n" + Color.ITEM + "Items" + Color.RESET + " are a very important part of " + Color.ENERGY + "Marburgh" + Color.RESET + "\n\nThe right " + Color.ITEM + "equipment" + Color.RESET + " can mean the difference between sucess and " + Color.DAMAGE + "death" + Color.RESET + ".");
        Console.WriteLine("\n\n" + Color.CLASS + "CHARACTER SCREEN" + Color.RESET + "\n\nPress [" + Color.CLASS + "9" + Color.RESET + "] from the shop to see your character information, including which items you currently have equiped");
        Console.WriteLine("\n\n" + Color.GOLD + "BUYING" + Color.RESET + "\n\n" + Color.ITEM + "Items" + Color.RESET + " are listed in the store in order of price as well as power.\nTo purchase an item, select [" + Color.ITEM + "B" + Color.RESET + "]uy, then the " + Color.ITEM + "item" + Color.RESET + " you would like to purchase.\nIf you have the required " + Color.GOLD + "gold" + Color.RESET + ", you can purchase it");
        Console.WriteLine("\n\n" + Color.GOLD + "SELLING" + Color.RESET + "\n\nWhen you sell an " + Color.ITEM + "item" + Color.RESET + ", you will receive half of the item's " + Color.GOLD + "value" + Color.RESET + "");
        Console.WriteLine("\nIf you attempt to equip an " + Color.ITEM + "item" + Color.RESET + " in a slot that already has one, you will be prompted to sell your current item\n\n\n");
        Utilities.Keypress();
    }
}