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

    public static Monster goblin1 = new Goblin(4, 2, 3, 1);
    public static Monster slime1 = new Slime(4, 2, 4, 1);
    public static Monster slime2 = new Slime(5, 2, 6, 2);
    public static Monster kobald1 = new Kobold(4, 3, 3, 1);
    public static Monster orc1 = new Orc(4, 3, 4, 1);
    public static Monster orcTest = new Orc(2, 2, 2, 1);
    public static Monster orc2 = new Orc(5, 4, 5, 2);
    public static Monster rat1 = new Rat(2, 2, 3, 1);
    public static Monster savageOrc = new SavageOrc(5, 4, 5, 2);
    public static Monster necromancer = new Necromancer(7, 7, 8, 4);
    public static Monster skeleton2 = new Skeleton(3, 3, 3, 2);
    public static Monster zombie3 = new Zombie(3, 3, 3, 3);
    public static Monster ghoul3 = new Ghoul(6, 5, 5, 3);


    public static List<Monster> dungeonSummon1 = new List<Monster> { goblin1, slime1, kobald1 };
    public static List<Monster> dungeonSummon2 = new List<Monster> { orc2, rat1, slime2, skeleton2 };

    


    public static void Summon(Monster monster)
    {
        Create.p.combatMonsters.Add(monster.MonsterCopy());
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
        }, dungeonSummon1, 1,1);

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
        }, dungeonSummon1, 2, 1);
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

