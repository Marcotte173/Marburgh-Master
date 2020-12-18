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
    internal static bool phase3;

    //Testing And Cheating
    public static void Test()
    {
        Create.p = new Warrior(3, 3, 3, 3);
        Create.p.Name = "Travis Marcotte";
    }

    public static void Cheat()
    {
        Button.itemShopButton.active = true;
        Phase2B();
        Create.p.XP += 300;
        Create.p.Gold += 30000;
        Create.p.PlayerDamage = 300;
        Create.p.PlayerHit = 100;
        Create.p.Health = 300;
        Create.p.AddDrop(DropList.potionOfDeath);
    }

    internal static void TestCombat(List<Monster> monsters)
    {
        Create.p = new Warrior(100,10,100,10);
        Create.p.Name = "Travis Marcotte";
        Create.p.AddDrop(DropList.potionOfDeath);
        Button.cleaveButton.active = true;
        Button.rendButton.active = true;
        foreach(Monster m in monsters)
        {
            Dungeon.Summon(m.MonsterCopy());
        }
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
        Create.p.TakeDamage(100, Dungeon.goblin1);
    }

    public static void CraftCheat()
    {
        Create.p.AddDrop(DropList.monsterEye.Copy());
        Create.p.AddDrop(DropList.monsterTooth.Copy());
        Craft.Menu();
    }

    //Gamestates
    public static void Phase1B()
    {
        Shop.itemOffenceList.Clear();
        Shop.itemDefenceList.Clear();
        Shop.itemOffenceList.Add(Equipment.bluntList[0]);
        Shop.itemOffenceList.Add(Equipment.bluntList[2]);
        Shop.itemOffenceList.Add(Equipment.daggerList[2]);
        Shop.itemOffenceList.Add(Equipment.magicList[2]);
        Shop.itemOffenceList.Add(Equipment.swordList[2]);
        Shop.itemDefenceList.Add(Equipment.armorList[0]);
        Shop.itemDefenceList.Add(Equipment.armorList[2]);
        Shop.itemDefenceList.Add(Equipment.shieldList[2]);
        Button.levelMasterButton.active = true;
        Button.enhancementMachine.active = true;
        Button.dungeon1bButton.active = true;
        Button.townspeopleButton.active = false;        
        phase1b = true;
    }

    public static void Phase2A()
    {
        Button.bossWeapons.active = true;
        phase2a = true;
    }

    public static void Phase2B()
    {
        Button.bankButton.active = true;
        Button.weaponShopButton.active = true;
        Button.armorShopButton.active = true;
        Button.magicShopButton.active = true;
        Button.dungeon2Button.active = true;
        Button.dungeonForestButton.active = true;
        Button.localGossipButton.active = true;
        Button.gambleButton.active = true;
        phase2b = true;
    }

    //Things that change day to day
    public static void NewDay()
    {
        Button.bankJobButton.active = false;
        Shop.magicJob = false;
        Shop.weaponJob = false;
        Shop.armorJob = false;
        //Bartender
        int who = Return.RandomInt(0, 6);
        if (who == 0) currentBartender = bartender3;
        else if (who == 1 || who == 2) currentBartender = bartender2;
        else currentBartender = bartender1;
        //Available Potions
        int pot = (phase3) ? 3 : (phase2b || phase2a) ? 2 : 1;
        Shop.potionAvailableList.Clear();
        Shop.potionAvailableList.Add(null);
        for (int i = 0; i < pot; i++)
        {
            Shop.potionAvailableList.Add(Shop.potionList[Return.RandomInt(0, Shop.potionList.Count)]);
        }
        if (phase2b||phase3)
        {            
            //Bank Job
            int job = Return.RandomInt(1, 101);
            if (job < 30) Button.bankJobButton.active = true;
            //Shop Job
            int job2 = Return.RandomInt(1, 101);
            if (job2 < 36)
            {
                int job3 = Return.RandomInt(0, 3);
                if (job3 == 0) Shop.magicJob = true;
                else if (job3 == 1) Shop.weaponJob = true;
                else Shop.armorJob = true;
            }
            //Tavern Job
            int job4 = Return.RandomInt(1, 101);
            if (job4 < 35) Button.tavernJobButton.active = true;
        }        
    }
}