using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Shell
{
    public int North;
    public int South;
    public int East;
    public int West;
    public bool current;
    public Room room;
    public Shell[] neighbor = new Shell[4];
    public Shell[] builtNeighbor = new Shell[4];
    public int roomNumber;
    public int amountOfCurrentDoors;
    public bool built;
    public int x;
    public int y;
    public string name;

    public Shell(int North, int South, int East, int West,  bool current, Room room)
    {
        this.North = North;
        this.South = South;
        this.East = East;
        this.West = West;
        this.current = current;
        this.room = room;
    }
    public Shell(int North, int South, int East, int West, bool current, Room room,int x, int y)
    {
        amountOfCurrentDoors = 0;
        this.North = North;
        this.South = South;
        this.East = East;
        this.West = West;
        this.current = current;
        this.room = room;
        this.x = x;
        this.y = y;
    }
}