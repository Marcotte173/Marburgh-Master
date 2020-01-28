using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Slime : Monster
{
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
    }
    public override void Attack3(Creature target)
    {
        if (AttemptToHit(target, 0))
        {
            Console.WriteLine($"The slime splits in two! Now there are TWO slimes!");
        }
        else Miss(target);
    }

    public override void Declare2()
    {
        intention = "Splitting";
    }
}