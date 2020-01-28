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