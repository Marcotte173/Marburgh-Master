using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SavageOrc : Monster
{
    int stunAttempts;
    public SavageOrc(int strength, int agility, int stamina, int level)
    : base(strength, agility, stamina, level)
    {
        stunAttempts = 2;
        name = "Savage Orc";
        mitigation = 2;
        xp = 15;
        gold = 30;
        dropRate = 100;
    }
    public override void Attack2(Player target)
    {
        if (AttemptToHit(target, 0))
        {
            Combat.combatText.Add($"The " + Color.MONSTER + "orc" + Color.RESET + $" charges at you, " + Color.STUNNED + "stunning " + Color.RESET + $"you and doing {Color.DAMAGE + Return.MitigatedDamage(damage, target.Mitigation) * 2 + Color.RESET} damage!");
            target.Stun = level;
            target.TakeDamage(Return.MitigatedDamage(damage, target.Mitigation), this);
        }
        else Miss(target);
    }
    public override void Declare2()
    {
        intention = "Charging";
    }
    public override Drop ChooseDrop()
    {
        return DropList.savageOrcFang;
    }
    public override void Declare()
    {
        action = Return.RandomInt(0, 4);
        if (bleed > 0 && !Status.Contains("Bleeding")) Status.Add(Color.BLOOD + "Bleeding" + Color.RESET);
        if (stun > 0 && !Status.Contains("Stunned")) Status.Add(Color.STUNNED + "Stunned" + Color.RESET);
        if (action == 0 && stunAttempts > 0)
        {
            stunAttempts--;
            Declare2();
        }
        else
        {
            action = 1;
            intention = "Ready";
        }
    }
}