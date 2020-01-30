using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Slime : Monster
{
    Drop slime = new Drop("Slime", 1, true);
    public Slime()
     : base()
    {
        name = "Slime";
        crit = 5;
        hit = 70;
        defence = 5;
        mitigation = 1;
        level = 1;
        health = maxHealth = 7;
        damage = 3;
        xp = 6;
        gold = 13;
        dropRate = 25;
    }
    public override void Attack2(Creature target)
    {
        Console.WriteLine($"The slime splits in two! Now there are TWO slimes!");
        //Add slime to list
    }

    public override void Declare2()
    {
        intention = "Splitting";
    }
    public override Drop ChooseDrop()
    {
        if (Return.RandomInt(0, 4) == 0) return slime;
        else return monsterEye;
    }
}