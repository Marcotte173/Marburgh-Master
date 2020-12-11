using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum EnterFrom {North,South,East,West };

public class AreaCreation
{
    public List<Shell> dungeon = new List<Shell> {};
    public List<Shell> builtDungeon = new List<Shell> {null };
    public EnterFrom enterFrom;
    public int howManyRooms;
    public Shell cameFrom;
    public List<Room> specialRooms;
    public List<int> placement;
    public AreaCreation(EnterFrom enterFrom, int howManyRooms, List<Room> specialRooms, List<int> placement)
    {
        this.specialRooms = specialRooms;
        this.placement = placement;
        this.enterFrom = enterFrom;
        this.howManyRooms = howManyRooms;
        for (int y = 1; y < 11; y++)
        {
            for (int x = 1; x < 11; x++)
            {
                Shell shell = new Shell(0, 0, 0, 0, false, new Room(), x, y);
                shell.name = $"{x} , {y}";                
                dungeon.Add(shell);
            }            
        }
        foreach (Shell l in dungeon)
        {
            foreach (Shell loc in dungeon)
            {
                if (loc.x == l.x + 1 && loc.y == l.y) l.neighbor[2] = loc;
                if (loc.x == l.x - 1 && loc.y == l.y) l.neighbor[3] = loc;
                if (loc.x == l.x && loc.y == l.y + 1) l.neighbor[0] = loc;
                if (loc.x == l.x && loc.y == l.y - 1) l.neighbor[1] = loc;
            }
        }
        RoomCreation(enterFrom,howManyRooms);
    }
    public AreaCreation(EnterFrom enterFrom, int howManyRooms, Shell cameFrom, List<Room> specialRooms, List<int> placement)
    {
        this.specialRooms = specialRooms;
        this.placement = placement;
        this.enterFrom = enterFrom;
        this.howManyRooms = howManyRooms;
        this.cameFrom = cameFrom;
        for (int y = 1; y < 11; y++)
        {
            for (int x = 1; x < 11; x++)
            {
                Shell shell = new Shell(0, 0, 0, 0, false, new Room(), x, y);
                shell.name = $"{x} , {y}";
                dungeon.Add(shell);
            }
        }
        foreach (Shell l in dungeon)
        {
            foreach (Shell loc in dungeon)
            {
                if (loc.x == l.x + 1 && loc.y == l.y) l.neighbor[2] = loc;
                if (loc.x == l.x - 1 && loc.y == l.y) l.neighbor[3] = loc;
                if (loc.x == l.x && loc.y == l.y + 1) l.neighbor[0] = loc;
                if (loc.x == l.x && loc.y == l.y - 1) l.neighbor[1] = loc;
            }
        }
        RoomCreation(enterFrom, howManyRooms);
        builtDungeon.Add(cameFrom);
        if (enterFrom == EnterFrom.North) builtDungeon[1].North = builtDungeon.Count - 1;
        else if (enterFrom == EnterFrom.South) builtDungeon[1].South = builtDungeon.Count - 1;
        else if (enterFrom == EnterFrom.East) builtDungeon[1].East = builtDungeon.Count - 1;
        else if (enterFrom == EnterFrom.West) builtDungeon[1].West = builtDungeon.Count - 1;
        for (int i = 0; i < specialRooms.Count; i++)
        {
            builtDungeon[placement[i]].room = specialRooms[i];
        }
    }

    public void RoomCreation(EnterFrom enterFrom, int x)
    {
        Shell startingTile = (enterFrom == EnterFrom.North) ? dungeon[94] : (enterFrom == EnterFrom.South) ? dungeon[4]:(enterFrom == EnterFrom.East) ? dungeon[49] : dungeon[40];
        Build(startingTile);
        while (builtDungeon.Count < x)
        {
            Shell cameFrom = builtDungeon[Return.RandomInt(1, builtDungeon.Count)];
            int neighbor = Return.RandomInt(0, 4);

            Shell theRoom = cameFrom.neighbor[neighbor];
            if (theRoom != null && !builtDungeon.Contains(theRoom)) Build(theRoom,cameFrom,neighbor);                
        }
        foreach (Shell l in builtDungeon)
        {
            if(l != null)
            {                
                foreach (Shell loc in builtDungeon)
                {
                    if(loc != null)
                    {
                        if (loc.x == l.x + 1 && loc.y == l.y) l.builtNeighbor[2] = loc;
                        if (loc.x == l.x - 1 && loc.y == l.y) l.builtNeighbor[3] = loc;
                        if (loc.x == l.x && loc.y == l.y + 1) l.builtNeighbor[0] = loc;
                        if (loc.x == l.x && loc.y == l.y - 1) l.builtNeighbor[1] = loc;
                    }                    
                }
            }      
        } 
    }

    

    public void DoorCount(Shell room)
    {
        if (room.North > 0) room.amountOfCurrentDoors++;
        if (room.South > 0) room.amountOfCurrentDoors++;
        if (room.East > 0) room.amountOfCurrentDoors++;
        if (room.West > 0) room.amountOfCurrentDoors++;
    }


    private void Build(Shell tile)
    {
        tile.built = true;
        tile.roomNumber = builtDungeon.Count;
        tile.room = new Entrance();
        builtDungeon.Add(tile);
    }
    private void Build(Shell tile,Shell cameFrom, int neighbor)
    {
        tile.built = true;
        tile.roomNumber = builtDungeon.Count;
        if(neighbor == 0) 
        {
            cameFrom.North = tile.roomNumber;
            tile.South = cameFrom.roomNumber;
        }
        else if (neighbor == 1)
        {
            cameFrom.South = tile.roomNumber;
            tile.North = cameFrom.roomNumber;
        }
        else if (neighbor == 2)
        {
            cameFrom.East = tile.roomNumber;
            tile.West = cameFrom.roomNumber;
        }
        else if (neighbor == 3)
        {
            cameFrom.West = tile.roomNumber;
            tile.East = cameFrom.roomNumber;
        }
        builtDungeon.Add(tile);
    }
    public AreaCreation MonsterCopy()
    {
        return (AreaCreation)MemberwiseClone();
    }
}