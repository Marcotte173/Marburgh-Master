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
    public override void Attack2(Player target)
    {
        Combat.combatText.Add($"The " + Color.MONSTER + "slime " + Color.RESET + "splits in two! Now there are TWO " + Color.MONSTER + "slimes" + Color.RESET + "!");
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