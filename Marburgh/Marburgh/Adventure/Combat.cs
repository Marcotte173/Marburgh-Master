using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Combat : Location
{
    Player p = Create.p;
    public static bool desecrated;
    public static int xpReward;
    public static int goldReward;
    
    internal static List<Monster> monsters = new List<Monster> {};
    public Combat()
    : base()
    {
        
    }

    public override void Menu()
    {
        while (monsters.Count > 0)
        {
            foreach (Monster m in monsters.ToList()) m.Declare();            
            p.AttackChoice();
            foreach (Monster m in monsters.ToList()) m.MakeAttack();
            Console.ReadKey(true);
        }
        UI.Keypress(new List<int> { 0, 0, 0, 0, 0 }, new List<string> {"You have defeated your enemies","",$"You find {goldReward} gold","",$"You gain {xpReward} experience"  });
        Create.p.Gold += goldReward;
        Create.p.XP += xpReward;
        xpReward = 0;
        goldReward = 0;
    }
}