using System;
using System.Collections.Generic;
using System.Text;

public class Mage : Player
{
    bool shielded;
    public Mage()
    : base()
    {
        Health = MaxHealth = 16;
        playerSpellpower = 1;
        Energy = MaxEnergy = 3;
        potionSize = maxPotionSize += 5;
        offHand = Magic.list[0];
        mainHand = Magic.list[1];
        armor = Armor.list[0];
        pClass = "Mage";
        CombatUI.option[1] = "Shield" ;
        option3 =  "Fire Blast";
        option4 =  "Magic Missiles";
        run = 60;                           //5          //10
        lvlSpellpower = new int[] { 0, 1, 2,      1, 3, 1, 2, 2, 3, 4, 4, 5, 10 };

        lvlHealth = new int[]     { 0, 3, 3,      3, 5, 4, 4, 4, 5, 7, 5, 5, 10 };
        lvlDamage = new int[]     { 0, 1, 2,      2, 3, 2, 2, 2, 3, 4, 3, 3, 5 };
        lvlEnergy = new int[]     { 0, 2, 2,      2, 4, 3, 3, 3, 3, 5, 4, 4, 4 };
        lvlMitigation = new int[] { 0, 0, 1,      0, 2, 0, 0, 2, 0, 2, 0, 1, 2 };
        lvlHit = new int[]        { 0, 3, 3,      3, 5, 4, 4, 4, 4, 5, 4, 4, 4 };
        lvlCrit = new int[]       { 0, 1, 0,      1, 2, 0, 1, 0, 1, 2, 0, 1, 0 };
        lvlPlayerDefence = new int[]    { 0, 3, 3,      3, 5, 4, 4, 4, 4, 5, 5, 5, 5 };
    }

    public override void Attack2(Creature target)
    {
        if (energy > 0 && shielded == false)
        {
            shielded = true;
            Status.Add(Colour.SHIELD + "Shielded" + Colour.RESET);
        }
        else if (shielded)
        {
            shielded = false;
            Status.Remove(Colour.SHIELD + "Shielded" + Colour.RESET);
        }
        AttackChoice();
    }

    public override void Attack3(Creature target)
    {
        int flameDamage = 2 + spellpower + mainHand.SpellPower + offHand.SpellPower;
        if (Return.HaveEnergy(1))
        {
            Console.WriteLine(Colour.BURNING + "Flames " + Colour.RESET + "burst out of your hands, burning the " + Colour.MONSTER + target.Name + Colour.RESET +" for " + Colour.DAMAGE + flameDamage + Colour.RESET +" damage and " + Colour.BURNING + "igniting " + Colour.RESET + "him!");
            target.TakeDamage(flameDamage);
            if (target.Burning > 0) target.BurnDam += 1;
            else target.BurnDam = 1;
            target.Burning = 3;
            energy--; 
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
                Status.Remove(Colour.SHIELD + "Shielded" + Colour.RESET);
                base.TakeDamage(damage, hitMe);
            }
        }
    }
}