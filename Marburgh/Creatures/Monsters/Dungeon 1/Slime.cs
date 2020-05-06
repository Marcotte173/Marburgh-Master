using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Slime : Monster
{
    Drop slime = new Drop("Slime", 1, 1);
    public Slime()
     : base()
    {
        name = "Slime";
        crit = 5;
        hit = 70;
        defence = 5;
        mitigation = 1;
        level = 1;
        health = maxHealth = 14;
        damage = 5;
        xp = 6;
        gold = 13;
        dropRate = 25;
    }
    public override void Attack2(Player target)
    {
        Console.WriteLine($"The slime splits in two! Now there are TWO slimes!");
        MaxHealth = Health;
        Slime s = new Slime();
        s.Health = s.MaxHealth = MaxHealth;
        Create.p.combatMonsters.Add(s);
    }

    public override void Declare2()
    {
        intention = "Splitting";
    }
    public override Drop ChooseDrop()
    {
        if (Return.RandomInt(0, 4) == 0) return slime;
        else return monsterEye;
    }

    public override void Declare()
    {
        if (bleed > 0 && !Status.Contains("Bleeding")) Status.Add(Colour.BLOOD + "Bleeding" + Colour.RESET);
        if (stun > 0 && !Status.Contains("Stunned")) Status.Add(Colour.STUNNED + "Stunned" + Colour.RESET);
        if (health < maxHealth/2 && Create.p.combatMonsters.Count<3)
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