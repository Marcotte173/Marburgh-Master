using System;
using System.Collections.Generic;
using System.Text;

public class Sharp : Weapon
{
    internal static string[] names = new string[]
   {
        "None",
        "Knife",
        "Dagger",
        "Short Sword",
        "Long Sword"
   };

    internal static Sharp[] list = new Sharp[]
    {
        new Sharp(0,1),
        new Sharp(1,1),
        new Sharp(2,1),
        new Sharp(3,1),
        new Sharp(4,1),
    };

    public Sharp(int level, int tier)
    : base()
    {
        this.level = level;
        this.tier = tier;
        if (tier < 3)
        {
            string a = (tier == 1) ? "" : "Deadly ";
            Name = $"{a}{names[level]}";
        }
        spellPower = 0;
        damage = level * 2 + Return.RandomInt((level + 1) * -1, level + 1) * level;
        damage = (damage <= 0) ? level * 2 : damage;
        coefficient = (damage <= Level * 2) ? 1 : (damage < Level * 4) ? 1.5 : 2;
        basePrice = (level == 0) ? 0 : (level == 1) ? 500 : (level == 2) ? 1500 : (level == 3) ? 2200 : 3000;
        price = Convert.ToInt32(BasePrice * Coefficient);
        hit = 5 * level;
        type = "Sharp";
        oneHand = true;
    }
}