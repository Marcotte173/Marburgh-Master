using System;
using System.Collections.Generic;
using System.Text;

public class Rogue : Player
{
    
    public Rogue()
    : base()
    {
        health = maxHealth = 20;
        damage = 4;
        crit += 3;
        hit += 10;
        offHand = Sharp.list[0];
        mainHand = Sharp.list[1];
        armor = Armor.list[1];
        pClass = "Rogue";
        option3 = "Stun";
        option4 = "Backstab";
        run = 66;
    }
    public override void Attack3(Creature target)
    {
        int stunDamage = damage + (mainHand.Damage + offHand.Damage) / 2;
        if (Return.HaveEnergy(1))
        {            
            Console.WriteLine($"You deliver a sturdy blow! The "+Colour.MONSTER+target.Name +Colour.RESET+" takes "+Colour.DAMAGE + stunDamage + Colour.RESET +" damage and is "+Colour.STUNNED + "stunned"+Colour.RESET+"!");
            target.TakeDamage(stunDamage);
            target.Stun = 2;
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