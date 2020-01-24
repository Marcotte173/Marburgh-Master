using System;
using System.Collections.Generic;
using System.Text;

public class Mage : Player
{
    public Mage()
    : base()
    {
        health = maxHealth = 16;
        damage = 3;
        spellpower = 3;
        potionSize = maxPotionSize += 5;
        offHand = Magic.list[0];
        mainHand = Magic.list[1];
        armor = Armor.list[0];
        pClass = "Mage";
    }
}