using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Location{Town, Level, Shop, House, Craft, Bank, Graveyard, Help, Tavern, Dungeon, Combat, CombatArena, ExploreTown, Forest}
public class GameState
{
    public static Bartender bartender1 = new Bartender("bartender");
    public static Bartender bartender2 = new Bartender("bartender");
    public static Bartender bartender3 = new Bartender("bartender");
    public static Bartender currentBartender;
    public static string villagersSaved = "";    
    public static Location location;
    internal static bool firstBossDead;
    internal static bool phase1b;
    internal static bool phase2a;
    internal static bool phase2b;
    internal static bool demo;
    internal static Job currentJob;
    internal static Job findJob = new Find(JobLocation.ArmorShop);
    internal static Job protectJob = new Protect(JobLocation.Bank);

    //Testing And Cheating
    public static void Test()
    {
        Create.p = new Warrior(3, 3, 3, 3);
        Create.p.Name = "Travis Marcotte";
    }

    public static void Cheat()
    {
        Phase1B();
        Phase2B();
        Create.p.Intelilgence = 1000;
        Create.p.XP += 900;
        Create.p.Gold += 30000;
        Create.p.PlayerDamage = 30000;
        Create.p.PlayerHit = 150;
        Create.p.Health = 3000;
        Button.levelMasterButton.active = true;
    }

    internal static void TestCombat()
    {
        Create.p = new Warrior(3,2,3,2);
        Button.shieldButton.active = true;
        Create.p.Name = "Travis Marcotte";
        Create.p.MainHand = Equipment.daggerList[3];
        Create.p.OffHand = Equipment.daggerList[0];
        Create.p.Armor = Equipment.armorList[2];
        Create.p.AddDrop(DropList.potionOfKnowledge);
        Create.p.AddDrop(DropList.potionOfFire);
        Create.p.AddDrop(DropList.potionOfPower);
        Create.p.AddDrop(DropList.potionOfLife);
        Create.p.AddDrop(DropList.potionOfProwess);
        Create.p.AddDrop(DropList.potionOfLearning);
        Create.p.XP = 1500;
        Create.p.Level += 2;
        Dungeon.Summon(Dungeon.balanceList[0].MonsterCopy());
        Combat.Menu();
    }

    internal static void TestMansion()
    {
        Create.p = new Mage(3, 3, 3, 3);
        Explore.dungeon = Dungeon.MansionEntrance;
        Create.p.Name = "Travis Marcotte";
        Cheat();
        new MansionNecromancerBoss().Explore();
    }

    public static void Death()
    {
        Create.p.TakeDamage(100, new Goblin(1));
    }

    public static void CraftCheat()
    {
        Create.p = new Warrior(3, 3, 3, 3);
        Create.p.Name = "Travis Marcotte";
        Create.p.MainHand = Equipment.swordList[2];
        Create.p.OffHand = Equipment.swordList[1];
        Create.p.Armor = Equipment.armorList[0];
        Create.p.AddDrop(DropList.monsterEye);
        Create.p.AddDrop(DropList.monsterTooth);
        Create.p.AddDrop(DropList.monsterEye);
        Create.p.AddDrop(DropList.monsterTooth);
        Create.p.AddDrop(DropList.monsterEye);
        Create.p.AddDrop(DropList.monsterTooth);
        Create.p.AddDrop(DropList.monsterEye);
        Create.p.AddDrop(DropList.monsterTooth);
        Create.p.AddDrop(DropList.savageOrcFang);
        Create.p.AddDrop(DropList.slime);
        Create.p.AddDrop(DropList.slime);
        Button.bossWeapons.active = true;
        Button.enhancementMachine.active = true;
        Town.Menu();
    }

    //Gamestates
    public static void Phase1B()
    {        
        Shop.itemOffenceList.Add(Equipment.bluntList[3]);
        Shop.itemOffenceList.Add(Equipment.daggerList[3]);
        Shop.itemOffenceList.Add(Equipment.magicList[3]);
        Shop.itemOffenceList.Add(Equipment.swordList[3]);
        Shop.itemDefenceList.Add(Equipment.armorList[3]);
        Shop.itemDefenceList.Add(Equipment.shieldList[3]);
        Button.levelMasterButton.active = true;
        Button.enhancementMachine.active = true;
        Button.dungeon1bButton.active = true;
        Button.townspeopleButton.active = false;
        Button.chatUpBartenderButton.active = true;
        Button.localGossipButton.active = true;
        phase1b = true;
    }

    public static void Phase2A()
    {
        Button.bossWeapons.active = true;
        phase2a = true;
    }

