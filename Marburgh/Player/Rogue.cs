using System;
using System.Collections.Generic;
using System.Text;

public class Rogue : Player
{

    public Rogue(int strength, int agility, int stamina, int intelligence)
    : base(strength, agility, stamina, intelligence)
    {
        damage = playerDamage = strength + agility;
        playerHit = 60 + agility * 4 + agility;
        playerCrit = agility * 4;
        playerDefence = 2 * agility;
        health = maxHealth = 12 + 4 * stamina;
        offHand = Dagger.list[0];
        mainHand = Dagger.list[1];
        armor = global::Armor.list[1];
        pClass = "Rogue";
        option3 = "Stun";
        option4 = "Backstab";
        run = 66;

        lvlHealth = new int[] { 0, 4, 4, 4, 5, 4, 4 };
        lvlDamage = new int[] { 0, 2, 2, 2, 4, 3, 3 };
        lvlEnergy = new int[] { 0, 1, 1, 1, 2, 1, 2 };
        lvlMitigation = new int[] { 0, 1, 0, 2, 2, 0, 1 };
        lvlHit = new int[] { 0, 5, 5, 3, 5, 4, 4 };
        lvlCrit = new int[] { 0, 2, 2, 1, 2, 0, 1 };
        lvlPlayerDefence = new int[] { 0, 3, 4, 3, 5, 4, 4 };
    }
    public override void Attack3(Creature target)
    {
        int stunDamage = damage + (mainHand.Damage + offHand.Damage) / 2;
        if (Return.HaveEnergy(1))
        {
            Combat.combatText.Add($"You deliver a sturdy blow! The " + Color.MONSTER + target.Name + Color.RESET + " takes " + Color.DAMAGE + Return.MitigatedDamage(stunDamage, target.Mitigation) + Color.RESET + " damage and is " + Color.STUNNED + "stunned" + Color.RESET + "!");
            target.TakeDamage(stunDamage);
            target.Stun = 2;
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
}