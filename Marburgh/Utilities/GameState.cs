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
    public static Location location;
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
        Create.p.TakeDamage(100, new Goblin(3,3,3));
    }

    public static void CraftCheat()
    {
        Create.p.AddDrop(AdventureItems.monsterEye.Copy());
        Create.p.AddDrop(AdventureItems.monsterTooth.Copy());
        Craft.Menu();
    }
}