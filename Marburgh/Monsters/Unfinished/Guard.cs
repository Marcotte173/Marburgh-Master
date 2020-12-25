using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Guard : Monster
{
    public Guard(int level)
    : base(level)
    {
        this.level = level;
        type = "Guard";
        name = "Guard";
        xp = Balance.guardXp * level + Return.RandomInt(Balance.guardXp / 2, Balance.guardXp + Balance.guardXp / 2);
        gold = Balance.guardGold * level + Return.RandomInt(Balance.guardGold / 2, Balance.guardGold + Balance.guardGold / 2);
        strength = Balance.guardStrength + Balance.guardStrength * level * 2 / 3;
        agility = Balance.guardAgility + Balance.guardAgility * level / 2;
        stamina = Balance.guardStamina + Balance.guardStamina * level / 2;
        defence = agility + agility - 1;
        damage = strength;
        hit = 65 + agility * 4;
        crit = agility * 4;
        health = maxHealth = 5 * stamina;
        mitigation = level * 3 / 2;
        dropRate = 30;
    }

    public override void Declare()
    {
        if (bleed > 0 && !Status.Contains("Bleeding")) Status.Add(Color.BLOOD + "Bleeding" + Color.RESET);
        if (stun > 0 && !Status.Contains("Stunned")) Status.Add(Color.STUNNED + "Stunned" + Color.RESET);
        action = 1;
        intention = "Ready";
    }
}