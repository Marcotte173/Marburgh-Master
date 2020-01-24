using System;
using System.Collections.Generic;
using System.Text;

public class Town : Location
{
    Player p = Create.p;
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
        if (choice == "c") CharacterSheet.Display();
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
        Location.now.Go();
    }
}