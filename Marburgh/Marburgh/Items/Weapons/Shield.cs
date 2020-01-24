using System;
using System.Collections.Generic;
using System.Text;

public class Shield : Weapon
{
    internal static string[] names = new string[]
    {
        "None",
        "Buckler",
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
    };

    public Shield(int level, int tier)
    : base()
    {
        this.level = level;
        this.tier = tier;
        if (tier < 3)
        {
            string a = (tier == 1) ? "" : "Sturdy ";
            Name = $"{a}{names[level]}";
        }
        defence = level * 10;
        mitigation = level * 2 - 2;
        coefficient = (tier == 1) ? 1 : (tier == 2) ? 1.5 : 2;
        basePrice = (level == 0) ? 0 : (level == 1) ? 500 : (level == 2) ? 1500 : (level == 3) ? 2200 : 3000;
        price = Convert.ToInt32(BasePrice * Coefficient);
        type = "Shield";
    }
}