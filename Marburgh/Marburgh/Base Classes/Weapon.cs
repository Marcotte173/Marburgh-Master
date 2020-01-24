using System;
using System.Collections.Generic;
using System.Text;

public class Weapon : Equipment
{
    protected int spellPower;
    protected int damage;
    protected int hit;
    protected int crit;
    protected int stun;
    protected bool splash;
    protected bool oneHand;
    protected string type;

    public Weapon()
    : base()
    {

    }

    public bool OneHand { get { return oneHand; } set { oneHand = value; } }
    public int Damage { get { return damage; } set { damage = value; } }
    public string Type { get { return type; } set { type = value; } }
    public int SpellPower { get { return spellPower; } set { spellPower = value; } }
    public int Hit { get { return hit; } set { hit = value; } }
    public int Crit { get { return crit; } set { crit = value; } }
    public int Stun { get { return stun; } set { stun = value; } }
    public bool Splash { get { return splash; } set { splash = value; } }
}