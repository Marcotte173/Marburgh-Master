﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Orc : Monster
{
    int stunAttempts;
    public Orc(int strength, int agility, int stamina, int level)
    : base(strength, agility, stamina, level)
    {
        name = "Orc";
        type = "Orc";
        mitigation = 1;
        xp = 9;
        gold = 19;
        stunAttempts = 1;
    }
    public Orc(int level)
    : base(level)
    {
        this.level = level;
        type = "Orc";
        name = "Orc";
        xp = Balance.orcXp * level + Return.RandomInt(Balance.orcXp / 2, Balance.orcXp + Balance.orcXp / 2);
        gold = Balance.orcGold * level + Return.RandomInt(Balance.orcGold / 2, Balance.orcGold + Balance.orcGold / 2);
        strength = Balance.orcStrength + Balance.orcStrength * level * 2 / 3;
        agility = Balance.orcAgility + Balance.orcAgility * level / 2;
        stamina = Balance.orcStamina + Balance.orcStamina * level / 2;
        defence = 2 * agility + agility - 1;
        damage = strength;
        hit = 65 + agility * 4;
        crit = agility * 4;
        health = maxHealth = 6 * stamina;
        mitigation = level;
        dropRate = 30;
    }

    public override void Attack2(Player target)
    {
        if (target.PersonalShield)
        {
            Combat.combatText.Add(Color.MONSTER + name + Color.RESET + $" charges at you but it cannot break through your " + Color.SHIELD + "shield");
            target.Energy = (target.Energy - damage / 2 <= 0) ? 0 : target.Energy - damage / 2;
            if (target.Energy == 0) target.Attack2(null);
        }
        else if (AttemptToHit(target, 0))
        {
            Combat.combatText.Add(Color.MONSTER + name + Color.RESET + $"charges at you, " + Color.STUNNED + "stunning" + Color.RESET + $" you and doing {Color.DAMAGE + Return.MitigatedDamage(damage, target.Mitigation) + Color.RESET} damage!");
            target.Stun = level;
            target.TakeDamage(Return.MitigatedDamage(damage, target.Mitigation), this);
        }
        else Miss(target);



        if (AttemptToHit(target, -10))
        {
            Combat.combatText.Add(Color.MONSTER + name + Color.RESET + $"charges at you, " + Color.STUNNED + "stunning" + Color.RESET + $" you and doing {Color.DAMAGE + Return.MitigatedDamage(damage, target.Mitigation) + Color.RESET} damage!");
            target.Stun = level;
            target.TakeDamage(Return.MitigatedDamage(damage, target.Mitigation), this);
        }
        else Miss(target);
    }
    public override void Declare2()
    {
        intention = "Charging";
    }
    public override void Declare()
    {
        action = Return.RandomInt(0, 4);
        if (bleed > 0 && !Status.Contains("Bleeding")) Status.Add(Color.BLOOD + "Bleeding" + Color.RESET);
        if (stun > 0 && !Status.Contains("Stunned")) Status.Add(Color.STUNNED + "Stunned" + Color.RESET);
        if(action == 0 && stunAttempts >0)
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