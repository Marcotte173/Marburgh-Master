﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Skeleton : Monster
{
    public Skeleton(int level)
    : base(level)
    {
        this.level = level;
        type = "Skeleton";
        name = "Skeleton";
        xp = Balance.skeletonXp * level + Return.RandomInt(Balance.skeletonXp / 2, Balance.skeletonXp + Balance.skeletonXp / 2);
        gold = Balance.skeletonGold * level + Return.RandomInt(Balance.skeletonGold / 2, Balance.skeletonGold + Balance.skeletonGold / 2);
        strength = Balance.skeletonStrength + Balance.skeletonStrength * level * 2 / 3;
        agility = Balance.skeletonAgility + Balance.skeletonAgility * level / 2;
        stamina = Balance.skeletonStamina + Balance.skeletonStamina * level / 2;
        defence = agility + agility - 1;
        damage = strength;
        hit = 65 + agility * 4;
        crit = agility * 4;
        health = maxHealth = 5 * stamina;
        mitigation = level * 3/2;
        dropRate = 45;
    }

    public override Drop ChooseDrop()
    {
        if (Return.RandomInt(0, 4) == 0) return DropList.bone;
        else
        {
            if (Return.RandomInt(0, 2) == 0) return DropList.monsterEye.Copy();
            else return DropList.monsterTooth.Copy();
        }
    }

    public override void Declare()
    {
        if (burning > 0 && !Status.Contains(Color.BURNING + "Burning" + Color.RESET)) Status.Add(Color.BURNING + "Burning" + Color.RESET);
        if (bleed > 0 && !Status.Contains(Color.BLOOD + "Bleeding" + Color.RESET)) Status.Add(Color.BLOOD + "Bleeding" + Color.RESET);
        if (stun > 0 && !Status.Contains(Color.STUNNED + "Stunned" + Color.RESET)) Status.Add(Color.STUNNED + "Stunned" + Color.RESET);
        action = 1;
        intention = "Ready";
    }
}