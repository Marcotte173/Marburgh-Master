using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Skeleton : Monster
{
    public Skeleton(int strength, int agility, int stamina, int level)
    : base(strength, agility, stamina, level)
    {
        name = "Skeleton";
        type = "Skeleton";
        mitigation = level;
        xp = 6;
        gold = 22;
        dropRate = 30;
        undead = true;
    }
    public override void Declare()
    {
        if (bleed > 0 && !Status.Contains("Bleeding")) Status.Add(Color.BLOOD + "Bleeding" + Color.RESET);
        if (stun > 0 && !Status.Contains("Stunned")) Status.Add(Color.STUNNED + "Stunned" + Color.RESET);
        action = 1;
        intention = "Ready";
    }
}