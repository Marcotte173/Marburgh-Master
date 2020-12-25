using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Zombie : Monster
{
    public int deadCount;
    
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
        health = maxHealth = 5 * stamina;
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
            Combat.AddCombatText(Color.MONSTER + name + Color.RESET +" falls to the ground. Finish the fight before it rises again!");
            deadCount = 4;
            Combat.outOfFight.Add(this);
            Create.p.combatMonsters.Remove(this);
        }
    }

    internal void Revive()
    {
        Combat.outOfFight.Remove(this);
        Stun = 0;
        Bleed = 0;
        BleedDam = 0;
        Burning = 0;
        Status.Clear();
        Create.p.combatMonsters.Add(this);
        health = maxHealth / 2;
        Combat.AddCombatText(Color.MONSTER + name + Color.RESET +" rises!");
    }
}