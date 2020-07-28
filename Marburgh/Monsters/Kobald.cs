using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Kobold : Monster
{
    public Kobold()
     : base()
    {
        name = "Kobald";
        crit = 15;
        hit = 70;
        defence = 5;
        mitigation = 1;
        level = 1;
        health = maxHealth = 40;
        damage = 12;
        xp = 6;
        gold = 20;
        dropRate = 30;
    }
    public override void Attack2(Player target)
    {
        if (AttemptToHit(target, 0))
        {
            Combat.combatText.Add($"The " + Color.MONSTER + "kobald" + Color.RESET + " throws a candle at you, causing "+Color.DAMAGE + "1"+Color.RESET + " damage, and " + Color.BURNING + "igniting " + Color.RESET + "you!");
            if (target.Burning > 0) target.Burning += 1;
            else target.BurnDam = 3;
            target.Burning = 3;
            target.TakeDamage(1,this);
        }
        else Miss(target);
    }

    public override void Declare2()
    {
        intention = "Throwing";
    }
}