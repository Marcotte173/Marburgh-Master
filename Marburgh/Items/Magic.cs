using System;
using System.Collections.Generic;
using System.Text;

public class Magic : Equipment
{
    int[] damageBoost = new int[] { 0, 2, 5, 8, 16, 20, 28, 35 };

    internal static Magic[] list = new Magic[]
    {
        new Magic("None",0,0,0,0,0,false,0),
        new Magic("Walking stick",4,3,0,0,250,true,1),
        new Magic("Staff",10,7,1,2,400,true,2),
        new Magic("Book",15,12,4,4,550,false,3),
        new Magic("Wand",20,18,6,6,700,false,4),
        new Magic("Orb",28,25,11,10,1000,false,5),
        new Magic("Ring",36,34,14,13,1300,false,6),
        new Magic("Source",50,45,16,16,1800,false,7)
    };

    public Magic(string name, int damage, int spellpower, int hit, int crit, int price, bool twoHand, int level)
    : base()
    {
        this.level = level;
        this.spellPower = spellpower;
        this.name = name;
        this.damage = damage;
        this.hit = hit;
        this.crit = crit;
        this.price = price;
        this.twoHand = twoHand;
        type = "Magic";
        monsterEye = monsterTooth = level * 2 - 1;
    }
    public override void Upgrade()
    {
        base.Upgrade();
        spellPower += damageBoost[level];
        Name = $"Arcane {name}";
    }
}