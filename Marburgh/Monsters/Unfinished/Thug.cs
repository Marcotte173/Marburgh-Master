using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Thug:Monster
{
    public Thug(int level)
    : base(level)
    {
        this.level = level;
        type = "Thug";
        name = "Thug";
        xp = Balance.thugXp * level + Return.RandomInt(Balance.thugXp / 2, Balance.thugXp + Balance.thugXp / 2);
        gold = Balance.thugGold * level + Return.RandomInt(Balance.thugGold / 2, Balance.thugGold + Balance.thugGold / 2);
        strength = Balance.thugStrength + Balance.thugStrength * level * 2 / 3;
        agility = Balance.thugAgility + Balance.thugAgility * level / 2;
        stamina = Balance.thugStamina + Balance.thugStamina * level / 2;
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