﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SavageOrc : Monster
{
    Drop savageOrcClaw = new Drop("Savage Orc Claw", 1, 1);
    public SavageOrc()
    : base()
    {
        name = "Savage Orc";
        crit = 10;
        hit = 80;
        defence = 8;
        mitigation = 2;
        level = 2;
        health = maxHealth = 35;
        damage = 12;
        xp = 15;
        gold = 30;
        dropRate = 100;
    }
    public override void Attack2(Player target)
    {
        if (AttemptToHit(target, 0))
        {
            Console.WriteLine($"The orc charges at you, stunning and doing {damage*2} damage!");
            target.Stun = 2;
            target.TakeDamage(damage);
        }
        else Miss(target);
    }
    public override void Declare2()
    {
        intention = "Charging";
    }
    public override Drop ChooseDrop()
    {
        return savageOrcClaw;
    }
}