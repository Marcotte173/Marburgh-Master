using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Necromancer : Monster
{
    public Necromancer(int strength, int agility, int stamina, int level)
    : base(strength, agility, stamina, level)
    {
        name = "Necromancer";
        mitigation = 1;
        xp = 6;
        gold = 22;
        dropRate = 30;
        undead = true;
    }

    public override void Attack2(Player target)
    {
        Monster summon = (Return.RandomInt(0, 2) == 0) ? Dungeon.skeleton2 : Dungeon.zombie3;
        Combat.combatText.Add($"The " + Color.MONSTER + "Necromancer " + Color.RESET + "mumbles something you can't quite hear ");
        Combat.combatText.Add($"The ground in front of him moves ");
        Combat.combatText.Add($"A {Color.MONSTER + summon.Name + Color.RESET} crawls out of the ground");
        Dungeon.Summon(summon);
    }

    public override void Declare2()
    {
        intention = "Summoning";
    }
    public override Drop ChooseDrop()
    {
        return DropList.necromancerBrain;
    }

    public override void Declare()
    {
        action = Return.RandomInt(0, 4);
        if (action == 0 && Create.p.combatMonsters.Count < 3)
        {
            action = 0;
            Declare2();
        }
        else
        {
            action = 1;
            intention = "Ready";
        }
    }
}

