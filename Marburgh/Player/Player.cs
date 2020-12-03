using System;
using System.Collections.Generic;
using System.Text;

public class Player : Creature
{
    protected bool alive;
    public List<Drop> combatDropList = new List<Drop> { };
    public List<Monster> combatMonsters = new List<Monster> { };
    protected int spellpower;
    protected Equipment  mainHand;
    protected Equipment  offHand;
    protected Equipment armor;
    protected string pClass;
    protected int tempDefence;
    protected int tempMit;
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
    protected int playerDamage;  
    protected int playerMitigation;  
    protected int playerHit;  
    protected int playerCrit;
    protected bool canExplore;
    protected string option3;
    protected string option4;
    protected int run;
    protected List<Drop> drops = new List<Drop> { };
    public static List<string> text = Combat.combatText;

    internal void AttackChoice()
    {
        tempMit = 0;
        tempDefence = 0;
        if (bleed > 0 && !Status.Contains(Color.BLOOD + "Bleeding" + Color.RESET)) Status.Add(Color.BLOOD + "Bleeding" + Color.RESET);
        if (burning > 0 && !Status.Contains(Color.BLOOD + "Burning" + Color.RESET)) Status.Add(Color.BLOOD + "Burning" + Color.RESET);
        if (bleed > 0)
        {
            text.Add(Color.NAME + "You " + Color.BLOOD + "bleed " + Color.RESET + "for " + Color.DAMAGE + bleedDam + Color.RESET + " damage!\n");
            TakeDamage(bleedDam);
            bleed--;
            if (bleed <= 0 && status.Contains(Color.BLOOD + "Bleeding" + Color.RESET)) status.Remove(Color.BLOOD + "Bleeding" + Color.RESET);
        }
        if (burning > 0)
        {
            text.Add(Color.NAME + "You " + Color.BURNING + "burn " + Color.RESET + "for " + Color.DAMAGE + burnDam + Color.RESET + " damage!\n");
            TakeDamage(burnDam);
            burning--;
            if (burning <= 0 && status.Contains(Color.BLOOD + "Burning" + Color.RESET)) status.Remove(Color.BLOOD + "Burning" + Color.RESET);
        }

        if (canAct)
        {
            string choice = Return.Option();
            Write.Position(0, 6);
            if (choice == "1") Attack1(GetTarget());
            else if (choice == "2") Attack2(null);
            else if (choice == "3" && CanAttack3) Attack3(GetTarget());
            else if (choice == "4" && CanAttack4) Attack4(GetTarget());
            else if (choice == "5" && CanAttack5) Attack5(GetTarget());
            else if (choice == "6" && CanAttack6) Attack6(GetTarget());
            else if (choice == "h")
            {
                DrinkPotion();
                AttackChoice();
            }
            else if (choice == "9")
            {
                CharacterSheet.Display();
                AttackChoice();
            }
            else if (choice == "0")
            {
                if (Return.RandomInt(1, 101) <= run)
                {
                    Console.Clear();
                    UI.Keypress(new List<int> { 0 }, new List<string> {"You succesfully run away... Coward" });
                    combatMonsters.Clear();
                    Utilities.ToTown();
                }
                else text.Add("You try to get away but can't!\n\n");
            }
            else AttackChoice();
        }
        else
        {
            Console.ReadKey();
        }
    }

    Creature GetTarget()
    {
        Monster target = null;
        while (target == null)
        {
            target = CombatUI.Target();
        }
        Write.Position(0, 6);
        return target;        
    }

    public Player()
    : base()
    {
        alive = true;
        xpNeeded = new int[] { 0, 45, 100, 150, 250, 450, 800};
        Energy = MaxEnergy = 1;
        gold = 200;
        potionSize = maxPotionSize = 15;
        playerCrit = 5;
        playerHit = 70;
        playerMitigation = 1;
        level = 1;
        playerDamage = 2;
        canExplore = true;
        canAct = true;
        xp = 0;
        attack3 = false;
        attack4 = false;
        attack5 = false;
        attack6 = false;
        combatDropList = new List<Drop> { };
        combatMonsters = new List<Monster> { };
    }    

    internal void Equip(Equipment e)
    {
        UI.Keypress(new List<int> { 1 }, new List<string>
            {
                Color.ITEM, "You equip the ",e.Name,""
            });
        armor = e.Copy();
    }
    internal void Equip(Equipment e, Equipment hand)
    {
        if (e.TwoHand)
        {
            UI.Keypress(new List<int> { 1 }, new List<string>
            {
                Color.ITEM, "You equip the ",e.Name,""
            });
            mainHand = e.Copy();
            offHand = Sword.twoHanded.Copy();
            offHand.Name = e.Name;
        }
        else
        {
            UI.Keypress(new List<int> { 1 }, new List<string>
            {
                Color.ITEM, "You equip the ",e.Name,""
            });
            if (hand == MainHand) MainHand = e.Copy();
            else if (hand == OffHand) OffHand = e.Copy();
        }
    }
    public virtual void TakeDamage(int damage, Monster hitMe)
    {
        health -= damage;
        health = (health < 0) ? 0 : health;
        if (health == 0)
        {
            Console.Clear();
            CombatUI.Box();
            int n = 6;
            for (int i = 0; i < Combat.combatText.Count; i++)
            {
                Write.Line(0, n + i, Combat.combatText[i]);
            }
            Console.WriteLine("\n\nYou have been " + Color.BOSS + "killed" + Color.RESET + " by the " + Color.MONSTER + hitMe.Name + Color.RESET + "!\n");
            Utilities.Keypress(40,22);
            Death(hitMe);
        }
    }

