﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GuardRoom : Room
{
    public Monster m;
    public GuardRoom(Monster m)
    : base()
    {
        flavorColourArray = new List<int> { 0 };
        flavor = new List<string> { "You have stumbled upon a guard post" };
        name = $"Guard Post";
        this.m = m;
    }

    internal override void Explore()
    {
        UI.Keypress(new List<int> { 0, 0, 0 }, new List<string>
        {
            $"Standing at his post is a {m.Name}",
            "",
            "He looks surprised but recovers quickly and attacks!",
        });
        if (m == global::Summon.goblin)global::Summon.Goblin();
        Create.p.combatMonsters[0].Name = $"{Create.p.combatMonsters[0].Name} Guard";
        Combat.Menu();
        UI.Keypress(new List<int> { 0, 0, 0, 0, 0 }, new List<string>
        {
            "You have defeated the guard",
            "",
            "Hopefully there aren't many more",
        });
        visited = true;
    }
}