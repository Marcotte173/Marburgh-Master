using System;
using System.Collections.Generic;
using System.Linq;

public enum PlayerClass {Warrior,Rogue,Mage }

public class Player : Creature
{    
    /// <summary>
    /// Variables
    /// </summary> 
    
    //Player Equipment
    protected Equipment mainHand;
    protected Equipment offHand;
    protected Equipment armor;
    
    //How much Attributes go up when you level
    protected int[] strengthLvl;
    protected int[] agilityLvl;
    protected int[] staminaLvl;
    protected int[] intelligenceLvl;

    //Basic Player Info
    protected bool alive;
    public PlayerClass pClass;
    protected List<Drop> drops = new List<Drop> { };
    protected int spellpower;
    protected int reputation;
    protected int playerSpellpower;
    protected int playerDefence;
    protected int playerDamage;
    protected int playerMitigation;
    protected int playerHit;
    protected int playerCrit;
    protected bool canExplore;
    public bool forestCamp;
    protected int run;
    public int suspicion;

    //Tavern
    public bool flirted;
    public string[] drinkText = new string[] { null, "nice and warm", "a little fuzzy", "quite silly", "sick", "VERY SICK" };    

    //Temporary bonuses
    public int tempStrength;
    public int tempAgility;
    public int tempStamina;
    public int tempIntelligence;
    public int tempHit;
    public int tempCrit;
    public int tempDefence;
    public int tempMit;
    public int mitBonus;
    public int defBonus;
    public float tempXp = 0;
    public int tempDamage = 0;
    public int drinks = 0;

    //Combat
    public Monster lastHit;
    public bool tutorial;
    public bool nonLethal;
    public List<Drop> combatDropList = new List<Drop> { };
    public List<Monster> combatMonsters = new List<Monster> { };

    //Debug
    public bool showNumbers;

    public void ItemCheck()
    {
        bool potion = false;
        foreach (Drop d in Create.p.Drops) 
        {
            if (d.rare == 2)
            {
                potion = true;
                break;
            }
        }
        if (potion) Button.potionButton.active = true;
        else Button.potionButton.active = false;
    }

    internal void AttackChoice()
    {                
        CombatUI.AttackOptions();
        if (canAct)
        {                   
            string choice = Return.Option();
            Console.Clear();
            CombatUI.Box();
            Write.Position(0, 6);
            if (choice == "1") Attack1(GetTarget());
            else if (choice == "2") Attack2(null);
            else if (choice == "3" && (Button.fireBlastButton.active || Button.rendButton.active || Button.backstabButton.active)) Attack3(GetTarget());
            else if (choice == "4" && (Button.stunButton.active)) Attack4(GetTarget());
            else if (choice == "4" && (Button.cleaveButton.active)) Attack4(GetTarget());
            else if (choice == "4" && (Button.magicMissileButton.active)) Attack4(null);
            //else if (choice == "5" && CanAttack5) Attack5(GetTarget());
            //else if (choice == "x")
            //{
            //    foreach(Monster m in combatMonsters.ToList())
            //    {
            //        m.TakeDamage(1000000);
            //    }
            //}
            else if (choice == "6" && Button.potionButton.active) Items();
            else if (choice == "h")
            {
                DrinkPotion();
                AttackChoice();
            }
            else if (choice == "9")
            {
                CharacterSheet.Display();
                Console.Clear();
                CombatUI.Box();
                AttackChoice();
            }
            //else if (choice == "c")
            //{
            //    CombatToggle();
            //    AttackChoice();
            //}
            else if (choice == "0")
            {
                if (nonLethal)
                {
                    Combat.AddCombatText("You can't run away from combat in the " + Color.MONSTER + "Arena");
                }
                else
                {
                    if (Return.RandomInt(1, 101) <= run)
                    {
                        Console.Clear();
                        UI.Keypress(new List<int> { 0 }, new List<string> { "You succesfully run away... Coward" });
                        combatMonsters.Clear();
                        if (GameState.location == Location.Forest)
                        {
                            Town.Menu();
                        }
                        else
                        {
                            Explore.currentRoom = Explore.dungeon.layout[1];
                            Explore.Menu();
                        }
                    }
                    else Combat.AddCombatText("You try to get away but can't!");
                }
            }
            else AttackChoice();
        }
        else
        {
            Console.ReadKey(true);
        }
    }

