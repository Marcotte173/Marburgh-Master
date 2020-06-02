using System;
using System.Collections.Generic;
using System.Text;

public class Blunt : Equipment
{    
    int[] damageBoost = new int[] { 0, 2, 4,  6,  8,  10, 0,  0 };

    internal static string[] names = new string[]
    {
        "None",
        "Club",
        "Hammer",
        "Shillelagh",
        "Flail",
        "Morning Star",
        "War Hammer",
        "Maul"
    };

    internal static Blunt[] list = new Blunt[]
    {
    new Blunt("Fist",0,0,0,0,false),
    new Blunt("Club",8,0,0,250,false),
    new Blunt("Hammer",15,1,1,400,false),
    new Blunt("Shillelagh",21,3,3,550,false),
    new Blunt("Flail",26,4,4,700,false),
    new Blunt("Morning Star",37,5,5,1000,false),
    new Blunt("War Hammer",45,8,8,1300,false),
    new Blunt("Maul",62,8,8,1800,false)
    };

    public Blunt(string name, int damage, int hit, int crit, int price, bool oneHand)
    : base()
    {        
        spellPower = 0;
        this.name = name;
        this.damage = damage;
        this.hit = hit;
        this.crit = crit;
        this.price = price;
        this.oneHand = oneHand;
        type = "Blunt";
    }
    public override void Upgrade()
    {
        base.Upgrade();
        damage += damageBoost[level];
        Name = $"Massive {names[level]}";
    }
}