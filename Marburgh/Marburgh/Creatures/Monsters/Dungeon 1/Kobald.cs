using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Kobald : Monster
{
    public Kobald()
     : base()
    {
        name = "Kobald";
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
    public override void Attack2(Creature target)
    {
        if (AttemptToHit(target, 0))
        {
            Console.WriteLine($"The kobald throws a candle at you, causing 1 damage, and igniting you!");
            Create.p.Burning += 2;
            Create.p.BurnDam = 3;
            Create.p.TakeDamage(1);
        }
        else Miss(target);
    }

    public override void Declare2()
    {
        intention = "Throwing";
    }
}