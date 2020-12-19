using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Zombie : Monster
{
    public int deadCount;
    public Zombie(int strength, int agility, int stamina, int level)
    : base(strength, agility, stamina, level)
    {
        name = "Zombie";
        type = "Zombie";
        mitigation = 1;
        xp = 6;
        gold = 22;
        dropRate = 30;
        undead = true;
    }

    public Zombie(int level)
    : base(level)
    {
        this.level = level;
        type = "Zombie";
        name = "Zombie";
        xp = Balance.zombieXp * level + Return.RandomInt(Balance.zombieXp / 2, Balance.zombieXp + Balance.zombieXp / 2);
        gold = Balance.zombieGold * level + Return.RandomInt(Balance.zombieGold / 2, Balance.zombieGold + Balance.zombieGold / 2);
        strength = Balance.zombieStrength + Balance.zombieStrength * level * 2 / 3;
        agility = Balance.zombieAgility + Balance.zombieAgility * level / 2;
        stamina = Balance.zombieStamina + Balance.zombieStamina * level / 2;
        defence = 3/2 * agility + agility - 1;
        damage = strength ;
        hit = 65 + agility * 4;
        crit = agility * 4;
        health = maxHealth = 6 * stamina;
    }
    public override void Declare()
    {
        canAct = true;
        action = 1;
        intention = "Ready";
    }

    public override void Death()
    {
        if (Create.p.combatMonsters.Count == 1) base.Death();
        else
        {
            Combat.combatText.Add(Color.MONSTER + name + Color.RESET +" falls to the ground. Finish the fight before it rises again!");
            deadCount = 4;
            Combat.outOfFight.Add(this);
            Create.p.combatMonsters.Remove(this);
        }
    }

    internal void Revive()
    {
        Combat.outOfFight.Remove(this);
        Create.p.combatMonsters.Add(this);
        health = maxHealth / 2;
        Combat.combatText.Add(Color.MONSTER + name + Color.RESET +" rises!");
    }
}