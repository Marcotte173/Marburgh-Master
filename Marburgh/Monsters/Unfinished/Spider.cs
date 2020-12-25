using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Spider : Monster
{
    public Spider(int level)
    : base(level)
    {
        this.level = level;
        type = "Spider";
        name = "Spider";
        xp = Balance.spiderXp * level + Return.RandomInt(Balance.spiderXp / 2, Balance.spiderXp + Balance.spiderXp / 2);
        gold = Balance.spiderGold * level + Return.RandomInt(Balance.spiderGold / 2, Balance.spiderGold + Balance.spiderGold / 2);
        strength = Balance.spiderStrength + Balance.spiderStrength * level * 2 / 3;
        agility = Balance.spiderAgility + Balance.spiderAgility * level / 2;
        stamina = Balance.spiderStamina + Balance.spiderStamina * level / 2;
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
