using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Rat : Monster
{
    bool frenzy;
    public Rat(int strength, int agility, int stamina, int level)
    : base(strength, agility, stamina, level)
    {
        name = "Rat";
        type = "Rat";
        mitigation = 1;
        xp = 6;
        gold = 22;
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
            damage += 1;
            Combat.combatText.Add(Color.MONSTER + name + Color.RESET + "senses your are injured and enters a frenzy, squealing at you and brandishing its teeth.  +1" + Color.DAMAGE+" Damage"+ Color.RESET);
        }
    }
        
}