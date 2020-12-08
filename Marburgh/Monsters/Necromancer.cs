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
    }

    public override void Attack2(Player target)
    {
        Combat.combatText.Add($"The " + Color.MONSTER + "slime " + Color.RESET + "splits in two! Now there are TWO " + Color.MONSTER + "slimes" + Color.RESET + "!");
        Slime s = new Slime(2, 2, 3, 1);
        s.Health = s.MaxHealth = MaxHealth;
        Create.p.combatMonsters.Add(s);
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

