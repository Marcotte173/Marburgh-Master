﻿using System;
using System.Collections.Generic;
using System.Text;

public class Warrior : Player
{

    public Warrior()
    : base()
    {
        strength = 3;
        agility = 2;
        stamina = 3;
        intelligence = 2;

        strengthLvl = new int[]     { 0, 0, 2, 2, 2, 3,3,3,3 };
        agilityLvl = new int[]      { 0, 0, 1, 2, 2, 2,3,3,2 };
        staminaLvl = new int[]      { 0, 0, 2, 2, 2, 4,3,3,4 };
        intelligenceLvl = new int[] { 0, 0, 1, 1, 2, 1,1,2,2 };
        Update();
        offHand = Equipment.shieldList[0];
        mainHand = Equipment.bluntList[0];
        armor = global::Equipment.armorList[0];
        pClass = PlayerClass.Warrior;
        run = 45;
    }
    public override void Attack3(Creature target)
    {
        int rendDamage = DamageMain / 2;
        if (Return.HaveEnergy(1))
        {
            Combat.AddCombatText($"You deliver a sturdy blow! "+Color.MONSTER + target.Name + Color.RESET + " takes " + Color.DAMAGE + Return.MitigatedDamage(rendDamage, target.Mitigation) + Color.RESET + " damage and starts to " + Color.BLOOD + "bleed" + Color.RESET + "!");
            target.TakeDamage(rendDamage);
            target.Bleed = 1+level/2;
            target.BleedDam = 4 + (level+1)/2;
            Energy -= 1;
        }
        else
        {
            Console.WriteLine("You don't have enough Energy!");
            AttackChoice();
        }
    }
    public override void Attack4(Creature target)
    {
        int cleaveDam = DamageMain * 2 / 3;
        if (Return.HaveEnergy(2))
        {
            List<Creature> possible = new List<Creature> { };
            foreach (Creature c in Create.p.combatMonsters) possible.Add(c);
            possible.Remove(target);
            Combat.AddCombatText($"You slam " + Color.MONSTER + target.Name + Color.RESET + " for " + Color.DAMAGE + Return.MitigatedDamage(DamageMain, target.Mitigation) + Color.RESET + " damage");
            Creature monster = possible[Return.RandomInt(0, possible.Count)];
            Combat.AddCombatText($"Additionally, you also hit " + Color.MONSTER + monster.Name + Color.RESET + " for " + Color.DAMAGE + Return.MitigatedDamage(cleaveDam, target.Mitigation) + Color.RESET + " damage");
            target.TakeDamage(Return.MitigatedDamage(DamageMain, target.Mitigation));
            monster.TakeDamage(Return.MitigatedDamage(cleaveDam, target.Mitigation));
            Energy -= 2;
        }
        else
        {
            Console.WriteLine("You don't have enough Energy!");
            AttackChoice();
        }
    }
    public override void Attack5(Creature target)
    {
        base.Attack5(target);
    }

    public override void Update()
    {
        damage = playerDamage = TotalStrength *  2;
        playerHit = 75 + TotalAgility * 3 + TotalIntelligence / 2;
        playerCrit = TotalAgility * 3;
        health = maxHealth = 12 + 6 * TotalStamina;
        playerDefence = 3 * TotalAgility + TotalAgility-1;
        maxEnergy = energy = TotalIntelligence;
    }
}