﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class VillagersRoom : Room
{
    //Variables, self explanatory


    //Constructor
    public VillagersRoom()
    : base()
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
        Combat.Menu();
        UI.Keypress(new List<int> { 0, 0, 0, 1, 1, 0, 0, 0, 0, 0 }, new List<string>
        {
            "You see several townsfolk huddling for warmth, obviously scared.",
            "One comes up to you to speak",
            "",
            Color.SPEAK, "","'Thank god you're here! We'd given up all hope!","",
            Color.SPEAK, "","Untie us and we will reward you handomely when we get back!'","",
            "",
            "You untie them and point the way out.",
            "Be sure to meet them in the tavern afterwards to claim your reward.",
            "",
            "That is.... if you live"
        });
        Tavern.tavernOptionButton[3] = Color.NAME + "S" + Color.RESET;
        Tavern.tavernOptionList[3] = "peak to townsfolk";
        GameState.Villagers = Create.p.Name;
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