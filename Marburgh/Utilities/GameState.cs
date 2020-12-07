using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Location{Town, Level, Shop, House, Craft, Bank, Other, Help, Tavern, Exploring, Combat  }
public class GameState
{
    public static string villagersSaved = "";    
    public static bool canCraft;
    public static bool canCraftWeaponsFromBossDrops;
    public static bool tutorialDungeon_B_available;
    public static bool dungeon_2_available;
    public static bool dungeon_3_available;
    public static bool dungeon_4_available;
    public static bool dungeon_Secret_available;
    public static Location location;
    

    public static void Test()
    {
        Cheat();
        Explore.dungeon = AreaCreation.dungeon;
        Explore.monstersPerRoom = 2;
        Explore.rewardMod = 1;
        Explore.currentDungeon = AreaCreation.builtDungeon[1];
        Explore.Menu();
    }

    public static void Cheat()
    {
        Create.p.PlayerDamage = 300;
        Create.p.PlayerHit = 100;
        Create.p.Health = 300;
        Explore.monstersPerRoom = 0;
        tutorialDungeon_B_available = true;
    }

    public static void Death()
    {
        Create.p.TakeDamage(100, new Goblin());
    }

    public static void CraftCheat()
    {
        Create.p.AddDrop(AdventureItems.monsterEye.Copy());
        Create.p.AddDrop(AdventureItems.monsterTooth.Copy());
        Craft.Menu();
    }

    public static void Dungeon2()
    {
        Buttons.adventureButton.Add(Color.MONSTER + "3" + Color.RESET);
        Buttons.adventureList.Add("Savage Orc's Lair");
        GameState.dungeon_2_available = true;
    }
    public static void Dungeon3()
    {
        Buttons.adventureButton.Add(Color.MONSTER + "4" + Color.RESET);
        Buttons.adventureList.Add("Savage Orc's Lair");
        GameState.dungeon_3_available = true;
    }
    public static void Dungeon4()
    {
        Buttons.adventureButton.Add(Color.MONSTER + "5" + Color.RESET);
        Buttons.adventureList.Add("Savage Orc's Lair");
        GameState.dungeon_4_available = true;
    }

    public static void SecretDungeonShow()
    {
        Buttons.adventureButton.Add(Color.MONSTER + "6" + Color.RESET);
        Buttons.adventureList.Add("Secret Dungeon");
        GameState.dungeon_Secret_available = true;
    }

    public static void SecretDungeonHide()
    {
        Buttons.adventureButton.Remove(Color.MONSTER + "6" + Color.RESET);
        Buttons.adventureList.Add("Secret Dungeon");
        GameState.dungeon_Secret_available = false;
    }

    internal static void DungeonTutorialB()
    {
        Buttons.adventureButton.Add(Color.MONSTER + "2" + Color.RESET);
        Buttons.adventureList.Add("Savage Orc's Lair");
        GameState.tutorialDungeon_B_available = true;
    }
}