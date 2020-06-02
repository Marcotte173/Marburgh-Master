using System;
using System.Collections.Generic;
using System.Text;

public class Dagger : Weapon
{
    int[] damageArray = new int[] { 0, 10, 5, 8, 12, 15 };
    int[] hitArray = new int[] { 0, 0, 5, 7, 10, 15 };
    int[] critArray = new int[] { 0, 10, 5, 7, 10, 12 };

    int[] damageBoost = new int[] { 0, 2, 4, 6, 8, 10, 0, 0 };

    internal static string[] names = new string[]
   {
        "None",
        "Butcher's Knife",
        "Knife",
        "Stilleto",        
        "Dirk",
        "Trench Knife",
   };

    internal static Dagger[] list = new Dagger[]
    {
        new Dagger(0),
        new Dagger(1),
        new Dagger(2),
        new Dagger(3),
        new Dagger(4),
        new Dagger(5),
    };

    public Dagger(int level)
    : base()
    {
        this.level = level;
        Name = names[level];
        spellPower = 0;
        damage = damageArray[level];
        hit = hitArray[level];
        crit = critArray[level];
        price = priceArray[level];
        type = "Dagger";
        oneHand = true;
    }
    public override void Upgrade()
    {
        base.Upgrade();
        damage += damageBoost[level];
        crit += EffectBoost[level];
        Name = $"Deadly {names[level]}";
    }
}