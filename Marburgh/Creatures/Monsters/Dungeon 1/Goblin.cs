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
        health = maxHealth = 10;
        damage = 5;
        xp = 6;
        gold = 13;
        dropRate = 30;
    }
    public override void Attack2(Player target)
    {
        if (AttemptToHit(target, 0))
        {
            Combat.combatText.Add($"The "+Color.MONSTER + "goblin" + Color.RESET +$" rakes you for {Color.DAMAGE + damage  + Color.RESET} damage, causing " + Color.BLOOD + "bleeding" + Color.RESET );
            target.Bleed = 2;
            target.BleedDam = 2;
            target.TakeDamage(Damage - 1,this);
        } 
        else Miss(target);
    }

    public override void Declare2()
    {
        intention = "Raking";
    }
    
}