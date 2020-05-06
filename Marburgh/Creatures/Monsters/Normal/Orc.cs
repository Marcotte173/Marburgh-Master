using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Orc : Monster
{
    public Orc()
    : base()
    {
        name = "Orc";
        crit = 5;
        hit = 75;
        defence = 7;
        mitigation = 1;
        level = 1;
        health = maxHealth = 16;
        damage = 9;
        xp = 9;
        gold = 19;
    }
    public override void Attack2(Player target)
    {
        if (AttemptToHit(target, 0))
        {
            Console.WriteLine($"The orc charges at you, stunning and doing {damage} damage!");
            Create.p.Stun = 2;
            Create.p.TakeDamage(damage,this);
        }
        else Miss(target);
    }
    public override void Declare2()
    {
        intention = "Charging";
    }
}