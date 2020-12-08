using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Goblin : Monster
{
    public Goblin(int strength, int agility, int stamina, int level)
    : base(strength, agility, stamina, level)
    {
        name = "Goblin";
        mitigation = 1;
        xp = 6;
        gold = 22;
        dropRate = 30;
    }
    public override void Attack2(Player target)
    {        
        if (AttemptToHit(target, 0))
        {
            Combat.combatText.Add($"The " + Color.MONSTER + "goblin" + Color.RESET + $" rakes you for {Color.DAMAGE + Return.MitigatedDamage(damage,target.Mitigation) + Color.RESET} damage, causing " + Color.BLOOD + "bleeding" + Color.RESET);
            target.Bleed = 2;
            target.BleedDam = 6;
            target.TakeDamage(Return.MitigatedDamage(damage, target.Mitigation) , this);
        }
        else Miss(target);
    }

    public override void Declare2()
    {
        intention = "Raking";
    }

}