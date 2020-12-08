using System;
using System.Collections.Generic;
using System.Text;

public class Dagger : Equipment
{
    int[] damageBoost = new int[] { 0, 3, 4, 4, 6, 7, 8, 10 };
    int[] critBoost = new int[]   { 0, 3, 2, 2, 2, 2, 3, 3};

    public static Dagger savageDagger = new Dagger("Savage Dagger",7,2,5,1000,false,2);

    internal static Dagger[] list = new Dagger[]
    {
        new Dagger("Fist",0,0,0,0,false,0),
        new Dagger("Butcher's Knife",4,1,4,250,false,1),
        new Dagger("Knife",14,2,8,400,false,2),
        new Dagger("Push Dagger",19,3,12,550,false,3),
        new Dagger("Stilleto",22,5,16,700,false,4),
        new Dagger("Dirk",31,7,20,1000,false,5),
        new Dagger("Trench Knife",39,8,24,1300,false,6),
        new Dagger("Baselard",50,20,30,1800,false,7)
    };

    public Dagger(string name, int damage, int hit, int crit, int price, bool twoHand, int level)
    : base()
    {
        this.level = level;
        spellPower = 0;
        this.name = name;
        this.damage = damage;
        this.hit = hit;
        this.crit = crit;
        this.price = price;
        this.twoHand = twoHand;
        type = "Dagger";
        monsterEye = monsterTooth = level * 2 - 1;
    }
    public override void Upgrade()
    {
        base.Upgrade();
        damage += damageBoost[level];
        crit += critBoost[level];
        Name = $"Deadly {name}";
    }
}