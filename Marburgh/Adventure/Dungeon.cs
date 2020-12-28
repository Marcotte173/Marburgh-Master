using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Dungeon
{
    public List<Shell> layout = new List<Shell> { };
    public List<Monster> bestiary = new List<Monster> { };
    public int howManyMonstersPerRoom;
    public int rewardMod;
    
    public static List<Monster> balanceList = new List<Monster> {  new Spider(6) };
    public static void Summon(Monster monster)
    {
        Monster m = monster.MonsterCopy();
        m.Stun = 0;
        m.Bleed = 0;
        m.BleedDam = 0;
        m.Burning = 0;
        m.Status.Clear();
        bool haveA = false;
        bool haveB = false;
        bool haveC = false;
        bool haveD = false;
        bool haveE = false;
        bool haveF = false;
        if (Create.p.combatMonsters.Count == 0)
        {
            
            m.Name = m.Name + " A";
            Create.p.combatMonsters.Add(m.MonsterCopy());
        }
        else
        {
            if (Combat.outOfFight.Count > 0)
            {
                foreach (Monster mon in Combat.outOfFight)
                {
                    if (mon.Name == m.Name + " A") haveA = true;
                    if (mon.Name == m.Name + " B") haveB = true;
                    if (mon.Name == m.Name + " C") haveC = true;
                    if (mon.Name == m.Name + " D") haveD = true;
                    if (mon.Name == m.Name + " E") haveE = true;
                    if (mon.Name == m.Name + " F") haveF = true;
                }
            }
            foreach (Monster mon in Create.p.combatMonsters)
            {
                if (mon.Name == m.Name + " A") haveA = true;
                if (mon.Name == m.Name + " B") haveB = true;
                if (mon.Name == m.Name + " C") haveC = true;
                if (mon.Name == m.Name + " D") haveD = true;
                if (mon.Name == m.Name + " E") haveE = true;
                if (mon.Name == m.Name + " F") haveF = true;
            }
            if (!haveA) m.Name = m.Name + " A";
            else if (!haveB) m.Name = m.Name + " B";
            else if (!haveC) m.Name = m.Name + " C";
            else if (!haveD) m.Name = m.Name + " D";
            else if (!haveE) m.Name = m.Name + " E";
            else if (!haveF) m.Name = m.Name + " F";
            Create.p.combatMonsters.Add(m);
        }
    }
    public static void Summon(Monster monster, string name)
    {
        Monster m = monster.MonsterCopy();
        m.Stun = 0;
        m.Bleed = 0;
        m.BleedDam = 0;
        m.Burning = 0;
        m.Status.Clear();
        m.Name = name;
        Create.p.combatMonsters.Add(m);
    }

    /// <summary>
    /// TUTORIAL DUNGEON 1A
    /// </summary>
    public static List<Monster> dungeonSummon1a = new List<Monster> { new Goblin(1) , new Kobold(1) , new Slime(1) };
    public static Dungeon dungeon1a = new Dungeon(
        new List<Shell>
        {
            null,

            new Shell(2, 0, 0, 0 ,true,  new Entrance()),                                                //1
            new Shell(0, 1, 3, 6 ,false, new Room(RoomType.Passage)),            //2
            new Shell(4, 0, 0, 2 ,false, new  GuardRoom(new Goblin(1))),         //3
            new Shell(5, 3, 0, 0 ,false, new  Room(RoomType.Passage)),            //4
            new Shell(0, 4, 0, 10 ,false, new Room(RoomType.StoreRoom)),            //5
            
            new Shell(7, 0, 2, 0 ,false, new ShrineRoom()),                                               //6
            new Shell(9, 6, 8, 0 ,false, new Room(RoomType.Hallway)),            //7
            new Shell(0, 0, 0, 7 ,false, new VillagersRoom()),                                           //8
            new Shell(0, 7, 10, 0 ,false, new GuardRoom(new Goblin(1))),            //9
            new Shell(0, 0, 5, 9 ,false, new DungeonTutorial_A_BossRoom())                                         //10
        }, dungeonSummon1a, 1,1);


    /////////////////////////////////////////////////////////


    /// <summary>
    /// TUTORIAL DUNGEON 1B
    /// </summary>
    public static List<Monster> dungeonSummon1b = new List<Monster> { new Goblin(1), new Kobold(1), new Slime(1) };
    public static Dungeon dungeon1b = new Dungeon(
        new List<Shell>
        {
            null,

            new Shell(0, 0, 7,  2   ,true,  new Entrance()),                                                //1
            new Shell(3, 0, 1,  0   ,false, new Room(RoomType.Hallway)),            //2
            new Shell(4, 2, 5,  0   ,false, new ChestRoom()),         //3
            new Shell(0, 3, 6,  0   ,false, new GuardRoom(new Goblin(2)) ),            //4
            new Shell(6, 0, 0,  3   ,false, new GuardRoom(new Kobold(2)) ),            //5

            new Shell(0, 5, 0,  4   ,false, new DungeonTutorial_B_MiniBossRoom()),   //MINI BOSS                                            //6
            new Shell(0, 0, 8,  1   ,false, new Room(RoomType.StoreRoom)),            //7
            new Shell(9, 0, 0,  7   ,false, new GuardRoom(new Goblin(2))),                                           //8
            new Shell(10, 8, 0, 0   ,false, new Latrine()),            //9
            new Shell(0, 9, 0,  0   ,false, new DungeonTutorial_B_LockRoom()),     //LOCKED ROOM, NEED TO DEFEAT MINIBOSS      //10

            new Shell(0, 12, 10, 0  ,false, new Room(RoomType.Passage)),            //11
            new Shell(11, 0, 0,  0  ,false, new DungeonTutorial_B_BossRoom())                                         //12
        }, dungeonSummon1b, 2, 1);


    ////////////////////////////////////

    /// <summary>
    /// Necromancer Mansion
    /// </summary>
    public static List<Monster> mansionSummon = new List<Monster> { new Orc(4), new Rat(3), new Slime(4), new Skeleton(4) };
    public static Dungeon MansionEntrance =
        new Dungeon(
        new List<Shell>
        {
            null,
            new Shell(0, 0, 0,  0 ,false,  new MansionEntrance()),                                        
        }, mansionSummon, 2, 2);

    public static Room mansionDoorToBoss = new MansionDoorToBoss();
    public static Room mansionNecromancerBoss = new MansionNecromancerBoss();

    public static List<Room> mansionEastSpecialRooms = new List<Room> {new Armory(),new Lab(), new MansionMiniBossNecromancer()  };
    public static List<int> mansionEastPlacement = new List<int> {Return.RandomInt(3,5), Return.RandomInt(6, 9), Return.RandomInt(10, 12) };

    public static List<Room> mansionWestSpecialRooms = new List<Room> {new Library(), new Kitchen(), new Altar() };
    public static List<int> mansionWestPlacement = new List<int> { Return.RandomInt(3, 5), Return.RandomInt(6, 9), Return.RandomInt(10, 12) };


    public static List<Shell> MansionLayoutEast = new AreaCreation(EnterFrom.West, 12, MansionEntrance.layout[1], mansionEastSpecialRooms, mansionEastPlacement).MonsterCopy().builtDungeon;
    public static List<Shell> MansionLayoutWest = new AreaCreation(EnterFrom.East, 12, MansionEntrance.layout[1], mansionWestSpecialRooms, mansionWestPlacement).MonsterCopy().builtDungeon;
    
    public static Dungeon MansionEast = new Dungeon(MansionLayoutEast, mansionSummon, 3, 2);
    public static Dungeon MansionWest = new Dungeon(MansionLayoutWest, mansionSummon, 3, 2);


    ///////////////////////////////////

    /// <summary>
    /// THE CAVE
    /// </summary>
    public static List<Monster> caveSummon = new List<Monster> { new Slime(4), new Bear(4), new Bat(4), new Rat(4), new Spider(4) };
    public static Shell caveEntrance = new Shell(0,0,0,0,true,new CaveEntrance());
    public static List<Room> caveSpecialRooms = new List<Room> { new ChestRoom(), new GuardRoom(new Goblin(5)), new DungPile(),new BigHole(),new AncestorLetter(), new Well(),new MguffinRoom(),new CaveSpiderQueenBoss() };
    public static List<int> cavePlacement = new List<int> { Return.RandomInt(3, 5), Return.RandomInt(5, 7), Return.RandomInt(7, 10), Return.RandomInt(10,12), Return.RandomInt(12,14), Return.RandomInt(14,17), Return.RandomInt(17, 19), Return.RandomInt(19, 20) };
    public static List<Shell> caveLayout = new AreaCreation(EnterFrom.South, 20, caveEntrance, caveSpecialRooms, cavePlacement).MonsterCopy().builtDungeon;
    public static Dungeon cave = new Dungeon(caveLayout, caveSummon, 4, 3);
    
    
    /////////////////////////////////////

    /// <summary>
    /// THE FOREST
    /// </summary>
    public static List<List<Monster>> forestSummon = new List<List<Monster>> 
    { 
        null,
        new List<Monster> {new Goblin(1),new Kobold(1),new Orc(1),new Slime(1),new Skeleton(1),new Ghoul(1),new Rat(1),new Bear(1),new Thug(1),new Bat(1) },
        new List<Monster> {new Goblin(1),new Kobold(1),new Orc(1),new Slime(1),new Skeleton(1),new Ghoul(1),new Rat(1),new Bear(1),new Thug(1),new Bat(1) },
        new List<Monster> {new Goblin(2),new Kobold(2),new Orc(2),new Slime(2),new Skeleton(2),new Ghoul(2),new Rat(2),new Bear(2),new Thug(2),new Bat(2) },
        new List<Monster> {new Goblin(3),new Kobold(3),new Orc(3),new Slime(3),new Skeleton(3),new Ghoul(3),new Rat(3),new Bear(3),new Thug(3),new Bat(3) }, 
        new List<Monster> {new Goblin(4),new Kobold(4),new Orc(4),new Slime(4),new Skeleton(4),new Ghoul(4),new Rat(4),new Bear(4),new Thug(4),new Bat(4) }, 
        new List<Monster> {new Goblin(5),new Kobold(5),new Orc(5),new Slime(5),new Skeleton(5),new Ghoul(5),new Rat(5),new Bear(5),new Thug(5),new Bat(5) } ,
        new List<Monster> {new Goblin(6),new Kobold(6),new Orc(6),new Slime(6),new Skeleton(6),new Ghoul(6),new Rat(6),new Bear(6),new Thug(6),new Bat(6) },
        new List<Monster> {new Goblin(7),new Kobold(7),new Orc(7),new Slime(7),new Skeleton(7),new Ghoul(7),new Rat(7),new Bear(7),new Thug(7),new Bat(7) },
        new List<Monster> {new Goblin(8),new Kobold(8),new Orc(8),new Slime(8),new Skeleton(8),new Ghoul(8),new Rat(8),new Bear(8),new Thug(8),new Bat(8) }
    };

    
    ////////////////////////////////////
    public Dungeon(List<Shell> layout, List<Monster> bestiary, int howManyMonstersPerRoom, int rewardMod)
    {
        this.layout = layout;
        this.bestiary = bestiary;
        this.howManyMonstersPerRoom = howManyMonstersPerRoom;
        this.rewardMod = rewardMod;
    }

}

