using System;
using System.Collections.Generic;
using System.Text;

public class Mage : Player
{
    

    public Mage()
    : base()
    {
        health = maxHealth = 16;
        damage = 3;
        spellpower = 3;
        potionSize = maxPotionSize += 5;
        offHand = Magic.list[0];
        mainHand = Magic.list[1];
        armor = Armor.list[0];
        pClass = "Mage";
        CanAttack3 = true;
        CombatUI.option[1] = "Shield" ;
        option3 =  "Fire Blast";
        option4 =  "Magic Missiles";
    }

    public override void Attack2(Creature target)
    {
        base.Attack2(target);
    }

    public override void Attack3(Creature target)
    {
        int flameDamage = 2 + spellpower + mainHand.SpellPower + offHand.SpellPower;
        if (Return.HaveEnergy(1))
        {
            Console.WriteLine(Colour.BURNING + "Flames " + Colour.RESET + "burst out of your hands, burning the " + Colour.MONSTER + target.Name + Colour.RESET +" for " + Colour.DAMAGE + flameDamage + Colour.RESET +" damage and " + Colour.BURNING + "igniting " + Colour.RESET + "him!");
            target.TakeDamage(flameDamage);
            target.BurnDam = 2;
            target.Burning = 2;
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
}