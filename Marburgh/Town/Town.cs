using System;
using System.Collections.Generic;
using System.Text;

public class Town
{
    public static void Menu()
    {
        GameState.location = Location.Town;
        Console.Clear();
        UI.Town(new string[]
        {
            "You are in the town of Marburgh", "It is a small town, but is clearly growing", "Who knows what will be here in a month?"
        }, Buttons.adventureList, Buttons.shopList, Buttons.serviceList, Buttons.otherList, Buttons.adventureButton, Buttons.shopButton, Buttons.serviceButton, Buttons.otherButton);
        string choice = Return.Option();
        if (choice == "9") CharacterSheet.Display();
        else if (choice == "0")
        {
            if (UI.Confirm(new List<int> { 1 }, new List<string>
                {
                    Color.DAMAGE, "Would you like to ", "quit","?"
                })) Utilities.Quit();
        }
        else if (choice == "m") Shop.Menu("Marley");
        else if (choice == "w") Shop.Menu("Oscar");
        else if (choice == "a") Shop.Menu("Lela");
        else if (choice == "l") Level.Menu();
        else if (choice == "t") Tavern.Menu();
        else if (choice == "?") Help.Menu();
        else if (choice == "o") Other.Menu();
        else if (choice == "y") House.Menu();
        else if (choice == "b") Bank.Menu();
        //else if (choice == "x") GameState.Test();
        //else if (choice == "z") GameState.Death();
        //else if (choice == "c") GameState.CraftCheat();
        else if (choice == "1" || (choice == "2" && GameState.tutorialDungeon_B_available) || choice == "3" && GameState.mansionAvailable)
        {
            //If no, go home
            if (Create.p.CanExplore == false)
            {
                UI.Keypress(new List<int> { 0, 0, 0 }, new List<string>
                {
                    "You are exhausted",
                    "",
                    "You should go to bed"
                });
                Menu();
            }
            //Warning so you don't use it then leave right away
            if (UI.Confirm(new List<int> { 0, 0, 0 }, new List<string>
            {
                "You may only go exploring once a day",
                "",
                "Would you like to go now?"
            }))
            //Explore!
            {
                Create.p.CanExplore = false;
                if (choice == "1")
                {                    
                    Explore.dungeon  = Dungeon.dungeon1a;
                    Explore.currentRoom = Explore.dungeon.layout[1];
                }
                else if (choice == "2")
                {

                    Explore.dungeon = Dungeon.dungeon1b;
                    Explore.currentRoom = Explore.dungeon.layout[1];
                }
                else if (choice == "3")
                {

                    Explore.dungeon = Dungeon.MansionEntrance;
                    Explore.dungeon.layout[1].room.Explore();
                }
                Explore.Menu();
            }
        }
        Menu();
    }

    public static void FakeMenu()
    {
        GameState.location = Location.Town;
        Console.Clear();
        UI.Town(new string[]
        {
            "You are in the town of Marburgh","", "", "","All the stores are closed.","","","","Maybe someone there knows what's happening"
        }, null, null, new List<string> {"avern" }, null, null, null, new List<string> { Color.TIME + "T" + Color.RESET }, null);
        Write.Line(51, 6, "Something is "+Color.DEATH+"wrong"+Color.RESET);
        Write.Line(45,10, "The light is on at the "+Color.TIME+"Tavern"+Color.RESET);
        string choice = Return.Option();
        if (choice == "9") CharacterSheet.Display();
        else if (choice == "0")
        {
            if (UI.Confirm(new List<int> { 1 }, new List<string>
                {
                    Color.DAMAGE, "Would you like to ", "quit","?"
                })) Utilities.Quit();
        }
        else if (choice == "?") FakeHelp();
        else if (choice == "t") FakeTavern();
        FakeMenu();
    }

    private static void FakeHelp()
    {
        Console.Clear();
        Write.Line(Color.BLOOD, "", "MORE INFO", "\n\nWelcome to Marburgh\n\nThings are pretty messed up");
        Write.Line(Color.DEATH, "\nEveryone's gone\n");
        Console.WriteLine("\nAll the stores are closed, and no one is on the streets");
        Console.WriteLine("It's actually worse than after the Savage Orc attacks\n");
        Write.Line(Color.NAME, "Tavern\n\n");
        Console.WriteLine("There is a light on at the tavern");
        Console.WriteLine("Maybe someone there knows something");
        Utilities.Keypress(0, 28);
    }

    private static void FakeTavern()
    {
        GameState.location = Location.Tavern;
        Console.Clear();
        UI.Choice(new List<int> { 1,0,1 }, new List<string>
            {
                Color.SPEAK, "", "You enter a decidedly unbustling tavern. There are one or two terified customers","",
                "",
                Color.SPEAK, "", "The bartender looks at you wearily as he cleans a glass",""
            },
           new List<string> {"peak with the bartender" }, new List<string> {Color.XP + "S"+ Color.RESET });
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (choice == "9") CharacterSheet.Display();
        else if (choice == "0") FakeMenu();
        else if (choice == "?") FakeHelp();
        else if (choice == "s") FakeBartender();
        FakeTavern();
    }

    private static void FakeBartender()
    {
        UI.Keypress(new List<int> { 1,0,1,0,1,0,1,0,1 }, new List<string>
        {
            Color.SPEAK,"","'I know you were trying to help, but you may have made things worse","",
            "",
            Color.SPEAK,"","You know the creepy old house on the top of the hill?","",
            "",
            Color.SPEAK,"","The owner always did creepy experiments on livestock","",
            "",
            Color.SPEAK,"","I heard was trying to create an army of undead, and needs humans to experiment on","",
            "",
            Color.SPEAK,"","When you killed the Orc, he must have figured this was the perfect opportunity to strike'","",
        });
        UI.Keypress(new List<int> { 1, 0, 1, 0, 1, 0, 2, 0, 1 }, new List<string>
        {
            Color.SPEAK,"","'We hate to ask you to help again, but we can't live like this","",
            "",
            Color.SPEAK,"","One last thing","",
            "",
            Color.SPEAK,"","My family had a necklace. It is an heirloom passed down through the years ","",
            "",
            Color.SPEAK,Color.DEATH,"","It has mystical powers and is said to be able to absorb ","","death","",
            "",
            Color.SPEAK,"","If you could return it to me I would be eternally grateful'","",
        });
        GameState.Mansion();
        Menu();
    }
}