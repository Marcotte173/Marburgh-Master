using System;
using System.Collections.Generic;
using System.Text;

public class Blunt : Equipment
{    
    int[] damageBoost = new int[] { 0, 2, 2,  2,  6,  9, 10,  14 };   

    public Blunt(string name, int damage, int hit, int crit,  bool twoHand,int level)
    : base()
    {
        this.level = level;
        spellPower = 0;
        this.name = name;
        this.damage = damage;
        this.hit = hit;
        this.crit = crit;
        if (twoHand) type = EquipmentType.TwoHand;
        else type = EquipmentType.OneHand;
        monsterEye = monsterTooth = level * 2 - 1;
        GetPrice();
    }
    public override void Upgrade()
    {
        base.Upgrade();
        damage += damageBoost[level];
        Name = $"Massive {name}";
    }
}