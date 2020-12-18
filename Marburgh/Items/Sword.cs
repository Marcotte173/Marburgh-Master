using System;
using System.Collections.Generic;
using System.Text;

public class Sword : Equipment
{
    int[] damageBoost = new int[] { 0, 2, 4, 4, 6, 6, 8, 10 };
    int[] hitBoost = new int[]    { 0, 3, 2, 2, 2, 2, 3, 3  };
    public static Sword twoHanded = new Sword("Two Hand", 0, 0, 0, false, 0);     

    public Sword(string name, int damage, int hit, int crit, bool twoHand, int level)
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
        hit += hitBoost[level];
        Name = $"Honed {name}";
    }
}