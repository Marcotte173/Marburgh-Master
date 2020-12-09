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
        else if (choice == "1" || (choice == "2" && GameState.tutorialDungeon_B_available))
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
                Explore.Menu();
            }
        }
        Menu();
    }
}