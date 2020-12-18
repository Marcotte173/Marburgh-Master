using System;
using System.Collections.Generic;
using System.Text;

public class Armor : Equipment
{
    int[] mitigationArray = new int[] { 0, 1, 2, 4, 6, 8,12,16 };
    int[] defenceArray =    new int[] { 0, 10, 8, 6, 4, 2 };    

    public Armor(string name, int mitigation, int defence, int level)
    : base()
    {        
        this.level = level;
        this.name = name;
        this.mitigation = mitigation;
        this.defence = defence;
        type = EquipmentType.Armor;
        monsterEye = monsterTooth = level * 2 - 1;
        GetPrice();
    }

    public override void Upgrade()
    {
        base.Upgrade();
        mitigation += mitigationArray[level];
        Name = $"Reinforced {name}";
    }
}