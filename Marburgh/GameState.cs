using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Location{Town, Level, Shop, House, Craft, Bank, Other, Help, Tavern, Exploring, Combat  }
public class GameState
{
    public static string Villagers = "";    
    public static bool CanCraft;
    public static bool Dungeon2Key;
    public static bool SavageOrc;
    public static bool BossWeapon;
    public static bool Dungeon2Available;
    public static Location location;
}