    private void CombatToggle()
    {
        if (showNumbers) showNumbers = false;
        if (!showNumbers) showNumbers = true;
    }

    Creature GetTarget()
    {
        Monster target = CombatUI.Target();
        Write.Position(0, 6);
        return target;
    }

    public Player(int strength, int agility, int stamina, int intelligence)
    : base(strength, agility, stamina)
    {
        reputation = 50;
        this.intelligence = intelligence;
        alive = true;
        xpNeeded = new int[] { 0, 45, 100, 150, 250, 450, 800 };
        Energy = MaxEnergy = 1;
        gold = 0;
        potionSize = maxPotionSize = 15;
        playerMitigation = 1;
        level = 1;
        playerDamage = damage;
        playerHit = hit;
        playerCrit = crit;
        CanExplore = true;
        forestCamp = true;
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
        if(e.Type == EquipmentType.Armor)
        {
            Shop.itemToSell = armor;
            Shop.itemToSell2 = null;
            UnequipBody(armor);
            armor = e.Copy();            
        }   
        else if (e.Type == EquipmentType.Shield)
        {
            Shop.itemToSell = offHand;
            Shop.itemToSell2 = null;
            UnequipBody(offHand);
            offHand = e.Copy();            
        }
        else if (e.Type == EquipmentType.TwoHand)
        {
            Shop.itemToSell = mainHand;
            Shop.itemToSell2 = offHand;
            UnequipBody(mainHand);
            UnequipBody(offHand);
            mainHand = e.Copy();
            offHand = Sword.twoHanded;            
        }
        else
        {
            if(UI.Hand(e) == mainHand)
            {
                if(mainHand.Type == EquipmentType.TwoHand)
                {
                    Shop.itemToSell = mainHand;
                    Shop.itemToSell2 = null;
                    UnequipBody(mainHand);
                    UnequipBody(offHand);
                    mainHand = e.Copy();
                    
                }
                else
                {
                    Shop.itemToSell = mainHand;
                    Shop.itemToSell2 = null;
                    UnequipBody(mainHand);
                    mainHand = e.Copy();                    
                }
            }
            else
            {
                if (mainHand.Type == EquipmentType.TwoHand)
                {
                    Shop.itemToSell = mainHand;
                    Shop.itemToSell2 = null;
                    UnequipBody(mainHand);
                    UnequipBody(offHand);
                    offHand = e.Copy();                    
                }
                else
                {
                    Shop.itemToSell = offHand;
                    Shop.itemToSell2 = null;
                    UnequipBody(offHand);
                    offHand = e.Copy();                    
                }
            }
        }
        UI.Keypress(new List<int> { 1 }, new List<string>
        {
            Color.ITEM, "You equip the ",e.Name,""
        });
    }
    internal void UnequipItem(Equipment item)
    {
        if(item.Name == mainHand.Name) mainHand = Equipment.bluntList[0];
        else if (item.Name == offHand.Name) offHand = Equipment.bluntList[0];
        else if (item.Name == armor.Name) armor = global::Equipment.armorList[0];
    }
    internal void UnequipBody(Equipment body)
    {
        if (body == mainHand) mainHand = Equipment.bluntList[0];
        else if (body == offHand) offHand = Equipment.bluntList[0];
        else if (body == armor) armor = global::Equipment.armorList[0];
    }
    public virtual void TakeDamage(int damage, Monster hitMe)
    {
        health -= damage;
        health = (health < 0) ? 0 : health;
        lastHit = hitMe;
    }

    public virtual void Update()
    {

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
        if (exists == false) Drops.Add(d.Copy()); ;
    }

    public void RemoveDrop(Drop d,int amount)
    {
        foreach (Drop D in Drops.ToList())
        {
            if (D.name == d.name)
            {
                D.amount -= amount;
                if (D.amount <= 0) Drops.Remove(D);
            }
        }
    }

