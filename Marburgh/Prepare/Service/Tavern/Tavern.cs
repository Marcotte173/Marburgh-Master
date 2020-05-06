using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Tavern:Location
{    
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
        Console.SetCursorPosition(53, 25);
        Console.Write("[?] " + Colour.BLOOD + "MORE INFO" + Colour.RESET);
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
        else if (choice == "s" && tavernOptionList[3] == "peak to townsfolk" && GameState.Villagers != "")
        {
            Console.Clear();
            if (GameState.CanCraft)
            {
                UI.Keypress(new List<int> { 0, 0, 0 }, new List<string>
                {
                    "The townspeople thank you, one by one, relief on all of their faces",
                    "",
                    "The last person to thank you, the mayor of the town pulls you aside a moment",
                });
                if (Create.p.Name == GameState.Villagers)
                {
                    UI.Keypress(new List<int> { 1, 0, 1 }, new List<string>
                    {
                         Colour.SPEAK,"","'Thank the gods you were able to save us all'","",
                        "",
                        Colour.SPEAK, "", "'We will start rebuilding immediately'","",
                        
                    });                    
                }
                else
                {
                    UI.Keypress(new List<int> { 1, 0, 1 }, new List<string>
                    {
                         Colour.SPEAK,"",$"'Thank you so much for saving us all. We owe everything to you and your family, especially {GameState.Villagers}","",
                        "",
                        Colour.SPEAK, "", "'We will start rebuilding immediately'","",

                    });
                }
                UI.Keypress(new List<int> { 1, 0, 1, 0, 1 }, new List<string>
                {
                    Colour.SPEAK, "",$"'I am worried, however'","",
                    "",
                        Colour.SPEAK,"","'The Savage Orc is still out there, raising and army'","",
                    "",
                    Colour.SPEAK, "", "'Take this, we found it when we were prisoner. It may lead you to his real location''","",
                });
                Buttons.adventureButton.Add(Colour.MONSTER + "2" + Colour.RESET);
                Buttons.adventureList.Add("Savage Orc's Lair");
                GameState.Dungeon2Available = true;
            }
            else
            {
                if (Create.p.Name == GameState.Villagers)
                    UI.Keypress(new List<int> { 0, 0, 3, 1, 1 }, new List<string>
                    {
                        "One of the townsfolk approaches, while the others regard you, gratitude in their eyes.",
                        "",
                        Colour.SPEAK, Colour.NAME, Colour.SPEAK, "", "'Thank you so much ","", $"{Create.p.Name} ","","for rescuing us!","",
                        Colour.SPEAK, "",$"We were sure we were going to die in there","",
                        Colour.SPEAK, "","If only that horrible Orc was dead we would be able to start rebuilding our village'","",
                    });
                else
                    UI.Keypress(new List<int> { 0, 0, 3, 3, 1 }, new List<string>
                    {
                        "One of the townsfolk approaches, while the others regard you, gratitude in their eyes.",
                        "",
                        Colour.SPEAK, Colour.NAME, Colour.SPEAK, "", "'We are so sorry for your loss, ","", $"{Create.p.Name} ","",".","",
                        Colour.SPEAK, Colour.NAME, Colour.SPEAK,"", "We know ","", $"{GameState.Villagers} ","","was family, and saving us from that Orc is a debt we'll never be able to repay.","",
                        Colour.SPEAK, "","We'll certainly try tho, once that Orc and his army are gone and we can rebuild'",""
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
            if (choice == "0") Location.list[5].Menu();
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
    void Info()
    {
        Console.Clear();
        Console.WriteLine("\n" + Colour.ITEM + "Items" + Colour.RESET + " are a very important part of " + Colour.ENERGY + "Marburgh" + Colour.RESET + "\n\nThe right " + Colour.ITEM + "equipment" + Colour.RESET + " can mean the difference between sucess and " + Colour.DAMAGE + "death" + Colour.RESET + ".");
        Console.WriteLine("\n\n" + Colour.CLASS + "CHARACTER SCREEN" + Colour.RESET + "\n\nPress [" + Colour.CLASS + "9" + Colour.RESET + "] from the shop to see your character information, including which items you currently have equiped");
        Console.WriteLine("\n\n" + Colour.GOLD + "BUYING" + Colour.RESET + "\n\n" + Colour.ITEM + "Items" + Colour.RESET + " are listed in the store in order of price as well as power.\nTo purchase an item, select [" + Colour.ITEM + "B" + Colour.RESET + "]uy, then the " + Colour.ITEM + "item" + Colour.RESET + " you would like to purchase.\nIf you have the required " + Colour.GOLD + "gold" + Colour.RESET + ", you can purchase it");
        Console.WriteLine("\n\n" + Colour.GOLD + "SELLING" + Colour.RESET + "\n\nWhen you sell an " + Colour.ITEM + "item" + Colour.RESET + ", you will receive half of the item's " + Colour.GOLD + "value" + Colour.RESET + "");
        Console.WriteLine("\nIf you attempt to equip an " + Colour.ITEM + "item" + Colour.RESET + " in a slot that already has one, you will be prompted to sell your current item\n\n\n");
        Utilities.Keypress();
    }
}