using System;
using System.Collections.Generic;
using System.Text;

public class Armor : Equipment
{
    int[] mitigationArray = new int[] { 0, 1, 2, 4, 6, 8 };
    int[] defenceArray =    new int[] { 0, 10, 8, 6, 4, 2 };
    int[] priceArray =      new int[] { 0, 500 , 1500, 3000, 5000, 7500 };

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
        new Armor(0),
        new Armor(1),
        new Armor(2),
        new Armor(3),
        new Armor(4),
        new Armor(5),
    };

    public Armor(int level)
    : base()
    {
        this.level = level;
        Name = names[level];
        price = priceArray[level];
        defence = defenceArray[level];
        mitigation = mitigationArray[level];
    }

    public override void Upgrade()
    {
        base.Upgrade();
        mitigation += EffectBoost[level];
        Name = $"Reinforced {names[level]}";
    }
}