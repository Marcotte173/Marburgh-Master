﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Dungeon1
{
    public static List<Shell> shell = new List<Shell> { };
    public Dungeon1()
    {
        shell = new List<Shell> 
        { 
            null,
            new Shell(2, 0, 0, 0 ,true,  new Entrance(0,0)),                                                //1
            new Shell(0, 1, 3, 6 ,false, new Dungeon1Room(Return.RandomInt(0,2),Return.RandomInt(0,2))),            //2
            new Shell(4, 0, 0, 2 ,false, new Library(Return.RandomInt(0,2),Return.RandomInt(0,2))),         //3
            new Shell(5, 3, 0, 0 ,false, new Dungeon1Room(Return.RandomInt(0,2),Return.RandomInt(0,2))),            //4
            new Shell(0, 4, 0, 10 ,false, new Dungeon1Room(Return.RandomInt(0,2),Return.RandomInt(0,2))),            //5
            new Shell(7, 0, 2, 0 ,false, new ChestRoom()),                                               //6
            new Shell(9, 6, 8, 0 ,false, new Dungeon1Room(Return.RandomInt(0,2),Return.RandomInt(0,2))),            //7
            new Shell(0, 0, 0, 7 ,false, new VillagersRoom()),                                           //8
            new Shell(0, 7, 10, 0 ,false, new Dungeon1Room(Return.RandomInt(0,2),Return.RandomInt(0,2))),            //9
            new Shell(0, 0, 5, 9 ,false, new Dungeon1BossRoom())                                         //10
        };
        if (Return.RandomInt(0, 2) == 0) shell[6].room = new ShrineRoom(0, 0);
    }

    public void Reset()
    {
        shell[2].room = new Dungeon1Room(2, Return.RandomInt(0, 2));
        shell[3].room = new Library(2, Return.RandomInt(0, 2));
        shell[4].room = new Dungeon1Room(2, Return.RandomInt(0, 2));
        shell[5].room = new Dungeon1Room(2, Return.RandomInt(0, 2));
        shell[7].room = new Dungeon1Room(2, Return.RandomInt(0, 2));
    }
}