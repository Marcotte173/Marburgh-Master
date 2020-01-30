﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class VillagersRoom : Room
{
    //Variables, self explanatory


    //Constructor
    public VillagersRoom(int size, int tier)
    : base(size, tier)
    {
        flavorColourArray = new List<int> { 0 };
        flavor = new List<string> { "You have found a prison cell!" };
        name = $"Cell";
    }

    internal override void Explore()
    {
        UI.Keypress(new List<int> { 0, 0, 0, 1, 1, 0, 0, 0, 0, 0 }, new List<string>
            {
                "Guarding the cell is a nasty looking orc!",
                "",
                "He pulls out his weapon and charges!",
            });
        global::Summon.Orc();
        Location.list[11].Go();
        UI.Keypress(new List<int> { 0, 0, 0, 1, 1, 0, 0, 0, 0, 0 }, new List<string>
            {
                "You see several townsfolk huddling for warmth, obviously scared.",
                "One comes up to you to speak",
                "",
                Colour.SPEAK, "","'Thank god you're here! We'd given up all hope!","",
                Colour.SPEAK, "","Untie us and we will reward you handomely when we get back!'","",
                "",
                "You untie them and point the way out.",
                "Be sure to meet them in the tavern afterwards to claim your reward.",
                "",
                "That is.... if you live"
            });
        Tavern.tavernOptionButton[3] = Colour.NAME + "S" + Colour.RESET;
        Tavern.tavernOptionList[3] = "peak to townsfolk";
        Create.p.Rescue = true;
        visited = true;
    }
    public override List<string> Flavor
    { get 
        { 
            if (visited) return new List<string> { $"You see an empty prison. Hopefully everyone escaped" };
            else return flavor;
        } 
    }
}