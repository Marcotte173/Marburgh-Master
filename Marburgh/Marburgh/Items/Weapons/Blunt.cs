using System;
using System.Collections.Generic;
using System.Text;

public class Blunt : Weapon
{
    int[] damageArray = new int[] { 0, 2, 5, 8, 12, 15 };
    int[] hitArray =    new int[] { 0, 1, 2, 3, 3, 5 };
    int[] critArray =   new int[] { 0, 1, 1, 2, 2, 3 };

    internal static string[] names = new string[]
    {
        "None",
        "Club",
        "Hammer",
        "Flail",
        "Morning Star",
        "War Hammer"
    };

    internal static Blunt[] list = new Blunt[]
    {
        new Blunt(0,1),
        new Blunt(1,1),
        new Blunt(2,1),
        new Blunt(3,1),
        new Blunt(4,1),
        new Blunt(5,1),
    };

    public Blunt(int level, int tier)
    : base()
    {        
        oneHand = true;
        this.level = level;
        this.tier = tier;
        Name = $"{modifier}{names[level]}";

        spellPower = 0;
        damage = damageArray[level];
        hit = hitArray[level];
        crit = critArray[level];

        price = priceArray[level];

        if (level != 5) oneHand = true;
        type = "Blunt";
    }
}