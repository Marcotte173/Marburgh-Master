using System;
using System.Collections.Generic;
using System.Text;

public class Player : Creature
{
    protected int spellpower;
    protected Weapon mainHand;
    protected Weapon offHand;
    protected Armor armor;
    protected string pClass;

    public Player()
    : base()
    {
        xpNeeded = new int[] { 0, 25, 60, 100, 150, 220, 300, 390, 500, 650 };
        energy = maxEnergy = 3;
        level = 0;
        gold = 100000;
        potionSize = maxPotionSize = 10;
        crit = 5;
        hit = 65;
        defence = 5;
        mitigation = 1;
        level = 1;
    }
    internal void Equip(Armor a) { armor = a; }
    internal void Equip(Weapon w, Weapon hand)
    {
        if (w.OneHand)
        {
            UI.Keypress(new List<int> { 1 }, new List<string>
            {
                Colour.ITEM, "You equip the ",w.Name,""
            });
            if (hand == MainHand) MainHand = w;
            else if (hand == OffHand) OffHand = w;
        }
        else
        {
            UI.Keypress(new List<int> { 1 }, new List<string>
            {
                Colour.ITEM, "You equip the ",w.Name,""
            });
            mainHand = w;
            offHand = Sharp.list[0];
        }
    }


    internal void DrinkPotion()
    {
        if (MaxHealth > Health)
        {
            AddHealth(MaxHealth - Health);
            PotionSize -= (MaxHealth - Health);
        }
        else DontNeedHeal();
    }

    public override void Attack1(Creature target)
    {
        Console.WriteLine($"You attack the {target.Name} for {Damage} damage");
        target.TakeDamage(Damage);
    }

    public override void HealStatement(int heal)
    {
        Console.WriteLine("You heal yourself for " + heal + " hit points");
    }

    public override void DontNeedHeal()
    {
        Console.WriteLine("You don't need healing!");
    }

    public Armor Armor { get { return armor; } set { armor = value; } }
    public Weapon MainHand { get { return mainHand; } set { mainHand = value; } }
    public Weapon OffHand { get { return offHand; } set { offHand = value; } }
    public string PClass { get { return pClass; } set { pClass = value; } }
    public override int Damage { get { return damage + MainHand.Damage + OffHand.Damage; } set { damage = value; } }
    public override int Hit { get { return hit + MainHand.Hit + OffHand.Hit; } set { hit = value; } }
    public override int Crit { get { return crit + MainHand.Crit + OffHand.Crit; } set { crit = value; } }
    public override int Defence { get { return defence + Armor.Defence; } set { defence = value; } }
    public override int Mitigation { get { return mitigation + Armor.Mitigation; } set { mitigation = value; } }
    public int Spellpower { get { return spellpower + MainHand.SpellPower + OffHand.SpellPower; } set { spellpower = value; } }
}