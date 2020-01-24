using System;
using System.Collections.Generic;
using System.Text;

public class Blunt : Weapon
{
    internal static string[] names = new string[]
    {
        "None",
        "Club",
        "Hammer",
        "Mace",
        "Morning Star"
    };

    internal static Blunt[] list = new Blunt[]
    {
        new Blunt(0,1),
        new Blunt(1,1),
        new Blunt(2,1),
        new Blunt(3,1),
        new Blunt(4,1),
    };

    public Blunt(int level, int tier)
    : base()
    {
        oneHand = true;
        this.level = level;
        this.tier = tier;
        if (tier < 3)
        {
            string a = (tier == 1) ? "" : "Weighted ";
            Name = $"{a}{names[level]}";
        }
        spellPower = 0;
        damage = level * 2 + Return.RandomInt((level + 1) * -1, level + 1) * level;
        damage = (damage <= 0) ? level * 2 : damage;
        coefficient = (damage <= Level * 2) ? 1 : (damage < Level * 4) ? 1.5 : 2;
        basePrice = (level == 0) ? 0 : (level == 1) ? 500 : (level == 2) ? 1500 : (level == 3) ? 2200 : 3000;
        price = Convert.ToInt32(BasePrice * Coefficient);
        hit = 5 * level;
        type = "Blunt";
    }
}