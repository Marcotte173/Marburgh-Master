﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Dungeon1BossRoom : Room
{
    //Variables, self explanatory


    //Constructor
    public Dungeon1BossRoom(int size, int tier)
    : base(size, tier)
    {
        flavorColourArray = new List<int> { 0 };
        flavor = new List<string> { "You are at the entrance to the dungeon" };
    }


}