using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Bear : Monster
{
    int stunAttempts;
    int lowerHit;
    public Bear(int level)
    : base(level)
    {
        lowerHit = 0;
        this.level = level;
        type = "Bear";
        name = "Bear";
        xp = Balance.bearXp * level + Return.RandomInt(Balance.bearXp / 2, Balance.bearXp + Balance.bearXp / 2);
        gold = Balance.bearGold * level + Return.RandomInt(Balance.bearGold / 2, Balance.bearGold + Balance.bearGold / 2);
        strength = Balance.bearStrength + Balance.bearStrength * level * 2 / 3;
        agility = Balance.bearAgility + Balance.bearAgility * level / 2;
        stamina = Balance.bearStamina + Balance.bearStamina * level / 2;
        defence = agility + agility - 1;
        damage = strength;
        hit = 65 + agility * 4;
        crit = agility * 4;
        health = maxHealth = 5 * stamina;
        mitigation = level * 3 / 2;
        dropRate = 30;
        stunAttempts = level;
    }
    public override void MakeAttack()
    {
        if (action == 0) Attack2(Create.p);
        else if (action == 2) Attack3(Create.p);
        else Attack1(Create.p);
    }

    public override void Attack2(Player target)
    {
        if (AttemptToHit(target, 5))
        {
            if (target.PersonalShield)
            {
                target.Energy = (target.Energy - damage / 2 <= 0) ? 0 : target.Energy - damage / 2;
                Combat.AddCombatText(Color.MONSTER + name + Color.RESET + $" smacks at you but cannot penetrate your " + Color.SHIELD + "shield");
            }
            else
            {
                target.Stun = level;
                target.TakeDamage(Return.MitigatedDamage(damage, target.Mitigation), this);
                Combat.AddCombatText(Color.MONSTER + name + Color.RESET + $"smacks you with a giant paw, " + Color.STUNNED + "stunning" + Color.RESET + $" you and doing {Color.DAMAGE + Return.MitigatedDamage(damage, target.Mitigation) + Color.RESET} damage!");
            }
        }
        else Miss(target);
    }

    public override void Attack3(Player target)
    {
        target.tempHit -= 10;
        Combat.AddCombatText(Color.MONSTER + name + Color.ABILITY + $" ROARS " + Color.RESET + ". You are so shaken your hit is lowered by"+ Color.HIT + " 10");
        lowerHit += 10;
    }

    public override void Declare2()
    {
        intention = "Charging";
    }
    public override void Declare3()
    {
        intention = "Roaring";
    }

    public override void Death()
    {
        Combat.AddCombatText($"You have killed " + Color.MONSTER + name + Color.RESET + "!");
        Create.p.combatMonsters.Remove(this);
        Combat.goldReward += gold;
        Combat.xpReward += xp;
        Create.p.tempHit += lowerHit;
        Drop();
    }
    public override Drop ChooseDrop()
    {
        if (Return.RandomInt(0, 4) == 0) return DropList.bearPaw;
        else return DropList.monsterEye.Copy();
    }

    public override void Declare()
    {
        action = Return.RandomInt(0, 8);
        if (burning > 0 && !Status.Contains(Color.BURNING + "Burning" + Color.RESET)) Status.Add(Color.BURNING + "Burning" + Color.RESET);
        if (bleed > 0 && !Status.Contains(Color.BLOOD + "Bleeding" + Color.RESET)) Status.Add(Color.BLOOD + "Bleeding" + Color.RESET);
        if (stun > 0 && !Status.Contains(Color.STUNNED + "Stunned" + Color.RESET)) Status.Add(Color.STUNNED + "Stunned" + Color.RESET);
        if ((action == 0 || action == 1 )&& stunAttempts > 0)
        {
            stunAttempts--;
            Declare2();
        }
        else if (action == 2)
        {
            Declare3();
        }
        else
        {
            action = 2;
            intention = "Ready";
        }
    }
}
