using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Summon
{
    static Goblin goblin = new Goblin();
    static Slime  slime = new Slime();
    static Kobald kobald = new Kobald();
    static Orc orc = new Orc();
    public static void Goblin()
    {
        Combat.monsters.Add(goblin.MonsterCopy());
    }
    public static void Slime()
    {
        Combat.monsters.Add(slime.MonsterCopy());
    }
    public static void Kobald()
    {
        Combat.monsters.Add(kobald.MonsterCopy());
    }
    public static void Orc()
    {
        Combat.monsters.Add(orc.MonsterCopy());
    }

}