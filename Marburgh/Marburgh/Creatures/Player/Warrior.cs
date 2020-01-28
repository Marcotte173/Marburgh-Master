using System;
using System.Collections.Generic;
using System.Text;

public class Warrior : Player
{
    public Warrior()
    : base()
    {
        health = maxHealth = 24;
        damage = 3;
        defence += 3;
        hit += 5;
        offHand = Shield.list[1];
        mainHand = Blunt.list[1];
        armor = Armor.list[1];
        pClass = "Warrior";
    }
    public override void Attack3(Creature target)
    {
        base.Attack3(target);
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