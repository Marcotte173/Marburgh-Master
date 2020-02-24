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
    protected int tier;
    protected int level;
    protected string modifier;
    public Equipment() { }

    public string Name { get { return name; } set { name = value; } }
    public string Modifier { get { return modifier; } set { modifier = value; } }
    public int Price { get { return price; } set { price = value; } }
    public int Tier { get { return tier; } set { tier = value; } }
    public int Level { get { return level; } set { level = value; } }
    public int Defence { get { return defence; } set { defence = value; } }
    public int Mitigation { get { return mitigation; } set { mitigation = value; } }
    public int SpellPower { get { return spellPower; } set { spellPower = value; } }
    public int Hit { get { return hit; } set { hit = value; } }
    public int Crit { get { return crit; } set { crit = value; } }
    public int Stun { get { return stun; } set { stun = value; } }
    public int Damage { get { return damage; } set { damage = value; } }
}