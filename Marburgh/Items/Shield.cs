using System;
using System.Collections.Generic;
using System.Text;

public class Shield : Equipment
{
    int[] mitigationArray = new int[] { 0, 0, 1, 3, 5, 7 };
    int[] defenceArray =    new int[] { 0, 10, 12, 14, 16, 20 };

    internal static string[] names = new string[]
    {
        "None",
        "Buckler",
        "Round Shield",
        "Pavise",
        "Targ",
        "Heater shield",
        "Kite Shield",
        "Teardrop Shield"
    };

    internal static Shield[] list = new Shield[]
    {
        new Shield("Fist",0,0,0,0),
        new Shield("Buckler",0,3,250,1),
        new Shield("Round Shield",0,10,400,2),
        new Shield("Pavise",0,15,550,3),
        new Shield("Targ",0,20,700,4),
        new Shield("Heater Shield",0,25,1000,5),
        new Shield("Kite Shield",0,30,1300,6),
        new Shield("Teardrop Shield",0,40,1800,7),
    };

    public Shield(string name, int mitigation, int defence, int price, int level)
    : base()
    {
        this.level = level;
        this.name = name;
        this.mitigation = mitigation;
        this.defence = defence;
        this.price = price;
        this.twoHand = false;
        type = "Shield";
        monsterEye = monsterTooth = level * 2 - 1;
    }
    public override void Upgrade()
    {
        base.Upgrade();
        mitigation += mitigationArray[Level] ;
        Name = $"Honed {name}";
    }
}