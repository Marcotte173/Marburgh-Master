using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Bat : Monster
{
    public Bat(int level)
    : base(level)
    {
        this.level = level;
        type = "Bat";
        name = "Bat";
        xp = Balance.batXp * level + Return.RandomInt(Balance.batXp / 2, Balance.batXp + Balance.batXp / 2);
        gold = Balance.batGold * level + Return.RandomInt(Balance.batGold / 2, Balance.batGold + Balance.batGold / 2);
        strength = Balance.batStrength + Balance.batStrength * level * 2 / 3;
        agility = Balance.batAgility + Balance.batAgility * level / 2;
        stamina = Balance.batStamina + Balance.batStamina * level / 2;
        defence = agility + agility - 1;
        damage = strength;
        hit = 65 + agility * 4;
        crit = agility * 4;
        health = maxHealth = 5 * stamina;
        mitigation = level * 3 / 2;
        dropRate = 45;
    }

    public override void Attack1(Player target)
    {
        if (AttemptToHit(target, 0) == false) Miss(target);
        else
        {
            if (target.PersonalShield)
            {
                Combat.AddCombatText(Color.MONSTER + name + Color.RESET + $" hits you");
                if (target.Energy >= damage / 2)
                {
                    target.Energy -= damage / 2;
                    Combat.AddCombatText("Your " + Color.SHIELD + "shield " + Color.RESET + $"absorbs the damage!");
                }
                else
                {
                    damage -= target.Energy * 2;
                    energy = 0;
                    shield = false;
                    Status.Remove(Color.SHIELD + "Shielded" + Color.RESET);
                    target.TakeDamage(Return.MitigatedDamage(damage, target.Mitigation), this);
                    Combat.AddCombatText("Your " + Color.SHIELD + "shield " + Color.RESET + $"absorbs {Color.SHIELD + target.Energy * 2 + Color.RESET} damage!");
                    Combat.AddCombatText($"You take {Color.DAMAGE + Return.MitigatedDamage(damage, target.Mitigation) + Color.RESET} damage!");
                }
            }
            else
            {
                target.TakeDamage(Return.MitigatedDamage(damage, target.Mitigation), this);
                target.AddHealth(Return.MitigatedDamage(damage, target.Mitigation)/3);
                Combat.AddCombatText(Color.MONSTER + name + Color.RESET + $" hits you for {Color.DAMAGE + Return.MitigatedDamage(damage, target.Mitigation) + Color.RESET} damage");
                Combat.AddCombatText(Color.MONSTER + name + Color.RESET + $" heals itself for {Color.DAMAGE + Return.MitigatedDamage(damage, target.Mitigation)/3 + Color.RESET} health");
            }
        }
    }

    public override void Declare()
    {
        if (bleed > 0 && !Status.Contains("Bleeding")) Status.Add(Color.BLOOD + "Bleeding" + Color.RESET);
        if (stun > 0 && !Status.Contains("Stunned")) Status.Add(Color.STUNNED + "Stunned" + Color.RESET);
        action = 1;
        intention = "Ready";
    }
    public override Drop ChooseDrop()
    {
        if (Return.RandomInt(0, 4) == 0) return DropList.batBrain;
        else return DropList.monsterEye.Copy();
    }
}
