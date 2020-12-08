using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum EnterFrom {North,South,East,West };

public class AreaCreation
{
    public static List<Shell> dungeon = new List<Shell> {};
    public static List<Shell> builtDungeon = new List<Shell> {null };
    public static List<Shell> CreateGrid(EnterFrom enterfrom, int howManyRooms)
    {
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
        RoomCreation(enterfrom,howManyRooms);
        return builtDungeon;
    }

    public static void RoomCreation(EnterFrom enterFrom, int x)
    {
        Shell startingTile = (enterFrom == EnterFrom.North) ? dungeon[4] : (enterFrom == EnterFrom.South) ? dungeon[94]:(enterFrom == EnterFrom.East) ? dungeon[40] : dungeon[49];
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

    private static void MakeDoors()
    {
        foreach(Shell room in builtDungeon)
        {
            if (room != null)
            {
                //Count Doors
                DoorCount(room);
                //Find possible doors by finding adjacent rooms
                List<int> possibleDoors = new List<int> { };
                if (room.builtNeighbor[0] != null && room.North == 0) possibleDoors.Add(0);
                if (room.builtNeighbor[1] != null && room.South == 0) possibleDoors.Add(1);
                if (room.builtNeighbor[2] != null && room.East == 0) possibleDoors.Add(2);
                if (room.builtNeighbor[3] != null && room.West == 0) possibleDoors.Add(3);
                if (possibleDoors.Count > 0)
                {
                    //Figure out the door to add
                    int doorToAdd = possibleDoors[Return.RandomInt(0, possibleDoors.Count)];
                    //Add The door
                    if (doorToAdd == 0)
                    {
                        room.North = room.builtNeighbor[0].roomNumber;
                        room.neighbor[0].South = room.roomNumber;
                    }
                    else if (doorToAdd == 1)
                    {
                        room.South = room.builtNeighbor[1].roomNumber;
                        room.neighbor[1].North = room.roomNumber;
                    }
                    else if (doorToAdd == 2)
                    {
                        room.East = room.builtNeighbor[2].roomNumber;
                        room.neighbor[2].West = room.roomNumber;
                    }
                    else if (doorToAdd == 3)
                    {
                        room.West = room.builtNeighbor[3].roomNumber;
                        room.neighbor[3].East = room.roomNumber;
                    }
                }
                DoorCount(room);
            }            
        }        
    }

    public static void DoorCount(Shell room)
    {
        if (room.North > 0) room.amountOfCurrentDoors++;
        if (room.South > 0) room.amountOfCurrentDoors++;
        if (room.East > 0) room.amountOfCurrentDoors++;
        if (room.West > 0) room.amountOfCurrentDoors++;
    }


    private static void Build(Shell tile)
    {
        tile.built = true;
        tile.roomNumber = builtDungeon.Count;
        tile.room = new Entrance();
        builtDungeon.Add(tile);
    }
    private static void Build(Shell tile,Shell cameFrom, int neighbor)
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
}