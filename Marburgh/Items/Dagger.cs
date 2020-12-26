using System;
using System.Collections.Generic;
using System.Text;

public class Dagger : Equipment
{
    int[] damageBoost = new int[] { 0, 1, 2, 2, 6, 7, 8, 10 };
    int[] critBoost = new int[]   { 0, 3, 2, 2, 2, 2, 3, 3};   

    public Dagger(string name, int damage, int hit, int crit, int level)
    : base()
    {
        this.level = level;
        spellPower = 0;
        this.name = name;
        this.damage = damage;
        this.hit = hit;
        this.crit = crit;
        type = EquipmentType.OneHand;
        monsterEye = monsterTooth = level * 2 - 1;
        GetPrice();
    }
    public override void Upgrade()
    {
        base.Upgrade();
        damage += damageBoost[level];
        crit += critBoost[level];
        Name = $"Deadly {name}";
    }
}