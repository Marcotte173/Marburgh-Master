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
}