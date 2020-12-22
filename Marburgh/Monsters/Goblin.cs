using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Goblin : Monster
{
    public Goblin(int level)
    : base(level)
    {
        this.level = level;
        type = "Goblin";
        name = "Goblin";
        xp = Balance.goblinXp * level + Return.RandomInt(Balance.goblinXp / 2, Balance.goblinXp + Balance.goblinXp / 2);
        gold = Balance.goblinGold * level + Return.RandomInt(Balance.goblinGold / 2, Balance.goblinGold + Balance.goblinGold / 2);
        strength = Balance.goblinStrength + Balance.goblinStrength * level /2;
        agility = Balance.goblinAgility + Balance.goblinAgility * level / 2;
        stamina = Balance.goblinStamina + Balance.goblinStamina * level / 2;
        defence = 2 * agility + agility - 1;
        damage = strength;
        hit = 65 + agility * 4;
        crit = agility * 4;
        mitigation = level;
        dropRate = 30;
        health = maxHealth = 5 * stamina;
    }
    public override void Attack2(Player target)
    {
        if (target.PersonalShield)
        {
            Combat.combatText.Add(Color.MONSTER + name + Color.RESET + $" tries to " + Color.DAMAGE + "rake" + Color.RESET + " you but cannot break through your " + Color.SHIELD + "shield");
            target.Energy = (target.Energy - damage / 2 <= 0) ? 0 : target.Energy - damage / 2;
            if (target.Energy == 0) target.Attack2(null);
        }
        else if (AttemptToHit(target, 0))
        {
            Combat.combatText.Add(Color.MONSTER + name + Color.RESET + $" rakes you for {Color.DAMAGE + Return.MitigatedDamage(damage, target.Mitigation) + Color.RESET} damage, causing " + Color.BLOOD + "bleeding" + Color.RESET);
            target.Bleed = 2;
            target.BleedDam = 3;
            target.TakeDamage(Return.MitigatedDamage(damage, target.Mitigation), this);
        }
        else Miss(target);
    }

    public override void Declare2()
    {
        intention = "Raking";
    }

}