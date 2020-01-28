using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Combat : Location
{
    Player p = Create.p;
    internal static List<Monster> monsters = new List<Monster> {};
    public Combat()
    : base()
    {
        
    }

    public override void Menu()
    {
        while (monsters.Count > 0)
        {
            foreach (Monster m in monsters) m.Declare();
            CombatUI.Declare();
        }
    }
}