    public void Death(Monster hitMe)
    {
        if (nonLethal)
        {
            UI.Keypress(new List<int> { 1, 0, 0,0,2}, new List<string>
            {
                Color.MONSTER, "Turns out ", CombatArena.currentGladiator.Name," is tougher than they look",
                "",
                "Who knew?",
                "",
                Color.XP,Color.HEALTH,"You're not sure who, but someone drags you to your ","house"," to sleep away the ","bruises",""
            }) ;
            nonLethal = false;
            House.Sleep();
            House.Menu();
        }
        else
        {
            alive = false;
            Forest.progress = 0;
            Family.dead.Add(Family.alive[0]);
            Family.cause.Add(hitMe.Name);
            Family.timeOfDeath[0, 0] = Time.day;
            Family.timeOfDeath[0, 1] = Time.week;
            Family.timeOfDeath[0, 2] = Time.month;
            Family.timeOfDeath[0, 3] = Time.year;
            if (Family.dead.Count == 3)
            {
                UI.Keypress(new List<int> { 1, 0, 0 }, new List<string>
                {
                    Color.NAME, "You are the last of the ", Family.lastName+"","s",
                    "",
                    "Your bloodline ends here"
                });
                Utilities.Quit();
            }
            else
            {
                UI.Keypress(new List<int> { 1, 0, 0 }, new List<string>
                {
                     Color.BOSS ,"", "YOU DIED!","",
                     "",
                     "Hopefully one of your family members can carry on for you"
                });
                Time.DayChange(1);
                Create.ChooseSibling();
            }
        }        
    }

    internal void DrinkPotion()
    {
        if (MaxHealth == Health) DontNeedHeal();
        else
        {
            if (PotionSize == 0) Combat.AddCombatText("Your " + Color.HEALTH + "potion" + Color.RESET + " is empty!");
            else if ((MaxHealth - Health) > PotionSize)
            {
                int healthGain = PotionSize;
                PotionSize = 0;
                AddHealth(healthGain);
                
            }
            else
            {
                PotionSize -= (MaxHealth - Health);
                AddHealth(MaxHealth - Health);
            }
        }
        Combat.combatText.Clear();
    }

