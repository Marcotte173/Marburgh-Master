using System;
using System.Collections.Generic;
using System.Text;

public class Sword : Weapon
{
    int[] damageArray = new int[] { 0, 1, 2, 3, 4, 5 };
    int[] hitArray =    new int[] { 0, 1, 2, 3, 4, 5 };
    int[] critArray =   new int[] { 0, 1, 2, 3, 4, 5 };
    int[] priceArray =  new int[] { 0, 1, 2, 3, 4, 5 };
    internal static string[] names = new string[]
    {
        "None",
        "Short Sword",
        "Arming Sword",
        "Long Sword",
        "Broad Sword",
        "Great Sword"
    };

    internal static Sword[] list = new Sword[]
    {
        new Sword(0,1),
        new Sword(1,1),
        new Sword(2,1),
        new Sword(3,1),
        new Sword(4,1),
        new Sword(5,1),
    };

    public Sword(int level, int tier)
    : base()
    {
        this.level = level;
        this.tier = tier;
        Name = $"{modifier}{names[level]}";

        spellPower = 0;
        damage = damageArray[level];
        hit = hitArray[level];
        crit = critArray[level];

        price = priceArray[level];

        if (level != 5) oneHand = true;
        type = "Sword";
    }
}