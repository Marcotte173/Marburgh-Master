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

    public override void Attack3()
    {
        base.Attack3();
    }
    public override void Attack4()
    {
        base.Attack4();
    }
    public override void Attack5()
    {
        base.Attack5();
    }
    public override void Attack6()
    {
        base.Attack6();
    }
}