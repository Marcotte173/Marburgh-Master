﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MansionMiniBossNecromancer : Room
{
    public MansionMiniBossNecromancer()
       : base()
    {
        flavorColourArray = new List<int> { 0 };
        flavor = new List<string> { "You have found the necromancer's apprentice!" };
        name = $"Apprentice";
    }
    internal override void Explore()
    {

    }

    public override List<string> Flavor
    {
        get
        {
            if (visited) return new List<string> { $"You see a shrine. There is clearly nothing else to learn from it" };
            else return flavor;
        }
    }
}