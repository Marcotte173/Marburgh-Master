using System;
using System.Collections.Generic;
using System.Text;

public class Magic : Equipment
{
    int[] damageBoost = new int[] { 0, 1, 2, 3, 3, 20, 28, 35 };

    public Magic(string name, int damage, int spellpower, int hit, int crit, bool twoHand, int level)
    : base()
    {
        this.level = level;
        this.spellPower = spellpower;
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
        spellPower += damageBoost[level];
        Name = $"Arcane {name}";
    }
}