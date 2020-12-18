using System;
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
        int newDamage = damage * 2;
        if (target.PersonalShield)
        {
            Combat.combatText.Add(Color.MONSTER + name + Color.RESET + $" takes a "+Color.ABILITY+ "BIG CUT "+Color.RESET+"but it is absorbed by your" + Color.SHIELD + "shield");
            target.Energy = (target.Energy - newDamage / 2 <= 0) ? 0 : target.Energy - newDamage / 2;
            if (target.Energy == 0) target.Attack2(null);
        }
        else if (AttemptToHit(target, 0))
        {
            Combat.combatText.Add(Color.MONSTER + name + Color.RESET + $" takes a " + Color.ABILITY + "BIG CUT" + Color.RESET + $" and hits you for {Color.DAMAGE + Return.MitigatedDamage(newDamage, target.Mitigation) + Color.RESET} damage!");
            target.TakeDamage(Return.MitigatedDamage(newDamage, target.Mitigation), this);
        }
        else Miss(target);
    }
    public override void Death()
    {
        Combat.combatText.Add($"You have defeated {Color.MONSTER + Name + Color.RESET}!");
        Combat.combatText.Add("");
        Create.p.combatMonsters.Remove(this);
    }
    public override void Declare2()
    {
        if(name == "Rudiger") intention = "Big Cut <- His next move will be his special! Use your Defence!";
        else intention = "Big Cut";
    }
    public override Drop ChooseDrop()
    {
        return DropList.savageOrcFang;
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