using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Slime : Monster
{    
    public Slime(int level)
    : base(level)
    {
        this.level = level;
        if (level < 4)
        {
            type = "Slime";
            name = "Slime";
        }
        else
        {
            if (Return.RandomInt(0, 2) == 0)
            {
                type = "Green Slime";
                name = "Green Slime";
            }
            else
            {
                type = "Red Slime";
                name = "Red Slime";
            }
        }        
        xp = Balance.slimeXp * level + Return.RandomInt(Balance.slimeXp / 2, Balance.slimeXp + Balance.slimeXp / 2);
        gold = Balance.slimeGold * level + Return.RandomInt(Balance.slimeGold / 2, Balance.slimeGold + Balance.slimeGold / 2);
        strength = Balance.slimeStrength + Balance.slimeStrength * level /2;
        agility = Balance.slimeAgility + Balance.slimeAgility * level / 2;
        stamina = Balance.slimeStamina + Balance.slimeStamina * level / 2;
        defence = agility + agility - 1;
        damage = strength ;
        hit = 65 + agility * 4;
        crit = agility * 4;
        health = maxHealth = 5 * stamina;
        mitigation = level*2;
        dropRate = 45;
    }

    public override void Attack2(Player target)
    {
        Combat.AddCombatText(Color.MONSTER + name + Color.RESET + " splits in two! Now there are TWO " + Color.MONSTER + "slimes" + Color.RESET + "!");
        MaxHealth = Health;
        Slime s = new Slime(level);
        s.Health = s.MaxHealth = MaxHealth;
        Dungeon.Summon(s);
    }

    public override void Attack3(Player target)
    {
        if(type == "Green Slime")
        {
            Combat.AddCombatText(Color.MONSTER + name + Color.HEALTH + " heals " + Color.RESET + "itself and gains "+ Color.HEALTH + 3* level+ Color.RESET + " health");
            AddHealth(3 * level);
        }
        else
        {
            if (AttemptToHit(target, 0))
            {
                int spellDamage = 3 + 2 * level;
                if (target.PersonalShield)
                {
                    target.Energy = (target.Energy - spellDamage / 2 <= 0) ? 0 : target.Energy - spellDamage / 2;
                    Combat.AddCombatText(Color.MONSTER + name + Color.RESET + $" spits " + Color.DAMAGE + "fire" + Color.RESET + " at you but it cannot break through your " + Color.SHIELD + "shield");
                }
                else
                {
                    if (target.Burning > 0) target.BurnDam += 2;
                    else target.BurnDam = spellDamage;
                    target.Burning = spellDamage;
                    target.TakeDamage(spellDamage, this);
                    Combat.AddCombatText(Color.MONSTER + name + Color.RESET + " spits" + Color.BURNING + " fire " + Color.RESET + "at you, causing " + Color.DAMAGE + spellDamage + Color.RESET + " damage, and " + Color.BURNING + "igniting " + Color.RESET + "you!");
                }
            }
            else Miss(target);
        }
        
    }

    public override void MakeAttack()
    {
        if (action == 0) Attack2(Create.p);
        else if (action == 1) Attack3(Create.p);
        else if (action == 2) Attack1(Create.p);
    }

    public override void Declare2()
    {
        intention = "Splitting";
    }
    public override void Declare3()
    {
        intention = (type == "Green Slime") ? "Healing" : "Spitting";
    }
    public override Drop ChooseDrop()
    {
        if (Return.RandomInt(0, 4) == 0) return DropList.slime;
        else return DropList.monsterEye.Copy();
    }

    public override void Declare()
    {
        if (burning > 0 && !Status.Contains(Color.BURNING + "Burning" + Color.RESET)) Status.Add(Color.BURNING + "Burning" + Color.RESET);
        if (bleed > 0 && !Status.Contains(Color.BLOOD + "Bleeding" + Color.RESET)) Status.Add(Color.BLOOD + "Bleeding" + Color.RESET);
        if (stun > 0 && !Status.Contains(Color.STUNNED + "Stunned" + Color.RESET)) Status.Add(Color.STUNNED + "Stunned" + Color.RESET);
        if (health < maxHealth / 2 && Create.p.combatMonsters.Count < 3)
        {
            action = 0;
            Declare2();
        }
        else
        {
            action = Return.RandomInt(1, 4);
            if (action == 1 && (type == "Red Slime" || (type == "Green Slime" && health < maxHealth)))
            {
                action = 1;
                Declare3();
            }
            else
            {
                action = 2;
                intention = "Ready";
            }
        }
    }
}