﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GladiatorA : Monster
{
    public GladiatorA(int strength, int agility, int stamina, int level)
    :base(strength, agility, stamina, level)
    {
        name = global::Name.list[Return.RandomInt(0, global::Name.list.Count)];
    }
    public GladiatorA(int strength, int agility, int stamina, int level,string name)
    : base(strength, agility, stamina, level)
    {
        this.name = name;
    }

    public override void Attack2(Player target)
    {
        if (AttemptToHit(target, 0))
        {
            int newDamage = damage * 3/2;
            if (target.PersonalShield)
            {
                target.Energy = (target.Energy - newDamage / 2 <= 0) ? 0 : target.Energy - newDamage / 2;
                Combat.AddCombatText(Color.MONSTER + name + Color.RESET + $" takes a " + Color.ABILITY + "BIG CUT " + Color.RESET + "but it is absorbed by your" + Color.SHIELD + "shield");
            }
            else
            {
                target.TakeDamage(Return.MitigatedDamage(newDamage, target.Mitigation), this);
                Combat.AddCombatText(Color.MONSTER + name + Color.RESET + $" takes a " + Color.ABILITY + "BIG CUT" + Color.RESET + $" and hits you for {Color.DAMAGE + Return.MitigatedDamage(newDamage, target.Mitigation) + Color.RESET} damage!");
            }
        }
        else Miss(target);
    }
    public override void Death()
    {
        Combat.AddCombatText($"You have defeated {Color.MONSTER + Name + Color.RESET}!");
        Combat.AddCombatText("");
        Create.p.combatMonsters.Remove(this);
    }
    public override void Declare2()
    {
        if(name == "Rudiger") intention = "Big Cut <- His next move will be his special! Use your Defence!";
        else intention = "Big Cut";
    }
    public override void Declare()
    {
        if (CombatArena.round>1 && CombatArena.round % 3 ==0)
        {
            Declare2();
            action = 0;
        }
        else
        {
            action = 1;
            if (name == "Rudiger") intention = "Ready <--- He is planning a regular attack!";
            else intention = "Ready";
        }
    }
}