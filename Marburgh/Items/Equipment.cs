using System;
using System.Collections.Generic;
using System.Text;

public enum EquipmentType {OneHand,TwoHand,Shield,Armor}
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
    protected EquipmentType type;
    protected bool upgraded;
    protected string modifier;
    protected bool splash;
    protected int monsterEye ;
    protected int monsterTooth ;

    internal static Sword[] swordList = new Sword[]
    {
        new Sword("Fist",0,0,0,false,0),

        new Sword("Short Sword",3,10,2,false,1),
        new Sword("Arming Sword",5,14,2,false,2),
        new Sword("Long Sword",7,17,3,false,3),
        new Sword("Katana",9,20,5,false,4),

        new Sword("Broad Sword",18,20,7,false,5),
        new Sword("Great Sword",46,24,8,false,6),
        new Sword("Claymore",58,30,10,false,7)
    };

    internal static Shield[] shieldList = new Shield[]
    {
        new Shield("Fist",0,0,0),

        new Shield("Buckler",0,10,1),
        new Shield("Round Shield",0,15,2),
        new Shield("Pavise",0,20,3),
        new Shield("Targ",0,25,4),

        new Shield("Heater Shield",0,25,5),
        new Shield("Kite Shield",0,30,6),
        new Shield("Teardrop Shield",0,40,7),
    };

    internal static Magic[] magicList = new Magic[]
    {
        new Magic("None",0,0,0,0,false,0),

        new Magic("Walking stick",3,3,5,2,true,1),
        new Magic("Staff",7,6,1,2,true,2),
        new Magic("Book",5,9,4,4,false,3),
        new Magic("Wand",7,12,6,6,false,4),

        new Magic("Orb",26,25,11,10,false,5),
        new Magic("Ring",32,34,14,13,false,6),
        new Magic("Source",40,45,16,16,false,7)
    };

    internal static Dagger[] daggerList = new Dagger[]
    {
        new Dagger("Fist",0,0,0,0),

        new Dagger("Butcher's Knife",3,2,5,1),
        new Dagger("Knife",5,2,8,2),
        new Dagger("Push Dagger",7,3,11,3),
        new Dagger("Stilleto",9,6,14,4),

        new Dagger("Dirk",17,7,20,5),
        new Dagger("Trench Knife",23,8,24,6),
        new Dagger("Baselard",29,20,30,7)
    };

    internal static Blunt[] bluntList = new Blunt[]
    {
        new Blunt("Fist",0,0,0,false,0),

        new Blunt("Club",3,6,3,false,1),
        new Blunt("Hammer",5,10,5,false,2),
        new Blunt("Shillelagh",7,14,8,false,3),
        new Blunt("Flail",9,15,10,false,4),

        new Blunt("Morning Star",18,5,5,false,5),
        new Blunt("War Hammer",45,8,8,false,6),
        new Blunt("Maul",60,8,8,false,7)
    };

    internal static Armor[] armorList = new Armor[]
    {
        new Armor("None",0,0,0),

        new Armor("Cloth",1,5,1),
        new Armor("Leather",2,6,2),
        new Armor("Hardened Leather",3,5,3),
        new Armor("Mail",3,6,4),

        new Armor("Coat Of Plates",5,4,5),
        new Armor("Mail and Plate",7,2,6),
        new Armor("Articulated Plate",10,0,7),
    };

    public Equipment() 
    {
        
    }
    public void GetPrice()
    {
        price = (level == 1) ? 50 : (level == 2) ? 150 : (level == 3) ? 400 : (level == 4) ? 700 : (level == 5) ? 1600 : (level == 6) ? 2000 : (level == 7) ? 2500 : 0;
        if (type == EquipmentType.TwoHand) price *= 2;
    }

    public bool Splash { get { return splash; } set { splash = value; } }
    public string Name { get { return name; } set { name = value; } }
    public string Modifier { get { return modifier; } set { modifier = value; } }
    public int Price { get { return price; } set { price = value; } }
    public int MonsterEye { get { return monsterEye; } set { monsterEye = value; } }
    public int MonsterTooth { get { return monsterTooth; } set { monsterTooth = value; } }
    public int Level { get { return level; } set { level = value; } }
    public bool Upgraded { get { return upgraded; } set { upgraded = value; } }
    public int Defence { get { return defence; } set { defence = value; } }
    public int Mitigation { get { return mitigation; } set { mitigation = value; } }
    public int SpellPower { get { return spellPower; } set { spellPower = value; } }
    public int Hit { get { return hit; } set { hit = value; } }
    public int Crit { get { return crit; } set { crit = value; } }
    public int Stun { get { return stun; } set { stun = value; } }
    public int Damage { get { return damage; } set { damage = value; } }
    public EquipmentType Type { get { return type; } set { type = value; } }
    public virtual void Upgrade()
    {
        upgraded = true;
    }
    public Equipment Copy()
    {
        return (Equipment)MemberwiseClone();
    }
}