    public void AddDrop(Drop d)
    {
        bool exists = false;
        foreach (Drop D in Drops)
        {            
            if (D.name == d.name)
            {
                D.amount++;
                exists = true;
                break;
            }            
        }
        if (exists == false) Drops.Add(d);
    }

    public void Death(Monster hitMe)
    {
        alive = false;
        CombatUI.button = CombatUI.buttonBasic;
        CombatUI.option = CombatUI.optionBasic;
        Family.dead.Add(Family.alive[0]);
        Family.cause.Add(hitMe.Name);
        Family.timeOfDeath[0, 0] = Time.day;
        Family.timeOfDeath[0, 1] = Time.week;
        Family.timeOfDeath[0, 2] = Time.month;
        Family.timeOfDeath[0, 3] = Time.year;
        if (Family.dead.Count == 3)
        {
            UI.Keypress(new List<int> { 1,0,0 }, new List<string>
            {
                Color.NAME, "You are the last of the ", Family.lastName+"","s",
                "",
                "Your bloodline ends here"
            });
            Utilities.Quit();
        }
        else
        {
            UI.Keypress(new List<int> { 1,0,0 }, new List<string>
            {
                 Color.BOSS ,"", "YOU DIED!","",
                 "",
                 "Hopefully one of your family members can carry on for you"
            });
            Time.DayChange(1);
            Create.ChooseSibling();
        }
    }

    internal void DrinkPotion()
    {
        if (MaxHealth == Health) DontNeedHeal();
        else
        {
            if (PotionSize == 0) text.Add("Your " + Color.HEALTH+ "potion"+Color.RESET+" is empty!");
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
        Combat.DisplayCombatText();
    }

    public virtual void Refresh()
    {
        health = MaxHealth;
        energy = MaxEnergy;
        potionSize = maxPotionSize;
        canExplore = true;
    }
    public virtual void Attack1(Creature target)
    {
        if (AttemptToHit(target, 0) == false) Miss(target);
        else
        {
            text.Add($"You attack the " + Color.MONSTER + target.Name + Color.RESET + " for " + Color.DAMAGE + Damage + Color.RESET + " damage\n");
            target.TakeDamage(Damage);
        }
    }
    public virtual void Attack2(Creature target)
    {
        tempMit = 2;
        tempMit = 15;
        text.Add("You focus on protecting yourself, increasing your defence and mitigation");
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
        text.Add("You " + Color.HEALTH + "heal " + Color.RESET + "yourself for " + Color.HEALTH+ heal + Color.RESET +" hit points");
    }

    public override void DontNeedHeal()
    {
        text.Add("You don't need " + Color.HEALTH + "healing" + Color.RESET + "!");
    }

    public override bool AttemptToHit(Creature target, int bonus)
    {
        return (Return.RandomInt(1, 101) < Hit + bonus - target.Defence);
    }

    public int[] LvlCrit { get { return lvlCrit; } set { lvlCrit = value; } }
    public bool Alive { get { return alive; } set { alive = value; } }
    public string Option3 { get { return option3; } set { option3 = value; } }
    public string Option4 { get { return option4; } set { option4 = value; } }
    public int[] LvlSpellpower { get { return lvlSpellpower; } set { lvlSpellpower = value; } }
    public int[] LvlDamage { get { return lvlDamage; } set { lvlDamage = value; } }
    public bool CanExplore { get { return canExplore; } set { canExplore = value; } }
    public int[] LvlDefence { get { return lvlPlayerDefence; } set { lvlPlayerDefence = value; } }
    public int[] LvlEnergy { get { return lvlEnergy; } set { lvlEnergy = value; } }
    public int[] LvlHealth { get { return lvlHealth; } set { lvlHealth = value; } }
    public int[] LvlHit { get { return lvlHit; } set { lvlHit = value; } }
    public int[] LvlMitigation { get { return lvlMitigation; } set { lvlMitigation = value; } }
    public List<Drop> Drops { get { return drops; } set { drops = value; } }
    public Equipment Armour { get { return armor; } set { armor = value; } }
    public Equipment MainHand { get { return mainHand; } set { mainHand = value; } }
    public Equipment OffHand { get { return offHand; } set { offHand = value; } }
    public string PClass { get { return pClass; } set { pClass = value; } }
    public override int Damage { get { return playerDamage + MainHand.Damage + OffHand.Damage/3 + Armour.Damage; } }
    public override int Hit { get { return playerHit + MainHand.Hit + OffHand.Hit + Armour.Hit; } }
    public override int Crit { get { return playerCrit + MainHand.Crit + OffHand.Crit + Armour.Crit; }  }
    public int PlayerDefence { get { return playerDefence; } set { playerDefence = value; } }
    public int PlayerDamage { get { return playerDamage; } set { playerDamage = value; } }
    public int PlayerMitigation { get { return playerMitigation; } set { playerMitigation = value; } }
    public int PlayerHit { get { return playerHit; } set { playerHit = value; } }
    public int PlayerCrit { get { return playerCrit; } set { playerCrit = value; } }
    public int PlayerSpellpower { get { return playerSpellpower; } set { playerSpellpower = value; } }
    public override int Defence { get { return playerDefence + Armour.Defence + MainHand.Defence + OffHand.Defence + tempDefence; } }
    public override int Mitigation { get { return playerMitigation + Armour.Mitigation + MainHand.Mitigation + OffHand.Mitigation + tempMit; } set { mitigation = value; } }
    public int Spellpower { get { return spellpower + MainHand.SpellPower + OffHand.SpellPower + Armour.SpellPower; } }
    public override int Health { get { return health; } set { health = value; } }
    public override int Energy { get { return energy; } set { energy = value; } }
}