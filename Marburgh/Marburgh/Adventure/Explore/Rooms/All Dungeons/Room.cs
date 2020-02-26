using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

public class Room
{
    //Variables, self explanatory
    protected int tier;
    protected int size;
    protected string name;
    protected List<int> flavorColourArray;
    protected List<string> flavor;
    protected int modifier;
    public bool visited;

    //Constructor
    public Room(int size, int tier)
    {
        this.size = size;
        this.tier = tier;
        string a = (size == 0) ? "tiny" : (size == 1) ? "small" : (size == 2) ? "medium sized" : "large";
        string b = (tier == 0) ? "squalid" : (tier == 1) ? null : (tier == 2) ? "nice" : "splendid";
        flavorColourArray = new List<int> { 0 };
        flavor = new List<string> { $"You enter a {a}, {b} room" };
        name = $"{a} room";
    }

    internal virtual void Explore()
    {
        if (Return.RandomInt(1, 101) < 75 + (size * 5)) Summon(Size + 1);
        else Alone();
    }

    public void Alone()
    {
        UI.Choice(new List<int> { 0 }, new List<string>
            {
                "You appear to be alone... for now",
            },
            new List<string> { "earch the room", "ove on" }, new List<string> { "S", "M" }
            );
        string choice = Return.Option();
        if (choice == "m") visited = true;
        else if (choice == "s") RoomSearch();
        else Alone();
    }

    public virtual void RoomSearch()
    {
        //Tell us what we won!
        string a = (tier == 2) ? $"gold, a potion and a book" : (tier == 1) ? $"gold and a potion" : (tier == 0) ? $"gold" : "Nothing!";
        List<string> findList = new List<string> { "" };
        List<int> findColourArray = new List<int> { 0 };
        for (int i = 0; i < tier + 2; i++)
        {
            if (i == 1)
            {
                Create.p.Gold +=120;
                findColourArray.Add(1);
                findList.Add(Colour.GOLD);
                findList.Add("You find ");
                findList.Add($"120");
                findList.Add(" gold");
                findColourArray.Add(0);
                findList.Add("");
            }
            if (i == 2)
            {
                if (Create.p.PotionSize == Create.p.MaxPotionSize)
                {
                    findColourArray.Add(1);
                    findList.Add(Colour.HEALTH);
                    findList.Add("Somebody already drank the ");
                    findList.Add($"potion");
                    findList.Add("");
                    findColourArray.Add(0);
                    findList.Add("It's just an empty bottle!");
                    findColourArray.Add(0);
                    findList.Add("Oh well...");
                    findColourArray.Add(0);
                    findList.Add("");
                }
                else
                {
                    Create.p.PotionSize = Create.p.MaxPotionSize;
                    findColourArray.Add(1);
                    findList.Add(Colour.HEALTH);
                    findList.Add("You refill your ");
                    findList.Add("potion");
                    findList.Add("");
                    findColourArray.Add(0);
                    findList.Add("");
                }
            }
            if (i == 3)
            {
                Create.p.XP += 10;
                findColourArray.Add(1);
                findList.Add(Colour.XP);
                findList.Add("You find a ");
                findList.Add("book");
                findList.Add(" providing insight into the dungeon and its inhabitants");
                findColourArray.Add(1);
                findList.Add(Colour.XP);
                findList.Add("You gain ");
                findList.Add($"10 ");
                findList.Add("experience");
                findColourArray.Add(0);
                findList.Add("");
            }
        }
        ActionWait(findColourArray, findList, "You find", a);    
        visited = true;
    }

    public virtual void Summon(int amount)
    {
        List<string> summonList = new List<string> { };
        List<int> colourArray = new List<int> { };        
        for (int i = 0; i < amount; i++)
        {
            int summon = Return.RandomInt(0, 4);
            string a = (summon == 0) ? " slime" : (summon == 1) ? " kobold" : (summon == 2) ? " goblin" : "n orc";
            colourArray.Add(1);
            summonList.Add(Colour.MONSTER);
            summonList.Add("A");
            summonList.Add(a);
            summonList.Add("");
            colourArray.Add(0);
            summonList.Add("");
            if (summon == 0) global::Summon.Slime();
            else if (summon == 1) global::Summon.Kobald();
            else if (summon == 2) global::Summon.Goblin();
            else if (summon == 3) global::Summon.Orc();
        }
        ActionWait(colourArray, summonList, "You have been discovered by", null);
        Location.list[11].Go();
        visited = true;
    }

    public static void ActionWait(List<int> colourArray, List<string> descriptions, string text, string a)
    {
        Console.Clear();
        Write.SetY(15);
        UIComponent.TopBar();
        Write.SetY(18);
        UIComponent.StandardMiddle(8);
        UIComponent.BarBlank();
        Console.SetCursorPosition(Console.WindowWidth / 2 - 12, 21);
        Write.ColourText(Colour.ENERGY, "Press any key to continue");
        Console.SetCursorPosition(Console.WindowWidth / 2 - text.Length / 2, 6 - colourArray.Count / 2);
        Console.Write(text);
        Write.DotDotDotSL();
        if (a != null) Console.Write(a);
        UIComponent.DisplayText(colourArray, descriptions);
        Console.ReadKey(true);
    }

    public int Tier { get { return tier; } set { tier = value; } }
    public string Name { get { return name; } set { name = value; } }
    public int Size { get { return size; } set { size = value; } }
    public virtual List<int> FlavorColourArray { get { return flavorColourArray; } set { flavorColourArray = value; } }
    public virtual List<string> Flavor { 
        get 
        {
            if (visited ) return new List<string> { $"You have explored this room" }; 
            else return flavor; 
        } 
        set { flavor = value; } 
    }    
}