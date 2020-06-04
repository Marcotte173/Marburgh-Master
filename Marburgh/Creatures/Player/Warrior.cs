﻿using System;
using System.Collections.Generic;
using System.Text;

public class Warrior : Player
{
    
    public Warrior()
    : base()
    {
        Health = MaxHealth = 85;
        playerDefence += 3;
        playerHit += 5;
        offHand = Shield.list[1];
        mainHand = Blunt.list[1];
        armor = ARMOR.list[1];
        pClass = "Warrior";
        option3 = "Rend";
        option4 = "Scream";
        run = 45;

        lvlHealth = new int[]           { 0, 5, 5, 3, 4, 5, 6 };
        lvlDamage = new int[]           { 0, 1, 2, 3, 4, 5, 6 };
        lvlEnergy = new int[]           { 0, 1, 2, 3, 4, 5, 6 };
        lvlMitigation = new int[]       { 0, 1, 1, 3, 4, 5, 6 };
        lvlHit = new int[]              { 0, 4, 4, 5, 4, 5, 5 };
        lvlCrit = new int[]             { 0, 1, 1, 3, 4, 5, 6 };
        lvlPlayerDefence = new int[]    { 0, 5, 5, 3, 4, 5, 6 };
    }
    public override void Attack3(Creature target)
    {
        int rendDamage = damage + (mainHand.Damage + offHand.Damage) / 2;
        if (Return.HaveEnergy(1))
        {
            Combat.combatText.Add($"You deliver a sturdy blow! The "+Color.MONSTER+target.Name +Color.RESET+" takes "+Color.DAMAGE + rendDamage + Color.RESET +" damage and starts to "+Color.BLOOD + "bleed"+Color.RESET+"!");
            target.TakeDamage(rendDamage);
            target.Bleed = 2;
            target.BleedDam = 3;
        }
        else
        {
            Console.WriteLine("You don't have enough Energy!");
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