using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Robber:Monster
{
    public Robber(int level)
    : base(level)
    {
        this.level = level;
        type = "Fenton";
        name = "Fenton";
        xp = Balance.robberXp * level + Return.RandomInt(Balance.robberXp / 2, Balance.robberXp + Balance.robberXp / 2);
        gold = Balance.robberGold * level + Return.RandomInt(Balance.robberGold / 2, Balance.robberGold + Balance.robberGold / 2);
        strength = Balance.robberStrength + Balance.robberStrength * level * 2 / 3;
        agility = Balance.robberAgility + Balance.robberAgility * level / 2;
        stamina = Balance.robberStamina + Balance.robberStamina * level / 2;
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
