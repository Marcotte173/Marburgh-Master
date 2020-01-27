using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Goblin:Monster
{    
    public Goblin()
     : base()
    {
        name = "Goblin";
        crit = 5;
        hit = 70;
        defence = 5;
        mitigation = 1;
        level = 1;
        health = maxHealth = 16;
        damage = 3;
        xp = 6;
        gold = 13;
    }
    public override void Attack3(Creature target)
    {
        if (AttemptToHit(target, 0))
        {
            Console.WriteLine($"The goblin rakes you for {Damage - 1} damage, causing bleeding");
            Create.p.Bleed = 2;
            Create.p.BleedDam = 2;
        } 
        else Miss(target);
    }

    public override void Declare3()
    {
        intention = "Raking";
    }
}