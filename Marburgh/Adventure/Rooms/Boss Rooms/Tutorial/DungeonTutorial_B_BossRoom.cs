using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class DungeonTutorial_B_BossRoom : Room
{
    ///Constructor
    public DungeonTutorial_B_BossRoom()
    : base()
    {
        resetable = false;
        name = "Savage Orc";
        flavorColourArray = new List<int> { 0 };
        flavor = new List<string> { "You have found the Savage Orc's Lair!" };
    }

    internal override void Explore()
    {
        UI.Keypress(new List<int> { 1, 0, 0 }, new List<string>
        {
            Color.BOSS,"The ","Savage Orc"," bellows at you as he brandishes his weapon",
            "",
            "There's no turning back now!",
        });
        Dungeon.Summon(Dungeon.savageOrc);
        Combat.Menu();

        //Delete when ready to push
        UI.Keypress(new List<int> { 1, 0, 1 }, new List<string>
        {
            Color.BOSS,"You have beaten the ","Savage Orc"," and for now, the game",
            "",
            Color.HEALTH,"","Check back soon","! As you read this I'm hard at work adding more dungeons, monsters and Items.",

        });
        Environment.Exit(0);



        //UI.Keypress(new List<int> { 1, 0, 0, 0, 2 }, new List<string>
        //{
        //    Color.BOSS,"The ","Savage Orc"," looks shocked as the life leaves his eyes",
        //    "",
        //    "You have defeated your foes, saving your town forever!",
        //    "",
        //    Color.XP,Color.TIME,"Exhausted, you return to you ","house"," and sleep for 3 ","days",""
        //});
        //Time.Events[0].active = false;
        //visited = true;
        //GameState.CanMakeBossWeapon();
        //Town.FakeMenu();        
    }
}