    public static void Phase2B()
    {
        Button.gambleButton.active = true;
        Button.bankButton.active = true;
        Button.weaponShopButton.active = true;
        Button.armorShopButton.active = true;
        Button.magicShopButton.active = true;
        Button.dungeon2Button.active = true;
        Button.dungeonForestButton.active = true;
        Button.gambleButton.active = true;
        phase2b = true;
    }

    //Things that change day to day
    public static void NewDay()
    {
        Equipment.LISTS.Clear();
        Equipment.LISTS.Add(Equipment.swordList);
        Equipment.LISTS.Add(Equipment.daggerList);
        Equipment.LISTS.Add(Equipment.bluntList);
        Equipment.LISTS.Add(Equipment.shieldList);
        Equipment.LISTS.Add(Equipment.armorList);
        Equipment.LISTS.Add(Equipment.magicList);
        List<Equipment> tempO = new List<Equipment> { };
        List<Equipment> tempD = new List<Equipment> { };
        foreach (Equipment e in Shop.itemOffenceList) tempO.Add(e);
        foreach (Equipment e in Shop.itemDefenceList) tempD.Add(e);
        //Bartender
        int who = Return.RandomInt(0, 6);
        if (who == 0) currentBartender = bartender3;
        else if (who == 1 || who == 2) currentBartender = bartender2;
        else currentBartender = bartender1;
        //Available Potions
        int pot = (phase2b || phase2a) ? 2 : 1;
        Shop.potionAvailableList.Clear();
        Shop.potionAvailableList.Add(null);
        for (int i = 0; i < pot; i++)
        {
            Shop.potionAvailableList.Add(Shop.potionList[Return.RandomInt(0, Shop.potionList.Count)]);
        }
        //AvailableEquipment
        int offensive = (phase2b || phase2a) ? 7 : 5;
        int defensive = (phase2b || phase2a) ? 5 : 3;
        Shop.itemOffenceAvailableList.Clear();
        Shop.itemOffenceAvailableList.Add(Equipment.bluntList[0]);
        for (int i = 0; i < offensive; i++)
        {
            Equipment e = tempO[Return.RandomInt(1, tempO.Count)];
            Shop.itemOffenceAvailableList.Add(e);
            tempO.Remove(e);
        }
        Utilities.SortDamage(Shop.itemOffenceAvailableList);
        Shop.itemDefenceAvailableList.Clear();
        Shop.itemDefenceAvailableList.Add(Equipment.armorList[0]);
        for (int i = 0; i < defensive; i++)
        {
            
            Equipment e = tempD[Return.RandomInt(1, tempD.Count)];
            Shop.itemDefenceAvailableList.Add(e);
            tempD.Remove(e);
        }
        Utilities.SortDefence(Shop.itemDefenceAvailableList);
        //Jobs
        if (phase2b)
        {   
            int job = Return.RandomInt(1, 101);
            if (job < 36)
            {
                int job2 = Return.RandomInt(0, 6);
                if (job2 == 0)
                {
                    if (Create.p.Reputation > 80 && findJob.status!=JobStatus.Complete)
                    {
                        findJob.location = JobLocation.ArmorShop;
                        currentJob = findJob;
                    }
                    else
                    {
                        currentJob = new Job(JobLocation.ArmorShop, Return.RandomInt(0, 4));
                    }
                }
                else if (job2 == 1)
                {
                    if (Create.p.Reputation > 80 && findJob.status != JobStatus.Complete)
                    {
                        findJob.location = JobLocation.WeaponShop;
                        currentJob = findJob;
                    }
                    else
                    {
                        currentJob = new Job(JobLocation.WeaponShop, Return.RandomInt(0, 4));
                    }
                }
                else if (job2 == 2)
                {
                    if (Create.p.Reputation > 80 && findJob.status != JobStatus.Complete)
                    {
                        findJob.location = JobLocation.MagicShop;
                        currentJob = findJob;
                    }
                    else
                    {
                        currentJob = new Job(JobLocation.MagicShop, Return.RandomInt(0, 4));
                    }
                }
                else if (job2 == 4)
                {
                    if (Create.p.Reputation > 80 && findJob.status != JobStatus.Complete)
                    {
                        findJob.location = JobLocation.ItemShop;
                        currentJob = findJob;
                    }
                    else
                    {
                        currentJob = new Job(JobLocation.ItemShop, Return.RandomInt(0, 4));
                    }
                }
                else
                {
                    if (Create.p.Reputation > 80 && protectJob.status != JobStatus.Complete)
                    {
                        currentJob = protectJob;
                    }
                    else
                    {
                        currentJob = new Job(JobLocation.Bank,Return.RandomInt(0,4));
                    }
                }
            }
            else currentJob = null;
        }        
    }
}