    public virtual void Refresh()
    {
        if (GameState.findJob.status != JobStatus.Complete) GameState.findJob.status = JobStatus.Available;
        if (GameState.protectJob.status != JobStatus.Complete) GameState.protectJob.status = JobStatus.Available;
        drinks = 0;
        health = MaxHealth;
        energy = MaxEnergy;
        flirted = false;
        potionSize = maxPotionSize;
        CanExplore = true;
        forestCamp = true;
        tempStrength = 0;
        tempAgility = 0;
        tempStamina = 0;
        tempXp = 0;
        tempDamage = 0;
        tempIntelligence = 0;
    }
    public virtual void Attack1(Creature target)
    {
        if (target != null)
        {
            if(mainHand.Name == "Fist" && offHand.Name == "Fist")
            {
                if (AttemptToHit(target, 0) == false) Miss(target);
                else
                {
                    Combat.AddCombatText($"You punch " + Color.MONSTER + target.Name + Color.RESET + " for " + Color.DAMAGE + Return.MitigatedDamage(DamageMain, target.Mitigation) + Color.RESET + " damage");
                    target.TakeDamage(Return.MitigatedDamage(DamageMain, target.Mitigation));
                }
            }            
            else
            {
                if (mainHand.Name != "Fist")
                {
                    if (AttemptToHit(target, 0) == false) Miss(target);
                    else
                    {
                        Combat.AddCombatText($"Your " + Color.ITEM + MainHand.Name + Color.RESET + " strikes " + Color.MONSTER + target.Name + Color.RESET + " for " + Color.DAMAGE + Return.MitigatedDamage(DamageMain, target.Mitigation) + Color.RESET + " damage");
                        target.TakeDamage(Return.MitigatedDamage(DamageMain, target.Mitigation));
                    }
                }
                if (offHand.Name != "Fist"&& mainHand.Type != EquipmentType.Shield && offHand.Type != EquipmentType.Shield && target.Health>0)
                {
                    if (AttemptToHit(target, 0) == false) Miss(target);
                    else
                    {
                        Combat.AddCombatText($"Your " + Color.ITEM + OffHand.Name + Color.RESET + " strikes " + Color.MONSTER + target.Name + Color.RESET + " for " + Color.DAMAGE + Return.MitigatedDamage(DamageOff, target.Mitigation) + Color.RESET + " damage");
                        target.TakeDamage(Return.MitigatedDamage(DamageOff, target.Mitigation));
                    }
                }
            }            
        }
        else
        {
            AttackChoice();
        }
    }
    public virtual void Attack2(Creature target)
    {
        mitBonus = level*2+1;
        defBonus = 25;
        Combat.AddCombatText("You focus on protecting yourself, increasing your " + Color.DEFENCE + "defence" + Color.RESET + " and" + Color.MITIGATION + " mitigation");
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
    public virtual void Items()
    {
        List<Drop> items = new List<Drop> { };
        foreach (Drop d in Create.p.drops) if (d.rare == 2) items.Add(d);
        CombatUI.Box();
        Write.Line(50, 10, "Please select an "+ Color.POTION + "Item"+ Color.RESET);
        Write.Line(46, 12, "Press [0] to return to combat");
        int width = 50;
        int height = 19;
        for (int i = 0; i < items.Count; i++)
        {
            Write.Line(width, height + i, $"[{i+1}] {Color.POTION+ items[i].name+ Color.RESET}");
        }
        int x = Return.Int();
        if (x > 0 && x <= items.Count)
        {
            Drop chosenItem = items[x - 1];
            CombatUI.Box();
            Write.Line(45, 19, "[" + Color.HEALTH + "Y" + Color.RESET + "]es         [" + Color.BOSS + "N" + Color.RESET + "]o");
            UIComponent.DisplayText(new List<int> { 1 }, new List<string>
            {
            Color.POTION, "Use the ", chosenItem.name,"?"
            });
            string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
            if (choice == "y") ItemUse(chosenItem);
        }
        else Items();
    }

    private void ItemUse(Drop chosenItem)
    {
        if (chosenItem.name == DropList.potionOfDeath.name)
        {
            RemoveDrop(DropList.potionOfDeath,1);
            Creature target = GetTarget();
            if (target.Undead)
            {
                Combat.AddCombatText($"The {Color.POTION + chosenItem.name + Color.RESET} splashes harmlessly at the feet of "+Color.MONSTER + target.Name + Color.RESET );
                if(target.Type == "Necromancer") Combat.AddCombatText(Color.SPEAK+"'You fool! I control Death!'");
                else Combat.AddCombatText($"You can't kill something that is already dead!");
            }
            else
            {
                Combat.AddCombatText($"You throw the potion at "+Color.MONSTER + target.Name + Color.RESET );
                Combat.AddCombatText($"It doesn't even have time to react as it's life force is instantly snuffed out");
                target.TakeDamage(100000);
            }            
        }
        else if (chosenItem.name == "Potion Of Fire")
        {
            RemoveDrop(DropList.potionOfFire, 1);
            Creature target = GetTarget();
            Combat.AddCombatText($"You throw the potion at " + Color.MONSTER + target.Name + Color.RESET);
            Combat.AddCombatText($"It screams as it starts " + Color.BURNING + "burning" + Color.RESET);
            target.BurnDam = 6;
            target.Burning = 3;
            AttackChoice();
        }
        else if (chosenItem.name == "Potion Of Learning")
        {
            Combat.AddCombatText($"You start to open the " + Color.POTION + "potion" + Color.RESET + " then think better of it, realizing it's unlikely to do anything useful here");
            AttackChoice();
        }
        else if (chosenItem.name == "Potion Of Life")
        {
            Combat.AddCombatText($"You start to open the " + Color.POTION + "potion" + Color.RESET + " then think better of it, realizing it's unlikely to do anything useful here");
            AttackChoice();
        }
        else if (chosenItem.name == "Potion Of Power")
        {
            Combat.AddCombatText($"You start to open the " + Color.POTION + "potion" + Color.RESET + " then think better of it, realizing it's unlikely to do anything useful here");
            AttackChoice();
        }
        else if (chosenItem.name == "Potion Of Prowess")
        {
            Combat.AddCombatText($"You start to open the " + Color.POTION + "potion" + Color.RESET + " then think better of it, realizing it's unlikely to do anything useful here");
            AttackChoice();
        }
        else if (chosenItem.name == "Potion Of Knowledge")
        {
            RemoveDrop(DropList.potionOfKnowledge, 1);
            Combat.AddCombatText($"You chug the " + Color.POTION + "potion" + Color.RESET + ". You feel " + Color.XP + "wiser" + Color.RESET + "...");
            tempXp += .25f;
            AttackChoice();
        }
        Combat.combatText.Clear();
    }

    public override void HealStatement(int heal)
    {
        Combat.AddCombatText("You " + Color.HEALTH + "heal " + Color.RESET + "yourself for " + Color.HEALTH + heal + Color.RESET + " hit points");
    }

    public override void DontNeedHeal()
    {
        Combat.AddCombatText("You don't need " + Color.HEALTH + "healing" + Color.RESET + "!");
    }

    public override bool AttemptToHit(Creature target, int bonus)
    {
        int attempt = Return.RandomInt(1, 101);
        if (showNumbers)
        {
            Combat.AddCombatText($"Your hit is {Hit + bonus} and your targets defense is {target.Defence}");
            Combat.AddCombatText($"You needed a {Hit + bonus - target.Defence}. You rolled {attempt}");
        }
        return (attempt < Hit + bonus - target.Defence);
    }


    public void RepAdd(int rep) 
    {
        reputation = (reputation + rep >= 100) ? 100 : (reputation + rep <= 0) ? 0 : reputation + rep;
    }
    public int Reputation { get { return reputation; } set { reputation = value; } }
    public string Rep => (reputation <=20)? "Hated" : (reputation<=40)?"Disliked":(Reputation <=60)?"Neutral":(reputation <=80)?"Liked":"Loved"; 
    public bool Alive { get { return alive; } set { alive = value; } }
    public bool CanExplore { get { return canExplore; } set { canExplore = value; } }    
    public int[] StrengthLvl { get { return strengthLvl; } set { strengthLvl = value; } }
    public int[] AgilityLvl { get { return agilityLvl; } set { agilityLvl = value; } }
    public int[] StaminaLvl { get { return staminaLvl; } set { staminaLvl = value; } }
    public int[] IntelligenceLvl { get { return intelligenceLvl; } set { intelligenceLvl = value; } }
    public List<Drop> Drops { get { return drops; } set { drops = value; } }
    public Equipment Armor { get { return armor; } set { armor = value; } }
    public Equipment MainHand { get { return mainHand; } set { mainHand = value; } }
    public Equipment OffHand { get { return offHand; } set { offHand = value; } }
    public PlayerClass PClass { get { return pClass; } set { pClass = value; } }    
    public override int Hit { get { return playerHit + MainHand.Hit/2 + OffHand.Hit/2 + Armor.Hit + tempHit; } }
    public override int Crit { get { return playerCrit + MainHand.Crit/2 + OffHand.Crit/2 + Armor.Crit + tempCrit; } }
    public int PlayerDefence { get { return playerDefence; } set { playerDefence = value; } }
    public int PlayerDamage { get { return playerDamage; } set { playerDamage = value; } }
    public int PlayerMitigation { get { return playerMitigation; } set { playerMitigation = value; } }
    public int PlayerHit { get { return playerHit; } set { playerHit = value; } }
    public int PlayerCrit { get { return playerCrit ; } set { playerCrit = value; } }
    public int PlayerSpellpower { get { return playerSpellpower; } set { playerSpellpower = value; } }
    public int TotalStrength { get { return strength + tempStrength; } }
    public int TotalStamina { get { return stamina + tempStamina; } }
    public int TotalAgility { get { return agility + tempAgility; } }
    public int TotalIntelligence { get { return intelligence + tempIntelligence; } }
    public override int Defence { get { return playerDefence + Armor.Defence + MainHand.Defence + OffHand.Defence + tempDefence+defBonus; } }
    public override int Mitigation { get { return playerMitigation + Armor.Mitigation + MainHand.Mitigation + OffHand.Mitigation + tempMit + mitBonus; } set { mitigation = value; } }
    public int Spellpower { get { return spellpower + MainHand.SpellPower + OffHand.SpellPower + Armor.SpellPower; } }
    public override int Health { get { return health; } set { health = value; } }
    public override int Energy { get { return energy; } set { energy = value; } }
    public override int DamageMain => playerDamage + MainHand.Damage + Armor.Damage + tempDamage;
    public override int DamageOff => playerDamage + OffHand.Damage * 2 / 3 + Armor.Damage / 2 + tempDamage;
    public override int DamageTH => playerDamage + MainHand.Damage + Armor.Damage + tempDamage*2;

}