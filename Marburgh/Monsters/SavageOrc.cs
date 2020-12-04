using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SavageOrc : Monster
{
    Drop savageOrcClaw = new Drop("Savage Orc Claw", 1, 1);
    public SavageOrc(int strength, int agility, int stamina)
    : base(strength, agility, stamina)
    {
        name = "Savage Orc";
        mitigation = 2;
        level = 2;
        xp = 15;
        gold = 30;
        dropRate = 100;
    }
    public override void Attack2(Player target)
    {
        if (AttemptToHit(target, 0))
        {
            Combat.combatText.Add($"The " + Color.MONSTER + "orc" + Color.RESET + $" charges at you, " + Color.STUNNED + "stunning " + Color.RESET + $"you and doing {Color.DAMAGE + Return.MitigatedDamage(damage, target.Mitigation) * 2 + Color.RESET} damage!");
            target.Stun = 2;
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
        return savageOrcClaw;
    }
}