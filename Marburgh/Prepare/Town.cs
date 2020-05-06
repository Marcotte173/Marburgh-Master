using System;
using System.Collections.Generic;
using System.Text;

public class Town : Location
{
    Dungeon1 dungeon1 = new Dungeon1();
    Dungeon2 dungeon2 = new Dungeon2();
    public Town()
    : base() { }

    public override void Menu()
    {
        Console.Clear();
        UI.Town(new string[]
            {
                "You are in the town of Marburgh", "It is a small town, but is clearly growing", "Who knows what will be here in a month?"
            }, Buttons.adventureList, Buttons.shopList, Buttons.serviceList, Buttons.otherList, Buttons.adventureButton, Buttons.shopButton, Buttons.serviceButton, Buttons.otherButton);
        string choice = Return.Option();
        if (choice == "9") CharacterSheet.Display();
        else if (choice == "q")
        {
            if (UI.Confirm(new List<int> { 1 }, new List<string>
                {
                    Colour.DAMAGE, "Would you like to ", "quit","?"
                })) Utilities.Quit();
        }
        else if (choice == "m") Location.now = Location.list[1];
        else if (choice == "w") Location.now = Location.list[2];
        else if (choice == "a") Location.now = Location.list[3];
        else if (choice == "l") Location.now = Location.list[4];
        else if (choice == "t") Location.now = Location.list[5];
        else if (choice == "?") Location.now = Location.list[6];
        else if (choice == "o") Location.now = Location.list[7];
        else if (choice == "y") Location.now = Location.list[8];
        else if (choice == "b") Location.now = Location.list[9];
        else if (choice == "z") Create.p.TakeDamage(100, new Goblin()) ;
        else if (choice == "1" || (choice == "2" && GameState.Dungeon2Available))
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
                    Explore.shell = Dungeon1.shell;
                    Explore.currentShell = Dungeon1.shell[1];
                    dungeon1.Reset();
                }
                else if (choice == "2")
                {

                    Explore.shell = Dungeon2.shell;
                    Explore.currentShell = Dungeon2.shell[1];
                    dungeon2.Reset();
                }
                Location.list[11].Go();
            }
        }
        else if (choice == "x") Create.p.XP += 5;
        else if (choice == "k") Time.DayChange(1);
        Location.now.Go();
    }
}