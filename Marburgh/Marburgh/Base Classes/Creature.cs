﻿using System;
using System.Collections.Generic;
using System.Text;

public class Creature
{
    public static Random rand = new Random();

    protected int potionSize;
    protected int maxPotionSize;
    protected string name;
    protected int damage;
    protected int maxHealth;
    protected int health;
    protected int maxEnergy;
    protected int energy;
    protected int gold;
    protected int hit;
    protected int crit;
    protected int defence;
    protected int mitigation;
    protected int level;
    protected int xp;
    protected int[] xpNeeded = new int[] { };
    protected bool canAct;
    protected int bleed;
    protected int confused;
    protected int casting;
    protected int burning;
    protected int shield;
    protected int burnDam;
    protected int bleedDam;
    protected bool defending;        

    public Creature() { }

    public string Name { get { return name; } set { name = value; } }
    public int MaxHealth { get { return maxHealth; } set { maxHealth = value; } }
    public int Health { get { return health; } set { health = value; } }    
    public int MaxEnergy { get { return maxEnergy; } set { maxEnergy = value; } }
    public int Energy { get { return energy; } set { energy = value; } }
    public int Gold { get { return gold; } set { gold = value; } }
    public virtual int Hit { get { return hit; } set { hit = value; } }
    public virtual int Damage { get { return damage; } set { damage = value; } }
    public virtual int Crit { get { return crit; } set { crit = value; } }
    public virtual int Defence { get { return defence; } set { defence = value; } }
    public virtual int Mitigation { get { return mitigation; } set { mitigation = value; } }
    public int Level { get { return level; } set { level = value; } }
    public int XP { get { return xp; } set { xp = value; } }
    public int[] XPNeeded { get { return xpNeeded; } set { xpNeeded = value; } }
    public bool CanAct { get { return canAct; } set { canAct = value; } }
    public int Bleed { get { return bleed; } set { bleed = value; } }
    public int Confused { get { return confused; } set { confused = value; } }
    public int Casting { get { return casting; } set { casting = value; } }
    public int Burning { get { return burning; } set { burning = value; } }
    public int PersonalShield { get { return shield; } set { shield = value; } }
    public int BurnDam { get { return burnDam; } set { burnDam = value; } }
    public int BleedDam { get { return bleedDam; } set { bleedDam = value; } }
    public int PotionSize { get { return potionSize; } set { potionSize = value; } }
    public int MaxPotionSize { get { return maxPotionSize; } set { maxPotionSize = value; } }
    public bool Defending { get { return defending; } set { defending = value; } }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        health = (health < 0) ? 0 : health;
        if (health == 0) ;
        Death();
    }

    public virtual void AddHealth(int heal)
    {
        if (health >= maxHealth)
        {
            DontNeedHeal();
        }
        else
        {
            health += heal;
            health = (health > maxHealth) ? maxHealth : health;
            HealStatement(heal);
        }
    }

    public virtual void DontNeedHeal() { }
    public virtual void HealStatement(int heal) { }
    public virtual void Death() { }

    public virtual void Attack1(Creature target)
    {

    }
    public virtual void Attack2()
    {

    }
    public virtual void Attack3()
    {

    }
    public virtual void Attack4()
    {

    }
    public virtual void Attack5()
    {

    }
    public virtual void Attack6()
    {

    }
    public virtual void Miss(Creature target)
    {
        Console.WriteLine("You miss the " + target + " !"); ;
    }
}