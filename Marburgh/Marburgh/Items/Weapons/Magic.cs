using System;
using System.Collections.Generic;
using System.Text;

public class Magic : Weapon
{
    internal static string[] names = new string[]
    {
        "None",
        "Walking stick",
        "Orb",
        "Wand",
        "Staff"
    };

    internal static Magic[] list = new Magic[]
    {
        new Magic(0,1),
        new Magic(1,1),
        new Magic(2,1),
        new Magic(3,1),
        new Magic(4,1),
    };

    public Magic(int level, int tier)
    : base()
    {
        this.level = level;
        this.tier = tier;
        if (tier < 3)
        {
            string a = (tier == 1) ? "" : "Arcane ";
            Name = $"{a}{names[level]}";
        }
        damage = 0;
        spellPower = level * 2 + Return.RandomInt((level + 1) * -1, level + 1) * level;
        spellPower = (spellPower <= 0) ? level * 2 : spellPower;
        coefficient = (spellPower <= Level * 2) ? 1 : (spellPower < Level * 4) ? 1.5 : 2;
        basePrice = (level == 0) ? 0 : (level == 1) ? 500 : (level == 2) ? 1500 : (level == 3) ? 2200 : 3000;
        price = Convert.ToInt32(BasePrice * Coefficient);
        type = "Magic";
    }
}