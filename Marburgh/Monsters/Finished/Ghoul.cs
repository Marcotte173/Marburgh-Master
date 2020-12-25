using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Ghoul:Monster
{
    public Ghoul(int level)
    : base(level)
    {        
        this.level = level;
        type = "Ghoul";
        name = "Ghoul";
        xp =  Balance.ghoulXp * level + Return.RandomInt(Balance.ghoulXp / 2, Balance.ghoulXp + Balance.ghoulXp / 2);
        gold = Balance.ghoulGold * level + Return.RandomInt(Balance.ghoulGold/2, Balance.ghoulGold+ Balance.ghoulGold/2);
        strength = Balance.ghoulStrength + Balance.ghoulStrength * level*2/3;
        agility = Balance.ghoulAgility + Balance.ghoulAgility * level/2;
        stamina = Balance.ghoulStamina + Balance.ghoulStamina * level / 2; 
        defence = 2 * agility + agility - 1;
        damage = strength;
        hit = 65 + agility * 4;
        crit = agility * 4;
        health = maxHealth = 5 * stamina;
        mitigation = level;
        dropRate = 30;
    }

    
    public override void Attack2(Player target)
    {        
        if (AttemptToHit(target, 0))
        {
            if (target.PersonalShield)
            {
                target.Energy = (target.Energy - damage / 2 <= 0) ? 0 : target.Energy - damage / 2;
                Combat.AddCombatText(Color.MONSTER + name + Color.RESET + $" tries to " + Color.DAMAGE + "bite" + Color.RESET + " you but cannot break through your " + Color.SHIELD + "shield");
            }
            else
            {
                target.TakeDamage(Return.MitigatedDamage(damage, target.Mitigation), this);
                AddHealth(6);
                Combat.AddCombatText(Color.MONSTER + name + Color.RESET + $" bites you for {Color.DAMAGE + Return.MitigatedDamage(damage, target.Mitigation) + Color.RESET} damage, " + Color.HEALTH + "healing " + Color.RESET + "itself for " + Color.HEALTH + "6" + Color.RESET + " hitpoints");
            }            
        }
        else Miss(target);
    }

    public override void Declare2()
    {
        intention = "Chomp";
    }
}