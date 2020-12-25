using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SavageOrc : Monster
{
    int stunAttempts;
    public SavageOrc(int level)
    : base(level)
    {
        this.level = level;
        type = "Savage Orc";
        name = "Savage Orc";
        xp = Balance.savageOrcXp * level + Return.RandomInt(Balance.savageOrcXp / 2, Balance.savageOrcXp + Balance.savageOrcXp / 2);
        gold = Balance.savageOrcGold * level + Return.RandomInt(Balance.savageOrcGold / 2, Balance.savageOrcGold + Balance.savageOrcGold / 2);
        strength = Balance.savageOrcStrength + Balance.savageOrcStrength * level /2;
        agility = Balance.savageOrcAgility + Balance.savageOrcAgility * level / 2;
        stamina = Balance.savageOrcStamina + Balance.savageOrcStamina * level / 2;
        defence = 2 * agility + agility - 1;
        damage = strength;
        hit = 65 + agility * 4;
        crit = agility * 4;
        health = maxHealth = 5 * stamina;
        mitigation = level;
        dropRate = 30;
        stunAttempts = level;
    }
    public override void Attack2(Player target)
    {
        if (AttemptToHit(target, -10))
        {
            if (target.PersonalShield)
            {
                target.Energy = (target.Energy - damage / 2 <= 0) ? 0 : target.Energy - damage / 2;
                Combat.AddCombatText(Color.MONSTER + name + Color.RESET + $" charges at you but it cannot break through your " + Color.SHIELD + "shield");
            }
            else
            {
                target.Stun = level;
                target.TakeDamage(Return.MitigatedDamage(damage, target.Mitigation), this);
                Combat.AddCombatText(Color.MONSTER + name + Color.RESET + $"charges at you, " + Color.STUNNED + "stunning" + Color.RESET + $" you and doing {Color.DAMAGE + Return.MitigatedDamage(damage, target.Mitigation) + Color.RESET} damage!");
            }
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