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

}