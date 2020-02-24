using System;
using System.Collections.Generic;
using System.Text;

public class Magic : Weapon
{
    int[] damageArray = new int[] { 0, 1, 2, 3, 4, 5 };
    int[] hitArray =    new int[] { 0, 1, 2, 3, 4, 5 };
    int[] critArray =   new int[] { 0, 1, 2, 3, 4, 5 };
    int[] priceArray =  new int[] { 0, 1, 2, 3, 4, 5 };
    internal static string[] names = new string[]
    {
        "None",
        "Walking stick",
        "Orb",
        "Wand",
        "Staff",
        "Ring"
    };

    internal static Magic[] list = new Magic[]
    {
        new Magic(0,1),
        new Magic(1,1),
        new Magic(1,1),
        new Magic(2,1),
        new Magic(3,1),
        new Magic(4,1),
        new Magic(5,1),
    };

    public Magic(int level, int tier)
    : base()
    {
        this.level = level;
        this.tier = tier;
        Name = $"{modifier}{names[level]}";

        damage = damageArray[level];
        hit = hitArray[level];
        crit = critArray[level];

        spellPower = level * 2 + Return.RandomInt((level + 1) * -1, level + 1) * level;
        spellPower = (spellPower <= 0) ? level * 2 : spellPower;

        price = priceArray[level];

        type = "Magic";
    }
}