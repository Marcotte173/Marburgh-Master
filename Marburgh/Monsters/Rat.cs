using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Rat : Monster
{
    bool frenzy;
    public Rat(int level)
    : base(level)
    {
        this.level = level;
        type = "Rat";
        name = "Rat";
        xp = Balance.ratXp * level + Return.RandomInt(Balance.ratXp / 2, Balance.ratXp + Balance.ratXp / 2);
        gold = Balance.ratGold * level + Return.RandomInt(Balance.ratGold / 2, Balance.ratGold + Balance.ratGold / 2);
        strength = Balance.ratStrength + Balance.ratStrength * level * 2 / 3;
        agility = Balance.ratAgility + Balance.ratAgility * level / 2;
        stamina = Balance.ratStamina + Balance.ratStamina * level / 2;
        defence = 3 * agility + agility - 1;
        damage = strength;
        hit = 65 + agility * 4;
        crit = agility * 4;
        health = maxHealth = 5 * stamina;
        mitigation = level;
        dropRate = 30;
    }

    public override void Declare()
    {
        action = 1;
        if (Create.p.Health < Create.p.MaxHealth/2)
        {            
            Frenzy();
        }
        else
        {
            intention = "Ready";
        }
    }

    private void Frenzy()
    {
        if (!frenzy)
        {
            intention = "Frenzy";
            frenzy = true;
            damage += 2;
            Combat.combatText.Add(Color.MONSTER + name + Color.RESET + " senses your are injured and enters a frenzy, squealing at you and brandishing its teeth.  +2" + Color.DAMAGE+" Damage"+ Color.RESET);
        }
    }
        
}