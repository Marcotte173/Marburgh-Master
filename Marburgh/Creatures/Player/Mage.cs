﻿using System;
using System.Collections.Generic;
using System.Text;

public class Mage : Player
{
    bool shielded;
    public Mage()
    : base()
    {
        Health = MaxHealth = 70;
        playerSpellpower = 1;
        Energy = MaxEnergy = 3;
        potionSize = maxPotionSize += 5;
        offHand = Magic.list[0];
        mainHand = Magic.list[1];
        armor = ARMOR.list[0];
        pClass = "Mage";
        CombatUI.option[1] = "Shield" ;
        option3 =  "Fire Blast";
        option4 =  "Magic Missiles";
        run = 60;                           //5          //10
        lvlSpellpower = new int[] { 0, 1, 2,      1, 3, 1, 2, 2, 3, 4, 4, 5, 10 };

        lvlHealth = new int[]           { 0, 3, 3, 3, 5, 4, 4};
        lvlDamage = new int[]           { 0, 1, 2, 2, 3, 2, 2};
        lvlEnergy = new int[]           { 0, 2, 2, 2, 4, 3, 3};
        lvlMitigation = new int[]       { 0, 0, 1, 0, 2, 0, 0};
        lvlHit = new int[]              { 0, 3, 3, 3, 5, 4, 4};
        lvlCrit = new int[]             { 0, 1, 0, 1, 2, 0, 1};
        lvlPlayerDefence = new int[]    { 0, 3, 3, 3, 5, 4, 4};
    }

    public override void Attack2(Creature target)
    {
        if (energy > 0 && shielded == false)
        {
            shielded = true;
            Status.Add(Color.SHIELD + "Shielded" + Color.RESET);
        }
        else if (shielded)
        {
            shielded = false;
            Status.Remove(Color.SHIELD + "Shielded" + Color.RESET);
        }
        AttackChoice();
    }

    public override void Attack3(Creature target)
    {
        int flameDamage = 2 + spellpower + mainHand.SpellPower + offHand.SpellPower;
        if (Return.HaveEnergy(1))
        {
            Combat.combatText.Add(Color.BURNING + "Flames " + Color.RESET + "burst out of your hands, burning the " + Color.MONSTER + target.Name + Color.RESET +" for " + Color.DAMAGE + flameDamage + Color.RESET +" damage and " + Color.BURNING + "igniting " + Color.RESET + "him!");
            target.TakeDamage(flameDamage);
            if (target.Burning > 0) target.BurnDam += 1;
            else target.BurnDam = 1;
            target.Burning = 3;
            energy--; 
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

    public override void TakeDamage(int damage, Monster hitMe)
    {
        if (shielded == false)
        {
            base.TakeDamage(damage,hitMe);
        }
        else
        {
            Console.WriteLine($"Your shield absorbs {energy} damage!");
            if (energy >= damage) energy -= damage;
            else
            {
                damage -= energy;
                energy = 0;
                shielded = false;
                Status.Remove(Color.SHIELD + "Shielded" + Color.RESET);
                base.TakeDamage(damage, hitMe);
            }
        }
    }
}