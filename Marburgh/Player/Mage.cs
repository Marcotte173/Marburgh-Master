using System;
using System.Collections.Generic;
using System.Text;

public class Mage : Player
{
    public Mage(int strength, int agility, int stamina, int intelligence)
    : base(strength, agility, stamina, intelligence)
    {
        strengthLvl = new int[]     { 0, 0, 1, 2, 2, 2,2,2 };
        agilityLvl = new int[]      { 0, 0, 2, 2, 2, 2,3,2 };
        staminaLvl = new int[]      { 0, 0, 1, 2, 2, 3,2,3 };
        intelligenceLvl = new int[] { 0, 0, 2, 2, 3, 4, 3, 3 };
        Update();
        potionSize = maxPotionSize += 5;
        offHand = Equipment.magicList[0];
        mainHand = Equipment.magicList[0];
        armor = global::Equipment.armorList[0];
        pClass = PlayerClass.Mage;
        run = 60;      
    }

    public override void Attack2(Creature target)
    {
        if (energy > 0 && shield == false)
        {
            shield = true;
            Status.Add(Color.SHIELD + "Shielded" + Color.RESET);
        }
        else if (shield)
        {
            shield = false;
            Status.Remove(Color.SHIELD + "Shielded" + Color.RESET);
        }
        Combat.DisplayCombatText();
        AttackChoice();
    }

    public override void Attack3(Creature target)
    {
        int flameDamage = 2 + Spellpower;
        if (Return.HaveEnergy(2))
        {
            Combat.combatText.Add(Color.BURNING + "Flames " + Color.RESET + "burst out of your hands, burning "+Color.MONSTER + target.Name + Color.RESET + " for " + Color.DAMAGE + flameDamage + Color.RESET + " damage and " + Color.BURNING + "igniting " + Color.RESET + "him!");
            target.TakeDamage(flameDamage);
            if (target.Burning > 0) target.BurnDam += 1;
            else target.BurnDam = 1;
            target.Burning = 3;
            energy-=2;
        }
        else
        {
            Console.WriteLine("You don't have enough Energy!");
            AttackChoice();
        }
    }
    public override void Attack4(Creature target)
    {
        int bolts = (level > 5) ? 5 : 3;
        int missileDamage = (level + Spellpower)/2;
        if (Return.HaveEnergy(3))
        {
            energy -= 3;
            Combat.combatText.Add($"{Color.ENERGY + bolts+ Color.RESET} bolts of pure "+Color.ENERGY + "Arcane Energy " + Color.RESET + "burst out of your hands");
            for (int i = 0; i < bolts; i++)
            {
                Monster m = combatMonsters[Return.RandomInt(0,combatMonsters.Count)];
                Combat.combatText.Add("A "+Color.ENERGY+"bolt"+Color.RESET+$" strikes {Color.MONSTER +m.Name+Color.RESET} doing {Color.DAMAGE + missileDamage + Color.RESET} damage!");
                m.TakeDamage(missileDamage);
            }            
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
        damage = playerDamage = TotalStrength;
        playerHit = 75 + TotalAgility * 3 + TotalAgility/2;
        playerCrit = TotalAgility * 3;
        playerDefence = 2 * TotalAgility+1;
        health = maxHealth = 12 + 3 * TotalStamina;
        maxEnergy = energy = TotalIntelligence*2-1;
        spellpower = TotalIntelligence;
    }
}