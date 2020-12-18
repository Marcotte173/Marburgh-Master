using System;
using System.Collections.Generic;
using System.Text;

public class Rogue : Player
{

    public Rogue(int strength, int agility, int stamina, int intelligence)
    : base(strength, agility, stamina, intelligence)
    {
        strengthLvl = new int[]     { 0, 0, 1, 2, 2, 3 };
        agilityLvl = new int[]      { 0, 0, 2, 2, 2, 4 };
        staminaLvl = new int[]      { 0, 0, 1, 1, 2, 2 };
        intelligenceLvl = new int[] { 0, 0, 0, 1, 2, 1 };
        Update();
        offHand = Equipment.daggerList[0];
        mainHand = Equipment.daggerList[0];
        armor = global::Equipment.armorList[0];
        pClass = PlayerClass.Rogue;
        run = 66;
    }
    public override void Attack3(Creature target)
    {
        int backstabDamage = Damage*2;
        if (Return.HaveEnergy(1))
        {
            Combat.combatText.Add($"You deliver a devastating blow that bypasses armor. " + Color.MONSTER + target.Name + Color.RESET + " takes " + Color.DAMAGE + backstabDamage + Color.RESET + " damage!");
            target.TakeDamage(backstabDamage);
        }
        else
        {
            Console.WriteLine("You don't have enough Energy!");
            AttackChoice();
        }

    }
    public override void Attack4(Creature target)
    {
        int stunDamage = Damage / 2;
        if (Return.HaveEnergy(2))
        {
            Combat.combatText.Add($"You deliver a tricky blow. " + Color.MONSTER + target.Name + Color.RESET + " takes " + Color.DAMAGE + Return.MitigatedDamage(stunDamage, target.Mitigation) + Color.RESET + " damage and is " + Color.STUNNED + "stunned" + Color.RESET + "!");
            target.TakeDamage(stunDamage);
            target.Stun = 2;
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
        damage = playerDamage = TotalStrength + TotalAgility;
        playerHit = 60 + TotalAgility * 4 + TotalAgility;
        playerCrit = TotalAgility * 4;
        playerDefence = 2 * TotalAgility;
        health = maxHealth = 12 + 4 * TotalAgility;
        maxEnergy = energy = TotalIntelligence;
    }
    public override int Damage { get { return playerDamage + MainHand.Damage + OffHand.Damage + Armor.Damage; } }
}