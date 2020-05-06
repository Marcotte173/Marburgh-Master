using System;
using System.Collections.Generic;
using System.Text;

public class Magic : Weapon
{
    int[] spellPowerArray = new int[] { 0, 2, 5, 7, 10, 15 };
    int[] damageArray = new int[] { 0, 2, 4, 6, 8, 10 };
    int[] hitArray =    new int[] { 0, 1, 2, 3, 4, 5 };
    int[] critArray =   new int[] { 0, 0, 0, 0, 0, 0 };

    internal static string[] names = new string[]
    {
        "None",
        "Walking stick",
        "Orb",
        "Wand",
        "Staff",
        "Ring"
    };

    internal static Magic[] list = new Magic[]
    {
        new Magic(0),
        new Magic(1),
        new Magic(2),
        new Magic(3),
        new Magic(4),
        new Magic(5),
    };

    public Magic(int level)
    : base()
    {
        this.level = level;
        Name = names[level];
        damage = damageArray[level];
        hit = hitArray[level];
        crit = critArray[level];
        spellPower = spellPowerArray[level];
        price = priceArray[level];
        type = "Magic";
    }
    public override void Upgrade()
    {
        base.Upgrade();
        spellPower += DamageBoost[level];
        Name = $"Arcane {names[level]}";
    }
}