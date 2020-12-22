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

    //Goblin
    public static Monster goblin1 = new Goblin(1);
    public static Monster goblin2 = new Goblin(2);
    public static Monster goblin3 = new Goblin(3);
    public static Monster goblin4 = new Goblin(4);
    //Slime
    public static Monster slime1 = new Slime(1);
    public static Monster slime2 = new Slime(2);
    public static Monster slime3 = new Slime(3);
    public static Monster slime4 = new Slime(4);
    //Kobald
    public static Monster kobald1 = new Kobold(1);
    public static Monster kobald2 = new Kobold(2);
    public static Monster kobald3 = new Kobold(3);
    public static Monster kobald4 = new Kobold(4);
    //Orc
    public static Monster orc1 = new Orc(1);
    public static Monster orc2 = new Orc(2);
    public static Monster orc3 = new Orc(3);
    public static Monster orc4 = new Orc(4);
    //Rat
    public static Monster rat1 = new Rat(1);
    public static Monster rat2 = new Rat(2);
    public static Monster rat3 = new Rat(3);
    public static Monster rat4 = new Rat(4);
    //SavageOrc
    public static Monster savageOrc = new SavageOrc(3);
    //Necromancer
    public static Monster necromancerApprentice = new Necromancer(3);
    public static Monster necromancer5 = new Necromancer(5);
    public static Monster necromancer6 = new Necromancer(6);
    //Skeleton
    public static Monster skeleton1 = new Skeleton(1);
    public static Monster skeleton2 = new Skeleton(2);
    public static Monster skeleton3 = new Skeleton(3);
    public static Monster skeleton4 = new Skeleton(4);
    //Zombie
    public static Monster zombie1 = new Zombie(1);
    public static Monster zombie2 = new Zombie(2);
    public static Monster zombie3 = new Zombie(3);
    public static Monster zombie4 = new Zombie(4);
    //Ghoul
    public static Monster ghoul1 = new Ghoul(1);
    public static Monster ghoul2 = new Ghoul(2);
    public static Monster ghoul3 = new Ghoul(3);
    public static Monster ghoul4 = new Ghoul(4);

    public static List<Monster> balanceList = new List<Monster> {  necromancer5,skeleton1,skeleton1 };
    public static List<Monster> dungeonSummon1a = new List<Monster> { goblin1, slime1, kobald1 };
    public static List<Monster> dungeonSummon1b = new List<Monster> { goblin1, slime1, kobald1 };
    public static List<Monster> dungeonSummon2 = new List<Monster> { orc3, rat3, slime3, skeleton3 };
    public static List<Monster> forestSummon = new List<Monster> { goblin1, goblin2, goblin3, slime1, slime2, slime3, kobald1, kobald2, kobald3, orc1, orc2, rat1,rat2, rat3, skeleton2, zombie2,zombie3, ghoul3 };

    


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
    /// TUTORIAL DUNGEON
    /// </summary>
    public static Dungeon dungeon1a = new Dungeon(
        new List<Shell>
        {
            null,

            new Shell(2, 0, 0, 0 ,true,  new Entrance()),                                                //1
            new Shell(0, 1, 3, 6 ,false, new Room(RoomType.Passage)),            //2
            new Shell(4, 0, 0, 2 ,false, new  GuardRoom(goblin1)),         //3
            new Shell(5, 3, 0, 0 ,false, new  Room(RoomType.Passage)),            //4
            new Shell(0, 4, 0, 10 ,false, new Room(RoomType.StoreRoom)),            //5
            
            new Shell(7, 0, 2, 0 ,false, new ShrineRoom()),                                               //6
            new Shell(9, 6, 8, 0 ,false, new Room(RoomType.Hallway)),            //7
            new Shell(0, 0, 0, 7 ,false, new VillagersRoom()),                                           //8
            new Shell(0, 7, 10, 0 ,false, new GuardRoom(goblin1)),            //9
            new Shell(0, 0, 5, 9 ,false, new DungeonTutorial_A_BossRoom())                                         //10
        }, dungeonSummon1a, 1,1);

    public static Dungeon dungeon1b = new Dungeon(
        new List<Shell>
        {
            null,

            new Shell(0, 0, 7,  2   ,true,  new Entrance()),                                                //1
            new Shell(3, 0, 1,  0   ,false, new Room(RoomType.Hallway)),            //2
            new Shell(4, 2, 5,  0   ,false, new ChestRoom()),         //3
            new Shell(0, 3, 6,  0   ,false, new GuardRoom(goblin1) ),            //4
            new Shell(6, 0, 0,  3   ,false, new GuardRoom(goblin1) ),            //5

            new Shell(0, 5, 0,  4   ,false, new DungeonTutorial_B_MiniBossRoom()),   //MINI BOSS                                            //6
            new Shell(0, 0, 8,  1   ,false, new Room(RoomType.StoreRoom)),            //7
            new Shell(9, 0, 0,  7   ,false, new GuardRoom(goblin1)),                                           //8
            new Shell(10, 8, 0, 0   ,false, new Latrine()),            //9
            new Shell(0, 9, 0,  0   ,false, new DungeonTutorial_B_LockRoom()),     //LOCKED ROOM, NEED TO DEFEAT MINIBOSS      //10

            new Shell(0, 12, 10, 0  ,false, new Room(RoomType.Passage)),            //11
            new Shell(11, 0, 0,  0  ,false, new DungeonTutorial_B_BossRoom())                                         //12
        }, dungeonSummon1b, 2, 1);
    ////////////////////////////////////

    /// <summary>
    /// Necromancer Mansion
    /// </summary>
    public static Dungeon MansionEntrance =
        new Dungeon(
        new List<Shell>
        {
            null,
            new Shell(0, 0, 0,  0 ,false,  new MansionEntrance()),                                        
        }, dungeonSummon2, 2, 2);

    public static List<Room> mansionEastSpecialRooms = new List<Room> {new Armory(),new Lab(), new MansionMiniBossNecromancer()  };
    public static List<int> mansionEastPlacement = new List<int> {Return.RandomInt(3,5), Return.RandomInt(6, 9), Return.RandomInt(10, 12) };

    public static List<Room> mansionWestSpecialRooms = new List<Room> {new Library(), new Kitchen(), new Altar() };
    public static List<int> mansionWestPlacement = new List<int> { Return.RandomInt(3, 5), Return.RandomInt(6, 9), Return.RandomInt(10, 12) };


    public static List<Shell> MansionLayoutEast = new AreaCreation(EnterFrom.West, 12, MansionEntrance.layout[1], mansionEastSpecialRooms, mansionEastPlacement).MonsterCopy().builtDungeon;
    public static List<Shell> MansionLayoutWest = new AreaCreation(EnterFrom.East, 12, MansionEntrance.layout[1], mansionWestSpecialRooms, mansionWestPlacement).MonsterCopy().builtDungeon;
    
    public static Dungeon MansionEast = new Dungeon(MansionLayoutEast, dungeonSummon2, 3, 2);
    public static Dungeon MansionWest = new Dungeon(MansionLayoutWest, dungeonSummon2, 3, 2);

    public static Room mansionDoorToBoss = new MansionDoorToBoss();
    public static Room mansionNecromancerBoss = new MansionNecromancerBoss();
    ///////////////////////////////////


    public Dungeon(List<Shell> layout, List<Monster> bestiary, int howManyMonstersPerRoom, int rewardMod)
    {
        this.layout = layout;
        this.bestiary = bestiary;
        this.howManyMonstersPerRoom = howManyMonstersPerRoom;
        this.rewardMod = rewardMod;
    }

}

