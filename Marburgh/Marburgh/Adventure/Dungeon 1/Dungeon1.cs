using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Dungeon1:Explore
{
    public Dungeon1()
    : base()
    {
        shell = new List<Shell> 
        { 
            null,
            new Shell(2, 0, 0, 0 ,true,  new Entrance(0,0)),
            new Shell(0, 1, 3, 6 ,false, new Room(0,0)),
            new Shell(4, 0, 0, 2 ,false, new Room(0,0)),
            new Shell(5, 3, 0, 0 ,false, new Room(0,0)),
            new Shell(0, 4, 0, 10,false, new Room(0,0)),
            new Shell(7, 0, 2, 0 ,false, new Room(0,0)),
            new Shell(9, 6, 8, 0 ,false, new Room(0,0)),
            new Shell(0, 0, 0, 7 ,false, new Room(0,0)),
            new Shell(0, 7, 10, 0,false, new Room(0,0)),
            new Shell(0, 0, 5, 9 ,false, new Dungeon1BossRoom(0,0))
        };
    }
}