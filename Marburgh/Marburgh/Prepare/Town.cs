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
        else if (choice == "l") Location.now = Location.list[4];
        else if (choice == "t") Location.now = Location.list[5];
        else if (choice == "?") Location.now = Location.list[6];
        else if (choice == "o") Location.now = Location.list[7];
        else if (choice == "y") Location.now = Location.list[8];
        else if (choice == "b") Location.now = Location.list[9];
        else if (choice == "x") p.XP += 5;
        else if (choice == "k") Time.DayChange(1);
        Location.now.Go();
    }
}