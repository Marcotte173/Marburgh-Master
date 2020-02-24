using System;
using System.Collections.Generic;
using System.Text;

public class Armor : Equipment
{
    int[] mitigationArray = new int[] { 0, 1, 2, 3, 4, 5 };
    int[] defenceArray =    new int[] { 0, 1, 2, 3, 4, 5 };
    int[] priceArray =      new int[] { 0, 1, 2, 3, 4, 5 };

    internal static string[] names = new string[]
    {
        "None",
        "Cloth",
        "Leather",
        "Mail",
        "Coat of Plates",
        "Plate"
    };

    internal static Armor[] list = new Armor[]
    {
        new Armor(0,1),
        new Armor(1,1),
        new Armor(2,1),
        new Armor(3,1),
        new Armor(4,1),
        new Armor(5,1),
    };

    public Armor(int level, int tier)
    : base()
    {
        this.level = level;
        this.tier = tier;
        Name = $"{modifier}{names[level]}";
        price = priceArray[level];
        defence = defenceArray[level];
        mitigation = mitigationArray[level];
    }
}