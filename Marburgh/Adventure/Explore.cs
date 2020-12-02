using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Explore
{
    public static int monstersPerRoom;
    public static List<Shell> dungeon = new List<Shell> { };
    protected static Room starter;
    public static Shell currentDungeon;
    public static void Menu()
    {
        GameState.location = Location.Exploring;
        Navigate();
        while (true)
        {        
            if (currentDungeon.room.visited == false)
            {
                UI.Keypress(currentDungeon.room.FlavorColourArray, currentDungeon.room.Flavor);
                currentDungeon.room.Explore();
            }                
            Navigate();
        }
    }

    private static void Navigate()
    {
        Console.Clear();
        NavigateUI(currentDungeon.room.FlavorColourArray, currentDungeon.room.Flavor, new int[] { currentDungeon.North, currentDungeon.South, currentDungeon.East, currentDungeon.West });
        string choice = Return.Option();
        if (choice == "n" && currentDungeon.North > 0)
        {
            if (dungeon[currentDungeon.North].room.visited == false) ExploreNextRoom(null, null, new int[] { currentDungeon.North, currentDungeon.South, currentDungeon.East, currentDungeon.West });
            ChangeDungeon(currentDungeon.North);
        }
        else if (choice == "s" && currentDungeon.South > 0)
        {
            if (dungeon[currentDungeon.South].room.visited == false) ExploreNextRoom(null, null, new int[] { currentDungeon.North, currentDungeon.South, currentDungeon.East, currentDungeon.West });
            ChangeDungeon(currentDungeon.South);
        }
        else if (choice == "e" && currentDungeon.East > 0)
        {
            if (dungeon[currentDungeon.East].room.visited == false) ExploreNextRoom(null, null, new int[] { currentDungeon.North, currentDungeon.South, currentDungeon.East, currentDungeon.West });
            ChangeDungeon( currentDungeon.East);
        }
        else if (choice == "w" && currentDungeon.West > 0)
        {
            if (dungeon[currentDungeon.West].room.visited == false) ExploreNextRoom(null, null, new int[] { currentDungeon.North, currentDungeon.South, currentDungeon.East, currentDungeon.West });
            ChangeDungeon( currentDungeon.West);
        }
        else if (choice == "9") CharacterSheet.Display();
        else if (choice == "h") Create.p.DrinkPotion();
        else if (choice == "0" && currentDungeon == dungeon[1])
        {
            //Utilities.ResetNormalRooms();
            //Sound.Stop();
            Utilities.ToTown();
        }
        else if (choice == "0" && currentDungeon != dungeon[1])
        {
            Console.Clear();
            Console.WriteLine("You can only leave the dungeon from the entance");
            Utilities.Keypress();
        }
        else Navigate();
    }

    //Changes the current room
    public static void ChangeDungeon(int connect)
    {
        //Current Dungeon isn't current anymore, the Dungeon connection number is not current and visited 
        currentDungeon = dungeon[connect];
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

    private static void TopExploreInfoBar()
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

    private static void Box(List<int> colourArray, List<string> descriptions)
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
            if (dungeon[currentDungeon.North].room.visited) Write.Line(98 - dungeon[currentDungeon.North].room.Name.Length / 2, 21, Color.SPEAK + dungeon[currentDungeon.North].room.Name);
            else Write.Line(97, 21, Color.SPEAK + "???");
        }
        else Write.Line(91, 21, "xxxxxxxxxxxxxxx");

        if (navConnect[1] > 0)
        {
            Console.SetCursorPosition(56, 27);
            Write.Line(Color.NAME, "[", "S", "]outh");
            if (dungeon[currentDungeon.South].room.visited) Write.Line(98 - dungeon[currentDungeon.South].room.Name.Length / 2, 25, Color.SPEAK + dungeon[currentDungeon.South].room.Name);
            else Write.Line(97, 25, Color.SPEAK + "???");
        }
        else Write.Line(91, 25, "xxxxxxxxxxxxxxx");

        if (navConnect[2] > 0)
        {
            Console.SetCursorPosition(70, 23);
            Write.Line(Color.NAME, "[", "E", "]ast");
            if (dungeon[currentDungeon.East].room.visited) Write.Line(113 - dungeon[currentDungeon.East].room.Name.Length / 2, 23, Color.SPEAK + dungeon[currentDungeon.East].room.Name);
            else Write.Line(112, 23, Color.SPEAK + "???");
        }
        else Write.Line(105, 23, "xxxxxxxxxxxxxxx");

        if (navConnect[3] > 0)
        {
            Console.SetCursorPosition(44, 23);
            Write.Line(Color.NAME, "[", "W", "]est");
            if (dungeon[currentDungeon.West].room.visited) Write.Line(84 - dungeon[currentDungeon.West].room.Name.Length / 2, 23, dungeon[currentDungeon.West].room.Name);
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