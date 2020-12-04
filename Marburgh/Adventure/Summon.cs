using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Summon
{
    public static Goblin goblin = new Goblin(4, 2, 3);
    public static Slime slime = new Slime(4, 2, 4);
    public static Kobold kobald = new Kobold(4, 3, 3);
    public static Orc orc = new Orc(4, 3, 4);
    public static SavageOrc savageOrc = new SavageOrc(5, 4, 5);
    public static void Goblin()
    {
        Create.p.combatMonsters.Add(goblin.MonsterCopy());
    }
    public static void Slime()
    {
        Create.p.combatMonsters.Add(slime.MonsterCopy());
    }
    public static void Kobald()
    {
        Create.p.combatMonsters.Add(kobald.MonsterCopy());
    }
    public static void Orc()
    {
        Create.p.combatMonsters.Add(orc.MonsterCopy());
    }
    public static void SavageOrc()
    {
        Create.p.combatMonsters.Add(savageOrc.MonsterCopy());
    }
}