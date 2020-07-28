using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Explore
{
    public static List<Shell> shell = new List<Shell> { };
    protected static Room starter;
    public static Shell currentShell;
    public static void Menu()
    {
        GameState.location = Location.Exploring;
        Navigate();
        while (true)
        {        
            if (currentShell.room.visited == false)
            {
                UI.Keypress(currentShell.room.FlavorColourArray, currentShell.room.Flavor);
                currentShell.room.Explore();
            }                
            Navigate();
        }
    }

    private static void Navigate()
    {
        Console.Clear();
        NavigateUI(currentShell.room.FlavorColourArray, currentShell.room.Flavor, new int[] { currentShell.North, currentShell.South, currentShell.East, currentShell.West });
        string choice = Return.Option();
        if (choice == "n" && currentShell.North > 0)
        {
            if (shell[currentShell.North].room.visited == false) ExploreNextRoom(null, null, new int[] { currentShell.North, currentShell.South, currentShell.East, currentShell.West });
            ChangeShell(currentShell.North);
        }
        else if (choice == "s" && currentShell.South > 0)
        {
            if (shell[currentShell.South].room.visited == false) ExploreNextRoom(null, null, new int[] { currentShell.North, currentShell.South, currentShell.East, currentShell.West });
            ChangeShell(currentShell.South);
        }
        else if (choice == "e" && currentShell.East > 0)
        {
            if (shell[currentShell.East].room.visited == false) ExploreNextRoom(null, null, new int[] { currentShell.North, currentShell.South, currentShell.East, currentShell.West });
            ChangeShell( currentShell.East);
        }
        else if (choice == "w" && currentShell.West > 0)
        {
            if (shell[currentShell.West].room.visited == false) ExploreNextRoom(null, null, new int[] { currentShell.North, currentShell.South, currentShell.East, currentShell.West });
            ChangeShell( currentShell.West);
        }
        else if (choice == "9") CharacterSheet.Display();
        else if (choice == "h") Create.p.DrinkPotion();
        else if (choice == "0" && currentShell == shell[1])
        {
            //Utilities.ResetNormalRooms();
            //Sound.Stop();
            Utilities.ToTown();
        }
        else if (choice == "0" && currentShell != shell[1])
        {
            Console.Clear();
            Console.WriteLine("You can only leave the dungeon from the entance");
            Utilities.Keypress();
        }
        else Navigate();
    }

    //Changes the current room
    public static void ChangeShell(int connect)
    {
        //Current shell isn't current anymore, the shell connection number is not current and visited 
        currentShell = shell[connect];
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
            if (shell[currentShell.North].room.visited) Write.Line(98 - shell[currentShell.North].room.Name.Length / 2, 21, Color.SPEAK + shell[currentShell.North].room.Name);
            else Write.Line(97, 21, Color.SPEAK + "???");
        }
        else Write.Line(91, 21, "xxxxxxxxxxxxxxx");

        if (navConnect[1] > 0)
        {
            Console.SetCursorPosition(56, 27);
            Write.Line(Color.NAME, "[", "S", "]outh");
            if (shell[currentShell.South].room.visited) Write.Line(98 - shell[currentShell.South].room.Name.Length / 2, 25, Color.SPEAK + shell[currentShell.South].room.Name);
            else Write.Line(97, 25, Color.SPEAK + "???");
        }
        else Write.Line(91, 25, "xxxxxxxxxxxxxxx");

        if (navConnect[2] > 0)
        {
            Console.SetCursorPosition(70, 23);
            Write.Line(Color.NAME, "[", "E", "]ast");
            if (shell[currentShell.East].room.visited) Write.Line(113 - shell[currentShell.East].room.Name.Length / 2, 23, Color.SPEAK + shell[currentShell.East].room.Name);
            else Write.Line(112, 23, Color.SPEAK + "???");
        }
        else Write.Line(105, 23, "xxxxxxxxxxxxxxx");

        if (navConnect[3] > 0)
        {
            Console.SetCursorPosition(44, 23);
            Write.Line(Color.NAME, "[", "W", "]est");
            if (shell[currentShell.West].room.visited) Write.Line(84 - shell[currentShell.West].room.Name.Length / 2, 23, shell[currentShell.West].room.Name);
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