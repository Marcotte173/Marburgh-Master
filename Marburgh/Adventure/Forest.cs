using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Forest
{
    public static int depth = 0;
    public static int savedDepth = 0;
    public static int campDepth = 3;
    public static int clearingsFound=0;
    public static void Menu()
    {
        GameState.location = Location.Forest;
        UI.Keypress(new List<int> { 1,0,2,0,1,0,0 }, new List<string>
        {
            Color.HEALTH,"You make your way out to the ","forest","",
            "",
            Color.MONSTER,Color.MONSTER,"Rumor has it that many of the ","creatures"," that infested the ","Savage Orc's"," Lair escaped when he was defeated",
            "",
            Color.MONSTER,"Who knows, there may be ","creatures"," here you've never seen before",
            "",
            "Caution is is recommended"
        });
        Clearing();        
    }

    private static void Clearing()
    {
        if (Create.p.forestCamp && depth >= campDepth) Button.campButton.active = true;
        else Button.campButton.active = false;
        Utilities.Buttons(Button.listOfForestOptions);
        UI.Choice(new List<int> { 1, 0, 1 }, new List<string>
        {
            Color.HEALTH,"You look around the foreboding ","forest","",
            "",
            Color.MONSTER,"Deeper inside, you think you hear ","movement","..."

        }, Button.list1, Button.button1);
        string choice = Return.Option();
        if (choice == "g") Deeper();
        else if (choice == "m" && Button.campButton.active && depth >= campDepth) Camp();
        else if (choice == "9") CharacterSheet.Display();
        else if (choice == "h") Utilities.Heal();
        else if (choice == "i" && Button.potionButton.active) Utilities.Item();
        else if (choice == "0") Utilities.ToTown();
        Clearing();
    }

    private static void Camp()
    {
        UI.Keypress(new List<int> { 0, 0, 1, 1, 1, 0, 1 }, new List<string>
        {
            "You make camp and rest for several hours",
            "",
            Color.HEALTH, "", "Health " , "at Maximum ",
            Color.ENERGY , "", "Energy " ,  "at maximum",
            Color.HEALTH, "Your potion returns to " , "full " , "size",
            "",
            Color.MONSTER, "Waking up feeling ","refreshed",", you grip your weaapon and press on"
        });
        Create.p.forestCamp = false;
        Create.p.Health = Create.p.MaxHealth;
        Create.p.Energy = Create.p.MaxEnergy;
        Create.p.PotionSize = Create.p.MaxPotionSize;
    }

    private static void Deeper()
    {
        depth++;
        if (depth >= 10) Reward(clearingsFound);
        Console.Clear();
        Write.SetY(15);
        UIComponent.TopBar();
        for (int i = 0; i < Console.WindowWidth; i++)
        {
            Console.Write("-");
        }
        UIComponent.StandardMiddle(8);
        UIComponent.BarBlank();
        Console.SetCursorPosition(Console.WindowWidth / 2 - 4, 9);
        Console.Write(Color.MONSTER+"Exploring"+Color.RESET);
        Write.DotDotDot();
        YouFind();
    }

    private static void YouFind()
    {
        if(GameState.currentJob == GameState.findJob && GameState.findJob.status == JobStatus.Issued && depth == 7) Roderick();
        if (Return.RandomInt(1, 101) <= 30)
        {
            int encounter = Return.RandomInt(1, 21);
            if (encounter == 1) Faeries();
            else if (encounter == 2 || encounter == 3 || encounter == 4) LostMan();            
            else if (encounter == 5 || encounter == 6 || encounter == 7) OldManGuess();
            else if (encounter == 8 || encounter == 9 || encounter == 10 || encounter == 11) Lost();
            else if (encounter == 12 || encounter == 13 ) FindSupplies();
            else if (encounter == 14|| encounter == 15 ) FindPotion();
            else if (encounter == 16 || encounter == 17 ) FindHealth();
            else if (encounter == 18) FindBiggerHealth();
            else if (encounter == 19|| encounter == 20) ManNeedsHelp();
        }
        else Combat();
    }

    private static void Faeries()
    {
        throw new NotImplementedException();
    }

    private static void OldManGuess()
    {
        throw new NotImplementedException();
    }

    private static void LostMan()
    {
        throw new NotImplementedException();
    }

    private static void Lost()
    {
        throw new NotImplementedException();
    }

    private static void FindSupplies()
    {
        throw new NotImplementedException();
    }

    private static void FindPotion()
    {
        throw new NotImplementedException();
    }

    private static void FindHealth()
    {
        throw new NotImplementedException();
    }

    private static void FindBiggerHealth()
    {
        throw new NotImplementedException();
    }

    private static void ManNeedsHelp()
    {
        throw new NotImplementedException();
    }

    private static void Roderick()
    {
        UI.Choice(new List<int> { 1, 0, 0, 0, 1, 0, 1, 0, 3 }, new List<string>
        {
            Color.NAME,"You find ","Roderick","!",
            "",
            "He looks pretty rough, as if he hasn't eaten in days",
            "",
            Color.ENERGY , "", "'Thank go you found me. I feel pretty rough and haven't eaten in days!" ,  "",
            "",
            Color.SPEAK,"","Can you help me find my way home?'","",
            "",
            Color.NAME,Color.HEALTH,Color.DAMAGE,"Helping ","Roderick"," find his way home involves leaving the ","forest"," and will reset your ","progress",""
        },
        new List<string> { " Keep going", " Help Roderick find his way home" }, new List<string> { Color.CRIT + "1" + Color.RESET, Color.DAMAGE + "2" + Color.RESET });
        string choice = Return.Option();
        if (choice == "1")
        {
            UI.Keypress(new List<int> { 2,0,1,0,1,0,1 }, new List<string>
            {
                Color.NAME,Color.HEALTH,"You leave ","Roderick"," in the ","forest","",
                "",
                Color.HEALTH, "I mean, you're a ","hero",", right?",
                "",
                Color.NAME , "You don't have time to save every helpless ","person"," you come across",
                "",
                Color.GOLD, "Go get your ","lootz",""
            });
            GameState.findJob.status = JobStatus.Complete;
        }
        else if (choice == "2")
        {
            UI.Keypress(new List<int> { 1, 0, 1, 0, 1 }, new List<string>
            {
                Color.NAME,"You guide ","Roderick"," back to town",
                "",
                Color.HEALTH, "I mean, you're a ","hero",", right?",
                "",
                Color.HEALTH , "That's what ","heroes"," do"
            });
            GameState.findJob.status = JobStatus.Finished;
            GameState.findJob.ButtonCheck();
            depth = 0;
            Utilities.ToTown();
        }
        else Roderick();
    }

    private static void Combat()
    {
        int amount = Return.RandomInt(1, 4);
        List<string> summonList = new List<string> { };
        List<int> colourArray = new List<int> { };
        for (int i = 0; i < amount; i++)
        {
            Monster summon = Dungeon.forestSummon[Return.RandomInt(0, Dungeon.forestSummon.Count)];
            colourArray.Add(1);
            summonList.Add(Color.MONSTER);
            if (summon.Name == "Orc") summonList.Add("An ");
            else summonList.Add("A ");
            summonList.Add(summon.Name);
            summonList.Add("");
            colourArray.Add(0);
            summonList.Add("");
            Dungeon.Summon(summon);
        }
        Room.ActionWait(colourArray, summonList, Color.RESET + "You have found" + Color.RESET, null);
        global::Combat.Menu();        
    }

    public static void Reward(int mod)
    {
        depth = 0;
        clearingsFound++;
        Utilities.ToTown();
    }
}