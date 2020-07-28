using System;
using System.Collections.Generic;
using System.Text;

public class Blunt : Equipment
{    
    int[] damageBoost = new int[] { 0, 3, 5,  5,  6,  9, 10,  14 };

    internal static Blunt[] list = new Blunt[]
    {
        new Blunt("Fist",0,0,0,0,false,0),
        new Blunt("Club",8,0,0,250,false,1),
        new Blunt("Hammer",15,1,1,400,false,2),
        new Blunt("Shillelagh",21,3,3,550,false,3),
        new Blunt("Flail",26,4,4,700,false,4),
        new Blunt("Morning Star",37,5,5,1000,false,5),
        new Blunt("War Hammer",45,8,8,1300,false,6),
        new Blunt("Maul",62,8,8,1800,false,7)
    };

    public Blunt(string name, int damage, int hit, int crit, int price, bool twoHand,int level)
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
        type = "Blunt";
    }
    public override void Upgrade()
    {
        base.Upgrade();
        damage += damageBoost[level];
        Name = $"Massive {name}";
    }
}