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
        new Shield(0),
        new Shield(1),
        new Shield(2),
        new Shield(3),
        new Shield(4),
        new Shield(5),
    };

    public Shield(int level)
    : base()
    {
        this.level = level;
        Name = names[level];
        mitigation = mitigationArray[level];
        defence = defenceArray[level];
        price = priceArray[level];
        type = "Shield";
    }
    public override void Upgrade()
    {
        base.Upgrade();
        mitigation += EffectBoost[Level] * 2;
        Name = $"Honed {names[level]}";
    }
}