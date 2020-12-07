using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Orc : Monster
{
    public Orc(int strength, int agility, int stamina)
    : base(strength, agility, stamina)
    {
        name = "Orc";
        mitigation = 1;
        level = 1;
        xp = 9;
        gold = 19;
    }
    public override void Attack2(Player target)
    {
        if (AttemptToHit(target, -10))
        {
            Combat.combatText.Add($"The " + Color.MONSTER + "orc " + Color.RESET + $"charges at you, " + Color.STUNNED + "stunning" + Color.RESET + $" you and doing {Color.DAMAGE + Return.MitigatedDamage(damage, target.Mitigation) + Color.RESET} damage!");
            Create.p.Stun = 2;
            Create.p.TakeDamage(Return.MitigatedDamage(damage, target.Mitigation), this);
        }
        else Miss(target);
    }
    public override void Declare2()
    {
        intention = "Charging";
    }
}