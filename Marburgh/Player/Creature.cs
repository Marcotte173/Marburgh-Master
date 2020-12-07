using System;
using System.Collections.Generic;
using System.Text;

public class Creature
{
    public static Random rand = new Random();
    protected List<string> status = new List<string> { };

    protected int potionSize;
    protected int maxPotionSize;
    protected int strength;
    protected int agility;
    protected int intelligence;
    protected int stamina;
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
    protected int stun;
    protected int confused;
    protected int casting;
    protected int burning;
    protected int shield;
    protected int burnDam;
    protected int bleedDam;
    protected bool defending;
    protected bool attack3;
    protected bool attack4;
    protected bool attack5;
    protected bool attack6;

    public Creature(int strength, int agility, int stamina)
    {
        this.strength = strength;
        this.agility = agility;
        this.stamina = stamina;
    }

    public List<string> Status { get { return status; } set { status = value; } }
    public string Name { get { return name; } set { name = value; } }
    public virtual int MaxHealth { get { return maxHealth; } set { maxHealth = value; } }
    public virtual int Health { get { return health; } set { health = value; } }
    public virtual int MaxEnergy { get { return maxEnergy; } set { maxEnergy = value; } }
    public virtual int Energy { get { return energy; } set { energy = value; } }
    public int Gold { get { return gold; } set { gold = value; } }
    public virtual int Hit { get { return hit; } set { hit = value; } }
    public virtual int Damage { get { return damage; } set { damage = value; } }
    public virtual int Crit { get { return crit; } set { crit = value; } }
    public virtual int Defence { get { return defence; } set { defence = value; } }
    public virtual int Mitigation { get { return mitigation; } set { mitigation = value; } }
    public int Level { get { return level; } set { level = value; } }
    public int XP { get { return xp; } set { xp = value; } }
    public int Stun { get { return stun; } set { stun = value; } }
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
    public int Strength { get { return strength; } set { strength = value; } }
    public int Agility { get { return agility; } set { agility = value; } }
    public int Stamina { get { return stamina; } set { stamina = value; } }
    public int Intelilgence { get { return intelligence; } set { intelligence = value; } }
    public bool Defending { get { return defending; } set { defending = value; } }
    public bool CanAttack3 { get { return attack3; } set { attack3 = value; } }
    public bool CanAttack4 { get { return attack4; } set { attack4 = value; } }
    public bool CanAttack5 { get { return attack5; } set { attack5 = value; } }
    public bool CanAttack6 { get { return attack6; } set { attack6 = value; } }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        health = (health < 0) ? 0 : health;
        if (health == 0) Death();
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

    public virtual void Miss(Creature target)
    {
        Combat.combatText.Add("You miss the " + Color.MONSTER + target + Color.RESET + "!");
    }

    public virtual bool AttemptToHit(Creature target, int bonus)
    {
        return (Return.RandomInt(1, 101) < hit + bonus - target.defence);
    }
}