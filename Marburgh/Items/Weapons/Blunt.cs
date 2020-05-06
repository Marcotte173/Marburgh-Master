using System;
using System.Collections.Generic;
using System.Text;

public class Blunt : Weapon
{
    int[] damageArray = new int[] { 0, 2, 5, 8, 12, 15 };
    int[] hitArray =    new int[] { 0, 1, 2, 3, 3, 5 };
    int[] critArray =   new int[] { 0, 1, 1, 2, 2, 3 };

    internal static string[] names = new string[]
    {
        "None",
        "Club",
        "Hammer",
        "Flail",
        "Morning Star",
        "War Hammer"
    };

    internal static Blunt[] list = new Blunt[]
    {
        new Blunt(0),
        new Blunt(1),
        new Blunt(2),
        new Blunt(3),
        new Blunt(4),
        new Blunt(5),
    };

    public Blunt(int level)
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
        type = "Blunt";
    }
    public override void Upgrade()
    {
        base.Upgrade();
        damage += DamageBoost[level];
        stun += EffectBoost[level];
        Name = $"Massive {names[level]}";
    }
}