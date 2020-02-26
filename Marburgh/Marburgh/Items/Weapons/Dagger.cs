using System;
using System.Collections.Generic;
using System.Text;

public class Dagger : Weapon
{
    int[] damageArray = new int[] { 0, 2, 5, 8, 12, 15 };
    int[] hitArray = new int[] { 0, 3, 5, 7, 10, 15 };
    int[] critArray = new int[] { 0, 3, 5, 7, 10, 12 };

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
        new Dagger(0,1),
        new Dagger(1,1),
        new Dagger(2,1),
        new Dagger(3,1),
        new Dagger(4,1),
        new Dagger(5,1),
    };

    public Dagger(int level, int tier)
    : base()
    {
        this.level = level;
        this.tier = tier;
        Name = $"{modifier}{names[level]}";

        spellPower = 0;
        damage = damageArray[level];
        hit = hitArray[level];
        crit = critArray[level];

        price = priceArray[level];

        type = "Dagger";
        oneHand = true;
    }
}