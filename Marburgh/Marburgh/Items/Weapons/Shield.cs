using System;
using System.Collections.Generic;
using System.Text;

public class Shield : Weapon
{
    int[] mitigationArray = new int[] { 0, 0, 1, 3, 5, 7 };
    int[] defenceArray =    new int[] { 0, 10, 12, 14, 16, 20 };

    internal static string[] names = new string[]
    {
        "None",
        "Buckler",
        "Round Shield",
        "Heater shield",
        "Kite Shield",
        "Teardrop Shield"
    };

    internal static Shield[] list = new Shield[]
    {
        new Shield(0,1),
        new Shield(1,1),
        new Shield(2,1),
        new Shield(3,1),
        new Shield(4,1),
        new Shield(5,1),
    };

    public Shield(int level, int tier)
    : base()
    {
        this.level = level;
        this.tier = tier;
        Name = $"{modifier}{names[level]}";

        mitigation = mitigationArray[level];
        defence = defenceArray[level];

        price = priceArray[level];

        type = "Shield";
    }
}