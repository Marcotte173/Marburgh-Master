using System;
using System.Collections.Generic;
using System.Text;

public class Rogue : Player
{
    public Rogue()
    : base()
    {
        health = maxHealth = 20;
        damage = 4;
        crit += 3;
        hit += 10;
        offHand = Sharp.list[0];
        mainHand = Sharp.list[1];
        armor = Armor.list[1];
        pClass = "Rogue";
    }
}