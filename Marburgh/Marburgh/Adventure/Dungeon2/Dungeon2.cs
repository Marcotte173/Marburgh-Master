using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Dungeon2 : Explore
{
    public Dungeon2()
    : base()
    {
        shell = new List<Shell>
        {
            null,
            new Shell(0, 0, 7,  2   ,true,  new Entrance(0,0)),                                                //1
            new Shell(3, 0, 1,  0   ,false, new Dungeon2Room(Return.RandomInt(0,2),Return.RandomInt(0,2))),            //2
            new Shell(4, 2, 5,  0   ,false, new ChestRoom()),         //3
            new Shell(0, 3, 6,  0   ,false, new Dungeon2Room(Return.RandomInt(0,2),Return.RandomInt(0,2))),            //4
            new Shell(6, 0, 0,  3   ,false, new Dungeon2Room(Return.RandomInt(0,2),Return.RandomInt(0,2))),            //5
            new Shell(0, 5, 0,  4   ,false, new Dungeon2MiniBoss()),   //MINI BOSS                                            //6
            new Shell(0, 0, 8,  1   ,false, new Dungeon2Room(2,Return.RandomInt(0,2))),            //7
            new Shell(9, 0, 0,  7   ,false, new Dungeon2Room(2,Return.RandomInt(0,2))),                                           //8
            new Shell(10, 8, 0, 0   ,false, new Dungeon2Room(Return.RandomInt(0,2),Return.RandomInt(0,2))),            //9
            new Shell(0, 9, 0,  0   ,false, new Dungeon2LockRoom()),     //LOCKED ROOM, NEED TO DEFEAT MINIBOSS      //10
            new Shell(0, 12, 10, 0  ,false, new Dungeon2Room(2,Return.RandomInt(0,2))),            //11
            new Shell(11, 0, 0,  0  ,false, new Dungeon2BossRoom())                                         //12
        };
    }
}