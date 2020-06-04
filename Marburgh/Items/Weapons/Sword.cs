using System;
using System.Collections.Generic;
using System.Text;

public class Sword : Weapon
{
    int[] damageBoost = new int[] { 0, 2, 4, 4, 6, 6, 8, 10 };
    int[] hitBoost = new int[]    { 0, 3, 2, 2, 2, 2, 3, 3  };

    internal static Sword[] list = new Sword[]
    {
        new Sword("Fist",0,0,0,0,false,0),
        new Sword("Short Sword",7,4,1,250,false,1),
        new Sword("Arming Sword",13,8,2,400,false,2),
        new Sword("Long Sword",18,12,3,550,false,3),
        new Sword("Katana",22,16,5,700,false,4),
        new Sword("Broad Sword",31,20,7,1000,false,5),
        new Sword("Great Sword",38,24,8,1300,false,6),
        new Sword("Claymore",50,30,10,1800,false,7)
    };

    public Sword(string name, int damage, int hit, int crit, int price, bool twoHand, int level)
    : base()
    {
        this.level = level;
        spellPower = 0;
        this.name = name;
        this.damage = damage;
        this.hit = hit;
        this.crit = crit;
        this.price = price;
        this.twoHand = twoHand;
        type = "Sword";
    }
    public override void Upgrade()
    {
        base.Upgrade();
        damage += damageBoost[level];
        hit += hitBoost[level];
        Name = $"Honed {name}";
    }
}