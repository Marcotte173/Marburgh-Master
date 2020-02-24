﻿using System;
using System.Collections.Generic;
using System.Text;

public class Warrior : Player
{
    
    public Warrior()
    : base()
    {
        playerHealth = playerMaxHealth = 24;
        playerDefence += 3;
        playerHit += 5;
        offHand = Shield.list[1];
        mainHand = Blunt.list[1];
        armor = Armor.list[1];
        pClass = "Warrior";
        option3 = "Rend";
        option4 = "Scream";
        run = 45;

        lvlHealth = new int[]     { 0, 5, 5,          3,   4,   5, 6, 7, 8,   9,   10, 11, 12 };
        lvlDamage = new int[]     { 0, 1, 2,          3,   4,   5, 6, 7, 8,   9,   10, 11, 12 };
        lvlEnergy = new int[]     { 0, 1, 2,          3,   4,   5, 6, 7, 8,   9,   10, 11, 12 };
        lvlMitigation = new int[] { 0, 1, 1,          3,   4,   5, 6, 7, 8,   9,   10, 11, 12 };
        lvlHit = new int[]        { 0, 4, 4,          3,   4,   5, 6, 7, 8,   9,   10, 11, 12 };
        lvlCrit = new int[]       { 0, 1, 1,          3,   4,   5, 6, 7, 8,   9,   10, 11, 12 };
        lvlPlayerDefence = new int[]    { 0, 5, 5,          3,   4,   5, 6, 7, 8,   9,   10, 11, 12 };
    }
    public override void Attack3(Creature target)
    {
        int rendDamage = damage + (mainHand.Damage + offHand.Damage) / 2;
        if (Return.HaveEnergy(1))
        {
            Console.WriteLine($"You deliver a sturdy blow! The "+Colour.MONSTER+target.Name +Colour.RESET+" takes "+Colour.DAMAGE + rendDamage + Colour.RESET +" damage and starts to "+Colour.BLOOD + "bleed"+Colour.RESET+"!");
            target.TakeDamage(rendDamage);
            target.Bleed = 2;
            target.BleedDam = 3;
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