using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MansionEntrance:Room
{
    public MansionEntrance()
    : base()
    {
        flavorColourArray = new List<int> { 0 };
        flavor = new List<string> { "You have returned to the foyer" };
        name = "Foyer";
        skipExplore = true;
    }

    internal override void Explore()
    {
        Console.Clear();
        global::Explore.Box(new List<int> {0,0,0,0,0,0,0 },new List<string> 
        {
            "You are in the main foyer of the Necromancer's mansion",
            "",
            "In the distance you hear screams",
            "",
            "There is a staircase leading upwards towards a Giant Ornate Door",
            "",
            "There are doors to the east and to the west"
        });
        Console.SetCursorPosition(56, 19);
        Write.Line(Color.NAME, "[", "N", "]orth");
        Console.SetCursorPosition(70, 23);
        Write.Line(Color.NAME, "[", "E", "]ast");
        Console.SetCursorPosition(44, 23);
        Write.Line(Color.NAME, "[", "W", "]est");
        Write.Line(98 - 5, 21, Color.SPEAK + "Ornate Door");
        Write.Line(113 - 5, 23, Color.SPEAK + "East Wing");
        Write.Line(84 - 4, 23, Color.SPEAK + "West Wing");
        Write.Line(91, 25, "xxxxxxxxxxxxxxx");
        global::Explore.TopExploreInfoBar();
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (choice == "n")
        {
            Dungeon.mansionDoorToBoss.Explore();
        }
        else if (choice == "e")
        {

            global::Explore.dungeon = Dungeon.MansionEast;
            global::Explore.currentRoom = global::Explore.dungeon.layout[1];
            global::Explore.Menu();
        }
        else if (choice == "w")
        {

            global::Explore.dungeon = Dungeon.MansionWest;
            global::Explore.currentRoom = global::Explore.dungeon.layout[1];
            global::Explore.Menu();
        }
        else if (choice == "0") Utilities.ToTown();
        else if (choice == "9")
        {
            CharacterSheet.Display();
            Explore();
        }
        else if (choice == "h")
        {
            Utilities.Heal();
            Explore();
        }
        else Explore();
    }    
}