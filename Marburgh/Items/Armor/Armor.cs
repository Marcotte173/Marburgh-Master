using System;
using System.Collections.Generic;
using System.Text;

public class ARMOR : Equipment
{
    int[] mitigationArray = new int[] { 0, 1, 2, 4, 6, 8 };
    int[] defenceArray =    new int[] { 0, 10, 8, 6, 4, 2 };

    internal static ARMOR[] list = new ARMOR[]
    {
        new ARMOR("Fist",0,0,0,0),
        new ARMOR("Cloth",0,0,250,1),
        new ARMOR("Leather",0,0,400,2),
        new ARMOR("Hardened Leather",0,0,550,3),
        new ARMOR("Mail",0,0,700,4),
        new ARMOR("Coat Of Plates",0,0,1000,5),
        new ARMOR("Mail and Plate",0,0,1300,6),
        new ARMOR("Articulated Plate",0,0,1800,7),
    };

    public ARMOR(string name, int mitigation, int defence, int price, int level)
    : base()
    {
        this.level = level;
        this.name = name;
        this.mitigation = mitigation;
        this.defence = defence;
        this.price = price;
        type = "Armor";
    }

    public override void Upgrade()
    {
        base.Upgrade();
        mitigation += mitigationArray[level];
        Name = $"Reinforced {name}";
    }
}