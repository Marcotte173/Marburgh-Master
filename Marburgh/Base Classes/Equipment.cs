using System;
using System.Collections.Generic;
using System.Text;

public class Equipment
{
    protected int spellPower;
    protected int damage;
    protected int hit;
    protected int crit;
    protected int stun;
    protected string name;
    protected int defence;
    protected int mitigation;
    protected int price;
    protected int level;
    protected string type;
    protected bool upgraded;
    protected string modifier;
    protected bool splash;
    protected bool oneHand;
    protected int[] monsterEye = new int[] { 0, 1, 3, 5 };
    protected int[] monsterTooth = new int[] { 0, 1, 5, 3 };
    protected int[] effectBoost = new int[] { 0, 1, 1, 2, 2, 3 };
    public Equipment() { }

    public bool OneHand { get { return oneHand; } set { oneHand = value; } }
    public bool Splash { get { return splash; } set { splash = value; } }
    public string Name { get { return name; } set { name = value; } }
    public string Modifier { get { return modifier; } set { modifier = value; } }
    public int Price { get { return price; } set { price = value; } }
    public int[] MonsterEye { get { return monsterEye; } set { monsterEye = value; } }
    public int[] MonsterTooth { get { return monsterTooth; } set { monsterTooth = value; } }
    public int[] EffectBoost { get { return effectBoost; } set { effectBoost = value; } }
    public int Level { get { return level; } set { level = value; } }
    public bool Upgraded { get { return upgraded; } set { upgraded = value; } }
    public int Defence { get { return defence; } set { defence = value; } }
    public int Mitigation { get { return mitigation; } set { mitigation = value; } }
    public int SpellPower { get { return spellPower; } set { spellPower = value; } }
    public int Hit { get { return hit; } set { hit = value; } }
    public int Crit { get { return crit; } set { crit = value; } }
    public int Stun { get { return stun; } set { stun = value; } }
    public int Damage { get { return damage; } set { damage = value; } }
    public string Type { get { return type; } set { type = value; } }
    public virtual void Upgrade()
    {
        upgraded = true;
    }
    public Equipment Copy()
    {
        return (Equipment)MemberwiseClone();
    }
}