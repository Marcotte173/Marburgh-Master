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