using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Kobold : Monster
{
    public Kobold(int level)
    : base(level)
    {
        this.level = level;
        type = "Kobold";
        name = "Kobold";
        xp = Balance.kobaldXp * level + Return.RandomInt(Balance.kobaldXp / 2, Balance.kobaldXp + Balance.kobaldXp / 2);
        gold = Balance.kobaldGold * level + Return.RandomInt(Balance.kobaldGold / 2, Balance.kobaldGold + Balance.kobaldGold / 2);
        strength = Balance.kobaldStrength + Balance.kobaldStrength * level * 2 / 3;
        agility = Balance.kobaldAgility + Balance.kobaldAgility * level / 2;
        stamina = Balance.kobaldStamina + Balance.kobaldStamina * level / 2;
        defence = 2 * agility + agility - 1;
        damage = strength ;
        hit = 65 + agility * 4;
        crit = agility * 4;
        health = maxHealth = 5 * stamina;
        mitigation = level;
        dropRate = 30;
    }
    public override void Attack2(Player target)
    {
        if (target.PersonalShield)
        {
            Combat.combatText.Add(Color.MONSTER + name + Color.RESET + $" throws a " + Color.DAMAGE + "candle" + Color.RESET + " at you but it cannot break through your " + Color.SHIELD + "shield");
            target.Energy = (target.Energy - damage / 2 <= 0) ? 0 : target.Energy - damage / 2;
            if (target.Energy == 0) target.Attack2(null);
        }
        else if (AttemptToHit(target, 0))
        {
            Combat.combatText.Add(Color.MONSTER + name + Color.RESET + " throws a candle at you, causing " + Color.DAMAGE + "4" + Color.RESET + " damage, and " + Color.BURNING + "igniting " + Color.RESET + "you!");
            if (target.Burning > 0) target.BurnDam += 2;
            else target.BurnDam = 4;
            target.Burning = 4;
            target.TakeDamage(4, this);
        }
        else Miss(target);
    }

    public override void Declare2()
    {
        intention = "Throwing";
    }
}