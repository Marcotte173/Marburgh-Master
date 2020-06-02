using System;
using System.Collections.Generic;
using System.Text;

public class Sword : Weapon
{
    int[] damageArray = new int[] { 0, 10, 5, 8, 12, 15 };
    int[] hitArray = new int[] { 0, 7, 8,7, 7, 15 };
    int[] critArray = new int[] { 0, 0, 1, 2, 2, 3 };

    int[] damageBoost = new int[] { 0, 2, 4, 6, 8, 10, 0, 0 };

    internal static string[] names = new string[]
    {
        "None",
        "Short Sword",
        "Arming Sword",
        "Long Sword",
        "Broad Sword",
        "Great Sword"
    };

    internal static Sword[] list = new Sword[]
    {
        new Sword(0),
        new Sword(1),
        new Sword(2),
        new Sword(3),
        new Sword(4),
        new Sword(5),
    };

    public Sword(int level)
    : base()
    {
        this.level = level;
        Name = names[level];
        spellPower = 0;
        damage = damageArray[level];
        hit = hitArray[level];
        crit = critArray[level];
        price = priceArray[level];
        if (level != 5) oneHand = true;
        type = "Sword";
    }
    public override void Upgrade()
    {
        base.Upgrade();
        damage += damageBoost[level];
        hit += EffectBoost[level];
        Name = $"Honed {names[level]}";
    }
}