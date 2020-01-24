using System;
using System.Collections.Generic;
using System.Text;

public class Armor : Equipment
{
    internal static string[] names = new string[]
    {
        "None",
        "Cloth",
        "Leather",
        "Mail",
        "Plate"
    };

    internal static Armor[] list = new Armor[]
    {
        new Armor(0,1),
        new Armor(1,1),
        new Armor(2,1),
        new Armor(3,1),
        new Armor(4,1),
    };

    public Armor(int level, int tier)
    : base()
    {
        this.level = level;
        this.tier = tier;
        if (tier < 3)
        {
            string a = (tier == 1) ? "" : "Black ";
            Name = $"{a}{names[level]}";
        }
        coefficient = (tier == 1) ? 1 : (tier == 2) ? 1.5 : 2;
        basePrice = (level == 0) ? 0 : (level == 1) ? 500 : (level == 2) ? 1500 : (level == 3) ? 2200 : 3000;
        price = Convert.ToInt32(BasePrice * Coefficient);
        defence = 10 - Level * 3;
        mitigation = level * 3 - 1;
    }
}