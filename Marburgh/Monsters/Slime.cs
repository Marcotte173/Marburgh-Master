using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Slime : Monster
{    
    public Slime(int strength, int agility, int stamina, int level)
    : base(strength, agility, stamina, level)
    {
        name = "Slime";
        type = "Slime";
        mitigation = 1;
        level = 1;
        xp = 6;
        gold = 22;
        dropRate = 25;
    }

    public Slime(int level)
    : base(level)
    {
        this.level = level;
        type = "Slime";
        name = "Slime";
        xp = Balance.slimeXp * level + Return.RandomInt(Balance.slimeXp / 2, Balance.slimeXp + Balance.slimeXp / 2);
        gold = Balance.slimeGold * level + Return.RandomInt(Balance.slimeGold / 2, Balance.slimeGold + Balance.slimeGold / 2);
        strength = Balance.slimeStrength + Balance.slimeStrength * level /2;
        agility = Balance.slimeAgility + Balance.slimeAgility * level / 2;
        stamina = Balance.slimeStamina + Balance.slimeStamina * level / 2;
        defence = agility + agility - 1;
        damage = strength ;
        hit = 65 + agility * 4;
        crit = agility * 4;
        health = maxHealth = 6 * stamina;
        mitigation = level*2;
        dropRate = 30;
    }

    public override void Attack2(Player target)
    {
        Combat.combatText.Add(Color.MONSTER + name + Color.RESET + "splits in two! Now there are TWO " + Color.MONSTER + "slimes" + Color.RESET + "!");
        MaxHealth = Health;
        Slime s = new Slime(2, 2, 3,1);
        s.Health = s.MaxHealth = MaxHealth;
        Create.p.combatMonsters.Add(s);
    }

    public override void Declare2()
    {
        intention = "Splitting";
    }
    public override Drop ChooseDrop()
    {
        if (Return.RandomInt(0, 4) == 0) return DropList.slime;
        else return DropList.monsterEye.Copy();
    }

    public override void Declare()
    {
        if (bleed > 0 && !Status.Contains("Bleeding")) Status.Add(Color.BLOOD + "Bleeding" + Color.RESET);
        if (stun > 0 && !Status.Contains("Stunned")) Status.Add(Color.STUNNED + "Stunned" + Color.RESET);
        if (health < maxHealth / 2 && Create.p.combatMonsters.Count < 3)
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