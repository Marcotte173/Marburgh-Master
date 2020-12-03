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

    public Shell(int North, int South, int East, int West,  bool current, Room room)
    {
        this.North = North;
        this.South = South;
        this.East = East;
        this.West = West;
        this.current = current;
        this.room = room;
    }
}