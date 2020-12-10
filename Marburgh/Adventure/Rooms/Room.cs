using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

public enum RoomType {Passage,Hallway,StoreRoom, LargeRoom, SmallRoom };
public class Room
{
    //Variables, self explanatory
    protected string name;
    protected List<int> flavorColourArray;
    protected List<string> flavor;
    protected int modifier;
    public bool skipExplore;
    public bool visited;
    public RoomType roomType;
    public bool resetable;

    //Constructor
    public Room()
    {
        resetable = true;
        int roomRand = Return.RandomInt(0, 5);
        roomType = (roomRand == 0) ? RoomType.Hallway : (roomRand == 1) ? RoomType.Passage : (roomRand == 2) ? RoomType.StoreRoom : (roomRand == 3) ? RoomType.SmallRoom : RoomType.LargeRoom ;
        flavorColourArray = new List<int> { 0 };
        name = (roomType == RoomType.Passage) ? "Passage" : (roomType == RoomType.Hallway) ? "Hallway" : (roomType == RoomType.SmallRoom) ? "Room" : (roomType == RoomType.LargeRoom) ? "Room" : "Store Room";
        flavor = (roomType == RoomType.Passage) ? new List<string> { "You have found a passageway. While tight, you are pretty sure you can squeeze through it." } :
               (roomType == RoomType.Hallway) ? new List<string> { "You have found a hallway, leading futher into the dungeon." } :  (roomType == RoomType.SmallRoom) ? new List<string> { "You have found a small, non descript room." } : (roomType == RoomType.LargeRoom) ? new List<string> { "You have found a large rrom. Anything could be inside" } : new List<string> { "You have found a store room. You will have to search it to see if there is anything of value" };
    }

    public Room(RoomType roomType)
    : base()
    {
        resetable = true;
        this.roomType = roomType;
        flavorColourArray = new List<int> { 0 };
        name = (roomType == RoomType.Passage) ? "Passage" : (roomType == RoomType.Hallway) ? "Hallway" :  (roomType == RoomType.SmallRoom) ? "Room" : (roomType == RoomType.LargeRoom) ? "Room" : "Store Room";
        flavor = (roomType == RoomType.Passage) ? new List<string> { "You have found a passageway. While tight, you are pretty sure you can squeeze through it." } :
               (roomType == RoomType.Hallway) ? new List<string> { "You have found a hallway, leading futher into the dungeon." } :  (roomType == RoomType.SmallRoom) ? new List<string> { "You have found a small, non descript room." } : (roomType == RoomType.LargeRoom) ? new List<string> { "You have found a large rrom. Anything could be inside" } : new List<string> { "You have found a store room. You will have to search it to see if there is anything of value" };
    }

    internal virtual void Explore()
    {
        if (Return.RandomInt(1, 101) < 75 ) Summon(Return.RandomInt((global::Explore.dungeon.howManyMonstersPerRoom==1)?1: global::Explore.dungeon.howManyMonstersPerRoom-1, global::Explore.dungeon.howManyMonstersPerRoom+1));
        else Alone();
    }

    public void Alone()
    {
        UI.Choice(new List<int> { 0 }, new List<string>
            {
                "You appear to be alone... for now",
            },
            new List<string> { "earch the room", "ove on" }, new List<string> { Color.ITEM + "S"+Color.RESET, Color.DAMAGE + "M"+ Color.RESET }
            );
        string choice = Return.Option();
        if (choice == "m") visited = true;
        else if (choice == "s") RoomSearch();
        else Alone();
    }

