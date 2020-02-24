using System;
using System.Collections.Generic;
using System.Text;

public class Rogue : Player
{
    
    public Rogue()
    : base()
    {
        health = maxHealth = 20;
        playerDamage += 1;
        playerCrit += 3;
        playerHit += 10;
        offHand = Dagger.list[0];
        mainHand = Dagger.list[1];
        armor = Armor.list[1];
        pClass = "Rogue";
        option3 = "Stun";
        option4 = "Backstab";
        run = 66;

        lvlHealth = new int[]           { 0, 4, 4,                   4,   5,   4, 4, 4, 5,   5,  5, 5, 10 };
        lvlDamage = new int[]           { 0, 2, 2,                   2,   4,   3, 3, 3, 5,   5,  5, 5, 10 };
        lvlEnergy = new int[]           { 0, 1, 1,                   1,   2,   1, 2, 1, 2,   3,  1, 2, 1 };
        lvlMitigation = new int[]       { 0, 1, 0,                   2,   2,   0, 1, 0, 1,   2,  0, 1, 2 };
        lvlHit = new int[]              { 0, 5, 5,                   3,   5,   4, 4, 4, 4,   5,  4, 4, 4 };
        lvlCrit = new int[]             { 0, 2, 2,                   1,   2,   0, 1, 0, 1,   2,  0, 1, 0 };
        lvlPlayerDefence = new int[]    { 0, 3, 4,                   3,   5,   4, 4, 4, 4,   5,  5, 5, 5 };
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