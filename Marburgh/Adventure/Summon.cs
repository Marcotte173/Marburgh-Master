using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Summon
{
    public static Goblin goblin = new Goblin();
    public static Slime  slime = new Slime();
    public static Kobold kobald = new Kobold();
    public static Orc orc = new Orc();
    public static SavageOrc savageOrc = new SavageOrc();
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