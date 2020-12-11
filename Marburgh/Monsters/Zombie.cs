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
            Combat.combatText.Add($"The {Color.MONSTER + Name + Color.RESET} falls to the ground. Finish the fight before it rises again!");
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
        Combat.combatText.Add($"The {Color.MONSTER + Name + Color.RESET} rises!");
    }
}