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
        mitigation = level;
        xp = 6;
        gold = 22;
        dropRate = 30;
    }
    public override void Declare()
    {
        action = 1;
        intention = "Ready";
    }
}