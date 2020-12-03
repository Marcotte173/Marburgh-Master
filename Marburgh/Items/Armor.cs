using System;
using System.Collections.Generic;
using System.Text;

public class Armor : Equipment
{
    int[] mitigationArray = new int[] { 0, 1, 2, 4, 6, 8 };
    int[] defenceArray =    new int[] { 0, 10, 8, 6, 4, 2 };

    internal static Armor[] list = new Armor[]
    {
        new Armor("Fist",0,0,0,0),
        new Armor("Cloth",0,3,250,1),
        new Armor("Leather",1,10,400,2),
        new Armor("Hardened Leather",2,8,550,3),
        new Armor("Mail",3,6,700,4),
        new Armor("Coat Of Plates",5,6,1000,5),
        new Armor("Mail and Plate",7,2,1300,6),
        new Armor("Articulated Plate",10,0,1800,7),
    };

    public Armor(string name, int mitigation, int defence, int price, int level)
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