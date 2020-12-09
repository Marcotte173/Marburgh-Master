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
        flavor = new List<string> { "You have found a chest!" };
        name = $"Chest";
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
            "There is a staircase leading upwards towards a Gaint Ornate Door",
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
        Write.Line(113 - 4, 23, Color.SPEAK + "East Wing");
        Write.Line(84 - 4, 23, Color.SPEAK + "West Wing");
        Write.Line(91, 25, "xxxxxxxxxxxxxxx");
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (choice == "n")
        {
            global::Explore.dungeon = Dungeon.MansionNorth;
            global::Explore.currentRoom = global::Explore.dungeon.layout[1];
            global::Explore.Menu();
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
        else Explore();
    }    
}