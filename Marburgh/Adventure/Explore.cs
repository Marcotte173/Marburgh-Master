using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Explore
{
    public static Dungeon dungeon ;
    protected static Room starter;
    public static Shell currentRoom;
    public static void Menu()
    {
        GameState.location = Location.Exploring;
        Navigate();
        while (true)
        {        
            if (currentRoom.room.visited == false)
            {
                if (!currentRoom.room.skipExplore) UI.Keypress(currentRoom.room.FlavorColourArray, currentRoom.room.Flavor);
                currentRoom.room.Explore();
            }                
            Navigate();
        }
    }

    private static void Navigate()
    {
        Console.Clear();
        NavigateUI(currentRoom.room.FlavorColourArray, currentRoom.room.Flavor, new int[] { currentRoom.North, currentRoom.South, currentRoom.East, currentRoom.West });
        string choice = Return.Option();
        if (choice == "n" && currentRoom.North > 0)
        {
            if (dungeon.layout[currentRoom.North].room.visited == false && !dungeon.layout[currentRoom.North].room.skipExplore ) ExploreNextRoom(null, null, new int[] { currentRoom.North, currentRoom.South, currentRoom.East, currentRoom.West });
            ChangeDungeon(currentRoom.North);
        }
        else if (choice == "s" && currentRoom.South > 0)
        {
            if (dungeon.layout[currentRoom.South].room.visited == false && !dungeon.layout[currentRoom.South].room.skipExplore) ExploreNextRoom(null, null, new int[] { currentRoom.North, currentRoom.South, currentRoom.East, currentRoom.West });
            ChangeDungeon(currentRoom.South);
        }
        else if (choice == "e" && currentRoom.East > 0)
        {
            if (dungeon.layout[currentRoom.East].room.visited == false && !dungeon.layout[currentRoom.East].room.skipExplore) ExploreNextRoom(null, null, new int[] { currentRoom.North, currentRoom.South, currentRoom.East, currentRoom.West });
            ChangeDungeon(currentRoom.East);
        }
        else if (choice == "w" && currentRoom.West > 0)
        {
            if (dungeon.layout[currentRoom.West].room.visited == false && !dungeon.layout[currentRoom.West].room.skipExplore) ExploreNextRoom(null, null, new int[] { currentRoom.North, currentRoom.South, currentRoom.East, currentRoom.West });
            ChangeDungeon(currentRoom.West);
        }
        else if (choice == "9") CharacterSheet.Display();
        else if (choice == "h") Utilities.Heal();        
        else if (choice == "0" && currentRoom == dungeon.layout[1])
        {
            ResetRoom();
            //Sound.Stop();
            Utilities.ToTown();
        }
        else if (choice == "0" && currentRoom != dungeon.layout[1])
        {
            Console.Clear();
            Console.WriteLine("You can only leave the dungeon from the entance");
            Utilities.Keypress();
        }
        else Navigate();
    }

    private static void ResetRoom()
    {
        foreach(Shell s in dungeon.layout)
        {
            if(s!= null)
            {
                if (s.room.resetable) s.room.visited = false;
            }           
        }
    }

    //Changes the current room
    public static void ChangeDungeon(int connect)
    {
        //Current Dungeon isn't current anymore, the Dungeon connection number is not current and visited 
        currentRoom = dungeon.layout[connect];
    }    

    public static void NavigateUI(List<int> colourArray, List<string> descriptions, int[] navConnect)
    {
        Box(colourArray, descriptions);
        Console.SetCursorPosition(57, 23);
        Write.Line(Color.HEALTH, "[", "H", "]eal");
        TopExploreInfoBar();
        NavOptions(navConnect);
    }

    //Small flavor for when you haven't been to a room yet
    public static void ExploreNextRoom(List<int> colourArray, List<string> descriptions, int[] navConnect)
    {
        Console.Clear();
        DotDotDot(colourArray, descriptions, navConnect, Color.MONSTER + "Exploring" + Color.RESET);
    }

    internal static void TopExploreInfoBar()
    {
        Console.SetCursorPosition(5, 17);
        Console.WriteLine(Color.NAME + $"{Create.p.Name}" + Color.RESET);
        Console.SetCursorPosition(32, 17);
        Console.WriteLine("Level:" + Color.XP + $"{Create.p.Level}" + Color.RESET);
        Console.SetCursorPosition(54, 17);
        Console.WriteLine("Health: " + Color.HEALTH + $"{Create.p.Health}" + Color.RESET + "/" + Color.HEALTH + $"{Create.p.MaxHealth}" + Color.RESET);
        Console.SetCursorPosition(78, 17);
        Console.WriteLine("[" + Color.CLASS + "9" + Color.RESET + "]Character");
        Console.SetCursorPosition(104, 17);
        Console.WriteLine("[" + Color.MITIGATION + "0" + Color.RESET + "]Return");
    }

    public static void Box(List<int> colourArray, List<string> descriptions)
    {
        Console.Clear();
        UIComponent.DisplayText(colourArray, descriptions);
        Console.SetCursorPosition(0, 16);
        Console.WriteLine("+----------------------------------------------------------------------------------------------------------------------+");
        Console.WriteLine("|                       |                       |                       |                       |                      |");
        Console.WriteLine("+----------------------------------------------------------------------------------------------------------------------+");
        Console.WriteLine("|xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx|       \\                  /       |xxxxxxxxxxxxx  " + Color.SHIELD + "Dungeon Map" + Color.RESET + "  xxxxxxxxxxxxx|");
        Console.WriteLine("|xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx|        \\                /        |xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx|");
        Console.WriteLine("|xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx|         +--------------+         |xxxxxxxxxxxxx               xxxxxxxxxxxxx|");
        Console.WriteLine("|xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx|         |              |         |xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx|");
        Console.WriteLine("|xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx|         |              |         |              xxxxx " + Color.BOSS + "O" + Color.RESET + " xxxxx              |");
        Console.WriteLine("|xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx|         |              |         |xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx|");
        Console.WriteLine("|xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx|         +--------------+         |xxxxxxxxxxxxx               xxxxxxxxxxxxx|");
        Console.WriteLine("|xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx|        /                \\        |xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx|");
        Console.WriteLine("|xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx|       /                  \\       |xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx|");
        Console.WriteLine("+-----------------------------------------+----------------------------------+-----------------------------------------+");
    }

    internal static void NavOptions(int[] navConnect)
    {
        if (navConnect[0] > 0)
        {
            Console.SetCursorPosition(56, 19);
            Write.Line(Color.NAME, "[", "N", "]orth");
            if (dungeon.layout[currentRoom.North].room.visited) Write.Line(98 - dungeon.layout[currentRoom.North].room.Name.Length / 2, 21, Color.SPEAK + dungeon.layout[currentRoom.North].room.Name);
            else Write.Line(97, 21, Color.SPEAK + "???");
        }
        else Write.Line(91, 21, "xxxxxxxxxxxxxxx");

        if (navConnect[1] > 0)
        {
            Console.SetCursorPosition(56, 27);
            Write.Line(Color.NAME, "[", "S", "]outh");
            if (dungeon.layout[currentRoom.South].room.visited) Write.Line(98 - dungeon.layout[currentRoom.South].room.Name.Length / 2, 25, Color.SPEAK + dungeon.layout[currentRoom.South].room.Name);
            else Write.Line(97, 25, Color.SPEAK + "???");
        }
        else Write.Line(91, 25, "xxxxxxxxxxxxxxx");

        if (navConnect[2] > 0)
        {
            Console.SetCursorPosition(70, 23);
            Write.Line(Color.NAME, "[", "E", "]ast");
            if (dungeon.layout[currentRoom.East].room.visited) Write.Line(113 - dungeon.layout[currentRoom.East].room.Name.Length / 2, 23, Color.SPEAK + dungeon.layout[currentRoom.East].room.Name);
            else Write.Line(112, 23, Color.SPEAK + "???");
        }
        else Write.Line(105, 23, "xxxxxxxxxxxxxxx");

        if (navConnect[3] > 0)
        {
            Console.SetCursorPosition(44, 23);
            Write.Line(Color.NAME, "[", "W", "]est");
            if (dungeon.layout[currentRoom.West].room.visited) Write.Line(84 - dungeon.layout[currentRoom.West].room.Name.Length / 2, 23, Color.SPEAK + dungeon.layout[currentRoom.West].room.Name);
            else Write.Line(83, 23, Color.SPEAK + "???");
        }
        else Write.Line(78, 23, "xxxxxxxxxxxxxxx");
    }
    
    public static void DotDotDot(List<int> colourArray, List<string> descriptions, int[] navConnect, string a)
    {
        Console.Clear();
        Box(colourArray, descriptions);
        TopExploreInfoBar();
        NavOptions(navConnect);
        Console.SetCursorPosition(Console.WindowWidth / 2 - 4, 9);
        Console.Write(a);
        Write.DotDotDot();
    }
}