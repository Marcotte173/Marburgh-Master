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
    protected int[] lvlSpellpower;
    protected int[] lvlHealth;
    protected int[] lvlDamage;
    protected int[] lvlEnergy;
    protected int[] lvlMitigation;
    protected int[] lvlHit;
    protected int[] lvlCrit;
    protected int[] lvlPlayerDefence;
    protected int playerSpellpower;
    protected int playerDefence; 
    protected int playerHealth; 
    protected int playerDamage; 
    protected int playerEnergy; 
    protected int playerMitigation;  
    protected int playerHit;  
    protected int playerCrit;
    protected int playerMaxHealth;
    protected int playerMaxEnergy;
    protected bool canExplore;
    protected bool canCraft;
    protected bool rescue;
    protected string option3;
    protected string option4;
    protected int run;
    protected List<Drop> drops = new List<Drop> { };

    internal void AttackChoice()
    {
        if (stun > 0)
        {
            CombatUI.Stunned();
            canAct = false;
            stun--;
            if (stun <= 0 && status.Contains("Stunned")) status.Remove("Stunned");
            Console.WriteLine(Colour.NAME + "You " + Colour.RESET + "are " + Colour.STUNNED + "stunned" + Colour.RESET + "!");
        }
        if (canAct)
        {
            CombatUI.Declare();
            if (bleed > 0 && !Status.Contains("Bleeding")) Status.Add(Colour.BLOOD + "Bleeding" + Colour.RESET);
            if (burning > 0 && !Status.Contains("Burning")) Status.Add(Colour.BLOOD + "Burning" + Colour.RESET);
            string choice = Return.Option();
            Monster target = null;
            while ( target == null)
            {
                target = CombatUI.Target();
            }
            CombatUI.Box();
            Write.Position(47, 22);
            Write.ColourText(Colour.ENERGY, "Press any key to continue");
            Write.Position(0,6);
            if (bleed > 0)
            {
                Console.WriteLine(Colour.NAME + "You " + Colour.BLOOD + "bleed " + Colour.RESET + "for " + Colour.DAMAGE + bleedDam + Colour.RESET + " damage!");
                TakeDamage(bleedDam);
                bleed--;
                if (bleed <= 0 && status.Contains("Bleeding")) status.Remove("Bleeding");
            }
            if (burning > 0)
            {
                Console.WriteLine(Colour.NAME + "You " + Colour.BURNING + "burn " + Colour.RESET + "for " + Colour.DAMAGE + burnDam + Colour.RESET + " damage!");
                TakeDamage(burnDam);
                burning--;
                if (burning <= 0 && status.Contains("Burning")) status.Remove("Burning");
            }            
            if (choice == "1") Attack1(target);
            else if (choice == "2") Attack2(target);
            else if (choice == "3" && CanAttack3) Attack3(target);
            else if (choice == "4" && CanAttack4) Attack4(target);
            else if (choice == "5" && CanAttack5) Attack5(target);
            else if (choice == "6" && CanAttack6) Attack6(target);
            else if (choice == "h")
            {
                DrinkPotion();
                Console.ReadKey(true);
                AttackChoice();
            }
            else if(choice == "c")
            {
                CharacterSheet.Display();
                AttackChoice();
            }
            else if (choice == "r")
            {
                if (Return.RandomInt(1, 101) <= run)
                {
                    Console.WriteLine("You have succesfully run away.... Coward");
                    Console.ReadKey(true);
                    Location.list[10].Go();
                }
                else Console.WriteLine("You try to get away but can't!");
            }
        }
    }

    public Player()
    : base()
    {
        xpNeeded = new int[] { 0, 25, 60, 100, 150, 220, 300, 390, 500, 650 };
        playerEnergy = playerMaxEnergy = 1;
        gold = 1000;
        potionSize = maxPotionSize = 10;
        playerCrit = 5;
        playerHit = 65;
        playerDefence = 5;
        playerMitigation = 1;
        level = 1;
        playerDamage = 3;
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
    public void TakeDamage(int damage, Monster hitMe)
    {
        health -= damage;
        health = (health < 0) ? 0 : health;
        if (health == 0)
        {
            Death(hitMe);
            Console.WriteLine("You have been " + Colour.BOSS + "killed" + Colour.RESET + " by the " + Colour.MONSTER + hitMe.Name + Colour.RESET + "!\n");
            Utilities.Keypress();
        }
    }

    public void Death(Monster hitMe)
    {
        Family.dead.Add(Family.alive[0]);
        Family.alive.RemoveAt(0);
        Family.cause.Add(hitMe.Name);
        Family.timeOfDeath[0, 0] = Time.day;
        Family.timeOfDeath[0, 1] = Time.week;
        Family.timeOfDeath[0, 2] = Time.month;
        Family.timeOfDeath[0, 3] = Time.year;
        if (Family.alive.Count == 0)
        {
            UI.Keypress(new List<int> { 1,0,0 }, new List<string>
            {
                Colour.NAME, "You are the last of the ", Family.lastName,"s",
                "",
                "Your bloodline ends here"
            });
            Utilities.Quit();
        }
        else
        {
            UI.Keypress(new List<int> { 0,0,0 }, new List<string>
            {
                 "YOU DIED!",
                 "",
                 "Hopefully one of your family members can carry on for you"
            });
            Time.DayChange(1);
            Create.Name();
        }
    }


    internal void DrinkPotion()
    {
        if (MaxHealth == Health) DontNeedHeal();
        else
        {
            if (PotionSize == 0) Console.WriteLine("Your " + Colour.HEALTH+ "potion"+Colour.RESET+" is empty!");
            else if ((MaxHealth - Health) > PotionSize)
            {
                AddHealth(PotionSize);
                PotionSize = 0;
            }
            else
            {
                PotionSize -= (MaxHealth - Health);
                AddHealth(MaxHealth - Health);
            }
        }
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
        Console.WriteLine($"You attack the " + Colour.MONSTER + target.Name + Colour.RESET+ " for "+ Colour.DAMAGE + Damage+Colour.RESET+" damage");
        target.TakeDamage(Damage);
    }
    public virtual void Attack2(Creature target)
    {

    }
    public virtual void Attack3(Creature target)
    {
        
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
        Console.WriteLine("You " + Colour.HEALTH + "heal " + Colour.RESET + "yourself for " + Colour.HEALTH+ heal + Colour.RESET +" hit points");
    }

    public override void DontNeedHeal()
    {
        Console.WriteLine("You don't need " + Colour.HEALTH + "healing" + Colour.RESET + "!");
    }

    public int[] LvlCrit { get { return lvlCrit; } set { lvlCrit = value; } }
    public string Option3 { get { return option3; } set { option3 = value; } }
    public string Option4 { get { return option4; } set { option4 = value; } }
    public int[] LvlSpellpower { get { return lvlSpellpower; } set { lvlSpellpower = value; } }
    public int[] LvlDamage { get { return lvlDamage; } set { lvlDamage = value; } }
    public bool CanExplore { get { return canExplore; } set { canExplore = value; } }
    public bool CanCraft { get { return canCraft; } set { canCraft = value; } }
    public bool Rescue { get { return rescue; } set { rescue = value; } }
    public int[] LvlDefence { get { return lvlPlayerDefence; } set { lvlPlayerDefence = value; } }
    public int[] LvlEnergy { get { return lvlEnergy; } set { lvlEnergy = value; } }
    public int[] LvlHealth { get { return lvlHealth; } set { lvlHealth = value; } }
    public int[] LvlHit { get { return lvlHit; } set { lvlHit = value; } }
    public int[] LvlMitigation { get { return lvlMitigation; } set { lvlMitigation = value; } }
    public List<Drop> Drops { get { return drops; } set { drops = value; } }
    public Armor Armor { get { return armor; } set { armor = value; } }
    public Weapon MainHand { get { return mainHand; } set { mainHand = value; } }
    public Weapon OffHand { get { return offHand; } set { offHand = value; } }
    public string PClass { get { return pClass; } set { pClass = value; } }
    public override int Damage { get { return playerDamage + MainHand.Damage + OffHand.Damage + Armor.Damage; } set { damage = value; } }
    public override int Hit { get { return playerHit + MainHand.Hit + OffHand.Hit + Armor.Hit; } set { hit = value; } }
    public override int Crit { get { return playerCrit + MainHand.Crit + OffHand.Crit + Armor.Crit; } set { crit = value; } }
    public int PlayerDefence { get { return playerDefence; } set { playerDefence = value; } }
    public int PlayerHealth { get { return playerHealth; } set { playerHealth = value; } }
    public int PlayerDamage { get { return playerDamage; } set { playerDamage = value; } }
    public int PlayerEnergy { get { return playerEnergy; } set { playerEnergy = value; } }
    public int PlayerMitigation { get { return playerMitigation; } set { playerMitigation = value; } }
    public int PlayerHit { get { return playerHit; } set { playerHit = value; } }
    public int PlayerCrit { get { return playerCrit; } set { playerCrit = value; } }
    public int PlayerSpellpower { get { return playerSpellpower; } set { playerSpellpower = value; } }
    public override int Defence { get { return playerDefence + Armor.Defence + MainHand.Defence + OffHand.Defence; } }
    public override int Mitigation { get { return playerMitigation + Armor.Mitigation + MainHand.Mitigation + OffHand.Mitigation; } set { mitigation = value; } }
    public int Spellpower { get { return spellpower + MainHand.SpellPower + OffHand.SpellPower + Armor.SpellPower; } set { spellpower = value; } }
    public override int MaxHealth { get { return playerMaxHealth; } set { maxHealth = value; } }
    public override int Health { get { return playerHealth; } set { health = value; } }
    public override int MaxEnergy { get { return playerMaxEnergy; } set { maxEnergy = value; } }
}