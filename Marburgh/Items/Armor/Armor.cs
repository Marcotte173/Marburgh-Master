using System;
using System.Collections.Generic;
using System.Text;

public class ARMOR : Equipment
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

    internal static ARMOR[] list = new ARMOR[]
    {
        new ARMOR(0),
        new ARMOR(1),
        new ARMOR(2),
        new ARMOR(3),
        new ARMOR(4),
        new ARMOR(5),
    };

    public ARMOR(int level)
    : base()
    {
        this.level = level;
        Name = names[level];
        price = priceArray[level];
        defence = defenceArray[level];
        mitigation = mitigationArray[level];
        type = "Armor";
    }

    public override void Upgrade()
    {
        base.Upgrade();
        mitigation += EffectBoost[level];
        Name = $"Reinforced {names[level]}";
    }
}