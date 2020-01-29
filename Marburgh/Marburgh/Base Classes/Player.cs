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
    protected int lvlHealth;
    protected int lvlDamage;
    protected int lvlEnergy;
    protected int lvlMagic;
    protected int lvlMitigation;
    protected int lvlHit;
    protected int lvlCrit;
    protected int lvlDefence;
    protected bool canExplore;
    protected bool canCraft;

    internal void AttackChoice()
    {
        if (canAct)
        {
            CombatUI.Declare();
            int choice = Return.Int();
            if (choice > 0 && choice <= CombatUI.button.Count)
            {
                Monster target = null;
                while ( target == null)
                {
                    target = CombatUI.Target();
                }
                CombatUI.Box();
                Write.Position(47, 22);
                Write.ColourText(Colour.ENERGY, "Press any key to continue");
                Write.Position(0,6);
                if (choice == 1) Attack1(target);
                else if (choice == 2) Attack2(target);
                else if (choice == 3 && CanAttack3) Attack3(target);
                Console.WriteLine("");
            }
            else AttackChoice();
        }
    }

    public Player()
    : base()
    {
        xpNeeded = new int[] { 0, 25, 60, 100, 150, 220, 300, 390, 500, 650 };
        energy = maxEnergy = 3;
        gold = 1000;
        potionSize = maxPotionSize = 10;
        crit = 5;
        hit = 65;
        defence = 5;
        mitigation = 1;
        level = 1;
        lvlHealth = 3;
        lvlDamage = 1;
        lvlEnergy = 2;
        lvlMagic = 1;
        lvlMitigation = 2;
        lvlHit = 5;
        lvlCrit = 2;
        lvlDefence = 2;
        canExplore = true;
        canAct = true;
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
    public virtual void Refresh()
    {
        health = maxHealth;
        energy = maxEnergy;
        potionSize = maxPotionSize;
        canExplore = true;
    }
    public virtual void Attack1(Creature target)
    {
        Console.WriteLine($"You attack the {target.Name} for {Damage} damage");
        target.TakeDamage(Damage);
    }
    public virtual void Attack2(Creature target)
    {

    }
    public virtual void Attack3(Creature target)
    {
        energy--;
    }
    public virtual void Attack4(Creature target)
    {

    }
    public virtual void Attack5(Creature target)
    {

    }
    public virtual void Attack6(Creature target)
    {

    }

    public override void HealStatement(int heal)
    {
        Console.WriteLine("You heal yourself for " + heal + " hit points");
    }

    public override void DontNeedHeal()
    {
        Console.WriteLine("You don't need healing!");
    }

    public int LvlCrit { get { return lvlCrit; } set { lvlCrit = value; } }
    public int LvlDamage { get { return lvlDamage; } set { lvlDamage = value; } }
    public bool CanExplore { get { return canExplore; } set { canExplore = value; } }
    public bool CanCraft { get { return canCraft; } set { canCraft = value; } }
    public int LvlDefence { get { return lvlDefence; } set { lvlDefence = value; } }
    public int LvlEnergy { get { return lvlEnergy; } set { lvlEnergy = value; } }
    public int LvlHealth { get { return lvlHealth; } set { lvlHealth = value; } }
    public int LvlHit { get { return lvlHit; } set { lvlHit = value; } }
    public int LvlMagic { get { return lvlMagic; } set { lvlMagic = value; } }
    public int LvlMitigation { get { return lvlMitigation; } set { lvlMitigation = value; } }
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