using System;
using System.Collections.Generic;
using System.Text;

public class Shield : Equipment
{
    int[] mitigationArray = new int[] { 0, 0, 1, 2, 2, 7 };
    int[] defenceArray =    new int[] { 0, 5, 7, 12, 16, 20 };    

    public Shield(string name, int mitigation, int defence, int level)
    : base()
    {
        this.level = level;
        this.name = name;
        this.mitigation = mitigation;
        this.defence = defence;   
        type = EquipmentType.Shield;
        monsterEye = monsterTooth = level * 2 - 1;
        GetPrice();
    }
    public override void Upgrade()
    {
        base.Upgrade();
        mitigation += mitigationArray[Level] ;
        Name = $"Honed {name}";
    }
}