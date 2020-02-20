﻿using System;
using System.Collections.Generic;
using System.Text;

public class Warrior : Player
{
    
    public Warrior()
    : base()
    {
        health = maxHealth = 24;
        damage = 3;
        defence += 3;
        hit += 5;
        offHand = Shield.list[1];
        mainHand = Blunt.list[1];
        armor = Armor.list[1];
        pClass = "Warrior";
        option3 = "Rend";
        option4 = "Scream";
    }
    public override void Attack3(Creature target)
    {
        int rendDamage = damage + (mainHand.Damage + offHand.Damage) / 2;
        if (Return.HaveEnergy(1))
        {
            Console.WriteLine($"You deliver a savage blow! The {target.Name} takes {rendDamage} damage and is stunned!");
            target.TakeDamage(rendDamage);
            target.Bleed = 2;
            target.BleedDam = 2;
        }
        else
        {
            Console.WriteLine("You don't have enough Energy!");
            Console.ReadKey(true);
            AttackChoice();
        }
    }
    public override void Attack4(Creature target)
    {
        base.Attack4(target);
    }
    public override void Attack5(Creature target)
    {
        base.Attack5(target);
    }
    public override void Attack6(Creature target)
    {
        base.Attack6(target);
    }
}