    public virtual void RoomSearch()
    {
        //Tell us what we won!
        
        List<string> findList = new List<string> { "" };
        List<int> findColourArray = new List<int> { 0 };
        bool gold = false;
        bool potion = false;
        bool book = false;
        int found = 0;
        string foundString = "";
        List<string> stuffFound = new List<string> { };
        if (roomType == RoomType.LargeRoom)
        {
            if (Return.RandomInt(0, 101) <= 40)
            {
                stuffFound.Add("Gold");
                found++;
                gold = true;
            }
            if (Return.RandomInt(0, 101) <= 30)
            {
                stuffFound.Add("A potion");
                found++;
                potion = true;
            }
            if (Return.RandomInt(0, 101) <= 20)
            {
                stuffFound.Add("A book");
                found++;
                book = true;
            }
        }
        else if (roomType == RoomType.SmallRoom)
        {
            if (Return.RandomInt(0, 101) <= 40)
            {
                stuffFound.Add("Gold");
                found++;
                gold = true;
            }
        }
        else if (roomType == RoomType.StoreRoom)
        {
            if (Return.RandomInt(0, 101) <= 40)
            {
                stuffFound.Add("Gold");
                found++;
                gold = true;
            }
            if (Return.RandomInt(0, 101) <= 40)
            {
                stuffFound.Add("A Potion");
                found++;
                potion = true;
            }
        }
        else if (roomType == RoomType.Passage)
        {
            if (Return.RandomInt(0, 101) <= 30)
            {
                stuffFound.Add("Gold");
                found++;
                gold = true;
            }
        }
        else if (roomType == RoomType.Hallway)
        {
            if (Return.RandomInt(0, 101) <= 30)
            {
                stuffFound.Add("Gold");
                found++;
                gold = true;
            }
            if (Return.RandomInt(0, 101) <= 20)
            {
                stuffFound.Add("A potion");
                found++;
                potion = true;
            }
        }        
        foundString = (found == 0)?"Nothing": (found == 1) ? $"{stuffFound[0]}": (found == 1) ? $"{stuffFound[0]} and {stuffFound[1]}" : $"{stuffFound[0]}, {stuffFound[1]} and {stuffFound[2]}";
        if (gold)
        {
            int goldFind = Return.RandomInt(3, 10) + Return.RandomInt(0, 12) * global::Explore.dungeon.rewardMod;
            Create.p.Gold += goldFind;
            findColourArray.Add(1);
            findList.Add(Color.GOLD);
            findList.Add("You find ");
            findList.Add($"{goldFind}");
            findList.Add(" gold");
            findColourArray.Add(0);
            findList.Add("");
        }
        if (potion)
        {
            if (Create.p.PotionSize == Create.p.MaxPotionSize)
            {
                findColourArray.Add(1);
                findList.Add(Color.HEALTH);
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
                findList.Add(Color.HEALTH);
                findList.Add("You refill your ");
                findList.Add("potion");
                findList.Add("");
                findColourArray.Add(0);
                findList.Add("");
            }
        }
        if (book)
        {
            Create.p.XP += 10;
            findColourArray.Add(1);
            findList.Add(Color.XP);
            findList.Add("You find a ");
            findList.Add("book");
            findList.Add(" providing insight into the dungeon and its inhabitants");
            findColourArray.Add(1);
            findList.Add(Color.XP);
            findList.Add("You gain ");
            findList.Add($"10 ");
            findList.Add("experience");
            findColourArray.Add(0);
            findList.Add("");
        }
        ActionWait(findColourArray, findList, Color.RESET + "You find" + Color.RESET + Color.RESET, foundString);   
        visited = true;
    }

    public virtual void Summon(int amount)
    {
        List<string> summonList = new List<string> { };
        List<int> colourArray = new List<int> { };
        for (int i = 0; i < amount; i++)
        {
            Monster summon = global::Explore.dungeon.bestiary[Return.RandomInt(0, global::Explore.dungeon.bestiary.Count)];
            colourArray.Add(1);
            summonList.Add(Color.MONSTER);
            if (summon.Name == "Orc")summonList.Add("An ");
            else summonList.Add("A ");
            summonList.Add(summon.Name);
            summonList.Add("");
            colourArray.Add(0);
            summonList.Add("");
            Dungeon.Summon(summon);
        }
        ActionWait(colourArray, summonList, Color.RESET + "You have been discovered by"+ Color.RESET, null);
        Combat.Menu();
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
        Write.Line(48, 22, "Press any key to continue");
        Write.Line(70 - text.Length / 2, 6 - colourArray.Count / 2,text);
        Write.DotDotDotSL();
        if (a != null) Console.Write(a);
        UIComponent.DisplayText(colourArray, descriptions);
        Console.ReadKey(true);
    }

    public string Name { get { return name; } set { name = value; } }
    public virtual List<int> FlavorColourArray { get { return flavorColourArray; } set { flavorColourArray = value; } }
    public virtual List<string> Flavor { 
        get 
        {
            if (visited ) return new List<string> { $"You have explored this room" }; 
            else return flavor; 
        } 
        set { flavor = value; } 
    }

    public Room Copy()
    {
        return (Room)MemberwiseClone();
    }
}